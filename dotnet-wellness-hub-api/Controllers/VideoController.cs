using dotnet_wellness_hub_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wellness_hub_api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VideoController(YouTubeApiClient youTubeApiClient) : ControllerBase
{
    private readonly YouTubeApiClient _youTubeApiClient = youTubeApiClient;

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetVideosByCategory(string categoryId)
    {
        var videos = await _youTubeApiClient.GetVideosByCategory(categoryId, 10);
        
        return Ok(videos);
    }
}