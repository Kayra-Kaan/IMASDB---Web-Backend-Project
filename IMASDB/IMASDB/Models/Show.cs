using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IMASDB.Models
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Show Name")]
        public String ShowName { get; set; }
        [Required]
        [Range(1,50)]
        [DisplayName("Season Count")]
        public int SeasonCount { get; set; }
        [Required]
        [Range(1,2000)]
        [DisplayName("Episode Count(Total)")]
        public int EpisodeCount { get; set; }
    }
}
