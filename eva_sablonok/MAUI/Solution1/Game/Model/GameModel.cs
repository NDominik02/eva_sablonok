using Game.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public enum TableSize { Small, Medium, Large }
    public class GameModel
    {
        #region Fields

        private IGameDataAccess _dataAccess;
        private GameTable _table;
        private TableSize _tableSize;
        #endregion
        #region Properties

        public TableSize TableSize
        {
            get => _tableSize;
            set
            {
                _tableSize = value;
            }
        }

        public GameTable Table { get { return _table; } }

        public bool IsGameOver { get { return _table.IsFilled; } }
        #endregion

        #region Events

        public event EventHandler<GameEventArgs>? GameAdvanced;
        public event EventHandler<GameEventArgs>? GameOver;
        public event EventHandler<GameEventArgs>? GameCreated;
        #endregion

        #region Constructor


        public GameModel(IGameDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _table = new GameTable();
        }
        #endregion

        #region Public game methods

        public void NewGame()
        {
            switch (_tableSize)
            {
                case TableSize.Small:
                    _table = new GameTable(4);
                    break;
                case TableSize.Medium:
                    _table = new GameTable(6);
                    break;
                case TableSize.Large:
                    _table = new GameTable(8);
                    break;
            }

            OnGameCreated();
        }

        public void Step(int x, int y)
        {
            if (IsGameOver)
                return;

            _table.StepValue(x, y);
            OnGameAdvanced();

            if (_table.IsFilled)
            {
                OnGameOver();
            }
        }

        public async Task LoadGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _table = await _dataAccess.LoadAsync(path);

            OnGameCreated();
        }

        public async Task SaveGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _table);
        }
        #endregion

        #region Private event methods

        private bool CheckGameOver()
        {
            // Megnézni vége van-e a játéknak
            return true;
        }

        private void OnGameAdvanced()
        {
            GameAdvanced?.Invoke(this, new GameEventArgs());
        }

        private void OnGameOver()
        {
            GameOver?.Invoke(this, new GameEventArgs());
        }

        private void OnGameCreated()
        {
            GameCreated?.Invoke(this, new GameEventArgs());
        }
        #endregion
    }
}
