using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Model
{
    public class BlockDocuEventArgs : EventArgs
    {
        private Int32 _points;

        public Int32 Points { get { return _points; } }

        public BlockDocuEventArgs(Int32 Points)
        {
            _points = Points;
        }

    }
}
