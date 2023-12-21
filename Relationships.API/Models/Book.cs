namespace Relationships.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }



        //one to many between book and author
        public Author Author { get; set; }

        public int AuthorId { get; set; }




        //many to many between book and publisher
        public ICollection<BookPublisher> BookPublishers { get; set; }
    }
}
