using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using movieAPI.Models;
namespace movieAPI
{
    public class WebRequest
    {
        public static async Task getMovie(string search, Action<List<Movie>> Callback)
        {
            using (var Client = new HttpClient())
            {
                try{
                    Client.BaseAddress = new Uri($"https://api.themoviedb.org/3/search/movie?api_key=605e83a569b5e567887f5f6291431616&language=en-US&query={search}&page=1&include_adult=false");
                    HttpResponseMessage Response = await Client.GetAsync("");
                    Response.EnsureSuccessStatusCode();
                    string StringResponse = await Response.Content.ReadAsStringAsync();
                    JObject movieList = JsonConvert.DeserializeObject<JObject>(StringResponse);
                    List<Movie> result = new List<Movie>();
                    foreach(var mov in movieList["results"]){
                    Movie movie = new Movie
                    {
                        Title = mov["title"].Value<string>(),
                        ReleaseDate = mov["release_date"].Value<string>(),
                        Rating = mov["vote_average"].Value<float>(),
                        PosterPath = mov["poster_path"].Value<string>()
                    };
                        result.Add(movie);
                    }

                    Callback(result);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}