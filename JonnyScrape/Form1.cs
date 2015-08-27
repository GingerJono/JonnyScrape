using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Reflection;

namespace JonnyGetVids
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboMethods.SelectedIndex = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioImportSingleURL.Checked && !radioImportURLsFromFile.Checked)
            {
                tbErrorBox.Text = "ERROR! Choose an Input Type!";
                return;
            }

            /*
            if (!radioImportSingleURL.Checked && !radioImportURLsFromFile.Checked)
            {
                tbErrorBox.Text = "ERROR! Choose an Method!";
                return;
            }
            */

            if (!radioOutputToFile.Checked && !radioOutputToBox.Checked)
            {
                tbErrorBox.Text = "ERROR! Choose an Output Type!";
                return;
            }

            Scrapes s = new Scrapes();
            List<string> InputURLs = new List<string>();
            List<string> OutputLines = new List<string>();

            /// URL Box?
            if (radioImportSingleURL.Checked)
            {
                // Check if a well-formed URL
                try
                {
                    InputURLs.Add(tbSingleURL.Text);
                }
                catch (Exception ex) { tbErrorBox.Text = "ERROR! " + ex.ToString(); }
            }

            /// URLs File
            if (radioImportURLsFromFile.Checked)
            {
                // Check if the file exists
                try
                {
                    using (FileStream fs = File.Open(tbURLsFromFile.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (BufferedStream bs = new BufferedStream(fs))
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Check if these are URLs
                            InputURLs.Add(line);
                        }
                    }
                }
                catch (Exception ex) { tbErrorBox.Text = "ERROR! " + ex.ToString(); }
            }
            
            if (comboMethods.SelectedItem.ToString() == "Get Length of Pages")
            {
                OutputLines = s.GetLengthOfHTMLPages(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get PGN from ChessGames.com collection")
            {
                OutputLines = s.GetPGNFromCGComCollection(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get PGN from ChessGames.com")
            {
                OutputLines = s.GetGamePGNFromCGCom(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get Video Titles from Amazon")
            {
                OutputLines = s.GetVideoTitlesFromAmazon(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get RottenTomatoes Score")
            {
                OutputLines = s.GetTomatoScore(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get RottenTomatoes Info")
            {
                OutputLines = s.GetTomatoInfo(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get All LV Season Scorecard URLs")
            {
                OutputLines = s.GetLVSeasonScorecardURLs(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get Scorecard Details")
            {
                OutputLines = s.GetScorecardDetails(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get Player Page URLs From Futhead")
            {
                OutputLines = s.GetPlayerPageURLsFromFuthead(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get Player Attributes From Futhead")
            {
                OutputLines = s.GetPlayerAttributesFromFuthead(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Get Words From ODO")
            {
                OutputLines = s.GetWordsFromODO(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Test ODO Search")
            {
                OutputLines = s.TestODOSearch(InputURLs);
            }
            if (comboMethods.SelectedItem.ToString() == "Test Music Directory Subfolders")
            {
                OutputLines = s.TestMusicDirectorySubfolders(InputURLs);
            }

            /// Output Box?
            if (radioOutputToBox.Checked)
            {
                foreach (string line in OutputLines)
                {
                    tbOutputBox.Text = tbOutputBox.Text + Environment.NewLine + line;
                }
            }

            /// Output File
            if (radioOutputToFile.Checked)
            {
                try
                {
                    using (FileStream fs = File.Open(tbOutputFile.Text, FileMode.Append, FileAccess.Write, FileShare.Write))
                    using (BufferedStream bs = new BufferedStream(fs))
                    using (StreamWriter sr = new StreamWriter(bs))
                    {
                        foreach (string line in OutputLines)
                        {
                            sr.WriteLine(line);
                        }
                    }
                }
                catch (Exception ex) { tbErrorBox.Text = "ERROR! " + ex.ToString(); }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // input from URL
            if (radioImportSingleURL.Checked)
            {
                // Enable URL control
                tbSingleURL.Enabled = true;
                // Disable File Controls
                tbURLsFromFile.Enabled = false;
                btnInput.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // input from file
            if (radioImportURLsFromFile.Checked)
            {
                // Enable File controsl
                tbURLsFromFile.Enabled = true;
                btnInput.Enabled = true;
                // Disable File Control
                tbSingleURL.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            // output to file
            if (radioOutputToFile.Checked)
            {
                // Enable File Controls
                tbOutputFile.Enabled = true;
                btnOutput.Enabled = true;
                // Disable TB Control
                tbOutputBox.Enabled = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            // output to box
            if (radioOutputToBox.Checked)
            {
                // Enable TB Control
                tbOutputBox.Enabled = true;
                // Disable File Controls
                tbOutputFile.Enabled = false;
                btnOutput.Enabled = false;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tbURLsFromFile.Text = openFileDialog1.FileName.ToString();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            tbOutputFile.Text = openFileDialog2.FileName.ToString();
        }
    }
}
