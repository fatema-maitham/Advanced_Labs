using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MusicStoreMvc1.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 50)]
        public int TrackCount { get; set; }

        public int GenreId { get; set; }

        [ValidateNever]
        public Genre Genre { get; set; } = null!;

        public int ArtistId { get; set; }

        [ValidateNever]
        public Artist Artist { get; set; } = null!;
    }
}
