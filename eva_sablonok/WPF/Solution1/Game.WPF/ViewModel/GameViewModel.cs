using Game.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Game.WPF.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        private GameModel _model;
        private int _size;
        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand LoadGameCommand { get; private set; }
        public DelegateCommand SaveGameCommand { get; private set; }
        public DelegateCommand ExitGameCommand { get; private set; }
        public ObservableCollection<GameField> Fields { get; set; }
        public int Width { get; set; }
        public int Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        public int Height { get; set; }

        public bool IsGameSmall
        {
            get { return _model.Size == 4; }
            set
            {
                if (_model.Size == 4)
                    return;

                _model.Size = 4;
                OnPropertyChanged(nameof(IsGameSmall));
                OnPropertyChanged(nameof(IsGameMedium));
                OnPropertyChanged(nameof(IsGameLarge));
            }
        }

        public bool IsGameMedium
        {
            get { return _model.Size == 6; }
            set
            {
                if (_model.Size == 6)
                    return;

                _model.Size = 6;
                OnPropertyChanged(nameof(IsGameSmall));
                OnPropertyChanged(nameof(IsGameMedium));
                OnPropertyChanged(nameof(IsGameLarge));
            }
        }

        public bool IsGameLarge
        {
            get { return _model.Size == 8; }
            set
            {
                if (_model.Size == 8)
                    return;

                _model.Size = 8;
                OnPropertyChanged(nameof(IsGameSmall));
                OnPropertyChanged(nameof(IsGameMedium));
                OnPropertyChanged(nameof(IsGameLarge));
            }
        }

        public event EventHandler? NewGame;
        public event EventHandler? LoadGame;
        public event EventHandler? SaveGame;
        public event EventHandler? ExitGame;

        public GameViewModel(GameModel model) 
        {
            _model = model;
            _model.GameAdvanced += new EventHandler<GameEventArgs>(Model_GameAdvanced);
            _model.GameOver += new EventHandler<GameEventArgs>(Model_GameOver);
            _model.GameCreated += new EventHandler<GameEventArgs>(Model_GameCreated);

            NewGameCommand = new DelegateCommand(param => OnNewGame());
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            ExitGameCommand = new DelegateCommand(param => OnExitGame());

            Width = _model.Table.Size * 80;
            Height = _model.Table.Size * 80 + 40;
            Size = _model.Size;

            Fields = new ObservableCollection<GameField>();
            for (Int32 i = 0; i < _model.Table.Size; i++) // inicializáljuk a mezőket
            {
                for (Int32 j = 0; j < _model.Table.Size; j++)
                {
                    Fields.Add(new GameField
                    {
                        X = i,
                        Y = j,
                        Number = i * _model.Table.Size + j,
                        StepCommand = new DelegateCommand(param => StepGame(Convert.ToInt32(param)))
                    });
                }
            }

            RefreshTable();
        }

        private void RefreshTable()
        {
            Width = _model.Table.Size * 80;
            OnPropertyChanged(nameof(Width));
            Height = _model.Table.Size * 80 + 40;
            OnPropertyChanged(nameof(Height));

            OnPropertyChanged(nameof(IsGameSmall));
            OnPropertyChanged(nameof(IsGameLarge));
            OnPropertyChanged(nameof(IsGameMedium));

            if (Size != _model.Size)
            {
                Fields.Clear();
                for (int i = 0; i < _model.Table.Size; ++i)
                {
                    for (int j = 0; j < _model.Table.Size; ++j)
                    {
                        Fields.Add(new GameField
                        {
                            X = i,
                            Y = j,
                            Number = i * _model.Table.Size + j,
                            StepCommand = new DelegateCommand(param => StepGame(Convert.ToInt32(param)))
                        });
                    }
                }
            }

            Size = _model.Table.Size;

            foreach (GameField field in Fields)
            {
                //TODO: szint szoveget egyebet beallitani
            }

            OnPropertyChanged(/*Ha valami valtozik*/);
        }

        private void StepGame(int index)
        {
            GameField field = Fields[index];
            _model.Step(field.X, field.Y);
            //TODO: Lehet kell itt vmit csinalni meg
            MessageBox.Show("Clicked " + index);
        }

        private void Model_GameAdvanced(object? sender, GameEventArgs e)
        {
            //TODO
        }

        private void Model_GameOver(object? sender, GameEventArgs e)
        {
            //TODO
        }

        private void Model_GameCreated(object? sender, GameEventArgs e)
        {
            RefreshTable();
        }

        private void OnNewGame()
        {
            NewGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadGame()
        {
            LoadGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnSaveGame()
        {
            SaveGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnExitGame()
        {
            ExitGame?.Invoke(this, EventArgs.Empty);
        }
    }
}
