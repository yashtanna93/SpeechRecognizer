namespace FinalApp
{
    partial class Chat
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
            this.jabberClient1 = new jabber.client.JabberClient(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlCredentials = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnSignin = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlContact = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.rosterTree1 = new muzzle.RosterTree();
            this.lblPresence = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.pnlCredentials.SuspendLayout();
            this.pnlContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // jabberClient1
            // 
            this.jabberClient1.AutoReconnect = 30F;
            this.jabberClient1.AutoStartCompression = true;
            this.jabberClient1.AutoStartTLS = true;
            this.jabberClient1.InvokeControl = this;
            this.jabberClient1.KeepAlive = 30F;
            this.jabberClient1.LocalCertificate = null;
            this.jabberClient1.Password = null;
            this.jabberClient1.User = null;
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStatus.Location = new System.Drawing.Point(10, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(236, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Double Click to enter your status message";
            // 
            // pnlCredentials
            // 
            this.pnlCredentials.Controls.Add(this.txtPassword);
            this.pnlCredentials.Controls.Add(this.lblPassword);
            this.pnlCredentials.Controls.Add(this.txtUserName);
            this.pnlCredentials.Controls.Add(this.btnSignin);
            this.pnlCredentials.Controls.Add(this.lblUserName);
            this.pnlCredentials.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlCredentials.Location = new System.Drawing.Point(25, 85);
            this.pnlCredentials.Name = "pnlCredentials";
            this.pnlCredentials.Size = new System.Drawing.Size(236, 239);
            this.pnlCredentials.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPassword.Location = new System.Drawing.Point(94, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPassword.Location = new System.Drawing.Point(26, 102);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtUserName.Location = new System.Drawing.Point(94, 31);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 5;
            // 
            // btnSignin
            // 
            this.btnSignin.BackColor = System.Drawing.SystemColors.Control;
            this.btnSignin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSignin.Location = new System.Drawing.Point(69, 160);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(75, 23);
            this.btnSignin.TabIndex = 7;
            this.btnSignin.Text = "Sign In";
            this.btnSignin.UseVisualStyleBackColor = false;
            this.btnSignin.Click += new System.EventHandler(this.btnSignin_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUserName.Location = new System.Drawing.Point(3, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(89, 20);
            this.lblUserName.TabIndex = 8;
            this.lblUserName.Text = "Gmail User Name";
            // 
            // pnlContact
            // 
            this.pnlContact.Controls.Add(this.lblStatus);
            this.pnlContact.Controls.Add(this.lblUser);
            this.pnlContact.Controls.Add(this.rosterTree1);
            this.pnlContact.Controls.Add(this.lblPresence);
            this.pnlContact.Controls.Add(this.tbStatus);
            this.pnlContact.Controls.Add(this.btnSignOut);
            this.pnlContact.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlContact.Location = new System.Drawing.Point(14, 15);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(258, 411);
            this.pnlContact.TabIndex = 10;
            this.pnlContact.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUser.Location = new System.Drawing.Point(10, 8);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(33, 13);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "User";
            // 
            // rosterTree1
            // 
            this.rosterTree1.AllowDrop = true;
            this.rosterTree1.BackColor = System.Drawing.SystemColors.Control;
            this.rosterTree1.Client = this.jabberClient1;
            this.rosterTree1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.rosterTree1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rosterTree1.ImageIndex = 1;
            this.rosterTree1.Location = new System.Drawing.Point(0, 44);
            this.rosterTree1.Name = "rosterTree1";
            this.rosterTree1.PresenceManager = null;
            this.rosterTree1.RosterManager = null;
            this.rosterTree1.SelectedImageIndex = 0;
            this.rosterTree1.ShowLines = false;
            this.rosterTree1.ShowRootLines = false;
            this.rosterTree1.Size = new System.Drawing.Size(255, 328);
            this.rosterTree1.Sorted = true;
            this.rosterTree1.StatusColor = System.Drawing.Color.Teal;
            this.rosterTree1.TabIndex = 5;
            // 
            // lblPresence
            // 
            this.lblPresence.AutoSize = true;
            this.lblPresence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPresence.Location = new System.Drawing.Point(163, 8);
            this.lblPresence.Name = "lblPresence";
            this.lblPresence.Size = new System.Drawing.Size(37, 13);
            this.lblPresence.TabIndex = 4;
            this.lblPresence.Text = "Offline";
            // 
            // tbStatus
            // 
            this.tbStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbStatus.Location = new System.Drawing.Point(10, 24);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(236, 20);
            this.tbStatus.TabIndex = 3;
            this.tbStatus.Visible = false;
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.SystemColors.Control;
            this.btnSignOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSignOut.Location = new System.Drawing.Point(80, 378);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(75, 23);
            this.btnSignOut.TabIndex = 0;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 440);
            this.Controls.Add(this.pnlCredentials);
            this.Controls.Add(this.pnlContact);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.pnlCredentials.ResumeLayout(false);
            this.pnlCredentials.PerformLayout();
            this.pnlContact.ResumeLayout(false);
            this.pnlContact.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private jabber.client.JabberClient jabberClient1;
        private System.Windows.Forms.Panel pnlCredentials;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUser;
        private muzzle.RosterTree rosterTree1;
        private System.Windows.Forms.Label lblPresence;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button btnSignOut;
    }
}