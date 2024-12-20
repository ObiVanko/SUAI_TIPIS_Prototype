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
    public partial class EventPlatformForm : EditBaseForm
    {
        private int _eventId;
        private DatabaseHelper dbHelper;
        private ImageConverter converter;
        private byte[] _image;

        public EventPlatformForm(BaseForm motherForm, int eventId = 0) : base(motherForm)
        {
            InitializeComponent();
            _eventId = eventId;
            dbHelper = new DatabaseHelper();
            converter = new ImageConverter();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditEventForm editEventForm = new EditEventForm(this, _eventId);
            editEventForm.Left = Left;
            editEventForm.Top = Top;
            editEventForm.Show();
            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }

        private void LoadEventDetails(int eventId)
        {
            Event existingEvent = dbHelper.GetEventById(eventId);
            List<string> existingGenreNames = dbHelper.GetGenresByEventId(eventId).Names;

            if (existingEvent != null)
            {
                nameLabel.Text = existingEvent.Name;
                descriptionLabel.Text = "Описание: " + existingEvent.Description;
                dateTimeLabel.Text = existingEvent.EventDate.ToString("yyyy-MM-dd HH:mm");
                Platform eventPlatform = dbHelper.GetPlatformById(existingEvent.PlatformID);
                platformLabel.Text = eventPlatform.Name;
                adressLabel.Text = eventPlatform.Address;

                int signedUpArtistsCount = dbHelper.GetSignedUpArtistsCountForEvent(eventId);
                int freeSeats = existingEvent.TotalSeats - signedUpArtistsCount;
                seatsLabel.Text = "Свободных мест: " + freeSeats.ToString();

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

        private void EventPlatformForm_Activated(object sender, EventArgs e)
        {
            if (_eventId > 0)
            {
                LoadEventDetails(_eventId);
            }
        }

        private void inviteButton_Click(object sender, EventArgs e)
        {
            ArtistsFeedForm artistsFeedForm = new ArtistsFeedForm(this, _eventId);
            artistsFeedForm.Left = Left;
            artistsFeedForm.Top = Top;
            artistsFeedForm.Show();
            Hide();
        }
    }
}
