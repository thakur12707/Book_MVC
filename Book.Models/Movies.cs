using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Order Must Be B/W 1-100")]
        public int DisplayOrder { get; set; }
    }
}
