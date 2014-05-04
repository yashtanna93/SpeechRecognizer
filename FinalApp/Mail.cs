using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web;
using System.Net.Mail;

namespace FinalApp
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            MailMessage mail = new MailMessage(from.Text, to.Text, subject.Text, body.Text);
            SmtpClient client = new SmtpClient(smtp.Text);
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(username.Text, password.Text);
            client.EnableSsl = true;
            client.Send(mail);
            MessageBox.Show("Mail sent!", "Success", MessageBoxButtons.OK);
        }
    }
}
