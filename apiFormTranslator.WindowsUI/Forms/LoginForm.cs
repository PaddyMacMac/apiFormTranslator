using System;
using System.ComponentModel;
using System.Windows.Forms;
using apiFormTranslator.Presenter;
using apiFormTranslator.Presenter.POCO;
using apiFormTranslator.View;

namespace apiFormTranslator.WindowsUI.Forms
{
    public partial class LoginForm : Form, ILoginForm
    {
        private User _currentUser;

        public LoginForm()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        #region ILoginForm Implementation
        public string UserName
        {
            get
            {
                return userNameTxtbox.Text;
            }
            set
            {
                userNameTxtbox.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return passwordTxtBox.Text;
            }
            set
            {
                passwordTxtBox.Text = value;
            }
        }
        #endregion

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (errorLbl.Visible)
                errorLbl.Visible = false;

            if (!string.IsNullOrEmpty(userNameTxtbox.Text) && !string.IsNullOrEmpty(passwordTxtBox.Text))
            {
                DisableControls();
                progressBar.MarqueeAnimationSpeed = 30;
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                errorLbl.Text = "Username and Password cannot be empty";
                errorLbl.Visible = true;
                EnableControls();
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _currentUser = new LoginPresenter(this).GetAuthenticatedUser();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_currentUser != null && _currentUser.Authenticated)
            {
                var mainForm = new APITranslationsForm(_currentUser.UserId);
                Hide();
                mainForm.ShowDialog();
            }
            else
            {
                errorLbl.Text = "Invalid Credentials";
                errorLbl.Visible = true;
                EnableControls();
                progressBar.MarqueeAnimationSpeed = 0;
                progressBar.Refresh();
            }
        }

        private void DisableControls()
        {
            progressBar.Visible = true;
            userNameTxtbox.Enabled = false;
            passwordTxtBox.Enabled = false;
            loginBtn.Enabled = false;
        }

        private void EnableControls()
        {
            userNameTxtbox.Enabled = true;
            passwordTxtBox.Enabled = true;
            loginBtn.Enabled = true;
            progressBar.Visible = false;
        }
    }
}
