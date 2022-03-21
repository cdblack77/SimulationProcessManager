using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Autodesk.AutoCAD.Runtime;
//using Autodesk.AutoCAD.ApplicationServices;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.EditorInput;
//using Autodesk.AutoCAD.Geometry;
using System.Windows.Forms;
//using bomGenerator.Forms;
using System.Drawing;



//[assembly: CommandClass(typeof(bomGenerator.Classes.Simulation.Simulator))]


namespace SimulationProcessManager
{
    class Simulator
    {
        //static Document _acadDoc;
        //static Database _acActiveDb;
        //static Editor _acEditor;

        //static FrmSimulation _outputForm;

        //static double binWidMillimeters = ConfigSettings.BIN_WIDTH * 10;
        //static double binHeightMillimeters = ConfigSettings.BIN_HEIGHT * 10;

        //const double ROTATION_DEGREES = 15;
        //const string ANT_BLOCK_NAME = "sim_ant";
        //const string BIN_BLOCK_NAME = "sim_bin";
        //const string PICK_PORT_BLOCK_NAME = "sim_pick_port";
        //const string FRONT_WORK_STATION_BLOCK_NAME = "sim_front_ws";

        //const string STEP_CALLOUT_ANT_BLOCK_NAME = "sim_step_callout_ant";
        //static string STEP_CALLOUT_ANT_LOCATION = Settings.Default.blockPath + STEP_CALLOUT_ANT_BLOCK_NAME + ".dwg";


        //const string STEP_CALLOUT_BIN_BLOCK_NAME = "sim_step_callout_bin";
        //static string STEP_CALLOUT_BIN_LOCATION = Settings.Default.blockPath + STEP_CALLOUT_BIN_BLOCK_NAME + ".dwg";

        //[CommandMethod("lsim")]

        //public static void launchSimulationUi()
        //{

        //    _acadDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
        //    _acActiveDb = _acadDoc.Database;
        //    _acEditor = _acadDoc.Editor;
        //    try
        //    {

        //        FrmSimulation f = new FrmSimulation();
        //        f.StartPosition = FormStartPosition.CenterScreen;
        //        f.ShowDialog();

        //        #region test data
        //        //List<BlockReference> ants = AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, "ant");
        //        //BlockReference ant = ants[0];

        //        //// BlockReference ant = AutoCadGenericFunctions.insertBlock(_acActiveDb, _acadDoc, "C:\\Users\\ChristopherBlack\\AutoCAD\\Blocks\\ant.dwg", "ant", new Point3d(0, 0, 0), null, 1, false);
        //        //// move ant one square to the right
        //        //Point3d newPoint = new Point3d(ant.Position.X + (binWidMillimeters * 9), ant.Position.Y, ant.Position.Z);

        //        //// determine whether we'er moving horizontally (x) or vertically (y)
        //        //moveAntIncrementally(ant, ant.Position, newPoint);

        //        //// up 4
        //        //newPoint = new Point3d(ant.Position.X, ant.Position.Y + (binWidMillimeters * 4), ant.Position.Z);
        //        //moveAntIncrementally(ant, ant.Position, newPoint);

        //        //// left 9
        //        //newPoint = new Point3d(ant.Position.X - (binWidMillimeters * 9), ant.Position.Y , ant.Position.Z);
        //        //moveAntIncrementally(ant, ant.Position, newPoint);


        //        //newPoint = new Point3d(ant.Position.X, ant.Position.Y - (binWidMillimeters * 4), ant.Position.Z);
        //        //moveAntIncrementally(ant, ant.Position, newPoint);


        //        //// move up to attic
        //        //newPoint = new Point3d(ant.Position.X, ant.Position.Y , ant.Position.Z + (binHeightMillimeters * 12));
        //        //moveAntIncrementally(ant, ant.Position, newPoint);

        //        //newPoint = new Point3d(ant.Position.X + (binWidMillimeters * 9), ant.Position.Y, ant.Position.Z);

        //        //// determine whether we'er moving horizontally (x) or vertically (y)
        //        //moveAntIncrementally(ant, ant.Position, newPoint);

        //        //// down again
        //        //newPoint = new Point3d(ant.Position.X, ant.Position.Y, ant.Position.Z - (binHeightMillimeters * 12));
        //        //moveAntIncrementally(ant, ant.Position, newPoint);
        //        #endregion
        //    }
        //    catch (Autodesk.AutoCAD.Runtime.Exception e)
        //    {
        //        MessageBox.Show("An unexpected error occurred: \n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    catch (System.Exception e)
        //    {
        //        MessageBox.Show("An unexpected error occurred: \n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}



