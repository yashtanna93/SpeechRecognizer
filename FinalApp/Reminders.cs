using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace FinalApp
{
    public partial class Reminders : Form
    {
        public Form RefToForm1 { get; set; }
        String date, time, hour, minute, ampm, reminder = "";
        int temp = 0;
        List<String> timeReminders = new List<String>();
        List<String> messageReminders = new List<String>();
        int number = 0;
        Boolean found = false;
        public Reminders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hour = (numericUpDown1.Value).ToString("00");
            ampm = domainUpDown1.Text;
            minute = (numericUpDown2.Value).ToString("00");
            time = hour + ":" + minute + ":00 " + ampm;
            reminder = textBox1.Text;
            date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            //System.Windows.Forms.MessageBox.Show(date + " " + time);
            timeReminders.Add(date + " " + time);
            messageReminders.Add(reminder);
            listBox1.Items.Add(timeReminders.ElementAt(number) + "  -   " + messageReminders.ElementAt(number));
            number += 1;
        }

        private void clock_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = "Date:" + DateTime.Now.ToString("dd/MM/yyyy") + "      Time:" + DateTime.Now.ToString("hh:mm:ss tt");
            for (int i = 0; i < number; i++)
            {
                if (timeReminders.ElementAt(i).Equals(DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm:ss tt")))
                {
                    temp = i;
                    found = true;
                    System.Threading.Thread.Sleep(1000);
                    break;
                }
            }
            if (found)
            {
                found = false;
                String msg = messageReminders.ElementAt(temp);
                String time = timeReminders.ElementAt(temp);
                listBox1.Items.Remove(msg + "  -   " + time);
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.Speak("Reminder alert");
                speechSynthesizer.Speak(msg);
                System.Windows.Forms.MessageBox.Show(msg);
                messageReminders.Remove(msg);
                timeReminders.Remove(time);
                number--;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
    }
}
