using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Model
{
    public class BlockDocuTable
    {
        #region Fields

        private Boolean[,] _fieldOwned;
        private Boolean _correctMove = false;
        private Int32 _pointsT;
        private Int32 _shapeNumT;

        #endregion

        #region Properties

        public Boolean IsFilled
        {
            get
            {
                switch (_shapeNumT)
                {
                    case 0:
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                //if (x + 1 >= _fieldOwned.GetLength(0) || _fieldOwned[x + 1, y])

                                if (i + 1 < _fieldOwned.GetLength(0) && !_fieldOwned[i, j] && !_fieldOwned[i+1, j])
                                {
                                    return false;
                                }
                            }
                        }
                        break;
                    case 1:
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (j + 1 < _fieldOwned.GetLength(1) && !_fieldOwned[i, j] && !_fieldOwned[i, j+1])
                                {
                                    return false;
                                }
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (i + 1 < _fieldOwned.GetLength(0) && j + 1 < _fieldOwned.GetLength(1) && !_fieldOwned[i, j] && !_fieldOwned[i+1, j] && !_fieldOwned[i+1, j+1])
                                {
                                    return false;
                                }
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (j + 1 < _fieldOwned.GetLength(1) && i + 1 < _fieldOwned.GetLength(0) && !_fieldOwned[i, j] && !_fieldOwned[i, j + 1] && !_fieldOwned[i+1, j+1])
                                {
                                    return false;
                                }
                            }
                        }
                        break;
                }
                return true;
            }
        }

        public Int32 Size { get { return _fieldOwned.GetLength(0); } }
        public Int32 PointsT { get { return _pointsT; } set { _pointsT = value; } }
        public Int32 ShapeNumT { get { return _shapeNumT; } set { _shapeNumT = value; } }
        public Boolean CorrectMove { get { return _correctMove; } set { _correctMove = value; } }

        #endregion

        #region Constructors

        public BlockDocuTable(Int32 tableSize)
        {
            if (tableSize < 0)
                throw new ArgumentOutOfRangeException(nameof(tableSize), "The table size is less than 0.");

            _fieldOwned = new Boolean[tableSize, tableSize];
        }

        #endregion

        #region Public methods

        public Boolean IsOwned(Int32 x, Int32 y)
        {
            if (x < 0 || x >= _fieldOwned.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldOwned.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

            return _fieldOwned[x, y];

        }

        public void StepValue(Int32 x, Int32 y)
        {
            if (x < 0 || x >= _fieldOwned.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldOwned.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

            if (_fieldOwned[x, y])
                return;

            switch (ShapeNumT)
            {
                case 0:
                    if (x + 1 < 0 || x + 1 >= _fieldOwned.GetLength(0) || _fieldOwned[x + 1, y])
                        break;
                    _fieldOwned[x, y] = true;
                    _fieldOwned[x + 1, y] = true;
                    _correctMove = true;
                    break;
                case 1:
                    if (y + 1 < 0 || y + 1 >= _fieldOwned.GetLength(1) || _fieldOwned[x, y + 1])
                        break;
                    _fieldOwned[x, y] = true;
                    _fieldOwned[x, y + 1] = true;
                    _correctMove = true;
                    break;
                case 2:
                    if ((x + 1 < 0 || x + 1 >= _fieldOwned.GetLength(0)) || (y + 1 < 0 || y + 1 >= _fieldOwned.GetLength(1)) || _fieldOwned[x + 1, y] || _fieldOwned[x+1, y+1])
                        break;
                    _fieldOwned[x, y] = true;
                    _fieldOwned[x + 1, y] = true;
                    _fieldOwned[x + 1, y + 1] = true;
                    _correctMove=true;
                    break;
                case 3:
                    if ((y + 1 < 0 || y + 1 >= _fieldOwned.GetLength(1)) || (x + 1 < 0 || x + 1 >= _fieldOwned.GetLength(0)) || _fieldOwned[x, y+1] || _fieldOwned[x+1, y+1])
                        break;
                    _fieldOwned[x, y] = true;
                    _fieldOwned[x, y + 1] = true;
                    _fieldOwned[x + 1, y + 1] = true;
                    _correctMove=true;
                    break;
            }
            return;
        }

        public void SetOwned(Int32 x, Int32 y, bool l)
        {
            if (x < 0 || x >= _fieldOwned.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(x), "The X coordinate is out of range.");
            if (y < 0 || y >= _fieldOwned.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(y), "The Y coordinate is out of range.");

            _fieldOwned[x, y] = l;
        }

        public static implicit operator BlockDocuTable((BlockDocuTable, BlockDocuTable) v)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}