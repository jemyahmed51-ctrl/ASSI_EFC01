    using Microsoft.EntityFrameworkCore;

    // Requirement 6
    using var context = new BookStoreContext();

    context.Database.EnsureCreated();

Console.WriteLine($"Can connect: {context.Database.CanConnect()}");
Console.WriteLine($"Books: {context.Books.Count()}");
Console.WriteLine($"Authors: {context.Authors.Count()}");
Console.WriteLine($"Categories: {context.Categories.Count()}");

// Requirement 4
public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
        public int PublishedYear { get; set; }
        public bool InStock { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }

    // Requirement 4
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

    // Requirement 4
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

    // Requirement 5
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Requirement 3
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=ReadMoreBooks;Trusted_Connection=True;TrustServerCertificate=True");
        }

        // Requirement 2: no OnModelCreating, no Data Annotations
    }
