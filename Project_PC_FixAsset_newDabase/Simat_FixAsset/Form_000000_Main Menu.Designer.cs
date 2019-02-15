namespace SimatSoft.FixAsset
{
    partial class Form_000000_MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_000000_MainMenu));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.folderTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.headerStrip1 = new System.Windows.Forms.Samples.HeaderStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.headerStrip2 = new System.Windows.Forms.Samples.HeaderStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.stackStrip = new System.Windows.Forms.Samples.StackStrip();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.headerStrip1.SuspendLayout();
            this.headerStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.headerStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.headerStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.stackStrip);
            this.splitContainer1.Size = new System.Drawing.Size(226, 608);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 0;
            // 
            // folderTreeView
            // 
            this.folderTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTreeView.BackColor = System.Drawing.Color.White;
            this.folderTreeView.HideSelection = false;
            this.folderTreeView.ImageIndex = 0;
            this.folderTreeView.ImageList = this.imageList1;
            this.folderTreeView.Location = new System.Drawing.Point(0, 44);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.SelectedImageIndex = 0;
            this.folderTreeView.Size = new System.Drawing.Size(226, 331);
            this.folderTreeView.TabIndex = 36;
            this.folderTreeView.TabStop = false;
            this.folderTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.folderTreeView_NodeMouseDoubleClick);
            this.folderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.folderTreeView_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "JournalEntry.bmp");
            // 
            // headerStrip1
            // 
            this.headerStrip1.AutoSize = false;
            this.headerStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.headerStrip1.ForeColor = System.Drawing.Color.Black;
            this.headerStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip1.HeaderStyle = System.Windows.Forms.Samples.AreaHeaderStyle.Small;
            this.headerStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3});
            this.headerStrip1.Location = new System.Drawing.Point(0, 25);
            this.headerStrip1.Name = "headerStrip1";
            this.headerStrip1.Size = new System.Drawing.Size(226, 19);
            this.headerStrip1.TabIndex = 34;
            this.headerStrip1.Text = "headerStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(51, 16);
            this.toolStripLabel3.Text = " All Client";
            // 
            // headerStrip2
            // 
            this.headerStrip2.AutoSize = false;
            this.headerStrip2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.headerStrip2.ForeColor = System.Drawing.Color.White;
            this.headerStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4});
            this.headerStrip2.Location = new System.Drawing.Point(0, 0);
            this.headerStrip2.Name = "headerStrip2";
            this.headerStrip2.Size = new System.Drawing.Size(226, 25);
            this.headerStrip2.TabIndex = 35;
            this.headerStrip2.Text = "headerStrip2";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel4.Text = "Client ";
            // 
            // stackStrip
            // 
            this.stackStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stackStrip.AutoSize = false;
            this.stackStrip.CanOverflow = false;
            this.stackStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.stackStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.stackStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stackStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.stackStrip.Location = new System.Drawing.Point(0, 0);
            this.stackStrip.Name = "stackStrip";
            this.stackStrip.Padding = new System.Windows.Forms.Padding(0);
            this.stackStrip.Size = new System.Drawing.Size(226, 230);
            this.stackStrip.TabIndex = 2;
            this.stackStrip.Tag = "Read";
            this.stackStrip.Text = "stackStrip1";
            // 
            // Form_000000_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 608);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(0, -2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_000000_MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ID:000000(Main Menu)";
            this.Load += new System.EventHandler(this.Form_003000_MainMenu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.headerStrip1.ResumeLayout(false);
            this.headerStrip1.PerformLayout();
            this.headerStrip2.ResumeLayout(false);
            this.headerStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Samples.HeaderStrip headerStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Samples.HeaderStrip headerStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        public System.Windows.Forms.TreeView folderTreeView;
        private System.Windows.Forms.Samples.StackStrip stackStrip;
        private System.Windows.Forms.ImageList imageList1;
    }
}