using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Reflection;

using System.Drawing.Drawing2D;

namespace System.Windows.Forms.Samples
{
	/// <summary>
	/// Summary description for MessageView.
	/// </summary>
	public class RightSpine : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;

		private System.Windows.Forms.WebBrowser webBrowser1;

		private System.Windows.Forms.Panel panel2;

		private System.Windows.Forms.Label fromLabel;

		private System.Windows.Forms.Label subjectLabel;

		private System.Windows.Forms.Label toText;

		private System.Windows.Forms.Label ccText;

		private System.Windows.Forms.Label repliedLabel;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.Label ccLabel;

		private System.Windows.Forms.Label toLabel;
		private TableLayoutPanel tableLayoutPanel1;

		private System.ComponentModel.IContainer components = null;
		private Assembly _assembly;
		private string _namePrefix;
		private bool _loaded = false;
		private MessageStore _store = null;
		private MailMessage _message = null;

		public RightSpine()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            Type type = this.GetType();
            _assembly = type.Assembly;
			_namePrefix = type.Namespace + ".Mail.";
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		// private void InitializeComponent()
		// {
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toText = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.ccLabel = new System.Windows.Forms.Label();
            this.ccText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.repliedLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 520);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 126);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(806, 392);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.repliedLabel);
            this.panel2.Controls.Add(this.fromLabel);
            this.panel2.Controls.Add(this.subjectLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 126);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.toText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ccLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ccText, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(790, 38);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // toText
            // 
            this.toText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.toText.AutoSize = true;
            this.toText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.toText.Location = new System.Drawing.Point(0, 0);
            this.toText.Margin = new System.Windows.Forms.Padding(0);
            this.toText.Name = "toText";
            this.toText.Padding = new System.Windows.Forms.Padding(1);
            this.toText.Size = new System.Drawing.Size(26, 16);
            this.toText.TabIndex = 3;
            this.toText.Text = "To:";
            // 
            // toLabel
            // 
            this.toLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(26, 0);
            this.toLabel.Margin = new System.Windows.Forms.Padding(0);
            this.toLabel.Name = "toLabel";
            this.toLabel.Padding = new System.Windows.Forms.Padding(6, 1, 1, 1);
            this.toLabel.Size = new System.Drawing.Size(76, 16);
            this.toLabel.TabIndex = 6;
            this.toLabel.Text = "Joe Stegman";
            // 
            // ccLabel
            // 
            this.ccLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ccLabel.AutoSize = true;
            this.ccLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccLabel.Location = new System.Drawing.Point(26, 16);
            this.ccLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ccLabel.Name = "ccLabel";
            this.ccLabel.Padding = new System.Windows.Forms.Padding(6, 1, 1, 1);
            this.ccLabel.Size = new System.Drawing.Size(131, 16);
            this.ccLabel.TabIndex = 7;
            this.ccLabel.Text = "Regis Brid, Mark Rideout";
            // 
            // ccText
            // 
            this.ccText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ccText.AutoSize = true;
            this.ccText.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.ccText.Location = new System.Drawing.Point(0, 16);
            this.ccText.Margin = new System.Windows.Forms.Padding(0);
            this.ccText.Name = "ccText";
            this.ccText.Padding = new System.Windows.Forms.Padding(1);
            this.ccText.Size = new System.Drawing.Size(26, 16);
            this.ccText.TabIndex = 4;
            this.ccText.Text = "Cc:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.label3.Location = new System.Drawing.Point(10, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(786, 1);
            this.label3.TabIndex = 5;
            // 
            // repliedLabel
            // 
            this.repliedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.repliedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(153)))), ((int)(((byte)(173)))));
            this.repliedLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repliedLabel.ForeColor = System.Drawing.SystemColors.Window;
            this.repliedLabel.Location = new System.Drawing.Point(10, 58);
            this.repliedLabel.Name = "repliedLabel";
            this.repliedLabel.Size = new System.Drawing.Size(786, 16);
            this.repliedLabel.TabIndex = 2;
            this.repliedLabel.Text = "You replied on 10/22/2003 4:26 PM";
            this.repliedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(10, 35);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(89, 17);
            this.fromLabel.TabIndex = 1;
            this.fromLabel.Text = "Mark Boulter";
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLabel.Location = new System.Drawing.Point(10, 10);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(103, 19);
            this.subjectLabel.TabIndex = 0;
            this.subjectLabel.Text = "Outlook grid";
            // 
            // RightSpine
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "RightSpine";
            this.Size = new System.Drawing.Size(820, 532);
            this.Load += new System.EventHandler(this.MessageView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Properties
		[DefaultValue(null)]
		private MailMessage Message
		{
			get
			{
				return _message;
			}
			set
			{
				_message = value;

				if ((null != value) && (_loaded))
				{
					// Set values
					this.subjectLabel.Text = _message.Subject;
					this.fromLabel.Text = _message.From;
					this.toLabel.Text = _message.To;
					this.ccLabel.Text = _message.Cc;

					// Add code to look for "RE:" and subtrack time of Sent
					if (_message.Subject.Contains("RE:"))
					{
						DateTime time = _message.SentDate;
						this.repliedLabel.Text = " You replied to this message on " + time.Subtract(new TimeSpan(3, 3, 3)).ToShortDateString();
					}
					else
					{
						this.repliedLabel.Text = " You have not responded to this message";
					}

                    if (null != _assembly)
                    {
                        Stream doc = _assembly.GetManifestResourceStream(_namePrefix + _message.Path);

                        if (null != doc)
                        {
                            this.webBrowser1.DocumentStream = doc;
                        }
                    }
				}
			}
		}
		#endregion

		#region Event Handlers
		protected override void OnPaint(PaintEventArgs e)
		{
			// Paint gradient
			LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(106, 112, 128), Color.FromArgb(138, 146, 166), LinearGradientMode.ForwardDiagonal);

			e.Graphics.FillRectangle(brush, this.ClientRectangle);

			// Call base
			base.OnPaint(e);
		}

		void MessageStore_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (String.IsNullOrEmpty(e.PropertyName) || (e.PropertyName == "SelectedMessage"))
			{
				this.Message = _store.SelectedMessage;
			}
		}

		private void MessageView_Load(object sender, EventArgs e)
		{
			// Set Dock Stlye
			this.Dock = DockStyle.Fill;

			// Set loaded flag
			_loaded = true;

			// Load the Message (if not in design mode)
			if (null == this.Site)
			{
				_store = MessageStore.GetMessageStore();

                if ((null != _store) && (null != _store.SelectedMessage))
                {
                    // Get Current
                    this.Message = _store.SelectedMessage;

                    // Hook change notification
                    _store.PropertyChanged += new PropertyChangedEventHandler(MessageStore_PropertyChanged);
                }
			}
			else if ((null != this.Parent) && (this.Parent.Site != null) && (this.Parent.Site.DesignMode == true))
			{
				this.webBrowser1.Visible = false;
			}

			// Set parent padding
			if (null != this.Parent)
			{
				this.Parent.Padding = new Padding(0, 3, 3, 3);
			}
		}
		#endregion
	}
}
