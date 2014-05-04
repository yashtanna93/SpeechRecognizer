using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FinalApp
{
    public partial class Stocks : Form
    {
        // Stock symbols seperated by space or comma.
        protected string q_symbol = "AAIT";
        public string[,] companydata = new string[2797, 2];
        public Stocks()
        {
            InitializeComponent();
            q_symbol = txtSymbol.Text;
            string filePath = "company.txt";
            int i = 0;
            StreamReader sr = new StreamReader(filePath);
            while (sr.EndOfStream == false)
            {
                string m = sr.ReadLine();
                var symbol = m.Split(';');
                companydata[i, 0] = symbol[0];
                companydata[i, 1] = symbol[1];
                i += 1;
            }
            pictureBox1.Load("http://ichart.finance.yahoo.com/b?s=" + q_symbol);
            GetQuote(q_symbol.Trim());
        }


        public void GetQuote(string symbol)
        {
            // Set the return string to null.
            try
            {
                // Use Yahoo finance service to download stock data from Yahoo
                string yahooURL = @"http://download.finance.yahoo.com/d/quotes.csv?s=" + symbol + "&f=sd1t1l1cpom2wva2baj3dr2e7";
                string[] symbols = symbol.Replace(",", " ").Split(' ');

                // Initialize a new WebRequest.
                HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(yahooURL);
                // Get the response from the Internet resource.
                HttpWebResponse webresp = (HttpWebResponse)webreq.GetResponse();
                // Read the body of the response from the server.
                StreamReader strm = new StreamReader(webresp.GetResponseStream(), Encoding.ASCII);

                string content = "";
                for (int i = 0; i < symbols.Length; i++)
                {
                    // Loop through each line from the stream, building the return XML Document string
                    if (symbols[i].Trim() == "")
                        continue;

                    content = strm.ReadLine().Replace("\"", "");
                    string[] contents = content.ToString().Split(',');
                    labelSymbol.Text = contents[0];
                    labelLastTradeTime.Text = contents[1];
                    labelLastTradeTime.Text = contents[2];
                    labelPrice.Text = contents[3];
                    labelChangePercentChange.Text = contents[4];
                    labelPreviousClose.Text = contents[5];
                    labelOpen.Text = contents[6];
                    labelDaysRange.Text = contents[7];
                    labelweek52Range.Text = contents[8];
                    labelVolume.Text = contents[9];
                    labelAverageDailyVolume.Text = contents[10];
                    labelBid.Text = contents[11];
                    labelAsk.Text = contents[12];
                    labelMarketCap.Text = contents[13];
                    labelDividendShare.Text = contents[14];
                    labelPERatio.Text = contents[15];
                    labelEPSEstimateCurrentYear.Text = contents[16];
                }
                // Close the StreamReader object.
                strm.Close();
            }
            catch
            {
                // Handle exceptions.
            }
            // Return the stock quote data in XML format.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://ichart.finance.yahoo.com/b?s=" + q_symbol);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://ichart.finance.yahoo.com/w?s=" + q_symbol);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://chart.finance.yahoo.com/c/3m/" + q_symbol);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://chart.finance.yahoo.com/c/6m/" + q_symbol);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://chart.finance.yahoo.com/c/1y/" + q_symbol);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://chart.finance.yahoo.com/c/2y/" + q_symbol);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://chart.finance.yahoo.com/c/5y/" + q_symbol);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("http://chart.finance.yahoo.com/c/my/" + q_symbol);
        }

        private void txtSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            q_symbol = txtSymbol.Text;
            for (int i = 0; i < 2797; i++)
            {
                if (companydata[i, 0].Equals(q_symbol))
                {
                    label1.Text = companydata[i, 1];
                }
            }
            // Update the textbox value.
            q_symbol = txtSymbol.Text;
            // This DIV that contains text and DIVs that displays stock quotes and chart from Yahoo.
            // Set the innerHTML property to replaces the existing content of the DIV.

            if (q_symbol.Trim() != "")
            {
                try
                {
                    // Return the stock quote data in XML format.
                    GetQuote(q_symbol.Trim());
                    // Display stock charts.
                    pictureBox1.Load("http://ichart.finance.yahoo.com/b?s=" + q_symbol);
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void labelSymbol_Click(object sender, EventArgs e)
        {

        }

        private void labelLastTradeTime_Click(object sender, EventArgs e)
        {

        }

        private void labelPrice_Click(object sender, EventArgs e)
        {

        }

        private void labelChangePercentChange_Click(object sender, EventArgs e)
        {

        }

        private void labelPreviousClose_Click(object sender, EventArgs e)
        {

        }

        private void labelOpen_Click(object sender, EventArgs e)
        {

        }

        private void labelDaysRange_Click(object sender, EventArgs e)
        {

        }

        private void labelweek52Range_Click(object sender, EventArgs e)
        {

        }

        private void labelVolume_Click(object sender, EventArgs e)
        {

        }

        private void labelAverageDailyVolume_Click(object sender, EventArgs e)
        {

        }

        private void labelBid_Click(object sender, EventArgs e)
        {

        }

        private void labelAsk_Click(object sender, EventArgs e)
        {

        }

        private void labelMarketCap_Click(object sender, EventArgs e)
        {

        }

        private void labelDividendShare_Click(object sender, EventArgs e)
        {

        }

        private void labelPERatio_Click(object sender, EventArgs e)
        {

        }

        private void labelEPSEstimateCurrentYear_Click(object sender, EventArgs e)
        {

        }
    }
}
