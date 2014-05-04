using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using jabber.client;
using System.Threading;
using jabber.protocol.iq;
using jabber;
using Google.GData.Contacts;
using Google.GData.Extensions;
using jabber.protocol;

namespace FinalApp
{
    public partial class Chat : Form
    {

        static ManualResetEvent done = new ManualResetEvent(false);
        string User, Pwd;
        const string TARGET = "";
        FrmChat[] frmChat = new FrmChat[500];
        RosterManager rm;
        PresenceManager pm;
        int chatCount = -1;
        Hashtable chatIndex = new Hashtable();
        public Chat()
        {
            InitializeComponent();
            jabberClient1.OnMessage += new MessageHandler(jabberClient1_OnMessage);
            jabberClient1.OnDisconnect += new bedrock.ObjectHandler(jabberClient1_OnDisconnect);
            jabberClient1.OnError += new bedrock.ExceptionHandler(jabberClient1_OnError);
            jabberClient1.OnAuthError += new jabber.protocol.ProtocolHandler(jabberClient1_OnAuthError);
        }

        void jabberClient1_OnAuthError(object sender, System.Xml.XmlElement rp)
        {
            if (rp.Name == "failure")
            {
                MessageBox.Show("Invalid User Name or Password", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlCredentials.Enabled = true;
                txtUserName.SelectAll();
                txtUserName.Focus();
            }
        }

        void jabberClient1_OnError(object sender, Exception ex)
        {
            MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            pnlCredentials.Enabled = true;
            txtUserName.SelectAll();
            txtUserName.Focus();
        }

        void jabberClient1_OnDisconnect(object sender)
        {
            pnlContact.Visible = false;
            pnlCredentials.Enabled = true;
            pnlCredentials.Visible = true;
            txtUserName.Focus();
        }

        private void jabberClient1_OnMessage(object sender, jabber.protocol.client.Message msg)
        {

            frmChat[(int)chatIndex[msg.From.Bare]].ReceiveFlag = true;
            string receivedMsg = msg.From.User + " Says : " + msg.Body + "\n";
            frmChat[(int)chatIndex[msg.From.Bare]].AppendConversation(receivedMsg);
            frmChat[(int)chatIndex[msg.From.Bare]].Show();
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            User = txtUserName.Text;
            Pwd = txtPassword.Text;
            pnlCredentials.Enabled = false;
            jabberClient1.User = User;
            jabberClient1.Server = "gmail.com";
            jabberClient1.Password = Pwd;
            jabberClient1.AutoRoster = true;

            rm = new RosterManager();
            rm.Stream = jabberClient1;
            rm.AutoSubscribe = true;
            rm.AutoAllow = jabber.client.AutoSubscriptionHanding.AllowAll;
            rm.OnRosterBegin += new bedrock.ObjectHandler(rm_OnRosterBegin);
            rm.OnRosterEnd += new bedrock.ObjectHandler(rm_OnRosterEnd);
            rm.OnRosterItem += new RosterItemHandler(rm_OnRosterItem);


            pm = new PresenceManager();
            pm.Stream = jabberClient1;

            rosterTree1.RosterManager = rm;
            rosterTree1.PresenceManager = pm;
            rosterTree1.DoubleClick += new EventHandler(rosterTree1_DoubleClick);

            jabberClient1.Connect();
            jabberClient1.OnAuthenticate += new bedrock.ObjectHandler(jabberClient1_OnAuthenticate);
            lblUser.Text = jabberClient1.User;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtUserName.SelectAll();
        }

        void rm_OnRosterItem(object sender, Item ri)
        {
            try
            {
                chatIndex.Add(ri.JID.Bare, ++chatCount);
                InitializeFrmChat(ri.JID.Bare, ri.Nickname);
            }
            catch { }
        }

        void rosterTree1_DoubleClick(object sender, EventArgs e)
        {
            muzzle.RosterTree.ItemNode selectedNode = rosterTree1.SelectedNode as muzzle.RosterTree.ItemNode;
            if (selectedNode != null)
                frmChat[(int)chatIndex[selectedNode.JID.Bare]].Show();
        }


        void rm_OnRosterBegin(object sender)
        {
            frmChat = new FrmChat[500];
            chatIndex = new Hashtable();
            rosterTree1.BeginUpdate();
        }

        void rm_OnRosterEnd(object sender)
        {
            RosterManager rm1 = (RosterManager)sender;
            done.Set();
            rosterTree1.EndUpdate();
            jabberClient1.Presence(jabber.protocol.client.PresenceType.available, tbStatus.Text, null, 0);
            lblPresence.Text = "Available";
            rosterTree1.ExpandAll();
        }

        void jabberClient1_OnAuthenticate(object sender)
        {
            pnlCredentials.Visible = false;
            pnlContact.Visible = true;
            done.Set();
            tbStatus.Text = "";
            txtPassword.Text = "";
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            jabberClient1.Close(true);
        }

        private void InitializeFrmChat(string targetId, string nickName)
        {
            frmChat[chatCount] = new FrmChat();
            frmChat[chatCount].MailId = targetId;
            frmChat[chatCount].JabberClint = jabberClient1;
            if (nickName != null)
                frmChat[chatCount].Text = nickName;
            else
                frmChat[chatCount].Text = (targetId.Split('@'))[0];
            frmChat[chatCount].JabberClint.OnMessage += new MessageHandler(frmChat[chatCount]._jabberClient_OnMessage);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignin.PerformClick();
                pnlCredentials.Enabled = false;
            }
        }

        private void lblStatus_DoubleClick(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            tbStatus.Visible = true;
            if (tbStatus.Text.Length > 0)
                tbStatus.Select(0, tbStatus.Text.Length);
        }

        private void tbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbStatus.Visible = false;
                lblStatus.Visible = true;
                lblStatus.Text = tbStatus.Text;
                jabberClient1.Presence(jabber.protocol.client.PresenceType.available, tbStatus.Text, null, 0);
            }
        }

        private void pnlContact_Click(object sender, EventArgs e)
        {
            ResetStatusMessage();
        }

        private void ResetStatusMessage()
        {
            tbStatus.Visible = false;
            lblStatus.Visible = true;
            tbStatus.Text = lblStatus.Text;
        }

        private void rosterTree1_Click(object sender, EventArgs e)
        {
            if (tbStatus.Visible)
            {
                ResetStatusMessage();
            }
        }

        private void rosterTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
