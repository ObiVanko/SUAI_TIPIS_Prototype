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
    public partial class EditProfileArtistForm : EditBaseForm
    {
        private DatabaseHelper dbHelper;
        private byte[] _image;
        private int _artistId;
        ImageConverter imageConverter;
        public EditProfileArtistForm(BaseForm motherForm, int artistId = -1) : base(motherForm)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            imageConverter = new ImageConverter();
            if (artistId == -1) { _artistId = CurrentUser.TypeID; }
            else { _artistId = artistId; }
            _image = (byte[])imageConverter.ConvertTo(Properties.Resources.NoImage, typeof(byte[]));

            var genres = dbHelper.GetGenres();

            foreach (var genre in genres)
            {
                genreCheckedListBox.Items.Add(genre);
            }

            LoadArtistData();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            List<string> selectedGenres = new List<string>();

            foreach (var item in genreCheckedListBox.CheckedItems)
            {
                selectedGenres.Add(item.ToString());
            }

            var updatedArtist = new Artist
            {
                ArtistID = _artistId,
                FullName = nameTextBox.Text,
                BirthDate = birthdayDateTimePicker.Value,
                Hometown = cityTextBox.Text,     
                Description = descriptionRichTextBox.Text,
                Image = _image
            };

            dbHelper.UpdateArtist(updatedArtist);

            List<int> selectedGenreIds = new List<int>();

            foreach (var item in selectedGenres)
            {
                int genreId = dbHelper.GetGenreIdByName(item.ToString()); 
                selectedGenreIds.Add(genreId);
            }

            UpdateArtistGenres(_artistId, selectedGenreIds);

            backToMother();
        }

        private void LoadArtistData()
        {
            Artist artistData = dbHelper.GetArtistById(_artistId);

            nameTextBox.Text = artistData.FullName;
            cityTextBox.Text = artistData.Hometown;
            descriptionRichTextBox.Text = artistData.Description;
            if (artistData.Image != null)
            {
                _image = artistData.Image;
            }
            imagePictureBox.Image = (Image)imageConverter.ConvertFrom(_image);

            birthdayDateTimePicker.Value = artistData.BirthDate;

            List<string> existingGenreNames = dbHelper.GetGenresByArtistId(_artistId).Names;
            for (int i = 0; i < genreCheckedListBox.Items.Count; i++)
            {
                string item = genreCheckedListBox.Items[i].ToString();
                if (existingGenreNames.Contains(item))
                {
                    genreCheckedListBox.SetItemChecked(i, true);
                }
            }

        }

        private void UpdateArtistGenres(int artistId, List<int> selectedGenreIds)
        {
            // Получаем текущие жанры из базы данных
            List<int> currentGenreIds = dbHelper.GetGenresByArtistId(artistId).IDs;

            // Определяем жанры для добавления
            List<int> genresToAdd = selectedGenreIds.Except(currentGenreIds).ToList();

            // Определяем жанры для удаления
            List<int> genresToRemove = currentGenreIds.Except(selectedGenreIds).ToList();

            // Удаляем ненужные жанры
            foreach (int genreId in genresToRemove)
            {
                dbHelper.RemoveArtistGenre(artistId, genreId);
            }

            // Добавляем новые жанры
            foreach (int genreId in genresToAdd)
            {
                dbHelper.AddArtistGenre(artistId, genreId);
            }
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


                // Преобразуем изображение в массив байтов
                _image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void removeAvatarButton_Click(object sender, EventArgs e)
        {
            imagePictureBox.Image = null;
            _image = (byte[])imageConverter.ConvertTo(Properties.Resources.NoImage, typeof(byte[]));
        }


    }
}
