using BlazorApp.Models;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages;

public partial class EmployeeAdd
{
	[Inject]
	protected IStateBox<List<Employee>> sessionState { get; set; } = default!;

	[Inject]
	protected NavigationManager navManager { get; set; } = default!;

	protected List<Employee> list = default!;
	protected bool sessionExsists => sessionState.HasState;
	protected Employee newEmployee { get; set; } = new Employee(string.Empty, DateTime.Now, 0, string.Empty);

	protected async Task NavigateToHomeBySubmitAsync()
	{
		if (sessionExsists)
		{
			list = sessionState.State!;
			list.Add(newEmployee);
			sessionState.State = list;
		}
		else
		{
			list ??= new List<Employee>
			{
				newEmployee
			};
			sessionState.State = list;
		}
		await Task.Yield();
		navManager.NavigateTo("/");
	}

	protected async Task NavigateToHomeByCancelAsync()
	{
		await Task.Yield();
		navManager.NavigateTo("/");
	}
}
