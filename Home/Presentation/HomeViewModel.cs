using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Services.Storage.Settings;
using Core.Domain.UseCases;

namespace Home.Presentation;

public partial class HomeViewModel(ISettingsStorageService settingsStorageService, GetAppVersionUseCase getAppVersionUseCase) : ObservableObject
{
    public string AppVersion => getAppVersionUseCase.Execute();

    public string Username => settingsStorageService.GetUserSession()?.UserName ?? string.Empty;

    public void Refresh()
    {
        OnPropertyChanged(nameof(Username));
        OnPropertyChanged(nameof(AppVersion));
    }

    [RelayCommand]
    private async Task GoToBlocksAsync()
    {
        await Shell.Current.GoToAsync("//Blocks");
    }

    [RelayCommand]
    private async Task GoToCountriesAsync()
    {
        await Shell.Current.GoToAsync("//Countries");
    }
}
