using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Diagnostics;
using iTextSharp.text.pdf;
using System.Xml;
using iTextSharp.text.pdf.parser;

namespace FinalApp
{
    public partial class MainForm : Form
    {
        String Temperature;
        String Condition;
        String Humidity;
        String WindSpeed;
        String Town;
        String TFcond;
        String TFlow;
        String TFhigh;
        public SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        public Grammar grammar;
        public Thread RecThread;
        public bool RecognizerState = false;
        public String s;
        bool app = false;
        bool flag = true;
        bool Write = false;
        string fileLoc = @"d:\";
        string location = "";
        Process called = null;
        bool textInsert = false;
        string name = Environment.UserName;
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();
            grammar = new Grammar(builder);
            recognizer = new SpeechRecognitionEngine();
            //recognizer.LoadGrammar(grammar);
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\MainFrame.txt");
            for (int i = 0; i < lines.Count(); i++)
            {
                recognizer.LoadGrammar(new Grammar(new GrammarBuilder(lines[i])));
            }
            speechSynthesizer.Speak("Hello " + name);
            //recognizer.LoadGrammar(new Grammar(new GrammarBuilder("yash")));
            RecognizerState = this.Visible;
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
                if (speakbt.Checked)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        s = e.Result.Text.ToLower();
                        wordstxt.Text = (e.Result.Text.ToLower());
                    });
                }                
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        public void RecThreadFunction()
        {
            while (RecognizerState)
            {
                try
                {
                    recognizer.Recognize();
                }
                catch
                {
                }
            }
        }

        private void stopbt_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak("Thank you for using the application");
            this.Close();
        }

        private void wordstxt_TextChanged(object sender, EventArgs e)
        {
            flag = this.Visible;
            if (s.Equals("startapplication", StringComparison.Ordinal))
            {
                app = true;
                //MessageBox.Show("application mode started");
            }
            if(app)
            {
                try
                {
                    Process firstProc = new Process();
                    firstProc.StartInfo.FileName = s;
                    firstProc.EnableRaisingEvents = true;
                    firstProc.Start();
                    app = false;
                }
                catch
                {
                }
            }
            if (s.Equals("openmaps", StringComparison.Ordinal) && flag)
            {
                speakbt.Checked = false;
                RecognizerState = false;
                Maps f2 = new Maps();
                f2.RefToForm1 = this;
                f2.CreateControl();
                f2.Show();
            }
            if (s.Equals("reminders", StringComparison.Ordinal) && flag)
            {
                speakbt.Checked = false;
                RecognizerState = false;
                Reminders f3 = new Reminders();
                f3.RefToForm1 = this;
                f3.CreateControl();
                f3.Show();
            }
            if (s.Equals("voice", StringComparison.Ordinal) && flag)
            {
                speakbt.Checked = false;
                RecognizerState = false;
                Recorder f4 = new Recorder();
                f4.CreateControl();
                f4.Show();
            }
            if (s.Equals("chat", StringComparison.Ordinal) && flag)
            {
                speakbt.Checked = false;
                RecognizerState = false;
                Chat f5 = new Chat();
                f5.CreateControl();
                f5.Show();
            }
            if (s.Equals("email", StringComparison.Ordinal) && flag)
            {
                speakbt.Checked = false;
                RecognizerState = false;
                Mail f6 = new Mail();
                f6.CreateControl();
                f6.Show();
            }
            if (s.Equals("stocks", StringComparison.Ordinal) && flag)
            {
                speakbt.Checked = false;
                RecognizerState = false;
                Stocks f7 = new Stocks();
                f7.CreateControl();
                f7.Show();
            }
            if (s.Equals("openpdfreader", StringComparison.Ordinal) && flag)
            {
                speakbt.Checked = false;
                RecognizerState = false;
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter =
                   "pdf files (*.pdf)|*.pdf";
                dialog.InitialDirectory = "C:\\";
                dialog.Title = "Select a text file";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fname = dialog.FileName;
                    ExtractTextFromPDFPage(fname, 1);
                }
                speakbt.Checked = true;
                RecognizerState = true;
            }
            if (s.Equals("close", StringComparison.Ordinal) && flag)
            {
                Application.Exit(); 
            }
            if (s.Equals("write", StringComparison.Ordinal))
            {
                if (Write == false)
                {
                    Write = true;
                    SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                    //speechSynthesizer.Speak("Say the text file name  what u want, when u want to end say insert to start inserting and stop to end");
                }
            }
            if (Write == true && s != "write")
            {
                String sampleText = s;
                FileStream fs = null;
                fs = File.Create(fileLoc + s + ".txt");
                location = fileLoc + s + ".txt";
                called = Process.Start("notepad.exe", s + ".txt");
                Write = false;
            }
            if (s.Equals("insert", StringComparison.Ordinal))
            {
                textInsert = true;
            }
            if (s.Equals("siri", StringComparison.Ordinal))
            {
                speechSynthesizer.Speak("Yes Sir");
            }

            if (textInsert == true)
            {
                try
                {
                    TextWriter tsw = new StreamWriter(location);
                    //Writing text to the file.
                    tsw.WriteLine(s);
                    called = Process.Start("notepad.exe", location);
                    //Close the file.
                    tsw.Close();
                }
                catch
                { }

            }
            if (s.Equals("stop", StringComparison.Ordinal))
            {
                textInsert = false;
            }
            if (s.Equals("weather", StringComparison.Ordinal))
            {
                GetWeather();
                speechSynthesizer.SpeakAsync("The weather in " + Town + " is " + Condition + " at " + Temperature + " degrees. There is a humidity of " + Humidity + " and a windspeed of " + WindSpeed + " miles per hour");
            }
            if (s.Equals("what's my name?", StringComparison.Ordinal))
            {
                speechSynthesizer.SpeakAsync(Environment.UserName);
            }
            if (s.Equals("time", StringComparison.Ordinal))
            {
                DateTime timenow = DateTime.Now;
                string time = timenow.GetDateTimeFormats('t')[0];
                speechSynthesizer.SpeakAsync(time);
            }
            if (s.Equals("day", StringComparison.Ordinal))
            {
                speechSynthesizer.SpeakAsync(DateTime.Today.ToString("dddd"));
            }
            if (s.Equals("date", StringComparison.Ordinal))
            {
                speechSynthesizer.SpeakAsync(DateTime.Today.ToString("dd-MM-yyyy"));
            }
            if (s.Equals("weather tomorrow", StringComparison.Ordinal))
            {
                GetWeather();
                speechSynthesizer.SpeakAsync("Tomorrows forecast is " + TFcond + " with a high of " + TFhigh + " and a low of " + TFlow);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); Environment.Exit(0);
        }

        private void speakbt_CheckedChanged(object sender, EventArgs e)
        {
            if (speakbt.Checked == false)
            {
                RecognizerState = false;
            }
        }
        public void ExtractTextFromPDFPage(string pdfFile, int pageNumber)
        {
            PdfReader reader = new PdfReader(pdfFile);
            string text = PdfTextExtractor.GetTextFromPage(reader, pageNumber);
            try { reader.Close(); }
            catch { }
            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(text);
        }
        public void GetWeather()
        {
            String query = String.Format("http://weather.yahooapis.com/forecastrss?w=90884377&u=f");
            XmlDocument wdata = new XmlDocument();
            wdata.Load(query);

            XmlNamespaceManager manager = new XmlNamespaceManager(wdata.NameTable);
            manager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");

            XmlNode channel = wdata.SelectSingleNode("rss").SelectSingleNode("channel");
            XmlNodeList nodes = wdata.SelectNodes("rss/channel/item/yweather:forecast", manager);

            Temperature = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["temp"].Value;
            Condition = channel.SelectSingleNode("item").SelectSingleNode("yweather:condition", manager).Attributes["text"].Value;
            Humidity = channel.SelectSingleNode("yweather:atmosphere", manager).Attributes["humidity"].Value;
            WindSpeed = channel.SelectSingleNode("yweather:wind", manager).Attributes["speed"].Value;
            Town = channel.SelectSingleNode("yweather:location", manager).Attributes["city"].Value;
            TFcond = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast",manager).Attributes["text"].Value;
            TFhigh = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["high"].Value;
            TFlow = channel.SelectSingleNode("item").SelectSingleNode("yweather:forecast", manager).Attributes["low"].Value;
        }
    }
}
