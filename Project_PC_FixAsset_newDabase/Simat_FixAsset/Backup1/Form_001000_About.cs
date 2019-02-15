//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
using System;
using System.Windows.Forms;

public class Form_001000_ABOUT : System.Windows.Forms.Form
{

    #region " Windows Form Designer generated code "

    public Form_001000_ABOUT()
    {
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
    }

    //Form overrides dispose to clean up the component list.
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

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components = null;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    private System.Windows.Forms.PictureBox pbIcon;

    private System.Windows.Forms.Label lblTitle;

    private System.Windows.Forms.Label lblVersion;

    private System.Windows.Forms.Label lblDescription;

    private System.Windows.Forms.Button cmdOK;

    private System.Windows.Forms.Label lblCopyright;
    private Label label2;

    private System.Windows.Forms.Label lblCodebase;

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_001000_ABOUT));
        this.pbIcon = new System.Windows.Forms.PictureBox();
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblVersion = new System.Windows.Forms.Label();
        this.lblDescription = new System.Windows.Forms.Label();
        this.cmdOK = new System.Windows.Forms.Button();
        this.lblCopyright = new System.Windows.Forms.Label();
        this.lblCodebase = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
        this.SuspendLayout();
        // 
        // pbIcon
        // 
        this.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
        this.pbIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.pbIcon.Location = new System.Drawing.Point(12, 16);
        this.pbIcon.Name = "pbIcon";
        this.pbIcon.Size = new System.Drawing.Size(166, 97);
        this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.pbIcon.TabIndex = 0;
        this.pbIcon.TabStop = false;
        // 
        // lblTitle
        // 
        this.lblTitle.BackColor = System.Drawing.Color.Transparent;
        this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
        this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.lblTitle.Location = new System.Drawing.Point(184, 16);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(248, 23);
        this.lblTitle.TabIndex = 1;
        this.lblTitle.Text = "Application Title";
        // 
        // lblVersion
        // 
        this.lblVersion.BackColor = System.Drawing.Color.Transparent;
        this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.lblVersion.Location = new System.Drawing.Point(184, 48);
        this.lblVersion.Name = "lblVersion";
        this.lblVersion.Size = new System.Drawing.Size(248, 23);
        this.lblVersion.TabIndex = 2;
        this.lblVersion.Text = "Application Version";
        // 
        // lblDescription
        // 
        this.lblDescription.BackColor = System.Drawing.Color.Transparent;
        this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.lblDescription.Location = new System.Drawing.Point(184, 94);
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.Size = new System.Drawing.Size(248, 46);
        this.lblDescription.TabIndex = 3;
        this.lblDescription.Text = "Application Description";
        // 
        // cmdOK
        // 
        this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.cmdOK.Location = new System.Drawing.Point(352, 200);
        this.cmdOK.Name = "cmdOK";
        this.cmdOK.Size = new System.Drawing.Size(75, 23);
        this.cmdOK.TabIndex = 4;
        this.cmdOK.Text = "OK";
        // 
        // lblCopyright
        // 
        this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
        this.lblCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.lblCopyright.Location = new System.Drawing.Point(184, 71);
        this.lblCopyright.Name = "lblCopyright";
        this.lblCopyright.Size = new System.Drawing.Size(248, 23);
        this.lblCopyright.TabIndex = 5;
        this.lblCopyright.Text = "Application Copyright";
        // 
        // lblCodebase
        // 
        this.lblCodebase.BackColor = System.Drawing.Color.Transparent;
        this.lblCodebase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
        this.lblCodebase.Location = new System.Drawing.Point(12, 196);
        this.lblCodebase.Name = "lblCodebase";
        this.lblCodebase.Size = new System.Drawing.Size(147, 27);
        this.lblCodebase.TabIndex = 6;
        this.lblCodebase.Text = "Application Codebase";
        this.lblCodebase.Visible = false;
        // 
        // label2
        // 
        this.label2.BackColor = System.Drawing.Color.Transparent;
        this.label2.Font = new System.Drawing.Font("Tahoma", 7F);
        this.label2.Location = new System.Drawing.Point(12, 140);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(304, 83);
        this.label2.TabIndex = 8;
        this.label2.Text = resources.GetString("label2.Text");
        // 
        // Form_001000_ABOUT
        // 
        this.AcceptButton = this.cmdOK;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.AutoSize = true;
        this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
        this.CancelButton = this.cmdOK;
        this.ClientSize = new System.Drawing.Size(440, 232);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.lblCodebase);
        this.Controls.Add(this.lblCopyright);
        this.Controls.Add(this.cmdOK);
        this.Controls.Add(this.lblDescription);
        this.Controls.Add(this.lblVersion);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.pbIcon);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "Form_001000_ABOUT";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "ID:001000(About)";
        this.Load += new System.EventHandler(this.frmAbout_Load);
        ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    // Note: Because this form is opened by frmMain using the ShowDialog command, we simply set the

    // DialogResult property of cmdOK to OK which causes the form to close when clicked.

    private void frmAbout_Load(object sender, System.EventArgs e)
    {

        try
        {

            // Set this Form's Text + Icon properties by using values from the parent form

            //this.Text = "About " + this.Owner.Text;

            //this.Icon = this.Owner.Icon;

            // Set this Form's Picture Box's image using the parent's icon 

            // However, we need to convert it to a Bitmap since the Picture Box Control

            // will not accept a raw Icon.

            //this.pbIcon.Image = this.Owner.Icon.ToBitmap();

            // Set the labels identitying the Title, Version, and Description by

            // reading Assembly meta-data originally entered in the AssemblyInfo.cs file

            // using the AssemblyInfo class defined in the same file

            AssemblyInfo ainfo = new AssemblyInfo();


            this.lblTitle.Text = ainfo.Title;

            this.lblVersion.Text = string.Format("Version {0}", ainfo.Version);

            this.lblCopyright.Text = ainfo.Copyright;

            this.lblDescription.Text = ainfo.Description;

            this.lblCodebase.Text = ainfo.CodeBase;

        }
        catch (System.Exception exp)
        {

            // This catch will trap any unexpected error.

            MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

    }

}

