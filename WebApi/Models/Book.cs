using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public bool Issued { get; set; }
    }
}
