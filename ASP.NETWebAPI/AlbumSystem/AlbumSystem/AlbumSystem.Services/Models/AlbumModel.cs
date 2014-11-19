namespace AlbumSystem.Services.Models
{
    using AlbumSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel
                {
                    AlbumId = a.AlbumId,
                    Title = a.Title,
                    Year = a.Year,
                    Producer = a.Producer
                };
            }
        }

        public int AlbumId { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Producer { get; set; }
    }
}