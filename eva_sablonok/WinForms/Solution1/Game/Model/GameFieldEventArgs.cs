using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    public class GameFieldEventArgs : EventArgs
    {
        private int _changedFieldX;
        private int _changedFieldY;

        public int X { get { return _changedFieldX; } }

        public int Y { get { return _changedFieldY; } }

        public GameFieldEventArgs(int x, int y)
        {
            _changedFieldX = x;
            _changedFieldY = y;
        }

    }
}
