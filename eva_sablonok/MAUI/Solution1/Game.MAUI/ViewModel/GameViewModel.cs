using Game.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.MAUI.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        #region Fields

        private GameModel _model;
        private int _size;
        private GameSizeViewModel _gameSize = null!;
        #endregion
        #region Properties

        public Command NewGameCommand { get; private set; }
        public Command LoadGameCommand { get; private set; }
        public Command SaveGameCommand { get; private set; }
        public Command SettingsCommand { get; private set; }
        public ObservableCollection<GameField> Fields { get; set; }
        public ObservableCollection<GameSizeViewModel> GameSizes { get; set; }
        public GameSizeViewModel GameSize
        {
            get => _gameSize;
            set
            {
                _gameSize = value;
                _model.TableSize = value.Size;
                OnPropertyChanged();
            }
        }

        public int Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(GameTableRows));
                OnPropertyChanged(nameof(GameTableColumns));
            }
        }

        public RowDefinitionCollection GameTableRows
        {
            get => new RowDefinitionCollection(Enumerable.Repeat(new RowDefinition(GridLength.Star), Size).ToArray());
        }
        public ColumnDefinitionCollection GameTableColumns
        {
            get => new ColumnDefinitionCollection(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), Size).ToArray());
        }
        #endregion

        #region Events


        public event EventHandler? NewGame;
        public event EventHandler? LoadGame;
        public event EventHandler? SaveGame;
        public event EventHandler? SettingsOpen;
        public event EventHandler? GameStep;
        #endregion
        #region Constructors

        public GameViewModel(GameModel model)
        {
            _model = model;
            _model.GameAdvanced += new EventHandler<GameEventArgs>(Model_GameAdvanced);
            _model.GameOver += new EventHandler<GameEventArgs>(Model_GameOver);
            _model.GameCreated += new EventHandler<GameEventArgs>(Model_GameCreated);

            NewGameCommand = new Command(param => OnNewGame());
            LoadGameCommand = new Command(param => OnLoadGame());
            SaveGameCommand = new Command(param => OnSaveGame());
            SettingsCommand = new Command(param => OnSettingsOpen());

            GameSizes = new ObservableCollection<GameSizeViewModel>
            {
                new GameSizeViewModel { Size = TableSize.Small },
                new GameSizeViewModel { Size = TableSize.Medium },
                new GameSizeViewModel { Size = TableSize.Large }
            };
            GameSize = GameSizes[0];

            Size = _model.Table.Size;

            Fields = new ObservableCollection<GameField>();
            for (int i = 0; i < _model.Table.Size; i++)
            {
                for (int j = 0; j < _model.Table.Size; j++)
                {
                    Fields.Add(new GameField
                    {
                        X = i,
                        Y = j,
                        Number = i * _model.Table.Size + j,
                        StepCommand = new Command(param => StepGame(Convert.ToInt32(param)))
                    });
                }
            }

            RefreshTable();
        }
        #endregion

        #region Private methods

        private void RefreshTable()
        {
            if (Fields.Count != _model.Table.Size * _model.Table.Size)
            {
                Size = _model.Table.Size;
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
                            StepCommand = new Command(param => StepGame(Convert.ToInt32(param)))
                        });
                    }
                }
                switch (_model.TableSize)
                {
                    case TableSize.Small:
                        GameSize = GameSizes[0];
                        break;
                    case TableSize.Medium:
                        GameSize = GameSizes[1];
                        break;
                    default:
                        GameSize = GameSizes[2];
                        break;
                }
            }
            else
            {
                //TODO: nem méreteződött át a tábla és refreshelodik
            }
        }

        private void StepGame(int index)
        {
            GameField field = Fields[index];
            _model.Step(field.X, field.Y);
            // Lehet kell itt vmit csinalni meg
            OnGameStep();
        }
        #endregion

        #region Model event handlers

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
        #endregion

        #region Event methods

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

        private void OnSettingsOpen()
        {
            SettingsOpen?.Invoke(this, EventArgs.Empty);
        }

        private void OnGameStep()
        {
            GameStep?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
