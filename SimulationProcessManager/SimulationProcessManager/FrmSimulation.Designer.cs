
namespace SimulationProcessManager
{
    partial class FrmSimulation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSimulation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolBarStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgWorkFlowItems = new System.Windows.Forms.DataGridView();
            this.btnRunSim = new System.Windows.Forms.Button();
            this.splitContainerOutput = new System.Windows.Forms.SplitContainer();
            this.panelGraphics = new System.Windows.Forms.Panel();
            this.lvOutput = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            this.toolBarStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkFlowItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutput)).BeginInit();
            this.splitContainerOutput.Panel1.SuspendLayout();
            this.splitContainerOutput.Panel2.SuspendLayout();
            this.splitContainerOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarStrip
            // 
            this.toolBarStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBarStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.helpToolStripButton});
            this.toolBarStrip.Location = new System.Drawing.Point(0, 0);
            this.toolBarStrip.Name = "toolBarStrip";
            this.toolBarStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolBarStrip.Size = new System.Drawing.Size(1658, 27);
            this.toolBarStrip.TabIndex = 8;
            this.toolBarStrip.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.openToolStripButton.Text = "&Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.ToolTipText = "Export Current Command Set";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel,
            this.tsProgress});
            this.statusStrip.Location = new System.Drawing.Point(0, 1044);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1658, 29);
            this.statusStrip.TabIndex = 7;
            // 
            // tsStatusLabel
            // 
            this.tsStatusLabel.Name = "tsStatusLabel";
            this.tsStatusLabel.Size = new System.Drawing.Size(0, 23);
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(100, 21);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgWorkFlowItems);
            this.splitContainer1.Panel1.Controls.Add(this.btnRunSim);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerOutput);
            this.splitContainer1.Size = new System.Drawing.Size(1658, 1009);
            this.splitContainer1.SplitterDistance = 689;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgWorkFlowItems
            // 
            this.dgWorkFlowItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWorkFlowItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgWorkFlowItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWorkFlowItems.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgWorkFlowItems.Location = new System.Drawing.Point(3, 3);
            this.dgWorkFlowItems.Name = "dgWorkFlowItems";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWorkFlowItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgWorkFlowItems.RowHeadersWidth = 51;
            this.dgWorkFlowItems.RowTemplate.Height = 24;
            this.dgWorkFlowItems.Size = new System.Drawing.Size(683, 834);
            this.dgWorkFlowItems.TabIndex = 0;
            this.dgWorkFlowItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWorkFlowItems_CellEndEdit);
            // 
            // btnRunSim
            // 
            this.btnRunSim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunSim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRunSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSim.Location = new System.Drawing.Point(457, 871);
            this.btnRunSim.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunSim.Name = "btnRunSim";
            this.btnRunSim.Size = new System.Drawing.Size(176, 48);
            this.btnRunSim.TabIndex = 7;
            this.btnRunSim.Text = "Run Simulation";
            this.btnRunSim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRunSim.UseVisualStyleBackColor = true;
            this.btnRunSim.Click += new System.EventHandler(this.btnRunSim_Click);
            // 
            // splitContainerOutput
            // 
            this.splitContainerOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOutput.Location = new System.Drawing.Point(0, 0);
            this.splitContainerOutput.Name = "splitContainerOutput";
            this.splitContainerOutput.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOutput.Panel1
            // 
            this.splitContainerOutput.Panel1.Controls.Add(this.panelGraphics);
            // 
            // splitContainerOutput.Panel2
            // 
            this.splitContainerOutput.Panel2.Controls.Add(this.lvOutput);
            this.splitContainerOutput.Size = new System.Drawing.Size(965, 1009);
            this.splitContainerOutput.SplitterDistance = 694;
            this.splitContainerOutput.TabIndex = 2;
            // 
            // panelGraphics
            // 
            this.panelGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGraphics.Location = new System.Drawing.Point(26, 19);
            this.panelGraphics.Name = "panelGraphics";
            this.panelGraphics.Size = new System.Drawing.Size(918, 656);
            this.panelGraphics.TabIndex = 0;
            this.panelGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraphics_Paint);
            // 
            // lvOutput
            // 
            this.lvOutput.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lvOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader2,
            this.colStartTime,
            this.colEndTime,
            this.colDuration,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOutput.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOutput.FullRowSelect = true;
            this.lvOutput.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvOutput.HideSelection = false;
            this.lvOutput.Location = new System.Drawing.Point(0, 0);
            this.lvOutput.Margin = new System.Windows.Forms.Padding(4);
            this.lvOutput.Name = "lvOutput";
            this.lvOutput.Size = new System.Drawing.Size(965, 311);
            this.lvOutput.TabIndex = 1;
            this.lvOutput.UseCompatibleStateImageBehavior = false;
            this.lvOutput.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Step No.";
            this.columnHeader1.Width = 99;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Conveyor";
            this.columnHeader5.Width = 67;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Action";
            this.columnHeader2.Width = 114;
            // 
            // colStartTime
            // 
            this.colStartTime.Text = "Start";
            this.colStartTime.Width = 102;
            // 
            // colEndTime
            // 
            this.colEndTime.Text = "End";
            this.colEndTime.Width = 115;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Duration";
            this.colDuration.Width = 201;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Owner";
            this.columnHeader3.Width = 165;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pass/Fail";
            this.columnHeader4.Width = 91;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "arrow-000-medium1.png");
            this.imageList1.Images.SetKeyName(1, "Arrow Forward.ico");
            this.imageList1.Images.SetKeyName(2, "arrowDown.jpg");
            this.imageList1.Images.SetKeyName(3, "arrowLeft.jpg");
            this.imageList1.Images.SetKeyName(4, "arrowRight.jpg");
            this.imageList1.Images.SetKeyName(5, "arrowUp21.jpg");
            this.imageList1.Images.SetKeyName(6, "Check-Icon.png");
            this.imageList1.Images.SetKeyName(7, "Rotate51.ico");
            this.imageList1.Images.SetKeyName(8, "Cross-Icon.png");
            this.imageList1.Images.SetKeyName(9, "sync.ico");
            this.imageList1.Images.SetKeyName(10, "UpgradeLogo.ico");
            // 
            // processTimer
            // 
            this.processTimer.Interval = 10;
            // 
            // FrmSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1658, 1073);
            this.Controls.Add(this.toolBarStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmSimulation";
            this.Text = "FrmSimulation";
            this.Load += new System.EventHandler(this.FrmSimulation_Load);
            this.toolBarStrip.ResumeLayout(false);
            this.toolBarStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkFlowItems)).EndInit();
            this.splitContainerOutput.Panel1.ResumeLayout(false);
            this.splitContainerOutput.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOutput)).EndInit();
            this.splitContainerOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolBarStrip;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
        public System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgWorkFlowItems;
        private System.Windows.Forms.Button btnRunSim;
        private System.Windows.Forms.SplitContainer splitContainerOutput;
        public System.Windows.Forms.Panel panelGraphics;
        public System.Windows.Forms.ListView lvOutput;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader colStartTime;
        private System.Windows.Forms.ColumnHeader colEndTime;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer processTimer;
    }
}