using Microsoft.EntityFrameworkCore;

namespace Relationships.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired();

                entity.HasOne(e => e.Publisher).WithOne(e => e.Author)
                .HasForeignKey<Publisher>(e => e.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Title).IsRequired();
                entity.HasOne(e => e.Author).WithMany(e => e.Books)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired();

            });


            modelBuilder.Entity<BookPublisher>(entity =>
            {
                entity.HasKey(a => new { a.BookId, a.PublisherId });


                entity.HasOne(a => a.Publisher).WithMany(a => a.BookPublishers).
                HasForeignKey(a => a.PublisherId)
                 .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(a => a.Book).WithMany(a => a.BookPublishers).
                HasForeignKey(a => a.BookId)
                 .OnDelete(DeleteBehavior.NoAction);

            });
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
    }
}
