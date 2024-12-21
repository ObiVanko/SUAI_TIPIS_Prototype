using Prototype.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Prototype
{
    public partial class LoginForm : BaseForm
    {
        DatabaseHelper dbHelper = new DatabaseHelper();
        public LoginForm()
        {
            InitializeComponent();
            dbHelper.TestConnection();
        }

        // Установка начального подставного текста
        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetPlaceholder(loginTextBox, "Логин");
            SetPlaceholder(passwordTextBox, "Пароль");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text) || loginTextBox.Text == "Логин" || passwordTextBox.Text == "Пароль")
            { 
                errorLabel.Text = "Пожалуйста, заполните все поля.";
                return;
            }

            var result = dbHelper.ValidateUser(loginTextBox.Text, passwordTextBox.Text);

            if (result.userID != -1)
            {
                if (result.userType == "Artist")
                {
                    var userInfo = dbHelper.GetUserById(result.userID);
                    CurrentUser.UserID = userInfo.Id;
                    CurrentUser.TypeID = userInfo.Artist.ArtistID;
                    new ArtistForm() {Left = Left, Top = Top }.Show();
                }
                else if (result.userType == "Platform")
                {
                    var userInfo = dbHelper.GetUserById(result.userID);
                    CurrentUser.UserID = userInfo.Id;
                    CurrentUser.TypeID = userInfo.Platform.PlatformID;
                    new PlatformForm() {Left = Left, Top = Top }.Show();
                }
                Hide();
            }
            else 
            {
                errorLabel.Text = "Некорректный логин или пароль.";
            }

        }

        private void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholderText, bool password = false)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;
                if (password)
                {
                    textBox.PasswordChar = '\0';
                }
            }
        }

        // Метод для удаления подставного текста при фокусе
        private void RemovePlaceholder(System.Windows.Forms.TextBox textBox, string placeholderText, bool password = false)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
                if (password)
                {
                    textBox.PasswordChar = '*';
                }
            }
        }

        // Обработчики событий
        private void loginTextBox_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(loginTextBox, "Логин");
        }

        private void loginTextBox_Leave(object sender, EventArgs e)
        {
            SetPlaceholder(loginTextBox, "Логин");
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(passwordTextBox, "Пароль", true);
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            SetPlaceholder(passwordTextBox, "Пароль", true);
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {

            RegistrationForm registrationForm = new RegistrationForm(this);
            registrationForm.Left = Left;
            registrationForm.Top = Top;
            registrationForm.Show();
            Hide();
        }
    }
}
