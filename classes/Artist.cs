using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Artist
    {
        public int ArtistID { get; set; }

        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Hometown { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
      
    }
}
