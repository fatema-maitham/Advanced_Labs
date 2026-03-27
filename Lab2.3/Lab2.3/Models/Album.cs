using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [Range(0.01, 999.99)]
        public decimal Price { get; set; }

        [Range(1, 100)]
        public int TrackCount { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Foreign keys 
        public int ArtistId { get; set; }
        public int GenreId { get; set; }

        public ICollection<PlaylistAlbum> PlaylistAlbums { get; set; } = new List<PlaylistAlbum>();

        // Navigation properties 
        public Artist Artist { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
    }
}
