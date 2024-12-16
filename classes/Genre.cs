using System.Collections.Generic;
namespace Prototype
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}