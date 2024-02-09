using System.Text.Json;
using Bit.Tutorial11.Client.Core.Controllers;
using Bit.Tutorial11.Client.Core.Controllers.Categories;
using Bit.Tutorial11.Client.Core.Controllers.Identity;
using Bit.Tutorial11.Client.Core.Controllers.Product;
using Bit.Tutorial11.Shared.Dtos.Categories;
using Bit.Tutorial11.Shared.Dtos.Identity;
using Bit.Tutorial11.Shared.Dtos.Products;

namespace Bit.Tutorial11.Client.Core.Components.Layout;

public partial class NavMenu : IDisposable
{
    private bool disposed;
    private bool isSignOutModalOpen;
    private string? profileImageUrl;
    private string? profileImageUrlBase;
    private UserDto user = new();
    private List<BitNavItem> navItems = [];
    private Action unsubscribe = default!;

    private List<CategoryDto>? categories;
    private List<ProductDto>? products;
    private bool isLoading = true;

    [AutoInject] private NavigationManager navManager = default!;
    [AutoInject] private ICategoryController categoryController = default!;
    [AutoInject] private IProductController productController = default!;
    [AutoInject] private IUserController userController = default!;
    [AutoInject] private IChatbotController chatbotController = default!;

    [Parameter] public bool IsMenuOpen { get; set; }

    [Parameter] public EventCallback<bool> IsMenuOpenChanged { get; set; }

