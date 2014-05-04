namespace FinalApp
{
    partial class Mail
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
            this.send = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.smtp = new System.Windows.Forms.TextBox();
            this.subject = new System.Windows.Forms.TextBox();
            this.to = new System.Windows.Forms.TextBox();
            this.from = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.SystemColors.Control;
            this.send.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.send.Location = new System.Drawing.Point(442, 196);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(95, 27);
            this.send.TabIndex = 27;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // password
            // 
            this.password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.password.Location = new System.Drawing.Point(468, 149);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(161, 20);
            this.password.TabIndex = 26;
            // 
            // username
            // 
            this.username.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.username.Location = new System.Drawing.Point(468, 122);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(161, 20);
            this.username.TabIndex = 25;
            // 
            // smtp
            // 
            this.smtp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.smtp.Location = new System.Drawing.Point(468, 95);
            this.smtp.Name = "smtp";
            this.smtp.Size = new System.Drawing.Size(161, 20);
            this.smtp.TabIndex = 24;
            // 
            // subject
            // 
            this.subject.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.subject.Location = new System.Drawing.Point(468, 68);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(161, 20);
            this.subject.TabIndex = 23;
            // 
            // to
            // 
            this.to.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.to.Location = new System.Drawing.Point(468, 41);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(161, 20);
            this.to.TabIndex = 22;
            // 
            // from
            // 
            this.from.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.from.Location = new System.Drawing.Point(468, 14);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(161, 20);
            this.from.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(379, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(379, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(379, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "SMTP server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(379, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Subject";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(379, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(379, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "From";
            // 
            // body
            // 
            this.body.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.body.Location = new System.Drawing.Point(17, 16);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(356, 227);
            this.body.TabIndex = 14;
            this.body.Text = "";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 256);
            this.Controls.Add(this.send);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.smtp);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.to);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.body);
            this.Name = "Form6";
            this.Text = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox smtp;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.TextBox from;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox body;
    }
}