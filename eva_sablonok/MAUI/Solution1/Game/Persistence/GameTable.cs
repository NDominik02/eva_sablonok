using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Persistence
{
    public class GameTable
    {
        #region Fields
        private int[,] _fieldValues;

        #endregion

        #region Properties

        public Boolean IsFilled
        {
            get
            {
                return false;
            }
        }
        public int Size { get { return _fieldValues.GetLength(0); } }
        public int this[int x, int y] { get { return GetValue(x, y); } set { SetValue(x, y, value); } }

        #endregion

        #region Constructors
        public GameTable() : this(4) { }
        public GameTable(int tableSize)
        {
            if (tableSize < 0)
                throw new ArgumentOutOfRangeException(nameof(tableSize), "The table size is less than 0.");

            _fieldValues = new int[tableSize, tableSize];
        }

        #endregion

        #region Public methods


        public bool IsEmpty(int x, int y)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

            return _fieldValues[x, y] == 0;
        }

        public int GetValue(int x, int y)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

            return _fieldValues[x, y];
        }
        public void SetValue(int x, int y, int value)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

            _fieldValues[x, y] = value;
        }

        public void StepValue(int x, int y)
        {
            if (x < 0 || x >= _fieldValues.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldValues.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

        }
        #endregion

    }
}
