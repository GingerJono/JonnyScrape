namespace JonnyGetVids
{
    partial class Form1
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
            this.tbOutputBox = new System.Windows.Forms.TextBox();
            this.tbSingleURL = new System.Windows.Forms.TextBox();
            this.radioImportSingleURL = new System.Windows.Forms.RadioButton();
            this.radioImportURLsFromFile = new System.Windows.Forms.RadioButton();
            this.btnInput = new System.Windows.Forms.Button();
            this.tbURLsFromFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboMethods = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.tbOutputFile = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbErrorBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioOutputToFile = new System.Windows.Forms.RadioButton();
            this.radioOutputToBox = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbOutputBox
            // 
            this.tbOutputBox.Location = new System.Drawing.Point(168, 242);
            this.tbOutputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOutputBox.Multiline = true;
            this.tbOutputBox.Name = "tbOutputBox";
            this.tbOutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutputBox.Size = new System.Drawing.Size(908, 279);
            this.tbOutputBox.TabIndex = 1;
            // 
            // tbSingleURL
            // 
            this.tbSingleURL.Location = new System.Drawing.Point(168, 45);
            this.tbSingleURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSingleURL.Name = "tbSingleURL";
            this.tbSingleURL.Size = new System.Drawing.Size(908, 26);
            this.tbSingleURL.TabIndex = 3;
            this.tbSingleURL.Text = "http://www.oxforddictionaries.com/definition/english/a";
            // 
            // radioImportSingleURL
            // 
            this.radioImportSingleURL.AutoSize = true;
            this.radioImportSingleURL.Checked = true;
            this.radioImportSingleURL.Location = new System.Drawing.Point(4, 9);
            this.radioImportSingleURL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioImportSingleURL.Name = "radioImportSingleURL";
            this.radioImportSingleURL.Size = new System.Drawing.Size(115, 24);
            this.radioImportSingleURL.TabIndex = 5;
            this.radioImportSingleURL.TabStop = true;
            this.radioImportSingleURL.Text = "Single URL";
            this.radioImportSingleURL.UseVisualStyleBackColor = true;
            this.radioImportSingleURL.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioImportURLsFromFile
            // 
            this.radioImportURLsFromFile.AutoSize = true;
            this.radioImportURLsFromFile.Location = new System.Drawing.Point(4, 42);
            this.radioImportURLsFromFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioImportURLsFromFile.Name = "radioImportURLsFromFile";
            this.radioImportURLsFromFile.Size = new System.Drawing.Size(140, 24);
            this.radioImportURLsFromFile.TabIndex = 8;
            this.radioImportURLsFromFile.Text = "URLs from File";
            this.radioImportURLsFromFile.UseVisualStyleBackColor = true;
            this.radioImportURLsFromFile.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(966, 82);
            this.btnInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(112, 35);
            this.btnInput.TabIndex = 7;
            this.btnInput.Text = "Select File";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // tbURLsFromFile
            // 
            this.tbURLsFromFile.Enabled = false;
            this.tbURLsFromFile.Location = new System.Drawing.Point(168, 85);
            this.tbURLsFromFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbURLsFromFile.Name = "tbURLsFromFile";
            this.tbURLsFromFile.Size = new System.Drawing.Size(787, 26);
            this.tbURLsFromFile.TabIndex = 6;
            this.tbURLsFromFile.Text = "C:\\Users\\Jono\\Desktop\\PlayerPageURLs.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select Input Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Select a Process";
            // 
            // comboMethods
            // 
            this.comboMethods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMethods.FormattingEnabled = true;
            this.comboMethods.Items.AddRange(new object[] {
            "Get Scorecard Details",
            "Get All LV Season Scorecard URLs",
            "Get RottenTomatoes Info",
            "Get RottenTomatoes Score",
            "Get Video Titles from Amazon",
            "Get Length of Pages",
            "Get PGN from ChessGames.com collection",
            "Get PGN from ChessGames.com",
            "Get Player Page URLs From Futhead",
            "Get Player Attributes From Futhead",
            "Get Words From ODO",
            "Test ODO Search",
            "Test Music Directory Subfolders"});
            this.comboMethods.Location = new System.Drawing.Point(168, 131);
            this.comboMethods.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboMethods.Name = "comboMethods";
            this.comboMethods.Size = new System.Drawing.Size(908, 28);
            this.comboMethods.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Select Output Type";
            // 
            // btnOutput
            // 
            this.btnOutput.Enabled = false;
            this.btnOutput.Location = new System.Drawing.Point(970, 197);
            this.btnOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(112, 35);
            this.btnOutput.TabIndex = 13;
            this.btnOutput.Text = "Select File";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // tbOutputFile
            // 
            this.tbOutputFile.Enabled = false;
            this.tbOutputFile.Location = new System.Drawing.Point(168, 200);
            this.tbOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbOutputFile.Name = "tbOutputFile";
            this.tbOutputFile.Size = new System.Drawing.Size(792, 26);
            this.tbOutputFile.TabIndex = 12;
            this.tbOutputFile.Text = "C:\\Users\\Jono\\Desktop\\PlayerAttributes.txt";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(18, 532);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(1060, 62);
            this.btnSubmit.TabIndex = 17;
            this.btnSubmit.Text = "DO IT";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbErrorBox
            // 
            this.tbErrorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbErrorBox.Location = new System.Drawing.Point(18, 603);
            this.tbErrorBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbErrorBox.Multiline = true;
            this.tbErrorBox.Name = "tbErrorBox";
            this.tbErrorBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbErrorBox.Size = new System.Drawing.Size(1058, 98);
            this.tbErrorBox.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioImportSingleURL);
            this.panel1.Controls.Add(this.radioImportURLsFromFile);
            this.panel1.Location = new System.Drawing.Point(18, 45);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 72);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioOutputToFile);
            this.panel2.Controls.Add(this.radioOutputToBox);
            this.panel2.Location = new System.Drawing.Point(18, 200);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 72);
            this.panel2.TabIndex = 20;
            // 
            // radioOutputToFile
            // 
            this.radioOutputToFile.AutoSize = true;
            this.radioOutputToFile.Location = new System.Drawing.Point(4, 6);
            this.radioOutputToFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioOutputToFile.Name = "radioOutputToFile";
            this.radioOutputToFile.Size = new System.Drawing.Size(130, 24);
            this.radioOutputToFile.TabIndex = 5;
            this.radioOutputToFile.Text = "Output to File";
            this.radioOutputToFile.UseVisualStyleBackColor = true;
            this.radioOutputToFile.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioOutputToBox
            // 
            this.radioOutputToBox.AutoSize = true;
            this.radioOutputToBox.Checked = true;
            this.radioOutputToBox.Location = new System.Drawing.Point(4, 42);
            this.radioOutputToBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioOutputToBox.Name = "radioOutputToBox";
            this.radioOutputToBox.Size = new System.Drawing.Size(132, 24);
            this.radioOutputToBox.TabIndex = 8;
            this.radioOutputToBox.TabStop = true;
            this.radioOutputToBox.Text = "Output to Box";
            this.radioOutputToBox.UseVisualStyleBackColor = true;
            this.radioOutputToBox.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 722);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbErrorBox);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.tbOutputFile);
            this.Controls.Add(this.comboMethods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.tbURLsFromFile);
            this.Controls.Add(this.tbSingleURL);
            this.Controls.Add(this.tbOutputBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "JonnyScrape";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOutputBox;
        private System.Windows.Forms.TextBox tbSingleURL;
        private System.Windows.Forms.RadioButton radioImportSingleURL;
        private System.Windows.Forms.RadioButton radioImportURLsFromFile;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.TextBox tbURLsFromFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboMethods;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox tbOutputFile;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbErrorBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioOutputToFile;
        private System.Windows.Forms.RadioButton radioOutputToBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label4;
    }
}

