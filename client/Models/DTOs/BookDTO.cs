namespace PersonalLibrary.Models.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public List<int> GenreIds { get; set; }  // Updated to be a list of GenreIds
        public string GenreName { get; set; }  // Optional, but can still be used for displaying genre names if needed
        public int UserProfileId { get; set; }

        public List<AuthorDTO> Authors { get; set; }

        public string Description { get; set; }
        public string Condition { get; set; }

        public string ImageUrl { get; set; }
    }
}