        //static  BlockReference antBlockRef;
        //static  BlockReference binBlockRef;
        //static BlockReference pickPortBlockRef;
        //static BlockReference frontWsBlockRef;

        static DateTime _processStartTime;
        //public static TimeLineItemsList runSimulation( List<SimulaionCommand> simCommands, FrmSimulation frm)
        //{
        //    _outputForm = frm;
        //    _outputForm.tsProgress.Maximum = simCommands.Count;

        //    List<BlockReference> antBlks = AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, ANT_BLOCK_NAME);
        //    List<BlockReference> binBlks= AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, BIN_BLOCK_NAME);
        //    List<BlockReference> pickPortBlks = AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, PICK_PORT_BLOCK_NAME) ;
        //    List<BlockReference> frontWsBlks = AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, FRONT_WORK_STATION_BLOCK_NAME);

        //    if (antBlks.Count > 0 && binBlks.Count > 0)
        //    {

        //        antBlockRef = antBlks[0];
        //        binBlockRef = binBlks[0];

        //        // not ablutely necessary if not exist for ant and bin simulation:
        //        if (pickPortBlks.Count > 0)
        //        {
        //            pickPortBlockRef = pickPortBlks[0];
        //        }
        //        if (frontWsBlks.Count > 0)
        //        {
        //            frontWsBlockRef = frontWsBlks[0];
        //        }

        //        _timeLIneItems = new TimeLineItemsList();
        //        _processStartTime = DateTime.Now;

        //        DateTime startTime;
        //        DateTime endTime;

        //        bool res = true;
        //        foreach (SimulaionCommand s in simCommands)
        //        {
        //            BlockReference blkRef;
        //            List<Entity> blkRefs = new List<Entity>();

        //            ListViewItem lvItemToUpdate;
        //            if (s._item.ToLower().Equals("pick port"))
        //            {
        //                startTime = DateTime.Now;
        //                if (pickPortBlockRef != null)
        //                {
        //                    lvItemToUpdate= updateOutputForm(true, s);

        //                    rotatePickstation(pickPortBlockRef,s._direction, s._gridSpaces);

        //                }
        //                else
        //                {
        //                    lvItemToUpdate= updateOutputForm(false, s);
        //                }
        //                endTime = DateTime.Now;

        //            }
        //             else if (s._item.ToLower().Equals("front workstation"))
        //            {
        //                startTime = DateTime.Now;
        //                if (frontWsBlockRef != null)
        //                {
        //                    lvItemToUpdate = updateOutputForm(true, s);

        //                    rotatePickstation(frontWsBlockRef, s._direction, s._gridSpaces);

        //                }
        //                else
        //                {
        //                    lvItemToUpdate = updateOutputForm(false, s);
        //                }
        //                endTime = DateTime.Now;

        //            }
        //            else
        //            {

        //                startTime = DateTime.Now;
        //                if (s._item.ToLower().Equals("ant"))
        //                {
        //                    blkRef = antBlockRef;
        //                    blkRefs.Add(antBlockRef);
        //                }
        //                else if (s._item.ToLower().Equals("bin"))
        //                {
        //                    blkRef = binBlockRef;
        //                    blkRefs.Add(binBlockRef);
        //                }
        //                else
        //                {
        //                    // move both ant and bin together
        //                    blkRef = antBlockRef;   // the ant and bin will always be at same insertion point when moving in tandem... so just use the ant insertion point for calculating next point
        //                    blkRefs.Add(binBlockRef);
        //                    blkRefs.Add(antBlockRef);
        //                }

        //                Point3d toPoint = calculateNextPoint(blkRef.Position, s);
        //                PubMoveIncrement = s._speedIncrement;
        //                lvItemToUpdate= updateOutputForm(res, s);
        //                res = moveItemIncrementally(blkRefs, blkRef.Position, toPoint);

        //                endTime = DateTime.Now;
        //            }
        //            addTimeStampsToListViewItem(lvItemToUpdate, startTime, endTime);

        //        }
        //        //buildTimeLineGraph();

        //        return _timeLIneItems;

        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        //public static void resetRobotPosition()
        //{

        //    List<BlockReference> antBlks = AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, ANT_BLOCK_NAME);
        //    List<BlockReference> binBlks = AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, BIN_BLOCK_NAME);

