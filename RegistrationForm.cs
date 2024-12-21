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

namespace Prototype
{
    public partial class RegistrationForm : EditBaseForm
    {
        public RegistrationForm(BaseForm motherForm) : base(motherForm)
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password1 = passwordTextBox.Text;
            string password2 = passwordTextBox2.Text;
            string email = emailTextBox.Text.Trim();
            string user_type;
            if (artistCheckBox.Checked) {user_type = "Artist";}
            else {user_type = "Platform";}

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password1) || string.IsNullOrEmpty(password2) || string.IsNullOrEmpty(email) || (!artistCheckBox.Checked && !platformСheckBox.Checked))
            {
                errorLabel.Text = "Пожалуйста, заполните все поля.";
                return;
            }

            if (password1 != password2)
            {
                errorLabel.Text = "Пароли не совпадают!";
                return;
            }

            var dbHelper = new DatabaseHelper();

            (int user_id, string error_text) = dbHelper.RegisterUser(login, password1, user_type, email);

            if (user_id != -1)
            {
                if (user_type == "Artist")
                {
                    dbHelper.CreateArtist(user_id);
                }
                else if (user_type == "Platform")
                {
                    dbHelper.CreatePlatform(user_id);
                }

                MessageBox.Show("Регистрация прошла успешно!");
                
                backToMother();
            }
            else
            {
                errorLabel.Text = error_text;
            }
        }

        private void artistCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            platformСheckBox.Checked = !artistCheckBox.Checked;
        }

        private void platformСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            artistCheckBox.Checked = !platformСheckBox.Checked;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }
    }
}
