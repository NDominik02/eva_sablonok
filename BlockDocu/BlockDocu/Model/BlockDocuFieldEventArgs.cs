﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Model
{
    public class BlockDocuFieldEventArgs : EventArgs
    {
        private Int32 _changedFieldX;
        private Int32 _changedFieldY;

        /// <summary>
        /// Megváltozott mező X koordinátájának lekérdezése.
        /// </summary>
        public Int32 X { get { return _changedFieldX; } }

        /// <summary>
        /// Megváltozott mező Y koordinátájának lekérdezése.
        /// </summary>
        public Int32 Y { get { return _changedFieldY; } }

        /// <summary>
        /// Sudoku mező eseményargumentum példányosítása.
        /// </summary>
        /// <param name="x">Megváltozott mező X koordinátája.</param>
        /// <param name="y">Megváltozott mező Y koordinátája.</param>
        public BlockDocuFieldEventArgs(Int32 x, Int32 y)
        {
            _changedFieldX = x;
            _changedFieldY = y;
        }

    }
}
