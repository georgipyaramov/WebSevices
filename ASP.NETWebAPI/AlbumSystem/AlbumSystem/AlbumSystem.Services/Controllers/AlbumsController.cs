namespace AlbumSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using AlbumSystem.Data;
    using AlbumSystem.Services.Models;
    using AlbumSystem.Models;

    public class AlbumsController : ApiController
    {
        private IAlbumSystemData data;

        public AlbumsController()
            : this(new AlbumSystemData())
        {
        }

        public AlbumsController(IAlbumSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            var album = this.data.Albums.All()
                .Select(AlbumModel.FromAlbum)
                .FirstOrDefault(a => a.AlbumId == id);

            return Ok(album);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums.All().Select(AlbumModel.FromAlbum);

            return Ok(albums);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAlbum = new Album
            {
                Producer = album.Producer,
                Title = album.Title,
                Year = album.Year
            };

            this.data.Albums.Add(newAlbum);

            this.data.SaveChanges();

            return Ok(newAlbum.AlbumId);
        }

        [HttpPut]
        public IHttpActionResult AddSong(int idAlbum, int idSong)
        {
            var existingSong = this.data.Songs.All().FirstOrDefault(a => a.SongId == idSong);
            if (existingSong == null)
            {
                return BadRequest("No such song with this id!");
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.AlbumId == idAlbum);
            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Songs.Add(existingSong);

            this.data.SaveChanges();

            return Ok();
        }


        [HttpPut]
        public IHttpActionResult RemoveSong(int idAlbum, int idSong)
        {
            var existingSong = this.data.Songs.All().FirstOrDefault(a => a.SongId == idSong);
            if (existingSong == null)
            {
                return BadRequest("No such song with this id!");
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.AlbumId == idAlbum);
            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Songs.Remove(existingSong);

            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult AddArtist(int idAlbum, int idArtist)
        {
            var existingArtist = this.data.Artist.All().FirstOrDefault(a => a.ArtistId == idArtist);
            if (existingArtist == null)
            {
                return BadRequest("No such artist with this id!");
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.AlbumId == idAlbum);
            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Artists.Add(existingArtist);

            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult RemoveArtist(int idAlbum, int idArtist)
        {
            var existingArtist = this.data.Artist.All().FirstOrDefault(a => a.ArtistId == idArtist);
            if (existingArtist == null)
            {
                return BadRequest("No such artist with this id!");
            }

            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.AlbumId == idAlbum);
            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Artists.Remove(existingArtist);

            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(int albumId, string albumName)
        {
            var existingAlbum = this.data.Albums.All().FirstOrDefault(a => a.AlbumId == albumId);

            if (existingAlbum == null)
            {
                return BadRequest("No such album with this id!");
            }

            existingAlbum.Title = albumName;

            this.data.Albums.Update(existingAlbum);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.data.Albums.All().FirstOrDefault(a => a.AlbumId == id);
            if (album == null)
            {
                return BadRequest("No such artist with this id!");
            }

            this.data.Albums.Delete(album);
            this.data.SaveChanges();

            return Ok();
        }
    }
}