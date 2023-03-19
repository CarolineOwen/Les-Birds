using System.ComponentModel.DataAnnotations.Schema;

namespace Les_Birds.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public int BirdId { get; set; }

        public virtual Bird? Bird { get; set; }
    }
}
