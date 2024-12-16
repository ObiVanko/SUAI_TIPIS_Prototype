
namespace Prototype
{
    public class ArtistGenre
    {

        public int ArtistGenreId { get; set; }
        public int ArtistId { get; set; }
        public string Genre { get; set; }

        public Artist Artist { get; set; }
    }
}