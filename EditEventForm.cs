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
using System.Xml.Linq;

namespace Prototype
{
    public partial class EditEventForm : EditBaseForm
    {
        private DatabaseHelper dbHelper;
        private byte[] _image;
        private int _eventId;
        ImageConverter imageConverter;

        public EditEventForm(BaseForm motherForm, int eventId = 0) : base(motherForm) 
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            imageConverter = new ImageConverter();
            _eventId = eventId;
            _image = (byte[])imageConverter.ConvertTo(Properties.Resources.NoImage, typeof(byte[]));

            var genres = dbHelper.GetGenres();

            foreach (var genre in genres)
            {
                genreCheckedListBox.Items.Add(genre);
            }
        }

        private void EditEventForm_Load(object sender, EventArgs e)
        {
            if (_eventId > 0)
            {
                LoadEventDetails(_eventId);
            }
        }

        private void LoadEventDetails(int eventId)
        {
            Event existingEvent = dbHelper.GetEventById(eventId);
            List<string> existingGenreNames = dbHelper.GetGenresByEventId(eventId).Names;

            if (existingEvent != null)
            {
                nameTextBox.Text = existingEvent.Name;
                descriptionRichTextBox.Text = existingEvent.Description;
                dateTimePicker.Value = existingEvent.EventDate;
                seatsNumericUpDown.Text = existingEvent.TotalSeats.ToString();
                _image = existingEvent.Image;
                imagePictureBox.Image = (Image)imageConverter.ConvertFrom(_image);

                for (int i = 0; i < genreCheckedListBox.Items.Count; i++)
                {
                    string item = genreCheckedListBox.Items[i].ToString();
                    if (existingGenreNames.Contains(item))
                    {
                        genreCheckedListBox.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
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
                catch (OutOfMemoryException) {
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

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string description = descriptionRichTextBox.Text;
            DateTime eventDate = dateTimePicker.Value;
            int totalSeats = int.Parse(seatsNumericUpDown.Text);
            List<string> selectedGenres = new List<string>();

            foreach (var item in genreCheckedListBox.CheckedItems)
            {
                selectedGenres.Add(item.ToString());
            }

            if (_eventId > 0)
            {     
                dbHelper.UpdateEvent(_eventId, name, description, eventDate, totalSeats, _image);

                List<int> selectedGenreIds = new List<int>();

                foreach (var item in selectedGenres)
                {
                    int genreId = dbHelper.GetGenreIdByName(item.ToString()); // Предполагается метод получения GenreID по имени
                    selectedGenreIds.Add(genreId);
                }
                UpdateEventGenres(_eventId, selectedGenreIds);
            }
            else
            {
                int eventId = dbHelper.AddEvent(name, description, eventDate, totalSeats, _image);

                foreach (string genre in selectedGenres)
                {
                    int genreId = dbHelper.GetGenreIdByName(genre); // Получите ID жанра по названию
                    dbHelper.AddEventGenre(eventId, genreId);      // Добавьте связь EventID и GenreID
                }

            }

            backToMother();
        }

        private void UpdateEventGenres(int eventId, List<int> selectedGenreIds)
        {
            // Получаем текущие жанры из базы данных
            List<int> currentGenreIds = dbHelper.GetGenresByEventId(eventId).IDs;

            // Определяем жанры для добавления
            List<int> genresToAdd = selectedGenreIds.Except(currentGenreIds).ToList();

            // Определяем жанры для удаления
            List<int> genresToRemove = currentGenreIds.Except(selectedGenreIds).ToList();

            // Удаляем ненужные жанры
            foreach (int genreId in genresToRemove)
            {
                dbHelper.RemoveEventGenre(eventId, genreId);
            }

            // Добавляем новые жанры
            foreach (int genreId in genresToAdd)
            {
                dbHelper.AddEventGenre(eventId, genreId);
            }
        }

        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            dbHelper.DeleteEventById(_eventId);
            if (motherForm is EditBaseForm editBaseForm)
            {
                editBaseForm.backToMother();
                closingByBackButton = true;
                Close();
            }
            else
            {
                backToMother();
            }
        }
    }
}
