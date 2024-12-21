using Prototype.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype
{
    public partial class EventArtistForm : EditBaseForm
    {
        private int _eventId;
        private DatabaseHelper dbHelper;
        private ImageConverter converter;
        private int platformId;
        private byte[] _image;
        public EventArtistForm(BaseForm motherForm, int eventId = 0) : base(motherForm)
        {
            InitializeComponent();
            _eventId = eventId;
            dbHelper = new DatabaseHelper();
            converter = new ImageConverter();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }

        private void LoadEventDetails(int eventId)
        {
            Event existingEvent = dbHelper.GetEventById(eventId);
            platformId = existingEvent.PlatformID;
            List<string> existingGenreNames = dbHelper.GetGenresByEventId(eventId).Names;

            if (existingEvent != null)
            {
                nameLabel.Text = existingEvent.Name;
                descriptionLabel.Text = "Описание: " + existingEvent.Description;
                dateTimeLabel.Text = existingEvent.EventDate.ToString("yyyy-MM-dd HH:mm");

                Platform eventPlatform = dbHelper.GetPlatformById(existingEvent.PlatformID);
                platformLinkLabel.Text = eventPlatform.Name;
                adressLabel.Text = eventPlatform.Address;

                int signedUpArtistsCount = dbHelper.GetSignedUpArtistsCountForEvent(eventId);
                int freeSeats = existingEvent.TotalSeats - signedUpArtistsCount;
                seatsLabel.Text = "Свободных мест: " + freeSeats.ToString();

                signButton.Enabled = (freeSeats > 0);

                _image = existingEvent.Image;
                imagePictureBox.Image = (Image)converter.ConvertFrom(_image);

                if (existingGenreNames.Count > 0)
                {
                    string genresString = "Жанры: ";
                    for (int i = 0; i < existingGenreNames.Count - 1; i++)
                    {
                        genresString += existingGenreNames[i] + "; ";
                    }
                    genresString += existingGenreNames.Last() + ".";
                    genresLabel.Text = genresString;
                }
            }
        }

        private void platformLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PlatformProfileForArtists platformProfile = new PlatformProfileForArtists(this, platformId);
            platformProfile.Left = Left;
            platformProfile.Top = Top;
            platformProfile.Show();
            Hide();
        }

        private void EventArtistForm_Activated(object sender, EventArgs e)
        {
            if (_eventId > 0)
            {
                LoadEventDetails(_eventId);
                UpdateSignButtonState();
            }
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            // Показываем окно подтверждения
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите записаться на это мероприятие?",
                "Подтверждение записи",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Если пользователь нажал "Да"
            if (result == DialogResult.Yes)
            {

                dbHelper.SignUpArtistForEvent(CurrentUser.TypeID, _eventId);

                MessageBox.Show("Вы успешно записались на мероприятие!");

                LoadEventDetails(_eventId);
                UpdateSignButtonState();
            }
        }

        private void UpdateSignButtonState()
        {
            int artistId = CurrentUser.TypeID; // Здесь должен быть реальный ID артиста

            // Проверяем, записан ли артист на мероприятие
            bool isSignedUp = dbHelper.IsArtistSignedUpForEvent(artistId, _eventId);

            signButton.Click -= signButton_Click;
            signButton.Click -= cancelSignUpButton_Click;

            if (isSignedUp)
            {
                // Если артист записан, показываем кнопку "Отменить запись"
                signButton.Enabled = true;
                signButton.Text = "Отменить запись";
                signButton.Click += cancelSignUpButton_Click; // Добавляем новую логику
            }
            else
            {
                // Если артист не записан, показываем кнопку "Записаться"
                signButton.Text = "Записаться";
                signButton.Click += signButton_Click; // Добавляем старую логику
            }
        }

        private void cancelSignUpButton_Click(object sender, EventArgs e)
        {
            // Показываем окно подтверждения для отмены записи
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите отменить свою запись на это мероприятие?",
                "Подтверждение отмены",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Отменяем запись артиста
                dbHelper.CancelArtistSignUp(CurrentUser.TypeID, _eventId);         

                MessageBox.Show("Вы отменили свою запись на мероприятие.");
     
                LoadEventDetails(_eventId);
                UpdateSignButtonState();
            }
        }
    }
}
