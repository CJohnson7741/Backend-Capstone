namespace PersonalLibrary.Models.DTOs;

    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int UserProfileId { get; set; }
        // public string Username { get; set; }
        public List<AuthorDTO> Authors { get; set; }

        public string Description { get; set; }
        public string Condition { get; set; }
    }