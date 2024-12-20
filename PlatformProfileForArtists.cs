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
using static System.Resources.ResXFileRef;

namespace Prototype
{
    public partial class PlatformProfileForArtists : EditBaseForm
    {
        int _platformId;
        DatabaseHelper dbHelper;
        ImageConverter converter;
        public PlatformProfileForArtists(BaseForm motherForm, int platformId) : base(motherForm) 
        {
            InitializeComponent();

            dbHelper = new DatabaseHelper();
            converter = new ImageConverter();
            _platformId = platformId;

            ProfileInit();
        }

        private void ProfileInit()
        {
            var platform = dbHelper.GetPlatformById(_platformId);

            // Заполнение элементов формы
            nameLabel.Text = platform.Name;
            addressLabel.Text = platform.Address;
            descriptionLabel.Text = platform.Description;

            // Установка аватара, если он есть, или замена на изображение по умолчанию
            if (platform.Image != null && platform.Image.Length > 0)
            {
                avatarPictureBox.Image = (Image)converter.ConvertFrom(platform.Image);
            }
            else
            {
                avatarPictureBox.Image = Properties.Resources.NoImage;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backToMother();
        }
    }
}
