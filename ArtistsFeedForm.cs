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
    public partial class ArtistsFeedForm : EditBaseForm
    {
        int _eventId;
        DatabaseHelper dbHelper;
        ImageConverter converter;
        public ArtistsFeedForm(BaseForm motherForm, int eventId) : base(motherForm)
        {
            InitializeComponent();
            _eventId = eventId;
            dbHelper = new DatabaseHelper();
            converter = new ImageConverter();

            InitializeListView();
        }

        private void InitializeListView()
        {
            List<Artist> artists = dbHelper.GetArtists();

            artistsListView.SmallImageList = new ImageList(); // Инициализация
            artistsListView.SmallImageList.ImageSize = new Size(40, 40); // Размер изображений
            artistsListView.View = View.Details;
            artistsListView.Columns.Add("Фото", 40);
            artistsListView.Columns.Add("Имя", 150);

            // Заполняем ListView
            foreach (var artist in artists)
            {
                int age = DateTime.Now.Year - artist.BirthDate.Year;
                if (artist.BirthDate > DateTime.Now.AddYears(-age)) age--;

                // Создаем элемент ListView
                ListViewItem item = new ListViewItem();
                item.Text = ""; // Фото будет в ImageList
                item.SubItems.Add(artist.FullName);
                item.Tag = artist.ArtistID; // Сохраняем ID артиста для использования

                Image artistImage;
                // Добавляем изображение
                if (artist.Image != null && artist.Image.Length > 0)
                {
                    artistImage = (Image)converter.ConvertFrom(artist.Image);
                }
                else
                {
                    artistImage = Properties.Resources.NoImage;
                }
                artistsListView.SmallImageList.Images.Add(artistImage);
                item.ImageIndex = artistsListView.SmallImageList.Images.Count - 1;

                artistsListView.Items.Add(item);
            }

            // Подписка на события
            artistsListView.DoubleClick += ArtistsListView_DoubleClick;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }

        private void inviteButton_Click(object sender, EventArgs e)
        {
            List<int> selectedArtistIds = new List<int>();

            foreach (ListViewItem item in artistsListView.SelectedItems)
            {
                if (item.Tag is int artistId)
                {
                    selectedArtistIds.Add(artistId);
                }
            }

            if (selectedArtistIds.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы одного артиста.");
                return;
            }

            SendInvitations(selectedArtistIds);
        }
        private void ArtistsListView_DoubleClick(object sender, EventArgs e)
        {
            if (artistsListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = artistsListView.SelectedItems[0];
                int artistId = (int)selectedItem.Tag;

                Console.WriteLine("Открываем профиль");
                // Открываем профиль артиста
                OpenArtistProfile(artistId);
            }
        }

        private void OpenArtistProfile(int artistId)
        {

            ArtistProfileForPlatforms profileForm = new ArtistProfileForPlatforms(this, artistId, _eventId);
            profileForm.Left = Left;
            profileForm.Top = Top;
            profileForm.Show();
            Hide();
        }

        private void SendInvitations(List<int> artistIds)
        {
            foreach (int artistId in artistIds)
            {
                dbHelper.AddNotification(new Notification
                {
                    UserID = dbHelper.GetUserByArtistId(artistId).Id,
                    Message = "Вас приглашают",
                    EventID = _eventId
                });
            }

            MessageBox.Show("Приглашения отправлены!");
        }
    }
}
