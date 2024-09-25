using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieWebsite.Models
{
    public class AddMovieViewModel
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Duration { get; set; } // Thời lượng tính bằng phút

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Director { get; set; }

        [StringLength(500)]
        public string Cast { get; set; }

        [StringLength(500)]
        public string PosterURL { get; set; }

        [StringLength(500)]
        public string VideoURL { get; set; }

        [Required]
        public long CountryID { get; set; } // Chọn Quốc Gia

        [Required]
        public List<long> SelectedGenreIDs { get; set; } = new List<long>(); // Chọn Thể Loại

        [Required]
        public List<long> SelectedCategoryIDs { get; set; } = new List<long>(); // Chọn Danh Mục
    }
}
