namespace dotnet_wellness_hub_api.Models
{
    public class VideoCategory
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}