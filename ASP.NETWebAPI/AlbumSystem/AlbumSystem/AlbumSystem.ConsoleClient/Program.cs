namespace AlbumSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using Newtonsoft.Json;

    using AlbumSystem.Data;
    using AlbumSystem.Models;
    using AlbumSystem.Services.Models;

    public class EntryPoint
    {
        private const string ServiceRoot = "http://localhost:60945/api/";

        static void GetAlbums(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("albums/all").Result;
            var responses = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString());
            Console.WriteLine(responses);
        }

        static void AddAlbum(HttpClient httpClient, AlbumModel theAlbum)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(theAlbum));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = httpClient.PostAsync("albums/create", postContent).Result;
            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album added!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error adding student");
            }
        }

        private static void UpdateAlbumName(HttpClient httpClient,int albumId, string albumName)
        {
            HttpContent putContent = new StringContent(albumName);
            putContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = httpClient.PutAsJsonAsync((string.Format("albums/Update/1?albumId={0}&albumName={1}",albumId,albumName)), albumName).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album name updated!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating album name!");
            }
        }

        private static void DeleteAlbum(HttpClient httpClient, int albumId)
        {
            var response = httpClient.DeleteAsync("albums/delete/" + albumId).Result;

            try
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Album deleted!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error deleting album!");
            }
        }

        public static void Main()
        {
            AlbumSystemData data = new AlbumSystemData();
            data.Albums.All().Count();
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ServiceRoot);

            var album = new Album() { Title = "Bots Maker", Producer = "Telerik Academy", Year = 2014 };

            var songs = new List<Song>();
            songs.Add(new Song() { Title = "DSA", Genre = "horror", Year = 2014 });
            songs.Add(new Song() { Title = "Can you feel the pain", Genre = "horror", Year = 2012 });
            songs.Add(new Song() { Title = "I just wanna sleep", Genre = "TA", Year = 2014 });

            var artists = new List<Artist>();
            artists.Add(new Artist() { Name = "Pehsko", Country = "Bulgaria", DateOfBirth = new DateTime(2006,10,01) });
            artists[0].Songs.Add(songs[0]);
            artists[0].Songs.Add(songs[1]);
            artists.Add(new Artist() { Name = "Goshko", Country = "England", DateOfBirth = new DateTime(1993,03,03) });
            artists[1].Songs.Add(songs[2]);

            album.Artists = artists;

            var albumModel = new AlbumModel();
            albumModel.Producer = album.Producer;
            albumModel.Title = album.Title;
            albumModel.Year = album.Year;
            AddAlbum(httpClient, albumModel);

            GetAlbums(httpClient);

            var updatedAlbum = new AlbumModel();
            updatedAlbum.Producer = albumModel.Producer;
            updatedAlbum.Year = albumModel.Year;
            updatedAlbum.Title = "Ninjas maker";
            UpdateAlbumName(httpClient,5, updatedAlbum.Title);

            GetAlbums(httpClient);

            DeleteAlbum(httpClient, 1);
        }
    }
}