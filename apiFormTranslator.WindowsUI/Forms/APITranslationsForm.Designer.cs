namespace apiFormTranslator.WindowsUI.Forms
{
    partial class APITranslationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APITranslationsForm));
            this.translateButton = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.outputDirTxtBox = new System.Windows.Forms.TextBox();
            this.outputDirLabel = new System.Windows.Forms.Label();
            this.outputDirButton = new System.Windows.Forms.Button();
            this.contextsLbl = new System.Windows.Forms.Label();
            this.contextComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.formComboBox = new System.Windows.Forms.ComboBox();
            this.formLabel = new System.Windows.Forms.Label();
            this.examComboBox = new System.Windows.Forms.ComboBox();
            this.examLabel = new System.Windows.Forms.Label();
            this.languageLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.exportTab = new System.Windows.Forms.TabControl();
            this.Export = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.importDocButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.exportTab.SuspendLayout();
            this.Export.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(247, 221);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(87, 23);
            this.translateButton.TabIndex = 0;
            this.translateButton.Text = "&Translate";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.TranslateBtnClick);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerDoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerRunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(330, 298);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(77, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            this.progressBar.Visible = false;
            // 
            // outputDirTxtBox
            // 
            this.outputDirTxtBox.Enabled = false;
            this.outputDirTxtBox.Location = new System.Drawing.Point(112, 184);
            this.outputDirTxtBox.Name = "outputDirTxtBox";
            this.outputDirTxtBox.Size = new System.Drawing.Size(171, 20);
            this.outputDirTxtBox.TabIndex = 25;
            this.outputDirTxtBox.Text = "C:\\";
            // 
            // outputDirLabel
            // 
            this.outputDirLabel.AutoSize = true;
            this.outputDirLabel.ForeColor = System.Drawing.Color.White;
            this.outputDirLabel.Location = new System.Drawing.Point(6, 184);
            this.outputDirLabel.Name = "outputDirLabel";
            this.outputDirLabel.Size = new System.Drawing.Size(55, 13);
            this.outputDirLabel.TabIndex = 26;
            this.outputDirLabel.Text = "Output Dir";
            // 
            // outputDirButton
            // 
            this.outputDirButton.Location = new System.Drawing.Point(306, 184);
            this.outputDirButton.Name = "outputDirButton";
            this.outputDirButton.Size = new System.Drawing.Size(25, 23);
            this.outputDirButton.TabIndex = 27;
            this.outputDirButton.Text = "...";
            this.outputDirButton.UseVisualStyleBackColor = true;
            this.outputDirButton.Click += new System.EventHandler(this.OutPutDirectoryBtnClick);
            // 
            // contextsLbl
            // 
            this.contextsLbl.AutoSize = true;
            this.contextsLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.contextsLbl.Location = new System.Drawing.Point(6, 12);
            this.contextsLbl.Name = "contextsLbl";
            this.contextsLbl.Size = new System.Drawing.Size(76, 13);
            this.contextsLbl.TabIndex = 28;
            this.contextsLbl.Text = "Select Context";
            // 
            // contextComboBox
            // 
            this.contextComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contextComboBox.FormattingEnabled = true;
            this.contextComboBox.Location = new System.Drawing.Point(112, 12);
            this.contextComboBox.Name = "contextComboBox";
            this.contextComboBox.Size = new System.Drawing.Size(171, 21);
            this.contextComboBox.TabIndex = 29;
            this.contextComboBox.SelectedIndexChanged += new System.EventHandler(this.ContextComboBoxSelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(133, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 58);
            this.panel1.TabIndex = 27;
            // 
            // formComboBox
            // 
            this.formComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formComboBox.FormattingEnabled = true;
            this.formComboBox.Location = new System.Drawing.Point(112, 83);
            this.formComboBox.Name = "formComboBox";
            this.formComboBox.Size = new System.Drawing.Size(171, 21);
            this.formComboBox.TabIndex = 32;
            // 
            // formLabel
            // 
            this.formLabel.AutoSize = true;
            this.formLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.formLabel.Location = new System.Drawing.Point(6, 91);
            this.formLabel.Name = "formLabel";
            this.formLabel.Size = new System.Drawing.Size(63, 13);
            this.formLabel.TabIndex = 31;
            this.formLabel.Text = "Select Form";
            // 
            // examComboBox
            // 
            this.examComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.examComboBox.FormattingEnabled = true;
            this.examComboBox.Location = new System.Drawing.Point(112, 49);
            this.examComboBox.Name = "examComboBox";
            this.examComboBox.Size = new System.Drawing.Size(171, 21);
            this.examComboBox.TabIndex = 34;
            this.examComboBox.SelectedIndexChanged += new System.EventHandler(this.ExamComboBoxSelectedIndexChanged);
            // 
            // examLabel
            // 
            this.examLabel.AutoSize = true;
            this.examLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.examLabel.Location = new System.Drawing.Point(6, 49);
            this.examLabel.Name = "examLabel";
            this.examLabel.Size = new System.Drawing.Size(66, 13);
            this.examLabel.TabIndex = 33;
            this.examLabel.Text = "Select Exam";
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.languageLabel.Location = new System.Drawing.Point(6, 126);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(88, 13);
            this.languageLabel.TabIndex = 35;
            this.languageLabel.Text = "Select Language";
            // 
            // languageComboBox
            // 
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "Chinese",
            "French",
            "Korean",
            "Spanish"});
            this.languageComboBox.Location = new System.Drawing.Point(112, 118);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(171, 21);
            this.languageComboBox.TabIndex = 36;
            // 
            // exportTab
            // 
            this.exportTab.Controls.Add(this.Export);
            this.exportTab.Controls.Add(this.tabPage2);
            this.exportTab.Location = new System.Drawing.Point(-1, -2);
            this.exportTab.Name = "exportTab";
            this.exportTab.SelectedIndex = 0;
            this.exportTab.Size = new System.Drawing.Size(415, 340);
            this.exportTab.TabIndex = 37;
            // 
            // Export
            // 
            this.Export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.Export.Controls.Add(this.contextsLbl);
            this.Export.Controls.Add(this.panel1);
            this.Export.Controls.Add(this.formComboBox);
            this.Export.Controls.Add(this.progressBar);
            this.Export.Controls.Add(this.languageComboBox);
            this.Export.Controls.Add(this.translateButton);
            this.Export.Controls.Add(this.languageLabel);
            this.Export.Controls.Add(this.outputDirTxtBox);
            this.Export.Controls.Add(this.examComboBox);
            this.Export.Controls.Add(this.outputDirLabel);
            this.Export.Controls.Add(this.examLabel);
            this.Export.Controls.Add(this.outputDirButton);
            this.Export.Controls.Add(this.contextComboBox);
            this.Export.Controls.Add(this.formLabel);
            this.Export.Location = new System.Drawing.Point(4, 22);
            this.Export.Name = "Export";
            this.Export.Padding = new System.Windows.Forms.Padding(3);
            this.Export.Size = new System.Drawing.Size(407, 314);
            this.Export.TabIndex = 0;
            this.Export.Text = "Export";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.tabPage2.Controls.Add(this.fileButton);
            this.tabPage2.Controls.Add(this.fileLabel);
            this.tabPage2.Controls.Add(this.fileTextBox);
            this.tabPage2.Controls.Add(this.importDocButton);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(407, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import";
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(295, 46);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(25, 23);
            this.fileButton.TabIndex = 33;
            this.fileButton.Text = "...";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.ForeColor = System.Drawing.Color.White;
            this.fileLabel.Location = new System.Drawing.Point(6, 51);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(56, 13);
            this.fileLabel.TabIndex = 32;
            this.fileLabel.Text = "Word Doc";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(101, 48);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(171, 20);
            this.fileTextBox.TabIndex = 31;
            this.fileTextBox.Text = "C:\\";
            // 
            // importDocButton
            // 
            this.importDocButton.Location = new System.Drawing.Point(233, 87);
            this.importDocButton.Name = "importDocButton";
            this.importDocButton.Size = new System.Drawing.Size(87, 23);
            this.importDocButton.TabIndex = 30;
            this.importDocButton.Text = "&Import Doc";
            this.importDocButton.UseVisualStyleBackColor = true;
            this.importDocButton.Click += new System.EventHandler(this.importDocButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Location = new System.Drawing.Point(134, 262);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 58);
            this.panel2.TabIndex = 29;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(329, 299);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(77, 16);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 28;
            this.progressBar1.Visible = false;
            // 
            // APITranslationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(410, 334);
            this.Controls.Add(this.exportTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "APITranslationsForm";
            this.Text = "API Translations";
            this.exportTab.ResumeLayout(false);
            this.Export.ResumeLayout(false);
            this.Export.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button translateButton;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox outputDirTxtBox;
        private System.Windows.Forms.Label outputDirLabel;
        private System.Windows.Forms.Button outputDirButton;
        private System.Windows.Forms.Label contextsLbl;
        private System.Windows.Forms.ComboBox contextComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox formComboBox;
        private System.Windows.Forms.Label formLabel;
        private System.Windows.Forms.ComboBox examComboBox;
        private System.Windows.Forms.Label examLabel;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.TabControl exportTab;
        private System.Windows.Forms.TabPage Export;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button importDocButton;
    }
}