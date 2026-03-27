using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._3.Models
{
    public class PlaylistAlbum
    {
        public int PlaylistId { get; set; }
        public int AlbumId { get; set; }
        public DateTime DateAdded { get; set; }

        // Navigation
        public Playlist Playlist { get; set; } = null!;
        public Album Album { get; set; } = null!;
    }
}
