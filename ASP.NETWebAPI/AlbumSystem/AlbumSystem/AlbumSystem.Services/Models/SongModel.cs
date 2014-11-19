namespace AlbumSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using AlbumSystem.Models;

    public class SongModel
    {
        public static Expression<Func<Song , SongModel>> FromSong
        {
            get
            {
                return a => new SongModel
                {
                    SongId = a.SongId,
                    Title = a.Title,
                    Year = a.Year,
                    Genre = a.Genre,
                    ArtistId=a.ArtistId
                };
            }
        }

        public int SongId { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }
        
        [Required]
        public int ArtistId { get; set; }
    }
}