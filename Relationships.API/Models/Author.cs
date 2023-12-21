namespace Relationships.API.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }



        //one to one between author and publisher
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }



        //one to many between book and author
        public ICollection<Book> Books { get; set; }
    }
}
