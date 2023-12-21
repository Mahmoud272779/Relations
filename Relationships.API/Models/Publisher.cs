namespace Relationships.API.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }




        //one to one between author and publisher
        public Author Author { get; set; }

        public int AuthorId { get; set; }




        //many to many between book and publisher
        public ICollection<BookPublisher> BookPublishers { get; set; }
    }
}
