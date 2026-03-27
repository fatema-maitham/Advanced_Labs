using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3.Models
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