        //    if (antBlks.Count > 0 && binBlks.Count > 0)
        //    {

        //        Point3d pntOrigin = new Point3d(0, 0, 0);
        //        antBlockRef = antBlks[0];
        //        binBlockRef = binBlks[0];

        //        moveEnt(antBlockRef, antBlockRef.Position, pntOrigin);
        //        moveEnt(binBlockRef, binBlockRef.Position, pntOrigin);
        //    }

        //}

        //private static Point3d getAntOrigin()
        //{
        //    List<BlockReference> antBlks = AutoCadGenericFunctions.getBlockList(_acEditor, _acActiveDb, ANT_BLOCK_NAME);
        //    if (antBlks.Count > 0)
        //    {
        //        return antBlks[0].Position;
        //    }
        //    else
        //    {

        //        throw new System.Exception("An ant must exist in the model!");
        //    }

        //}


        //public static void deleteStepCallouts()
        //{
        //    AutoCadGenericFunctions.deleteBlockRefsByName(_acEditor, _acActiveDb, STEP_CALLOUT_ANT_BLOCK_NAME + "," + STEP_CALLOUT_BIN_BLOCK_NAME);
        //}
        //public static void addStepCallouts(List<SimulaionCommand> simComms)
        //{
        //    // delete existing callouts and rebuild
        //    deleteStepCallouts();

        //    #region old code
        //    //Point3d ins = getAntOrigin();

        //    //Point3d antIns = ins;
        //    //Point3d binIns = ins;
        //    //foreach (SimulaionCommand simComm in simComms)
        //    //{
        //    //    List<BlockRefPair> blks = getBlockRefPairs(simComm);

        //    //    AcadAttributePair attPairs = new AcadAttributePair();
        //    //    AcadAttributePair ap = new AcadAttributePair("STEP_NUMBER", (simComm._stepNumber).ToString());
        //    //    attPairs.addAttributePairToList(ap);
        //    //    ins = calculateNextPoint(ins, simComm);
        //    //    if (simComm._item.ToLower().Equals("ant"))
        //    //    {
        //    //        antIns = ins;
        //    //    }
        //    //    else if (simComm._item.ToLower().Equals("bin"))
        //    //    {
        //    //        binIns = ins;
        //    //    }
        //    //    else
        //    //    {
        //    //        antIns = ins;
        //    //        binIns = ins;
        //    //    }

        //    //    foreach (BlockRefPair bp in blks)
        //    //    {
        //    //        if (bp._blockName == STEP_CALLOUT_ANT_BLOCK_NAME)
        //    //        {
        //    //            AutoCadGenericFunctions.insertBlock(_acActiveDb, _acadDoc, bp._blockPath, bp._blockName, antIns, attPairs.attributePairList, 1, false);

        //    //        }
        //    //        else
        //    //        {
        //    //            AutoCadGenericFunctions.insertBlock(_acActiveDb, _acadDoc, bp._blockPath, bp._blockName, binIns, attPairs.attributePairList, 1, false);
        //    //        }


        //    //    }
        //    //}
        //    #endregion

        //    // make two separate point lists... one for ant movement and one for all bin movements



        //    List<SimulaionCommand> antMovments = (from SimulaionCommand in simComms
        //                                          where SimulaionCommand._item.ToLower().Contains("ant")
        //                                          select SimulaionCommand).ToList();
        //    processStepCallouts(antMovments, STEP_CALLOUT_ANT_BLOCK_NAME, STEP_CALLOUT_ANT_LOCATION);

        //    List<SimulaionCommand> binMovments = (from SimulaionCommand in simComms
        //                                          where SimulaionCommand._item.ToLower().Contains("bin")
        //                                          select SimulaionCommand).ToList();
        //    processStepCallouts(binMovments, STEP_CALLOUT_BIN_BLOCK_NAME, STEP_CALLOUT_BIN_LOCATION);

        //}

        //private static void processStepCallouts(List<SimulaionCommand> simComms, string blockName, string blockPath)
        //{
        //    Point3d ins = getAntOrigin();
        //    foreach (SimulaionCommand mComm in simComms)
        //    {
        //        AcadAttributePair attPairs = new AcadAttributePair();
        //        AcadAttributePair ap = new AcadAttributePair("STEP_NUMBER", (mComm._stepNumber).ToString());
        //        attPairs.addAttributePairToList(ap);
        //        ins = calculateNextPoint(ins, mComm);
        //        AutoCadGenericFunctions.insertBlock(_acActiveDb, _acadDoc, blockPath, blockName, ins, attPairs.attributePairList, 1, false);
        //    }
        //}


