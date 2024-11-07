using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models;

public class Tasuku(string title, DateTime deadline, int state, string contents)
{
	[Required(ErrorMessage = "題名を入力してください。")]
	public string Title { get; set; } = title;

	[Required(ErrorMessage = "期限を入力してください。")]
	public DateTime Deadline { get; set; } = deadline;

	[Required(ErrorMessage = "状態を入力してください。")]
	public int State { get; set; } = state;

	public string Contents { get; set; } = contents;
}
