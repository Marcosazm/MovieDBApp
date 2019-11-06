using System;
using System.Collections.Generic;
using System.Text;
using Flurl.Http; 
using System.Threading.Tasks;

namespace MovieDBApp.Services
{
    public class FlurlHttpRequest : IHttpRequest
    {
        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            return await uri.GetJsonAsync<TResult>();
        }
    }
}
