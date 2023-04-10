using System.ComponentModel.DataAnnotations;

namespace SMALS.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Status { get; set; }
    }
}
