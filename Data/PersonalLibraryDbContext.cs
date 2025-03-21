using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalLibrary.Models;

namespace PersonalLibrary.Data
{
    public class PersonalLibraryDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }  // Added for many-to-many relationship

        public PersonalLibraryDbContext(DbContextOptions<PersonalLibraryDbContext> context, IConfiguration config)
            : base(context)
        {
            _configuration = config;
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite primary key for BookGenre
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            // Optional: You can also configure relationships explicitly if needed
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            // ---------------------------- SEED DATA FOR IDENTITY USERS ----------------------------
            modelBuilder
                .Entity<IdentityUser>()
                .HasData(
                    new IdentityUser
                    {
                        Id = "1", // Admin User ID
                        UserName = "adminuser",
                        Email = "admin@library.com",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        ),
                    },
                    new IdentityUser
                    {
                        Id = "2", // Second User ID
                        UserName = "user2",
                        Email = "user2@library.com",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        ),
                    }
                );

            // ---------------------------- SEED DATA FOR UserProfiles ----------------------------
            modelBuilder
                .Entity<UserProfile>()
                .HasData(
                    new UserProfile
                    {
                        Id = 1,
                        IdentityUserId = "1", // Admin User
                        UserName = "adminuser",
                        Email = "admin@library.com"
                    },
                    new UserProfile
                    {
                        Id = 2,
                        IdentityUserId = "2", // Second User
                        UserName = "user2",
                        Email = "user2@library.com"
                    }
                );

            // ---------------------------- SEED DATA FOR GENRES ----------------------------
            modelBuilder
                .Entity<Genre>()
                .HasData(
                    new Genre { Id = 1, Name = "Science Fiction" },
                    new Genre { Id = 2, Name = "Fantasy" },
                    new Genre { Id = 3, Name = "Mystery" }
                );

            // ---------------------------- SEED DATA FOR AUTHORS ----------------------------
            modelBuilder
                .Entity<Author>()
                .HasData(
                    new Author { Id = 1, Name = "Isaac Asimov" },
                    new Author { Id = 2, Name = "J.K. Rowling" },
                    new Author { Id = 3, Name = "Agatha Christie" }
                );

            // ---------------------------- SEED DATA FOR BOOKS ----------------------------
            modelBuilder
                .Entity<Book>()
                .HasData(
                    new Book
                    {
                        Id = 1,
                        Title = "Foundation",
                        ISBN = "978-0-553-80371-0",
                        UserProfileId = 1,
                        Description = "A science fiction novel about the fall of the Galactic Empire.",
                        Condition = "New",
                        ImageUrl = "" // Blank ImageUrl for now
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Harry Potter and the Sorcerer's Stone",
                        ISBN = "978-0-590-35340-3",
                        UserProfileId = 1,
                        Description = "A young wizard's journey begins at Hogwarts School of Witchcraft and Wizardry.",
                        Condition = "Good",
                        ImageUrl = "" // Blank ImageUrl for now
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Murder on the Orient Express",
                        ISBN = "978-0-06-269366-2",
                        UserProfileId = 1,
                        Description = "A detective story featuring Hercule Poirot solving a murder mystery on a train.",
                        Condition = "Worn",
                        ImageUrl = "" // Blank ImageUrl for now
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "The Hobbit",
                        ISBN = "978-0-618-00221-3",
                        UserProfileId = 2,
                        Description = "A fantasy novel about a hobbit's adventures in Middle-earth.",
                        Condition = "Fair",
                        ImageUrl = "" // Blank ImageUrl for now
                    }
                );

            // ---------------------------- SEED DATA FOR BOOKGENRES (Many-to-many relationship) ----------------------------
            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre { BookId = 1, GenreId = 1 }, // "Foundation" book, "Science Fiction" genre
                new BookGenre { BookId = 1, GenreId = 3 }, // "Foundation" book, "Mystery" genre
                new BookGenre { BookId = 2, GenreId = 2 }, // "Harry Potter", "Fantasy" genre
                new BookGenre { BookId = 3, GenreId = 3 }, // "Murder on the Orient Express", "Mystery" genre
                new BookGenre { BookId = 4, GenreId = 2 }  // "The Hobbit", "Fantasy" genre
            );

            // ---------------------------- SEED DATA FOR BOOKAUTHORS ----------------------------
            modelBuilder
                .Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId }); // Define composite key for BookAuthor

            modelBuilder
                .Entity<BookAuthor>()
                .HasData(
                    new BookAuthor { BookId = 1, AuthorId = 1 },
                    new BookAuthor { BookId = 2, AuthorId = 2 },
                    new BookAuthor { BookId = 3, AuthorId = 3 },
                    new BookAuthor { BookId = 4, AuthorId = 2 } // Adding author for the new book by second user
                );
        }

    }
}
