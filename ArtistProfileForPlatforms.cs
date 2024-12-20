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
    public partial class ArtistProfileForPlatforms : EditBaseForm
    {
        private int _eventId;
        private int _artistId;
        private DatabaseHelper dbHelper;
        private ImageConverter converter;
        public ArtistProfileForPlatforms(BaseForm motherForm, int artistId, int eventId = -1) : base(motherForm)
        {
            InitializeComponent();
            _eventId = eventId;
            _artistId = artistId;
            dbHelper = new DatabaseHelper();
            converter = new ImageConverter();
            LoadArtistInfo();

            inviteButton.Enabled = eventId != -1;

        }

        private void LoadArtistInfo()
        {
            Artist artist = dbHelper.GetArtistById(_artistId);

            // Заполнение элементов формы
            nameLabel.Text = artist.FullName;
            cityLabel.Text = artist.Hometown;
            var nowDate = DateTime.Now;
            int age = nowDate.Year - artist.BirthDate.Year;
            if (nowDate < artist.BirthDate.AddYears(age))
            {
                age--;
            }
            ageLabel.Text = "Возраст: " + age.ToString();
            descriptionLabel.Text = artist.Description;

            // Установка аватара, если он есть, или замена на изображение по умолчанию
            if (artist.Image != null && artist.Image.Length > 0)
            {
                avatarPictureBox.Image = (Image)converter.ConvertFrom(artist.Image);
            }
            else
            {
                avatarPictureBox.Image = Properties.Resources.NoImage;
            }

            List<string> existingGenreNames = dbHelper.GetGenresByArtistId(CurrentUser.TypeID).Names;
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

        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }

        private void inviteButton_Click(object sender, EventArgs e)
        {
            dbHelper.AddNotification(new Notification
            {
                UserID = dbHelper.GetUserByArtistId(_artistId).Id,
                Message = "Вас приглашают",
                EventID = _eventId
            });

            MessageBox.Show("Приглашение отправлено!");
        }
    }
}
