using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieWebsite.Models
{
    public class Country
    {
        [Key]
        public long CountryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        // Navigation Properties
        // Một quốc gia có nhiều movie
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
