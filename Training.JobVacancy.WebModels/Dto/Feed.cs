namespace Adaptit.Training.JobVacancy.Backend.Dto;

using System.Text.Json.Serialization;

public class Feed
{
	public string Version { get; set; }
	public string Title { get; set; }

	[JsonPropertyName("home_page_url")]
	public string HomePageUrl { get; set; }

	[JsonPropertyName("feed_url")]
	public string FeedUrl { get; set; }

	public string Description { get; set; }

	[JsonPropertyName("next_url")]
	public string? NextUrl { get; set; }
	public string Id { get; set; }

	[JsonPropertyName("next_id")]
	public int? NextId { get; set; }

	public List<FeedLine> Items { get; set; }
}
