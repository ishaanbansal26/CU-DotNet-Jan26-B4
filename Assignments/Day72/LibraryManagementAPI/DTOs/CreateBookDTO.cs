namespace LibraryManagementAPI.DTOs
{
    public class CreateBookDTO
    {
        public string BookName { get; set; } = null!;

        public decimal Price { get; set; }

        public int AuthorId { get; set; }
    }
}
