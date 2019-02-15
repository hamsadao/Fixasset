namespace System.Windows.Forms.Samples
{
	partial class MessageArea
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.messageList1 = new System.Windows.Forms.Samples.MessageList();
            this.headerStrip1 = new System.Windows.Forms.Samples.HeaderStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.headerStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageList1
            // 
            this.messageList1.BackColor = System.Drawing.SystemColors.Window;
            this.messageList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageList1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.messageList1.Location = new System.Drawing.Point(0, 25);
            this.messageList1.Name = "messageList1";
            this.messageList1.Size = new System.Drawing.Size(711, 460);
            this.messageList1.TabIndex = 1;
            this.messageList1.Load += new System.EventHandler(this.messageList1_Load);
            // 
            // headerStrip1
            // 
            this.headerStrip1.AutoSize = false;
            this.headerStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.headerStrip1.ForeColor = System.Drawing.Color.White;
            this.headerStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.headerStrip1.Location = new System.Drawing.Point(0, 0);
            this.headerStrip1.Name = "headerStrip1";
            this.headerStrip1.Size = new System.Drawing.Size(711, 25);
            this.headerStrip1.TabIndex = 0;
            this.headerStrip1.Text = "headerStrip1";
            this.headerStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.headerStrip1_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "Inbox";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // MessageArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.messageList1);
            this.Controls.Add(this.headerStrip1);
            this.Name = "MessageArea";
            this.Size = new System.Drawing.Size(711, 485);
            this.Load += new System.EventHandler(this.MessageArea_Load);
            this.headerStrip1.ResumeLayout(false);
            this.headerStrip1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private MessageList messageList1;
        private ToolStripLabel toolStripLabel1;
        private HeaderStrip headerStrip1;


	}
}
