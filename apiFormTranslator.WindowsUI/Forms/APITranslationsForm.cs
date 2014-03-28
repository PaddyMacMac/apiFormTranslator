using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using apiFormTranslator.Presenter;
using apiFormTranslator.View;

namespace apiFormTranslator.WindowsUI.Forms
{
    public partial class APITranslationsForm : Form, IAPITranslationsForm
    {
        private const int PROGRESS_BAR_SPEED = 30;
        private const string CHINESE = "Chinese";

        private APITranslationsFormPresenter _presenter;

        #region IMainForm Implementation
        public string UserId { get; set; }
        public string CurrentContext { get; set; }
        public string OutputDir { get; set; }
        public string ExamCode { get; set; }
        public string FormCode { get; set; }
        public string Language { get; set; }
        #endregion

        public APITranslationsForm(string userId)
        {
            _presenter = new APITranslationsFormPresenter(this);
            InitializeComponent();
            MaximizeBox = false;
            UserId = userId;
            LoadForm();
            this.languageComboBox.SelectedIndex = this.languageComboBox.FindStringExact(CHINESE);
        }

        private void LoadForm()
        {
            var contexts = _presenter.LoadUserContexts().Values.OrderBy(x => x).ToList();
            foreach (var context in contexts)
            {
                contextComboBox.Items.Add(context);
            }

            if (contextComboBox.Items.Count > 0)
                contextComboBox.SelectedIndex = 0;
        }

        private const string C_DRIVE = @"C:\";

        private void TranslateBtnClick(object sender, EventArgs e)
        {
            if (!outputDirTxtBox.Text.Equals(C_DRIVE))
            {
                DisableControls();

                if (!worker.IsBusy)
                {
                    progressBar.MarqueeAnimationSpeed = PROGRESS_BAR_SPEED;
                    progressBar1.MarqueeAnimationSpeed = PROGRESS_BAR_SPEED;
                    worker.RunWorkerAsync(new[] { outputDirTxtBox.Text, formComboBox.Text, languageComboBox.Text });
                }
                outputDirTxtBox.Text = C_DRIVE;
            }
            else
            {
                MessageBox.Show("Please Select an Output Location to place the Word File", "API Translations");
            }
        }

        private const int OUTPUT_DIR_INDEX = 0;
        private const int FORM_CODE_INDEX = 1;
        private const int LANGUAGE_INDEX = 2;
        private const int IMPORT_SELECTED = 3;
        private const int EXPORT_SELECTED = 1;

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var args = e.Argument as object[];
                var message = string.Empty;
                if (args.Length == IMPORT_SELECTED)
                {
                    OutputDir = args[OUTPUT_DIR_INDEX].ToString();
                    FormCode = args[FORM_CODE_INDEX].ToString();
                    Language = args[LANGUAGE_INDEX].ToString();
                    message = _presenter.PerformExports();

                }
                else if (args.Length == EXPORT_SELECTED)
                {
                    OutputDir = args[OUTPUT_DIR_INDEX].ToString();
                    message = _presenter.PerformImports();
                }
                MessageBox.Show(message, "API Translations");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "API Translations");
            }
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableControls();
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Refresh();
        }

        private void OutPutDirectoryBtnClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderBrowserDialog.Description = "Please select output folder to place created Word Document...";
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                outputDirTxtBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void ContextComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            DisableControls();
            examComboBox.Items.Clear();
            if (!string.IsNullOrEmpty(contextComboBox.Text))
            {
                CurrentContext = contextComboBox.Text;
                _presenter.SetCurrentContext();

                var exams = _presenter.LoadContextExams().Values.OrderBy(x => x).ToList(); ;

                foreach (var exam in exams)
                {
                    examComboBox.Items.Add(exam);
                }

                if (examComboBox.Items.Count > 0)
                    examComboBox.SelectedIndex = 0;
            }

            EnableControls();
        }

        private void ExamComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            DisableControls();
            ExamCode = examComboBox.Text;

            formComboBox.Items.Clear();
            if (!string.IsNullOrEmpty(contextComboBox.Text))
            {
                CurrentContext = contextComboBox.Text;
                _presenter.SetCurrentContext();

                var forms = _presenter.LoadExamsForms().Values.OrderBy(x => x).ToList(); ;

                foreach (var form in forms)
                {
                    formComboBox.Items.Add(form);
                }

                if (formComboBox.Items.Count > 0)
                    formComboBox.SelectedIndex = 0;
            }

            EnableControls();
        }

        private void DisableControls()
        {
            progressBar.Visible = true;
            progressBar1.Visible = true;
            translateButton.Enabled = false;
            outputDirButton.Enabled = false;
            outputDirTxtBox.Enabled = false;
            examComboBox.Enabled = false;
            formComboBox.Enabled = false;
            contextComboBox.Enabled = false;
            languageComboBox.Enabled = false;
            importDocButton.Enabled = false;
            fileButton.Enabled = false;
            fileTextBox.Enabled = false;
        }

        private void EnableControls()
        {
            translateButton.Enabled = true;
            outputDirButton.Enabled = true;
            progressBar.Visible = false;
            progressBar1.Visible = false;
            examComboBox.Enabled = true;
            formComboBox.Enabled = true;
            contextComboBox.Enabled = true;
            languageComboBox.Enabled = true;
            importDocButton.Enabled = true;
            fileButton.Enabled = true;
            fileTextBox.Enabled = true;
            
        }

        private const string WORD_DOC_NEW = ".docx";
        private const string WORD_DOC_OLD = ".doc";

        private void fileButton_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(fileDialog.FileName);
                if (!extension.Equals(WORD_DOC_NEW) || !extension.Equals(WORD_DOC_NEW))
                {
                    importDocButton.Visible = false;
                    MessageBox.Show("Please upload an Word Doc file...", "API Translations");
                    fileDialog.Filter = null;
                    return;
                }

                fileTextBox.Text = fileDialog.FileName;
            }
        }

        private void importDocButton_Click(object sender, EventArgs e)
        {
            if (!fileTextBox.Text.Equals(C_DRIVE))
            {
                DisableControls();
                if (!worker.IsBusy)
                {
                    progressBar1.MarqueeAnimationSpeed = PROGRESS_BAR_SPEED;
                    progressBar.MarqueeAnimationSpeed = PROGRESS_BAR_SPEED;
                    worker.RunWorkerAsync(new[] { fileTextBox.Text });
                }
            }
            else
            {
                MessageBox.Show("Please Select a Word Doc containing Items to Import!", "Input Error....");
            }
            fileTextBox.Text = C_DRIVE;
        }
    }
}
