

namespace Prototype
{
    public class EventParticipant
    {
        public int EventParticipantId { get; set; }
        public int EventId { get; set; }
        public int ArtistId { get; set; }

        public Event Event { get; set; }
        public Artist Artist { get; set; }
    }
}