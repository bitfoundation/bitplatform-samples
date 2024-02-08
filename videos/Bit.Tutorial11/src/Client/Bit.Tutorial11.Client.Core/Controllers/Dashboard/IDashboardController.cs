using Bit.Tutorial11.Shared.Dtos.Dashboard;

namespace Bit.Tutorial11.Client.Core.Controllers.Dashboard;

[Route("api/[controller]/[action]/")]
public interface IDashboardController : IAppController
{
    [HttpGet]
    Task<OverallAnalyticsStatsDataResponseDto> GetOverallAnalyticsStatsData(CancellationToken cancellationToken = default);

    [HttpGet]
    Task<IAsyncEnumerable<ProductsCountPerCategoryResponseDto>> GetProductsCountPerCategoryStats(CancellationToken cancellationToken = default);

    [HttpGet]
    Task<IAsyncEnumerable<ProductSaleStatResponseDto>> GetProductsSalesStats(CancellationToken cancellationToken = default);

    [HttpGet]
    Task<ProductPercentagePerCategoryResponseDto[]> GetProductsPercentagePerCategoryStats(CancellationToken cancellationToken = default);
}
