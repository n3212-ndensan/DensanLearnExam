using BlazorApp.Models;

namespace BlazorApp.Components.Pages;

public partial class Home
{
	protected List<Employee> list = default!;
	protected bool sessionExsists => sessionState.HasState;

	protected override async Task OnInitializedAsync()
	{
		if (sessionExsists)
		{
			list = sessionState.State!;
		}
		else
		{
			SetInitialEmployeeList();
		}
		var c = new Comparison<Employee>(Compare);
		list.Sort(c);
		await Task.CompletedTask;
	}

	async Task LoadEmployeeListAsync()
	{
		await Task.Yield();

		if (sessionExsists)
		{
			sessionState.State = list;
			return;
		}
	}

	void SetInitialEmployeeList()
	{
		list ??= new List<Employee>
		{
			new Employee("電算　一郎", new DateTime(2024, 12, 24), 3, "１部"),
			new Employee("電算　二郎", new DateTime(2023, 9, 23), 1, "２部"),
			new Employee("電算　三郎", new DateTime(2024, 4, 1), 0, "総務部"),
			new Employee("電算　四郎", new DateTime(2023, 9, 22), 1, "人事部"),
			new Employee("Densan Goro", new DateTime(2024, 12, 25), 3, "３部")
		};

		if (!sessionExsists)
		{
			sessionState.State = list;
		}
	}

	private async Task NavigateToEmployeeAddPageAsync()
	{
		await Task.Yield(); 
		NavManager.NavigateTo("employeeadd");
	}

	static string GetEmploymentTypeName(int employmentType)
	{
		switch (employmentType)
		{
			case 0:
				return "正社員";
			case 1:
				return "嘱託";
			case 3:
				return "協力会社";
			default:
				return string.Empty;
		}
	}

	static int Compare(Employee a, Employee b)
	{
		if (a.EmploymentType != b.EmploymentType)
		{
			return a.EmploymentType - b.EmploymentType;
		}

		if (a.JoiningDate >= b.JoiningDate)
		{
			return 1;
		}
		else
		{
			return -1;
		}
	}
}
