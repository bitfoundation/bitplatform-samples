using Bit.Tutorial11.Client.Core.Controllers.Dashboard;
using Bit.Tutorial11.Shared.Dtos.Dashboard;

namespace Bit.Tutorial11.Client.Core.Components.Pages.Dashboard;

public partial class OverallStatsWidget
{
    [AutoInject] IDashboardController dashboardController = default!;

    private bool isLoading;
    private OverallAnalyticsStatsDataResponseDto data = new();

    protected override async Task OnInitAsync()
    {
        await GetData();
    }

    private async Task GetData()
    {
        isLoading = true;

        try
        {
            data = await dashboardController.GetOverallAnalyticsStatsData(CurrentCancellationToken);
        }
        finally
        {
            isLoading = false;
        }
    }
}
