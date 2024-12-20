using Prototype.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class EditProfilePlatformForm : EditBaseForm
    {
        private DatabaseHelper dbHelper;
        private byte[] _image;
        private int _platformId;
        ImageConverter imageConverter;
        public EditProfilePlatformForm(BaseForm motherForm, int platformId = -1) : base(motherForm) 
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            imageConverter = new ImageConverter();
            if (platformId == -1) { _platformId = CurrentUser.TypeID; }
            else { _platformId = platformId; }
            _image = (byte[])imageConverter.ConvertTo(Properties.Resources.NoImage, typeof(byte[]));
            LoadPlatformData();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var updatedPlatform = new Platform
            {
                PlatformID = _platformId,
                Name = nameTextBox.Text,
                Address = addressTextBox.Text,
                Description = descriptionRichTextBox.Text,
                Image = _image
            };

            dbHelper.UpdatePlatform(updatedPlatform);
            backToMother();
        }

        private void LoadPlatformData()
        {     
            var platformData = dbHelper.GetPlatformById(_platformId);

            nameTextBox.Text = platformData.Name;
            addressTextBox.Text = platformData.Address;
            descriptionRichTextBox.Text = platformData.Description;
            if (platformData.Image != null)
            {
                _image = platformData.Image;
            }
            imagePictureBox.Image = (Image)imageConverter.ConvertFrom(_image);
        }

        private void removeAvatarButton_Click(object sender, EventArgs e)
        {
            imagePictureBox.Image = null;
            _image = (byte[])imageConverter.ConvertTo(Properties.Resources.NoImage, typeof(byte[]));
        }

        private void addAvatarButton_Click(object sender, EventArgs e)
        {
            // Создаем диалоговое окно для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Image"
            };

            // Проверяем, выбрал ли пользователь файл
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Загружаем выбранное изображение в PictureBox
                try
                {
                    imagePictureBox.Image = Image.FromFile(openFileDialog.FileName);
                    errorLabel.Text = "";
                }
                catch (OutOfMemoryException)
                {
                    errorLabel.Text = "Слишком большой файл";
                }

                _image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
    }
}
