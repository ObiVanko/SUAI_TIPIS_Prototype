namespace Prototype
{
    public class EventGenre
    {
        public int EventId { get; set; }  // Связь с мероприятием
        public Event Event { get; set; }

        public int GenreId { get; set; }  // Связь с жанром
        public Genre Genre { get; set; }
    }
}