        class BlockRefPair
        {
            public string _blockName { get; private set; }
            public string _blockPath { get; private set; }

            public BlockRefPair(string blockName, string blockPath)
            {
                _blockName = blockName;
                _blockPath = blockPath;
            }

        }

        //private static List<BlockRefPair> getBlockRefPairs(SimulaionCommand simComm)
        //{
        //    BlockRefPair blkRef;
        //    List<BlockRefPair> blkRefs = new List<BlockRefPair>(); ;
        //    if (simComm._item.ToLower().Equals("ant"))
        //    {
        //        blkRef = new BlockRefPair(STEP_CALLOUT_ANT_BLOCK_NAME, STEP_CALLOUT_ANT_LOCATION);
        //        blkRefs.Add(blkRef);
        //    }
        //    else if (simComm._item.ToLower().Equals("bin"))
        //    {
        //        blkRef = new BlockRefPair(STEP_CALLOUT_BIN_BLOCK_NAME, STEP_CALLOUT_BIN_LOCATION);
        //        blkRefs.Add(blkRef);
        //    }
        //    else
        //    {
        //        blkRef = new BlockRefPair(STEP_CALLOUT_ANT_BLOCK_NAME, STEP_CALLOUT_ANT_LOCATION);
        //        blkRefs.Add(blkRef);
        //        blkRef = new BlockRefPair(STEP_CALLOUT_BIN_BLOCK_NAME, STEP_CALLOUT_BIN_LOCATION);
        //        blkRefs.Add(blkRef);
        //    }
        //    return blkRefs;
        //}




        
        //private static ListViewItem updateOutputForm(bool success, SimulaionCommand simCommand)
        //{
        //    int imageIndex = success ? 6 : 8;
            
        //    ListViewItem l = _outputForm.lvOutput.Items.Add(simCommand._stepNumber.ToString());
        //    l.SubItems.Add(simCommand._item);
        //    l.SubItems.Add(simCommand._direction);
        //    l.SubItems.Add(simCommand._gridSpaces.ToString());
        //    l.SubItems.Add(simCommand._speedIncrement.ToString());
        //    // add start and end times
            

        //    l.ImageIndex = imageIndex;
        //    _outputForm.tsProgress.Value = simCommand._stepNumber;
        //    _outputForm.tsStatusLabel.Text = "Processing " + simCommand._stepNumber.ToString() + " of " + _outputForm.tsProgress.Maximum.ToString() + " steps";
        //     _outputForm.lblCounter.Text = simCommand._stepNumber.ToString() + " of " + _outputForm.tsProgress.Maximum.ToString() + "..." ;

        //    System.Windows.Forms.Application.DoEvents();

        //    return l;

        //}


        static TimeLineItemsList _timeLIneItems;
        private static void addTimeStampsToListViewItem(ListViewItem lvItem, DateTime startTime, DateTime endTime)
        {
            lvItem.SubItems.Add(startTime.TimeOfDay.ToString());
            lvItem.SubItems.Add(endTime.TimeOfDay.ToString());
            double duration =Math.Round( (endTime - startTime).TotalSeconds,3);
            lvItem.SubItems.Add(duration.ToString());

            // maintain list of TimLineItems to use for building out timeline graph
            TimeLineItem t = new TimeLineItem(_timeLIneItems.Count, lvItem.SubItems[1].Text, lvItem.SubItems[2].Text,_processStartTime, startTime, endTime, duration);
            _timeLIneItems.Add(t);

        }


        

