using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Model
{
    public class BlockDocuGameModel
    {
        #region Fields

        private IBlockDocuDataAccess _dataAccess;
        private BlockDocuTable _table;
        private BlockDocuTable _shapeTable;
        private Int32 _shapeNum;

        #endregion

        #region Properties

        public Int32 ShapeNum { get { return _shapeNum; } }

        public BlockDocuTable Table { get { return _table; } }
        public BlockDocuTable ShapeTable { get { return _shapeTable; } }

        public Boolean IsGameOver { get { return _table.IsFilled; } }

        #endregion

        #region Events

        public event EventHandler<BlockDocuFieldEventArgs>? FieldChanged;

        public event EventHandler<BlockDocuEventArgs>? GameOver;

        #endregion

        #region Constructor

        public BlockDocuGameModel(IBlockDocuDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _table = new BlockDocuTable(4);
            _shapeTable = new BlockDocuTable(2);
        }

        #endregion

        #region Public game methods

        public void NewGame()
        {
            _table = new BlockDocuTable(4);
            _shapeTable = new BlockDocuTable(2);
            GenerateShapes();
            _table.PointsT = 0;
        }

        public void Step(Int32 x, Int32 y)
        {
            if (IsGameOver)
                return;
            if (_table.IsOwned(x, y))
                return;

            _table.StepValue(x, y);

            if (_table.CorrectMove)
            {
                _table.PointsT++;
                LineIsFull();
                GenerateShapes();
                _table.CorrectMove = false;
            }
            OnFieldChanged(x, y);
            

            if (_table.IsFilled)
            {
                OnGameOver();
            }

        }

        public async Task LoadGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            (_table, _shapeTable) = await _dataAccess.LoadAsync(path);
        }

        /// <summary>
        /// Játék mentése.
        /// </summary>
        /// <param name="path">Elérési útvonal.</param>
        public async Task SaveGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _table, _shapeTable);
        }

        #endregion

        #region Private game methods

        private void GenerateShapes()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    _shapeTable.SetOwned(i, j, false);
                }
            }
            Random random = new Random();
            _shapeNum = random.Next(4);
            _table.ShapeNumT = _shapeNum;
            switch (_shapeNum)
            {
                case 0: // 2 függőleges
                    _shapeTable.SetOwned(0, 0, true);
                    _shapeTable.SetOwned(1, 0, true);
                    break;
                case 1: // 2 vízszintes
                    _shapeTable.SetOwned(1, 0, true);
                    _shapeTable.SetOwned(1, 1, true);
                    break;
                case 2: // L
                    _shapeTable.SetOwned(0, 0, true);
                    _shapeTable.SetOwned(1, 0, true);
                    _shapeTable.SetOwned(1, 1, true);
                    break;
                case 3: // L fordítva
                    _shapeTable.SetOwned(0, 0, true);
                    _shapeTable.SetOwned(0, 1, true);
                    _shapeTable.SetOwned(1, 1, true);
                    break;
            }
        }

        private void LineIsFull()
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_table.IsOwned(i, j))
                    {
                        counter++;
                    }
                }

                if (counter == 4)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        _table.SetOwned(i, j, false);
                    }
                }
                counter = 0;
            }

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (_table.IsOwned(i, j))
                    {
                        counter++;
                    }
                }

                if (counter == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        _table.SetOwned(i, j, false);
                    }
                }
                counter = 0;
            }
        }

        #endregion

        #region Private event methods

        private void OnFieldChanged(Int32 x, Int32 y)
        {
            FieldChanged?.Invoke(this, new BlockDocuFieldEventArgs(x, y));
        }

        private void OnGameOver()
        {
            GameOver?.Invoke(this, new BlockDocuEventArgs(_table.PointsT));
        }

        #endregion

    }
}
