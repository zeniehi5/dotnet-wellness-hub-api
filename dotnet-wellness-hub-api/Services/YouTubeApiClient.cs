using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace dotnet_wellness_hub_api.Services;

public class YouTubeApiClient
{
    private readonly YouTubeService _youTubeService;
    
    public YouTubeApiClient(string apiKey)
    {
        _youTubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = apiKey,
            ApplicationName = "dotnet_wellness_hub_api"
        });
    }

    public async Task<IList<SearchResult>> GetVideosByCategory(string categoryId, long maxResults = 50)
    {
        var searchListRequest = _youTubeService.Search.List("snippet"); 
        
        searchListRequest.Type = "video";
        searchListRequest.VideoCategoryId = categoryId;
        searchListRequest.MaxResults = maxResults;
        searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
        
        var searchResponse = await searchListRequest.ExecuteAsync();

        return searchResponse.Items;
    }
}