        //private static Point3d calculateNextPoint(Point3d antCurrentPosition, SimulaionCommand simComm)
        //{
        //    double travelDist;
        //    if (simComm._direction.Contains("z"))
        //    {
        //        travelDist = binHeightMillimeters * simComm._gridSpaces;    // use the bin height dist for up and down motions
        //    }
        //    else
        //    {
        //        travelDist = binWidMillimeters * simComm._gridSpaces;
        //    }
        //    if (simComm._direction.Contains( "x+"))
        //    {
        //        return  new Point3d(antCurrentPosition.X + travelDist, antCurrentPosition.Y, antCurrentPosition.Z);
        //    }
        //    else if (simComm._direction.Contains( "x-"))
        //    {
        //        return new Point3d(antCurrentPosition.X - travelDist, antCurrentPosition.Y, antCurrentPosition.Z);
        //    }
        //    else if (simComm._direction.Contains( "y+"))
        //    {
        //        return new Point3d(antCurrentPosition.X , antCurrentPosition.Y + travelDist, antCurrentPosition.Z);
        //    }
        //    else  if(simComm._direction.Contains( "y-"))
        //    {
        //        return new Point3d(antCurrentPosition.X, antCurrentPosition.Y - travelDist, antCurrentPosition.Z);
        //    }
        //    else if (simComm._direction.Contains( "z+"))
        //    {
        //        return new Point3d(antCurrentPosition.X, antCurrentPosition.Y, antCurrentPosition.Z + travelDist);
        //    }
        //    else //if (simComm._direction == "z-")
        //    {
        //        return new Point3d(antCurrentPosition.X, antCurrentPosition.Y , antCurrentPosition.Z - travelDist);
        //    }

        //}

        //static int PubMoveIncrement ;
        //private static bool moveItemIncrementally(List<Entity> blockRefs, Point3d startPosition, Point3d newPosition)
        //{
        //    try
        //    {
        //        movementConfig mConfig = getMovementConfig(startPosition, newPosition);

        //        int movePoints;
        //        bool isReverse = false; // if true - we're going backwards
        //        if (mConfig == movementConfig.horizontal)
        //        {
        //            // find the x coord dif
        //            movePoints = (int)Math.Abs(newPosition.X - startPosition.X) / PubMoveIncrement;
        //            if (newPosition.X < startPosition.X)
        //            {
        //                isReverse = true;
        //            }
        //        }
        //        else if (mConfig == movementConfig.vertical)
        //        {
        //            // find the y coord dif
        //            movePoints = (int)Math.Abs(newPosition.Y - startPosition.Y) / PubMoveIncrement;
        //            if (newPosition.Y < startPosition.Y)
        //            {
        //                isReverse = true;
        //            }
        //        }
        //        else //if (mConfig == movementConfig.zmovement)
        //        {
        //            // find the y coord dif
        //            movePoints = (int)Math.Abs(newPosition.Z - startPosition.Z) / PubMoveIncrement;
        //            if (newPosition.Z < startPosition.Z)
        //            {
        //                isReverse = true;
        //            }
        //        }



        //        Point3d incPostion = startPosition;
        //        for (int i = 0; i < movePoints; i++)
        //        {


