using Game.MAUI.Persistence;
using Game.MAUI.ViewModel;
using Game.Model;
using Game.Persistence;

namespace Game.MAUI
{
    public partial class App : Application
    {
        private const string SuspendedGameSavePath = "SuspendedGame";

        private readonly AppShell _appShell;
        private readonly IGameDataAccess _dataAccess;
        private readonly GameModel _gameModel;
        private readonly IStore _store;
        private readonly GameViewModel _viewModel;
        public App()
        {
            InitializeComponent();

            _store = new GameStore();
            _dataAccess = new FileDataAccess(FileSystem.AppDataDirectory);

            _gameModel = new GameModel(_dataAccess);
            _viewModel = new GameViewModel(_gameModel);

            _appShell = new AppShell(_store, _dataAccess, _gameModel, _viewModel)
            {
                BindingContext = _viewModel
            };
            MainPage = _appShell;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);

            // az alkalmazás indításakor
            window.Created += (s, e) =>
            {
                // új játékot indítunk
                _gameModel.NewGame();
            };

            // amikor az alkalmazás fókuszba kerül
            window.Activated += (s, e) =>
            {
                if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)))
                    return;

                Task.Run(async () =>
                {
                    // betöltjük a felfüggesztett játékot, amennyiben van
                    try
                    {
                        await _gameModel.LoadGameAsync(SuspendedGameSavePath);
                    }
                    catch
                    {
                    }
                });
            };

            // amikor az alkalmazás fókuszt veszt
            window.Deactivated += (s, e) =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await _gameModel.SaveGameAsync(SuspendedGameSavePath);
                    }
                    catch
                    {
                    }
                });
            };

            return window;
        }
    }
}
