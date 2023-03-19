using System.ComponentModel.DataAnnotations;

namespace Les_Birds.Models
{
    public class Bird
    {
        public int Id { get; set; }
        [Required]
        public string? Nom { get; set; }

        //Elle est nullable
        public string? Description { get; set; }

        public int? Nombre { get; set; }
        public virtual Image? Image { get; set; }
    }
}
