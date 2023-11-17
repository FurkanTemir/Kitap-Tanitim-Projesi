using System.ComponentModel.DataAnnotations;

namespace KitapOneri.Data.Entities
{
    public class Book
    {
        public int? BookId { get; set; }
        public string? BookName { get; set; }
        public string? BookDescription { get; set; }
        public string? AuthorName { get; set; }
        public string? BookImage { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
