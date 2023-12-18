using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WPF.ViewModel
{
    public class GameField : ViewModelBase
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Number { get; set; }
        public DelegateCommand? StepCommand { get; set; }
    }
}
