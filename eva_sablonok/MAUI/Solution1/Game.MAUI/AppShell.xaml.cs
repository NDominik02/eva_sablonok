using Game.MAUI.View;
using Game.MAUI.ViewModel;
using Game.Model;
using Game.Persistence;

namespace Game.MAUI
{
    public partial class AppShell : Shell
    {
        #region Fields

        private IGameDataAccess _dataAccess;
        private readonly GameModel _gameModel;
        private readonly GameViewModel _viewModel;

        private readonly IStore _store;
        private readonly StoredGameBrowserModel _storedGameBrowserModel;
        private readonly StoredGameBrowserViewModel _storedGameBrowserViewModel;
        #endregion

        #region Application methods

        public AppShell(IStore store,
            IGameDataAccess dataAccess,
            GameModel gameModel,
            GameViewModel viewModel)
        {
            InitializeComponent();

            // játék összeállítása
            _store = store;
            _dataAccess = dataAccess;
            _gameModel = gameModel;
            _viewModel = viewModel;

            _gameModel.GameOver += GameModel_GameOver;

            _viewModel.NewGame += ViewModel_NewGame;
            _viewModel.LoadGame += ViewModel_LoadGame;
            _viewModel.SaveGame += ViewModel_SaveGame;
            _viewModel.SettingsOpen += ViewModel_SettingsOpen;
            _viewModel.GameStep += ViewModel_GameStep;

            _storedGameBrowserModel = new StoredGameBrowserModel(_store);
            _storedGameBrowserViewModel = new StoredGameBrowserViewModel(_storedGameBrowserModel);
            _storedGameBrowserViewModel.GameLoading += StoredGameBrowserViewModel_GameLoading;
            _storedGameBrowserViewModel.GameSaving += StoredGameBrowserViewModel_GameSaving;
        }
        #endregion

        #region Model event handlers

        private async void GameModel_GameOver(object? sender, GameEventArgs e)
        {
            // győzelemtől függő üzenet megjelenítése
            await DisplayAlert("Game játék",
                "Gratulálok, győztél!",
                "OK");
        }
        #endregion

        #region ViewModel event handlers

        private async void ViewModel_GameStep(object? sender, EventArgs e)
        {
            await DisplayAlert("Game", "Clicked", "Ok");
        }

        private void ViewModel_NewGame(object? sender, EventArgs e)
        {
            _gameModel.NewGame();
        }

        private async void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            await _storedGameBrowserModel.UpdateAsync();
            await Navigation.PushAsync(new LoadGamePage
            {
                BindingContext = _storedGameBrowserViewModel
            });
        }

        private async void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            await _storedGameBrowserModel.UpdateAsync();
            await Navigation.PushAsync(new SaveGamePage
            {
                BindingContext = _storedGameBrowserViewModel
            });
        }

        private async void ViewModel_SettingsOpen(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage
            {
                BindingContext = _viewModel
            });
        }


        private async void StoredGameBrowserViewModel_GameLoading(object? sender, StoredGameEventArgs e)
        {
            await Navigation.PopAsync();

            try
            {
                await _gameModel.LoadGameAsync(e.Name);

                await Navigation.PopAsync();
                await DisplayAlert("Game", "Sikeres betöltés.", "OK");

            }
            catch
            {
                await DisplayAlert("Game", "Sikertelen betöltés.", "OK");
            }
        }

        private async void StoredGameBrowserViewModel_GameSaving(object? sender, StoredGameEventArgs e)
        {
            await Navigation.PopAsync();

            try
            {
                await _gameModel.SaveGameAsync(e.Name);
                await DisplayAlert("Game", "Sikeres mentés.", "OK");
            }
            catch
            {
                await DisplayAlert("Game", "Sikertelen mentés.", "OK");
            }
        }
        #endregion

    }
}