    protected override async Task OnInitAsync()
    {
        navItems =
        [
            new BitNavItem
            {
                Text = Localizer[nameof(AppStrings.Home)],
                IconName = BitIconName.Home,
                Url = "/",
            },
            new BitNavItem
            {
                Text = Localizer[nameof(AppStrings.ProductCategory)],
                IconName = BitIconName.Product,
                IsExpanded = true,
                ChildItems =
                [
                    new() {
                        Text = Localizer[nameof(AppStrings.Dashboard)],
                        Url = "/dashboard",
                    },
                    new() {
                        Text = Localizer[nameof(AppStrings.Products)],
                        Url = "/products",
                    },
                    new() {
                        Text = Localizer[nameof(AppStrings.Categories)],
                        Url = "/categories",
                    },
                ]
            },
            new BitNavItem
            {
                Text = Localizer[nameof(AppStrings.EditProfileTitle)],
                IconName = BitIconName.EditContact,
                Url = "/edit-profile",
            },
            new BitNavItem
            {
                Text = Localizer[nameof(AppStrings.TermsTitle)],
                IconName = BitIconName.EntityExtraction,
                Url = "/terms",
            }
        ];

        unsubscribe = PubSubService.Subscribe(PubSubMessages.PROFILE_UPDATED, async payload =>
        {
            if (payload is null) return;

            user = (UserDto)payload;

            SetProfileImageUrl();

            await InvokeAsync(StateHasChanged);
        });

        // Download the source code from the link provided in youtube video's description.

        #region Typical useless HttpClient usage => /-:
        {
            // No CancellationToken, low performance due lack of AppJsonContext usage for request and response bodies.

            // get current user
            var user = await HttpClient.GetFromJsonAsync<UserDto>("api/User/GetCurrentUser?query1=value");

            // save category
            await HttpClient.PostAsJsonAsync("api/Category/Create", new CategoryDto { Color = "#000000", Name = "Category to save" });

            // save category and get saved category to retrive its database generated id
            var savedCategory = await (await HttpClient.PostAsJsonAsync("api/Category/Create", new CategoryDto { Color = "#000000", Name = "Category to save" }))
                .Content.ReadFromJsonAsync<CategoryDto>();
        }
        #endregion

        #region Effective HttpClient usage => (:
        {
            // JsonSerializerOptions gets automatically injected by services.TryAddTransient(sp => AppJsonContext.Default.Options);
            // CurrentCancellationToken get automatically cancelled when user navigates to another page / component.

            // get current user
            var user = await HttpClient.GetFromJsonAsync("api/User/GetCurrentUser", JsonSerializerOptions.GetTypeInfo<UserDto>(), CurrentCancellationToken);

            // save category
            await HttpClient.PostAsJsonAsync("api/Category/Create", new() { Color = "#000000", Name = "Category to save" }, JsonSerializerOptions.GetTypeInfo<CategoryDto>(), CurrentCancellationToken);

            // save category and get saved category to retrive its database generated id
            var savedCategory = await (await HttpClient.PostAsJsonAsync("api/Category/Create", new() { Color = "#000000", Name = "Category to save" }, JsonSerializerOptions.GetTypeInfo<CategoryDto>(), CurrentCancellationToken))
                .Content.ReadFromJsonAsync(JsonSerializerOptions.GetTypeInfo<CategoryDto>());
        }
        #endregion

        #region IAppControllers => ;D
        {
            userController.AddQueryString("query1", "value"); // add query string

            // get current user
            var user = await userController.GetCurrentUser(CurrentCancellationToken);

            // save category
            await categoryController.Create(new() { Color = "#000000", Name = "Category to save" }, CurrentCancellationToken);

            // save category and get saved category to retrive its database generated id
            var savedCategory = await categoryController.Create(new() { Color = "#000000", Name = "Category to save" }, CurrentCancellationToken);
        }
        #endregion

        #region Prerender related code => (:
        {
            // Pre render incompatible code, you may not call such a code in OnInitAsync that has `await` but lacks `PrerenderStateService.GetValue`:
            user = (await HttpClient.GetFromJsonAsync("api/User/GetCurrentUser", JsonSerializerOptions.GetTypeInfo<UserDto>(), CurrentCancellationToken))!;

            // Prerender compatible code:
            user = (await PrerenderStateService.GetValue(() => HttpClient.GetFromJsonAsync("api/User/GetCurrentUser", JsonSerializerOptions.GetTypeInfo<UserDto>(), CurrentCancellationToken)))!;

            // also prerender compatible code:
            user = await userController.GetCurrentUser(CurrentCancellationToken); // IAppControllers are already prerender compatible ;D
        }
        #endregion

        #region Ineffective way of getting streamed responses => /-:
        {
            var chatbotResults = await (await chatbotController.GetChatbotResults(CurrentCancellationToken)).ToListAsync(); // lasts 3 seconds

            foreach (var chatbotResult in chatbotResults)
            {
                await Console.Info(chatbotResult);
            }
        }
        #endregion

        #region Effective way of getting streamed responses => ;D
        {
            await foreach (var chatbotResult in await chatbotController.GetChatbotResults(CurrentCancellationToken))
            {
                await Console.Info(chatbotResult);

                // Optionally call StateHasChanged if you're manipulating UI bounded objects in the loop.
            }
        }
        #endregion

        #region Getting responses one by one => /-:
        {
            try
            {
                categories = await categoryController.Get(CurrentCancellationToken);
                products = await productController.Get(CurrentCancellationToken);
            }
            finally
            {
                isLoading = false;
            }
        }
        #endregion

        #region Reduce loading time by loading categories and products in parallel => ;D
        {
            try
            {
                (categories, products) = await (categoryController.Get(CurrentCancellationToken), productController.Get(CurrentCancellationToken));
                // See Shared/Extensions/TupleExtensions.cs
            }
            finally
            {
                isLoading = false;
            }
        }
        #endregion

        var access_token = await PrerenderStateService.GetValue(() => AuthTokenProvider.GetAccessTokenAsync());
        profileImageUrlBase = $"{Configuration.GetApiServerAddress()}api/Attachment/GetProfileImage?access_token={access_token}&file=";

        SetProfileImageUrl();
    }

    private void SetProfileImageUrl()
    {
        profileImageUrl = user.ProfileImageName is not null ? profileImageUrlBase + user.ProfileImageName : null;
    }

    private async Task DoSignOut()
    {
        isSignOutModalOpen = true;

        await CloseMenu();
    }

    private async Task GoToEditProfile()
    {
        await CloseMenu();
        navManager.NavigateTo("edit-profile");
    }

    private async Task HandleNavItemClick(BitNavItem item)
    {
        if (string.IsNullOrEmpty(item.Url)) return;

        await CloseMenu();
    }

    private async Task CloseMenu()
    {
        IsMenuOpen = false;
        await IsMenuOpenChanged.InvokeAsync(false);
    }

    public override void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed || disposing is false) return;

        unsubscribe?.Invoke();

        disposed = true;
    }
}
