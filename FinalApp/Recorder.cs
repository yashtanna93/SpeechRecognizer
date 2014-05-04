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
using System.Threading;
using System.IO;
using System.Globalization;

namespace FinalApp
{
    public partial class Recorder : Form
    {
        public SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        public Grammar grammar;
        public Thread RecThread;
        public Recorder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();
            grammar = new Grammar(builder);
            recognizer = new SpeechRecognitionEngine();
            recognizer.LoadGrammar(grammar);
            recognizer.RequestRecognizerUpdate(); // request for recognizer update
            recognizer.SpeechRecognized += recognizer_SpeechRecognized; // if speech is recognized, call the specified method
            recognizer.SetInputToDefaultAudioDevice(); // set the input to the default audio device
            recognizer.RecognizeAsync(RecognizeMode.Multiple); // recognize speech asynchronous
            RecThread = new Thread(new ThreadStart(RecThreadFunction));
            RecThread.IsBackground = false;
            RecThread.Start();
        }
        public void recognizer_SpeechRecognized(Object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.AppendText(e.Result.Text + " ");
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex);

            }
        }
        public void RecThreadFunction()
        {
            try
            {
                recognizer.Recognize();
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folder = @"C:\Users\Yash\Desktop\";
            string fileName = "speechfile";
            string fileExtension = ".txt";
            string data = richTextBox1.Text;
            if (File.Exists(folder + fileName + fileExtension))
            {
                for (int i = 1; i < 1000; i++)
                {
                    if (!File.Exists(folder + fileName + i + fileExtension))
                    {
                        File.AppendAllText(folder + fileName + i + fileExtension, data);
                        break;
                    }
                }
            }
            else
            {
                File.AppendAllText(folder + fileName + fileExtension, data);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
