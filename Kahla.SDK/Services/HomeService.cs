﻿using Aiursoft.Handler.Exceptions;
using Aiursoft.Handler.Models;
using Aiursoft.Scanner.Interfaces;
using Aiursoft.XelNaga.Models;
using Aiursoft.XelNaga.Services;
using Kahla.SDK.Models.ApiViewModels;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Kahla.SDK.Services
{
    public class HomeService : IScopedDependency
    {
        private readonly HTTPService _http;

        public HomeService(HTTPService http)
        {
            _http = http;
        }

        public async Task<IndexViewModel> IndexAsync(string serverRoot)
        {
            var url = new AiurUrl(serverRoot, "Home", "Index", new { });
            var result = await _http.Get(url, false);
            var jResult = JsonConvert.DeserializeObject<IndexViewModel>(result);

            if (jResult.Code != ErrorType.Success)
                throw new AiurUnexpectedResponse(jResult);
            return jResult;
        }
    }
}
