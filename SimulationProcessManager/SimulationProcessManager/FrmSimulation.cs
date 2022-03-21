using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SimulationProcessManager
{
    public partial class FrmSimulation : Form
    {
        public FrmSimulation()
        {
            InitializeComponent();
        }


        ObservableCollection<int> objserveCollection;

        const string TIME_FORMAT = "h:mm:ss.ff";
      





        List<SimulaionCommand> simComms = new List<SimulaionCommand>();


        static TimeLineItemsList _timeLIneItems;
        private void btnRunSim_Click(object sender, EventArgs e)
        {



            lvOutput.Items.Clear();
            enableDisableForm(false);
            _timeLIneItems = new TimeLineItemsList();
            buildTimeLineGraph();
            tsProgress.Maximum = dgWorkFlowItems.Rows.Count;
            tsProgress.Visible = true;
            try
            {
                splitContainerOutput.Visible = true;
                //_timeLIneItems = Simulator.runSimulation(simComms, this);

                runSimulation();
                tsProgress.Value = 0;
                tsStatusLabel.Text = "Process Complete";
                Application.DoEvents();
            }

            catch (System.Exception er)
            {
                MessageBox.Show("An unexpected error occurred: \n\n" + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        TimeLineItem wfItem;
        Timer timerObj;
        Stopwatch stopWatchObj;

        int wfItemNumber;
        private void runSimulation()
        {
            _timeLIneItems = new TimeLineItemsList();


            // get the first item 
            wfItemNumber = 0;
            //wfItem = wFlowList._workFlowList[wfItemNumber];
            timerObj = new Timer();
            //int timerInterval = (int)t._duration * 1000 > 0 ? (int)t._duration * 1000 : 1;
            //timerObj.Interval = timerInterval;
            timerObj.Start();
            timerObj.Tick += TimerObj_Tick;

            stopWatchObj = new Stopwatch();
            stopWatchObj.Start();



            processTimer.Start();
            processTimer.Tick += ProcessTimer_Tick;


        }


        int processTimerValue;
        double secondsCounter;
        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            processTimerValue++;
            secondsCounter = processTimerValue * .01;
            if (lvCurrentItem != null)
            {
                //lvCurrentItem.SubItems[5].Text = secondsCounter.ToString();
                lvCurrentItem.SubItems[5].Text = stopWatchObj.Elapsed.ToString();
            }
        }


        ListViewItem lvCurrentItem;
        private void TimerObj_Tick(object sender, EventArgs e)
        {
            if (wfItemNumber > dgWorkFlowItems.Rows.Count - 1)
            {
                timerObj.Stop();
                processTimer.Stop();
                stopWatchObj.Stop();


                buildTimeLineGraph(_timeLIneItems);
                enableDisableForm(true);
                tsProgress.Visible = false;
                resetDurationValues();
                //lblCounter.Visible = false;
            }
            else
            {
                //throw new NotImplementedException();
                wfItem = wFlowList._workFlowList[wfItemNumber];
                TimeLineItem t = new TimeLineItem(wfItem._itemNumber, wfItem._conveyorNumber, wfItem._actionOwner,
                    wfItem._action, wfItem._processStartTime, wfItem._startTime, wfItem._endTime, wfItem._duration, wfItem._isAnimated, wfItem._actionPassed);
                // build new item so the constructor updates the points/lengths of lines
                _timeLIneItems.Add(t);
                lvCurrentItem = updateOutputForm(wfItem._actionPassed, t);
                objGraphics.Clear(panelGraphics.BackColor);
                buildTimeLineGraph(_timeLIneItems);
                int timerInterval = (int)t._duration * 1000 > 0 ? (int)t._duration * 1000 : 1;
                timerObj.Interval = timerInterval;
                wfItemNumber++;

                processTimerValue = 0;

                //stopWatchObj.Reset();

                lvCurrentItem.SubItems[5].Text = wfItem._duration.ToString();
                resetDurationValues();
            }
        }

        private void resetDurationValues()
        {
            foreach (ListViewItem lvi in lvOutput.Items)
            {
                lvi.SubItems[5].Text = _timeLIneItems[lvi.Index]._duration.ToString();
            }
        }

        private ListViewItem updateOutputForm(bool success, TimeLineItem tLineItem)
        {
            int imageIndex = success ? 6 : 8;

            ListViewItem l = lvOutput.Items.Add(tLineItem._itemNumber.ToString());
            l.SubItems.Add(tLineItem._conveyorNumber);
            l.SubItems.Add(tLineItem._action);
            l.SubItems.Add(tLineItem._startTime.ToString(TIME_FORMAT));
            l.SubItems.Add(tLineItem._endTime.ToString(TIME_FORMAT));
            l.SubItems.Add(tLineItem._duration.ToString());
            l.SubItems.Add(tLineItem._actionOwner.ToString());
            l.SubItems.Add(tLineItem._actionPassed.ToString());
            // add start and end times


            l.ImageIndex = imageIndex;
            tsProgress.Value = tLineItem._itemNumber;
            tsStatusLabel.Text = "Processing " + tLineItem._itemNumber.ToString() + " of " + tsProgress.Maximum.ToString() + " steps";
            //lblCounter.Text = tLineItem._itemNumber.ToString() + " of " + tsProgress.Maximum.ToString() + "...";

            System.Windows.Forms.Application.DoEvents();

            return l;

        }




        private string validateInputs()
        {
            string errors = "";

            

            return errors;
        }

        private void enableDisableForm(bool enable)
        {
            btnRunSim.Enabled = enable;
            
            //btnClear.Enabled = enable;
            toolBarStrip.Enabled = enable;

            
            Application.DoEvents();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //lvCommandList.Items.Clear();
            objserveCollection.Clear();
        }

        WorkFlowItemList wFlowList;
        private void FrmSimulation_Load(object sender, EventArgs e)
        {
            #region old method
            
            //btnClear.Enabled = false;
            btnRunSim.Enabled = false;
            saveToolStripButton.Enabled = false;

            enableDisableForm(true);
            // splitContainerOutput.Visible = false;

            //displayBuildSteps(false);

            objserveCollection = new ObservableCollection<int>();
            //objserveCollection.CollectionChanged += ObjserveCollection_CollectionChanged;
            #endregion

            // new data grid method - load all steps into workflow.  User can adjust timings and exception flag
            //build list of workflow items
            wFlowList = new WorkFlowItemList();
            wFlowList.buildWorkFlowList();
            dgWorkFlowItems.DataSource = wFlowList._workFlowList;
            formatGridView();
            dgWorkFlowItems.Refresh();

            buildGraph();

            
        }

        private void formatGridView()
        {
            foreach (DataGridViewColumn dc in dgWorkFlowItems.Columns)
            {
                if (dc.ValueType == typeof(System.DateTime))
                {
                    dc.DefaultCellStyle.Format = TIME_FORMAT;
                    //dc.ReadOnly = false; // just remove the private from the setter property in the TimeLineItem class
                }
                // hide unnecessary data
                if (dc.HeaderText.Equals("_label") || dc.HeaderText.Equals("_isAnimated") || dc.HeaderText.Equals("_itemColor")
                    || dc.HeaderText.Equals("_ySpaceFactor") || dc.HeaderText.ToLower().Contains("point") || dc.HeaderText.ToLower().Contains("process"))
                {
                    dc.Visible = false;
                }

            }
        }

        //private void ObjserveCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    //throw new NotImplementedException();

        //    // rebuild the command collection
        //    simComms = new List<SimulaionCommand>();
        //    foreach (ListViewItem li in lvCommandList.Items)
        //    {
        //        SimulaionCommand sc = new SimulaionCommand(li.SubItems[1].Text.ToLower(), Convert.ToInt16(li.Text), li.SubItems[2].Text.ToLower(), Convert.ToInt16(li.SubItems[3].Text), Convert.ToInt16(li.SubItems[4].Text));
        //        simComms.Add(sc);
        //    }
        //    if (deleteKeyFlag)
        //    {
        //        deleteKeyFlag = false;
        //    }
        //    else
        //    {
        //        // plot out the steps in CAD
        //        //if (!_isImport)
        //        //{
        //        //    Simulator.addStepCallouts(simComms);
        //        //}
        //    }



        //    if (((ObservableCollection<int>)sender).Count > 0)
        //    {
        //        btnRunSim.Enabled = true;
        //        btnClear.Enabled = true;

        //        saveToolStripButton.Enabled = true;
        //    }
        //    else
        //    {
        //        btnRunSim.Enabled = false;
        //        btnClear.Enabled = false;
        //        saveToolStripButton.Enabled = false;
        //    }
        //}

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            runValidation();
        }


        private void runValidation()
        {
            string errs = validateInputs();
            //lblError.Text = errs;
            //if (errs.Length > 0)
            //{
            //    btnAdd.Enabled = false;
            //}
            //else
            //{
            //    btnAdd.Enabled = true;
            //}
            Application.DoEvents();
        }

        private void txtGridSpaces_TextChanged(object sender, EventArgs e)
        {
            runValidation();
        }

        private void txtMovementIncrement_TextChanged(object sender, EventArgs e)
        {
            runValidation();
        }

       



        private void btnResetAnt_Click(object sender, EventArgs e)
        {
            //Simulator.resetRobotPosition();
        }

        //private void displayBuildSteps(bool isRotation)
        //{
        //    if (isRotation)
        //    {
        //        //lblDirections.Visible = false;
        //        cmbDirection.Visible = false;
        //        lblGridSpaces.Visible = false;
        //        txtGridSpaces.Visible = false;
        //        lblSpeed.Visible = false;
        //        txtMovementIncrement.Visible = false;

        //        cmbAngleDirection.Visible = true;
        //        lblAngle.Visible = true;
        //        txtAngle.Visible = true;

        //    }
        //    else
        //    {
        //        //lblDirections.Visible = true ;
        //        cmbDirection.Visible = true;
        //        lblGridSpaces.Visible = true;
        //        txtGridSpaces.Visible = true;
        //        lblSpeed.Visible = true;
        //        txtMovementIncrement.Visible = true;

        //        cmbAngleDirection.Visible = false;
        //        lblAngle.Visible = false;
        //        txtAngle.Visible = false;


        //    }
        //}

        private void cmbAngleDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            runValidation();
        }

        private void txtAngle_TextChanged(object sender, EventArgs e)
        {
            runValidation();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveToolStripButton.Enabled = false;
                Application.DoEvents();

                SaveFileDialog sf = new SaveFileDialog();
                sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                sf.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                sf.Title = "Select Command List Export Save Location:";

                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    string FileName = sf.FileName;
                    ImportExportCommandList.exportCommandList(FileName, simComms);
                }
            }
            finally
            {
                saveToolStripButton.Enabled = true;
                Application.DoEvents();
            }
        }

        //private void openToolStripButton_Click(object sender, EventArgs e)
        //{

        //    bool retContinueImport = true;
        //    if (lvCommandList.Items.Count > 0)
        //    {
        //        // warn user that continuing will delete existing command list
        //        DialogResult ysNo = MessageBox.Show("Importing an external Comand List will delete the current command list.  Do you want to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (ysNo == DialogResult.No)
        //        {
        //            retContinueImport = false;
        //        }
        //    }

        //    if (retContinueImport)
        //    {
        //        OpenFileDialog of = new OpenFileDialog();
        //        of.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //        of.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        //        of.Title = "Select Command List file to import:";
        //        if (of.ShowDialog(this) == DialogResult.OK)
        //        {
        //            string fName = of.FileName;

        //            List<SimulaionCommand> commList = ImportExportCommandList.importCommandList(fName);
        //            populateCommandListWithImportedData(commList);
        //        }
        //    }
        //}




        #region GDI graphics
        private void panelGraphics_Paint(object sender, PaintEventArgs e)
        {
            buildTimeLineGraph(_timeLIneItems);
        }




        const int PROCESS_TIME_Y_OFFSET = 150;
        private static Graphics objGraphics;


        double timerDuration;
        private void showElapsedTimeGraphics()
        {
            objGraphics.Clear(panelGraphics.BackColor);
            objGraphics = panelGraphics.CreateGraphics();

            drawText(150, 150, timerDuration.ToString(), 100, Color.Blue, false, true);

            Invalidate();
        }

        DateTime processStartTime;

        private void buildTimeLineGraph(TimeLineItemsList tLineItems)
        {
            if (tLineItems != null)
            {
                objGraphics = panelGraphics.CreateGraphics();
                if (tLineItems.Count > 0)
                {
                    objGraphics.Clear(panelGraphics.BackColor);
                    // get max y value to draw vertical lines to:
                    int maxYVal = (int)tLineItems.Max(t => t._startPoint.Y);

                    int stepNumber = 1;
                    Point2d lastPoint = new Point2d();
                    Point2d bottomPoint;
                    int spaceFac = 0;
                    DateTime endTime = new DateTime();
                    processStartTime = new DateTime();


                    foreach (TimeLineItem tl in tLineItems)
                    {
                        bottomPoint = new Point2d(tl._startPoint.X, maxYVal + tl._ySpaceFactor);
                        Point2d bottomPointEnd = new Point2d(tl._endPoint.X, maxYVal + tl._ySpaceFactor);
                        if (tl._itemNumber == 1)
                        {
                            // this is the process starting time
                            processStartTime = tl._startTime;
                            drawText((int)bottomPoint.X - 5, (int)bottomPoint.Y + PROCESS_TIME_Y_OFFSET + 40, tl._startTime.ToString(TIME_FORMAT), 11, Color.CornflowerBlue, true);

                        }
                        drawLIne(tl._startPoint, tl._endPoint, tl._itemColor, 5);

                        // to the right of the line
                        drawText((int)tl._endPoint.X + 15, (int)tl._endPoint.Y - 10, stepNumber.ToString() + ". " + tl._label + " (" + tl._duration.ToString() + " sec.)" + tl._action, 8, tl._itemColor);


                        // on top of the line (left to right)
                        // drawText((int)tl._startPoint.X + 5, (int)tl._endPoint.Y - 25, stepNumber.ToString() + ". " + tl._label + " (" + tl._duration.ToString() + " sec.) , " + tl._action, 7, tl._itemColor);
                        if (!tl._actionPassed)
                        {
                            // exception flag
                            drawText((int)tl._endPoint.X + 205, (int)tl._endPoint.Y - 10, "Action Failed!", 8, Color.Red, false, false, true);
                            // also flag in verical time line text
                            drawText((int)bottomPoint.X - 15, (int)bottomPoint.Y + 205, "Action Failed!", 8, Color.Red, true, false, true);

                        }


                        // draw lines to bottom separating each task
                        // start time line
                        drawLIne(tl._startPoint, bottomPoint, Color.Orange, 1, true);
                        if (tl._itemNumber == 1)
                        {
                            drawText((int)bottomPoint.X, (int)bottomPoint.Y + 45, "Start: " + tl._startTime.ToString(TIME_FORMAT), 9, Color.Black, true);

                        }
                        else
                        {
                            drawText((int)bottomPoint.X - 15, (int)bottomPoint.Y + 45, "Start: " + tl._startTime.ToString(TIME_FORMAT), 9, Color.Black, true);
                        }
                        //end time line
                        drawLIne(tl._endPoint, bottomPointEnd, Color.Purple, 1, true);
                        // end time
                        drawText((int)bottomPointEnd.X + 2, (int)bottomPoint.Y + 45, "End: " + tl._endTime.ToString(TIME_FORMAT), 9, Color.Red, true);

                        stepNumber++;

                        spaceFac = tl._ySpaceFactor;
                        lastPoint = tl._endPoint;

                        endTime = tl._endTime;
                    }
                    // calculate entire process duration
                    tLineItems.calculateProcessDuration(processStartTime, endTime);


                    // draw last division line
                    bottomPoint = new Point2d(lastPoint.X, maxYVal + spaceFac);
                    drawLIne(lastPoint, bottomPoint, Color.Orange, 1, true);
                    //drawText((int)bottomPoint.X - 5, (int)bottomPoint.Y + 25, endTime.ToString("h:mm:ss.ff tt"), 9, Color.Black, true);

                    // overall process end time
                    drawText((int)bottomPoint.X - 5, (int)bottomPoint.Y + PROCESS_TIME_Y_OFFSET + 40, endTime.ToString(TIME_FORMAT), 11, Color.CornflowerBlue, true);

                    // add text showing total process time
                    drawText((int)bottomPoint.X / 2, (int)bottomPoint.Y + (PROCESS_TIME_Y_OFFSET * 2), "Total Process Time: " + tLineItems._processDuration.ToString() + " Seconds", 20, Color.Blue, false, true);
                    // show overall start time and overall end time

                    Invalidate();


                }
                else
                {
                    objGraphics.Clear(panelGraphics.BackColor);
                }
            }

        }


        private void buildTimeLineGraph()
        {
            if (_timeLIneItems != null)
            {
                objGraphics = panelGraphics.CreateGraphics();
                if (_timeLIneItems.Count > 0)
                {
                    objGraphics.Clear(panelGraphics.BackColor);
                    // get max y value to draw vertical lines to:
                    int maxYVal = (int)_timeLIneItems.Max(t => t._startPoint.Y);

                    int stepNumber = 1;
                    Point2d lastPoint = new Point2d();
                    Point2d bottomPoint;
                    int spaceFac = 0;
                    DateTime endTime = new DateTime();
                    processStartTime = new DateTime();


                    foreach (TimeLineItem tl in _timeLIneItems)
                    {
                        bottomPoint = new Point2d(tl._startPoint.X, maxYVal + tl._ySpaceFactor);
                        Point2d bottomPointEnd = new Point2d(tl._endPoint.X, maxYVal + tl._ySpaceFactor);
                        if (tl._itemNumber == 0)
                        {
                            // this is the process starting time
                            processStartTime = tl._startTime;
                            drawText((int)bottomPoint.X - 5, (int)bottomPoint.Y + PROCESS_TIME_Y_OFFSET + 40, tl._startTime.ToString(TIME_FORMAT), 11, Color.CornflowerBlue, true);

                        }
                        drawLIne(tl._startPoint, tl._endPoint, tl._itemColor, 5);

                        // to the right of the line
                        drawText((int)tl._endPoint.X + 15, (int)tl._endPoint.Y - 10, stepNumber.ToString() + ". " + tl._label + " (" + tl._duration.ToString() + " sec.)" + tl._action, 8, tl._itemColor);


                        // on top of the line (left to right)
                        // drawText((int)tl._startPoint.X + 5, (int)tl._endPoint.Y - 25, stepNumber.ToString() + ". " + tl._label + " (" + tl._duration.ToString() + " sec.) , " + tl._action, 7, tl._itemColor);
                        if (!tl._actionPassed)
                        {
                            // exception flag
                            drawText((int)tl._endPoint.X + 205, (int)tl._endPoint.Y - 10, "Action Failed!", 8, Color.Red, false, false, true);
                            // also flag in verical time line text
                            drawText((int)bottomPoint.X - 15, (int)bottomPoint.Y + 205, "Action Failed!", 8, Color.Red, true, false, true);

                        }


                        // draw lines to bottom separating each task
                        // start time line
                        drawLIne(tl._startPoint, bottomPoint, Color.Orange, 1, true);
                        if (tl._itemNumber == 0)
                        {
                            drawText((int)bottomPoint.X, (int)bottomPoint.Y + 45, "Start: " + tl._startTime.ToString(TIME_FORMAT), 9, Color.Black, true);

                        }
                        else
                        {
                            drawText((int)bottomPoint.X - 15, (int)bottomPoint.Y + 45, "Start: " + tl._startTime.ToString(TIME_FORMAT), 9, Color.Black, true);
                        }
                        //end time line
                        drawLIne(tl._endPoint, bottomPointEnd, Color.Purple, 1, true);
                        // end time
                        drawText((int)bottomPointEnd.X + 2, (int)bottomPoint.Y + 45, "End: " + tl._endTime.ToString(TIME_FORMAT), 9, Color.Red, true);

                        stepNumber++;

                        spaceFac = tl._ySpaceFactor;
                        lastPoint = tl._endPoint;

                        endTime = tl._endTime;
                    }
                    // calculate entire process duration
                    _timeLIneItems.calculateProcessDuration(processStartTime, endTime);


                    // draw last division line
                    bottomPoint = new Point2d(lastPoint.X, maxYVal + spaceFac);
                    drawLIne(lastPoint, bottomPoint, Color.Orange, 1, true);
                    //drawText((int)bottomPoint.X - 5, (int)bottomPoint.Y + 25, endTime.ToString("h:mm:ss.ff tt"), 9, Color.Black, true);

                    // overall process end time
                    drawText((int)bottomPoint.X - 5, (int)bottomPoint.Y + PROCESS_TIME_Y_OFFSET + 40, endTime.ToString(TIME_FORMAT), 11, Color.CornflowerBlue, true);

                    // add text showing total process time
                    drawText((int)bottomPoint.X / 2, (int)bottomPoint.Y + (PROCESS_TIME_Y_OFFSET * 2), "Total Process Time: " + _timeLIneItems._processDuration.ToString() + " Seconds", 20, Color.Blue, false, true);
                    // show overall start time and overall end time

                    Invalidate();


                }
                else
                {
                    objGraphics.Clear(panelGraphics.BackColor);
                }
            }

        }





        private void drawLIne(Point2d point1, Point2d point2, Color color, int width, bool isDashed = false)
        {
            Pen linePen = new Pen(color, width);
            if (isDashed)
            {
                linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }
            else
            {
                linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }
            objGraphics.DrawLine(linePen, (float)point1.X, (float)point1.Y, (float)point2.X, (float)point2.Y);

        }

        private void drawText(int x, int y, string text, float textSize, Color textColor, bool isVertical = false, bool centerText = false, bool isBold = false)
        {

            Font f;
            if (isBold)
            {
                f = new Font("Arial", textSize, FontStyle.Bold);

            }
            else
            {
                f = new Font("Arial", textSize);
            }

            SolidBrush b = new SolidBrush(textColor);
            StringFormat format = new StringFormat();

            format.Alignment = StringAlignment.Near;

            if (isVertical)
            {
                format.FormatFlags = StringFormatFlags.DirectionVertical;
            }
            if (centerText)
            {
                format.Alignment = StringAlignment.Center;
            }



            objGraphics.DrawString(text, f, b, x, y, format);
        }

        private void dgWorkFlowItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if user changes duration... update the end time

            int startTimIndex = dgWorkFlowItems.Columns["_startTime"].Index;
            int durationIndex = dgWorkFlowItems.Columns["_duration"].Index;
            int endTimIndex = dgWorkFlowItems.Columns["_endTime"].Index;


            if (dgWorkFlowItems.Columns[e.ColumnIndex].HeaderText.Equals("_duration"))
            {
                //DateTime startTime =(DateTime) dgWorkFlowItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                double duration = (double)dgWorkFlowItems.Rows[e.RowIndex].Cells[durationIndex].Value;
                DateTime startTime = (DateTime)dgWorkFlowItems.Rows[e.RowIndex].Cells[startTimIndex].Value;
                DateTime endTime = startTime.AddSeconds(duration);

                dgWorkFlowItems.Rows[e.RowIndex].Cells[endTimIndex].Value = endTime;
            }
            else if (dgWorkFlowItems.Columns[e.ColumnIndex].HeaderText.Equals("_startTime") || dgWorkFlowItems.Columns[e.ColumnIndex].HeaderText.Equals("_endTime"))
            {
                // if user changes start time or end time... update the duration
                DateTime startTime = (DateTime)dgWorkFlowItems.Rows[e.RowIndex].Cells[startTimIndex].Value;
                DateTime endTime = (DateTime)dgWorkFlowItems.Rows[e.RowIndex].Cells[endTimIndex].Value; //.ToString("h:mm:ss.ff");
                string tStart = startTime.ToString(TIME_FORMAT);
                string tEnd = endTime.ToString(TIME_FORMAT);
                startTime = Convert.ToDateTime(tStart);
                endTime = Convert.ToDateTime(tEnd);
                double duration = (endTime - startTime).TotalSeconds;

                dgWorkFlowItems.Rows[e.RowIndex].Cells[durationIndex].Value = duration;
            }
            buildGraph();
        }

        private void buildGraph()
        {
            // create _timLineItems list based on the existing binding list
            _timeLIneItems = new TimeLineItemsList();
            foreach (TimeLineItem t in wFlowList._workFlowList)
            {
                TimeLineItem tt = new TimeLineItem(_timeLIneItems.Count + 1, t._conveyorNumber, t._actionOwner, t._action, t._processStartTime, t._startTime, t._endTime, t._duration, t._isAnimated, t._actionPassed);

                _timeLIneItems.Add(tt);
            }
            //TimeLineItem t = new TimeLineItem(_timeLIneItems.Count, lvItem.SubItems[1].Text, lvItem.SubItems[2].Text, _processStartTime, startTime, endTime, duration);
            buildTimeLineGraph(_timeLIneItems);
        }

        private void dgWorkFlowItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            enableRunButton();
        }

        private void dgWorkFlowItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            enableRunButton();
        }

        private void enableRunButton()
        {
            if (dgWorkFlowItems.Rows.Count > 0)
            {
                btnRunSim.Enabled = true;
            }
            else
            {
                btnRunSim.Enabled = false;
            }
        }

       







        #endregion

        //private void processTimer_Tick(object sender, EventArgs e)
        //{
        //    timerDuration = (DateTime.Now - processStartTime).TotalSeconds;
        //    lblCounter.Text = timerDuration.ToString();
        //    Application.DoEvents();
        //    //showElapsedTimeGraphics();
        //}
    }
}

    

