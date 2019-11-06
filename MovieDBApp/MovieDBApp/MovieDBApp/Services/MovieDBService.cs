using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieDBApp.Helpers;
using MovieDBApp.Models;

namespace MovieDBApp.Services
{
    public class MovieDBService : IMovieDBService
    {
        private readonly IHttpRequest _request;

        public MovieDBService(IHttpRequest request)=>
            _request = request;
        
        public async Task<Movie> FindByIdAsync(int movieId, string language = "en")
        {
            string url = $"{AppSettings.ApiBaseUrl}movie/{movieId}?api_key={AppSettings.ApiKey}&language={language}";

            return await _request.GetAsync<Movie>(url);
        }

        public async Task<SearchResponse<Movie>> GetUpcomingMoviesAsync
            (int pageNumber = 1, string language = "en")
        {
            var url = $"{AppSettings.ApiBaseUrl}movie/" +
                  $"upcoming?api_key={AppSettings.ApiKey}" +
                  $"&language={language}" +
                  $"&page={pageNumber}";

            return await _request.GetAsync<SearchResponse<Movie>>(url).ConfigureAwait(false);
        }
    }
}
