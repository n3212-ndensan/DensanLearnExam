using BlazorApp.Models;

namespace BlazorApp.Components.Pages;

public partial class Home
{
    private List<Tasuku> list = default!;
    bool sessionExsists => sessionState.HasState;

    protected override void OnInitialized()
    {
        if (sessionExsists)
        {
            list = sessionState.State!;
		}
        else
        {
            SetInitialTask();

		}
		var c = new Comparison<Tasuku>(Compare);
		list.Sort(c);
	}

    async Task LoadTask()
    {
        await Task.Yield();

        if (sessionExsists)
        {
            sessionState.State = list;
            return;
        }
    }

    void SetInitialTask()
    {
        list ??= new List<Tasuku>
        {
            new Tasuku("タスク1", new DateTime(2024, 10, 31), 2, "ああああ"),
            new Tasuku("タスク2", new DateTime(2024, 11, 30), 1, "いいいいいいい"),
            new Tasuku("タスク3", new DateTime(2024, 12, 31), 0, "ううう")
        };

        if (!sessionExsists)
        {
            sessionState.State = list;
        }
    }

	private void NavigateToTaskAddPage()
    {
        NavManager.NavigateTo("taskadd");
	}

	static string GetState(int state)
	{
		switch (state)
		{
			case 0:
				return "未着手";
			case 1:
				return "仕掛中";
			case 2:
				return "完了";
			case 9:
				return "無視";
			default:
				return string.Empty;
		}
    }

    static int Compare(Tasuku a, Tasuku b)
	{
        if (a.State != b.State)
        {
			return a.State - b.State;
        }

        if( a.Deadline >= b.Deadline)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
