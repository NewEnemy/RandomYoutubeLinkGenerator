using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Google.Apis;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace RandomYoutubeLinkGenerator
{
    class RandomSerachKeyWordApi
    {

        public Google.Apis.YouTube.v3.Data.SearchListResponse Resoults;
        string Api;
    public RandomSerachKeyWordApi()
        {
            Api = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/ApiKey.txt");
        }
        public void Serach(string Querry)
        {

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {

                ApiKey = Api,
                ApplicationName = this.GetType().ToString()

            });
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            searchListRequest.MaxResults = 50;
            
            searchListRequest.Q = Querry;

            Resoults =  searchListRequest.Execute();



        }

    }
    
}
