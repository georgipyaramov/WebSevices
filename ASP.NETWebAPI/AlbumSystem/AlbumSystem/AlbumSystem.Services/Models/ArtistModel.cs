namespace AlbumSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using AlbumSystem.Models;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel
                {
                    Id = a.ArtistId,
                    Name = a.Name,
                    Country = a.Country,
                    DateOfBirth = a.DateOfBirth
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}