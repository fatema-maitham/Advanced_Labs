using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        // Navigation
        public ICollection<PlaylistAlbum> PlaylistAlbums { get; set; } = new List<PlaylistAlbum>();

    }
}
