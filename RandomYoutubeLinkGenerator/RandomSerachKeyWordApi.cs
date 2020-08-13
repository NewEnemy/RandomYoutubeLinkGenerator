using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Google.Apis;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace RandomYoutubeLinkGenerator
{
    class RandomSerachKeyWordApi
    {

        private async Task Run(string Querry)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {

                ApiKey = "Secret",
                ApplicationName = this.GetType().ToString()

            });
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            searchListRequest.MaxResults = 50;
            searchListRequest.Q = Querry;

            var searchResponse = await searchListRequest.ExecuteAsync();



        }
    }
    
}
