namespace Relationships.API.Models
{
    public class BookPublisher
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
    }
}
