using System.ComponentModel.DataAnnotations;

namespace KitapOneri.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Book>? Books{ get; set;} 
    }
}
