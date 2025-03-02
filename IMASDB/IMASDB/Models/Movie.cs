using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IMASDB.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        [Required]
        [Range(60,240)]
        [DisplayName("Duration(In Minutes)")]
        public int Duration { get; set; }


    }
}
