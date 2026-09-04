using Core.Domain.UseCases;
using Core.Services.Storage.Settings;
using Core.Services.Storage.Settings.Models;
using Home.Presentation;
using Xunit;

namespace Home.Tests.Presentation;

public sealed class HomeViewModelTests
{
    [Fact]
    public void HomeViewModel_ShouldExposeUserAndVersionAndRaisePropertyChangedOnRefresh()
    {
        var storage = new InMemoryStorage(new UserSession("alice", "token"));
        var viewModel = new HomeViewModel(storage, new GetAppVersionUseCase());
        var changedProperties = new List<string>();
        viewModel.PropertyChanged += (_, args) => changedProperties.Add(args.PropertyName ?? string.Empty);

        viewModel.Refresh();

        Assert.Equal("alice", viewModel.Username);
        Assert.False(string.IsNullOrWhiteSpace(viewModel.AppVersion));
        Assert.Contains(nameof(HomeViewModel.Username), changedProperties);
        Assert.Contains(nameof(HomeViewModel.AppVersion), changedProperties);
    }
}

internal sealed class InMemoryStorage(UserSession? initialSession = null) : ISettingsStorageService
{
    public UserSession? GetUserSession() => initialSession;

    public void SaveUserSession(UserSession session) { }

    public AppRegion? GetSelectedRegion() => null;

    public void SaveSelectedRegion(AppRegion region) { }

    public IReadOnlyList<string> GetSelectedCountryNames(AppRegion region) => Array.Empty<string>();

    public void SaveSelectedCountryNames(AppRegion region, IEnumerable<string> names) { }
}