        //            if (mConfig == movementConfig.horizontal)
        //            {
        //                if (isReverse)
        //                {
        //                    incPostion = new Point3d(incPostion.X - PubMoveIncrement, incPostion.Y, incPostion.Z);
        //                }
        //                else
        //                {
        //                    incPostion = new Point3d(incPostion.X + PubMoveIncrement, incPostion.Y, incPostion.Z);
        //                }
        //            }
        //            else if (mConfig == movementConfig.vertical)
        //            {
        //                if (isReverse)
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y - PubMoveIncrement, incPostion.Z);
        //                }
        //                else
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y + PubMoveIncrement, incPostion.Z);
        //                }

        //            }
        //            else
        //            {
        //                if (isReverse)
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y, incPostion.Z - PubMoveIncrement);
        //                }
        //                else
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y, incPostion.Z + PubMoveIncrement);
        //                }

        //            }
        //            foreach (Entity blockItem in blockRefs)
        //            {
        //                moveEnt((Entity)blockItem, startPosition, incPostion);
        //                Autodesk.AutoCAD.ApplicationServices.Application.UpdateScreen();
        //            }
                    

        //            startPosition = incPostion;
        //        }
        //        foreach (Entity blockItem in blockRefs)
        //        {
        //            // since it doesn't move exactly to the position.. give it one last push
        //            moveEnt((Entity)blockItem, startPosition, newPosition);
        //            //Autodesk.AutoCAD.ApplicationServices.Application.UpdateScreen();
        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}


        //#region for one block
        //private static bool moveItemIncrementally(Entity blockItem, Point3d startPosition, Point3d newPosition)
        //{
        //    try
        //    {
        //        movementConfig mConfig = getMovementConfig(startPosition, newPosition);

        //        int movePoints;
        //        bool isReverse = false; // if true - we're going backwards
        //        if (mConfig == movementConfig.horizontal)
        //        {
        //            // find the x coord dif
        //            movePoints = (int)Math.Abs(newPosition.X - startPosition.X) / PubMoveIncrement;
        //            if (newPosition.X < startPosition.X)
        //            {
        //                isReverse = true;
        //            }
        //        }
        //        else if (mConfig == movementConfig.vertical)
        //        {
        //            // find the y coord dif
        //            movePoints = (int)Math.Abs(newPosition.Y - startPosition.Y) / PubMoveIncrement;
        //            if (newPosition.Y < startPosition.Y)
        //            {
        //                isReverse = true;
        //            }
        //        }
        //        else //if (mConfig == movementConfig.zmovement)
        //        {
        //            // find the y coord dif
        //            movePoints = (int)Math.Abs(newPosition.Z - startPosition.Z) / PubMoveIncrement;
        //            if (newPosition.Z < startPosition.Z)
        //            {
        //                isReverse = true;
        //            }
        //        }



        //        Point3d incPostion = startPosition;
        //        for (int i = 0; i < movePoints; i++)
        //        {


        //            if (mConfig == movementConfig.horizontal)
        //            {
        //                if (isReverse)
        //                {
        //                    incPostion = new Point3d(incPostion.X - PubMoveIncrement, incPostion.Y, incPostion.Z);
        //                }
        //                else
        //                {
        //                    incPostion = new Point3d(incPostion.X + PubMoveIncrement, incPostion.Y, incPostion.Z);
        //                }
        //            }
        //            else if (mConfig == movementConfig.vertical)
        //            {
        //                if (isReverse)
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y - PubMoveIncrement, incPostion.Z);
        //                }
        //                else
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y + PubMoveIncrement, incPostion.Z);
        //                }

        //            }
        //            else
        //            {
        //                if (isReverse)
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y, incPostion.Z - PubMoveIncrement);
        //                }
        //                else
        //                {
        //                    incPostion = new Point3d(incPostion.X, incPostion.Y, incPostion.Z + PubMoveIncrement);
        //                }

        //            }
        //            moveEnt((Entity)blockItem, startPosition, incPostion);
        //            Autodesk.AutoCAD.ApplicationServices.Application.UpdateScreen();

        //            startPosition = incPostion;
        //        }
        //        // since it doesn't move exactly to the position.. give it one last push
        //        moveEnt((Entity)blockItem, startPosition, newPosition);
        //        Autodesk.AutoCAD.ApplicationServices.Application.UpdateScreen();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //#endregion

        //private enum movementConfig { horizontal, vertical, zmovement }

        //private static movementConfig getMovementConfig(Point3d startPoint, Point3d endPoint)
        //{
        //    if (startPoint.X != endPoint.X && startPoint.Y == endPoint.Y &&  startPoint.Z == endPoint.Z)
        //    {
        //        return movementConfig.horizontal;
        //    }
        //    else if (startPoint.X == endPoint.X && startPoint.Y != endPoint.Y && startPoint.Z == endPoint.Z)
        //    {
        //        return movementConfig.vertical;
        //    }
        //    else // if (startPoint.X == endPoint.X && startPoint.Y == endPoint.Y && startPoint.Z != endPoint.Z)
        //    {
        //        return movementConfig.zmovement;
        //    }

        //}

        //private static void moveEnt(Entity ant, Point3d startPosition, Point3d newPosition)
        //{


        //    using (Transaction acTrans = _acActiveDb.TransactionManager.StartTransaction())
        //    {
        //        ObjectId id = ant.ObjectId;

        //        DBObject obj = (DBObject)acTrans.GetObject(id, OpenMode.ForWrite);
        //        Entity castObj = (Entity)obj;

        //        Vector3d v3d = startPosition.GetVectorTo(newPosition);
        //        Matrix3d movementMat = Matrix3d.Displacement(v3d);
        //        castObj.TransformBy(movementMat);


        //        acTrans.Commit();
        //    }
     
        //}


        
        //private static void rotatePickstation(BlockReference pickPort,string direction,  double rotationDegrees)
        //{

        //    //if (direction.ToLower().Contains("z-"))
        //    //{
        //    //    rotationDegrees = rotationDegrees - (rotationDegrees * 2);
        //    //}
        //    for (int i = 0; i < rotationDegrees; i++)
        //    {
        //        int k = 1;
        //        if (direction.ToLower().Contains("z-"))
        //        {
        //            k = k - (k * 2);
        //        }
        //        AutoCadGenericFunctions.rotateEntity(_acActiveDb, _acadDoc, k, pickPort, pickPort.Position);
        //    }


        //}








    }
}
