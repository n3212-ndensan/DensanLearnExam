using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models;

public class Employee(string name, DateTime joiningDate, int employmentType, string biko)
{
	[Required(ErrorMessage = "氏名を入力してください。")]
	public string Name { get; set; } = name;

	[Required(ErrorMessage = "入社日「を入力してください。")]
	public DateTime JoiningDate { get; set; } = joiningDate;

	[Required(ErrorMessage = "備考を入力してください。")]
	public int EmploymentType { get; set; } = employmentType;

	public string Biko { get; set; } = biko;
}
