using System.ComponentModel.DataAnnotations;

namespace MusicStoreMvc1.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(50)]
        public string? Country { get; set; }

        [Range(1900, 2100)]
        public int? DebutYear { get; set; }

        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
