using Game.Model;
using Game.Persistence;
using Game.WPF.ViewModel;
using Microsoft.Win32;
using System.ComponentModel;
using System.Windows;

namespace Game.WPF
{

    public partial class App : Application
    {
        private GameModel _model = null!;
        private GameViewModel _viewModel = null!;
        private MainWindow _view = null!;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object? sender, StartupEventArgs e)
        {
            _model = new GameModel(new GameFileDataAccess());
            _model.GameOver += new EventHandler<GameEventArgs>(Model_GameOver);
            _model.NewGame();

            _viewModel = new GameViewModel(_model);
            _viewModel.NewGame += new EventHandler(ViewModel_NewGame);
            _viewModel.ExitGame += new EventHandler(ViewModel_ExitGame);
            _viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
            _viewModel.SaveGame += new EventHandler(ViewModel_SaveGame);

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Closing += new CancelEventHandler(View_Closing); // eseménykezelés a bezáráshoz
            _view.Show();
        }

        private void View_Closing(object? sender, CancelEventArgs e)
        {
           
            if (MessageBox.Show("Biztos, hogy ki akar lépni?", "Game", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ViewModel_NewGame(object? sender, EventArgs e)
        {
            _model.NewGame();
        }

        private async void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog(); 
                openFileDialog.Title = "Játék tábla betöltése";
                openFileDialog.Filter = "Játék tábla|*.gtl";
                if (openFileDialog.ShowDialog() == true)
                {
                    await _model.LoadGameAsync(openFileDialog.FileName);
                }
            }
            catch (GameDataException)
            {
                MessageBox.Show("A fájl betöltése sikertelen!", "Game", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog(); // dialógablak
                saveFileDialog.Title = "Játék tábla betöltése";
                saveFileDialog.Filter = "Játék tábla|*.gtl";
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        // játéktábla mentése
                        await _model.SaveGameAsync(saveFileDialog.FileName);
                    }
                    catch (GameDataException)
                    {
                        MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("A fájl mentése sikertelen!", "Game", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewModel_ExitGame(object? sender, EventArgs e)
        {
            _view.Close();
        }

        private void Model_GameOver(object? sender, GameEventArgs e)
        {
            //TODO: Mi történjen ha vége van
        }
    }

}
