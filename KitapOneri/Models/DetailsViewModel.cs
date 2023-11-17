using KitapOneri.Data.Entities;

namespace KitapOneri.Models
{
    public class DetailsViewModel
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? AuthorName { get; set; }
        public string? Description { get; set; }
        public string? BookImage { get; set; }
        public string? CategoryId { get; set; }
    }
}
