namespace Adaptit.Training.JobVacancy.Backend.Dto;

using System.Text.Json.Serialization;

public class FeedLine
{
	public string Id { get; set; }
	public string Url { get; set; }
	public string Title { get; set; }

	[JsonPropertyName("content_text")]
	public string ContentText { get; set; }

	[JsonPropertyName("date_modified")]
	public string? DateModified { get; set; }

	[JsonPropertyName("_feed_entry")]
	public FeedEntry FeedEntry { get; set; }
}
