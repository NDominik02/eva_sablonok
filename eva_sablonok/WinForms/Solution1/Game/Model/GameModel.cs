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
        public GameTable Table { get { return _table; } }
        public TableSize TableSize { get { return _tableSize; } set { _tableSize = value; } }

        public bool IsGameOver { get { return _table.IsFilled; } }
        #endregion

        #region Events
        public event EventHandler<GameFieldEventArgs>? FieldChanged;
        public event EventHandler<GameEventArgs>? GameAdvanced;
        public event EventHandler<GameEventArgs>? GameOver;
        #endregion

        #region Constructor
        public GameModel(IGameDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _table = new GameTable();
            _tableSize = TableSize.Small;
        }
        #endregion

        #region Public game methods
        public void NewGame()
        {
            switch (_tableSize)
            {
                case TableSize.Small:
                    _table = new GameTable(4);
                    // Ha kell csinálj hozzá GenerateFields-et (ha nem alap üres gombos cuccról kezded - private void GenerateFields())
                    break;
                case TableSize.Medium:
                    _table = new GameTable(6);
                    break;
                case TableSize.Large:
                    _table = new GameTable(8);
                    break;
            }
        }

        public void Step(int x, int y)
        {
            if (IsGameOver) // ha már vége a játéknak, nem játszhatunk
                return;

            _table.StepValue(x, y); // tábla módosítása
            OnFieldChanged(x, y);

            //OnGameAdvanced();

            if (_table.IsFilled) // ha vége a játéknak, jelezzük, hogy győztünk
            {
                OnGameOver();
            }
        }

        public async Task LoadGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _table = await _dataAccess.LoadAsync(path);
        }

        public async Task SaveGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _table);
        }

        #endregion

        #region Private event methods

        private void OnFieldChanged(int x, int y)
        {
            FieldChanged?.Invoke(this, new GameFieldEventArgs(x, y));
        }

        private void OnGameAdvanced()
        {
            GameAdvanced?.Invoke(this, new GameEventArgs());
        }

        private void OnGameOver()
        {
            GameOver?.Invoke(this, new GameEventArgs());
        }
        #endregion
    }
}
