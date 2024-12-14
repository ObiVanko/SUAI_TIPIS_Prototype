using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prototype
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeForms()
        {
            FeedForm feedForm = new FeedForm();
            ProfileArtistForm profileArtistForm = new ProfileArtistForm();
            ProfilePlatformForm profilePlatformForm = new ProfilePlatformForm();

            profileArtistForm.SwitchToFeed += (left, top) =>
            {
                feedForm.Left = left;
                feedForm.Top = top;
                feedForm.Show();
            };

            profilePlatformForm.SwitchToFeed += (left, top) =>
            {
                feedForm.Left = left;
                feedForm.Top = top;
                feedForm.Show();
            };

            feedForm.SwitchToArtistProfile += (left, top) =>
            {
                profileArtistForm.Left = left;
                profileArtistForm.Top = top;
                profileArtistForm.Show();
            };

            feedForm.SwitchToPlatformProfile += (left, top) =>
            {
                profilePlatformForm.Left = left;
                profilePlatformForm.Top = top;
                profilePlatformForm.Show();
            };

            feedForm.Left = Left;
            feedForm.Top = Top;
            feedForm.Show();
        }


        // Установка начального подставного текста
        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetPlaceholder(loginTextBox, "Логин");
            SetPlaceholder(passwordTextBox, "Пароль");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            InitializeForms();
            Hide();
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
