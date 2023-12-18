using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.MAUI.ViewModel
{
    public class GameSizeViewModel : ViewModelBase
    {
        private TableSize _size;

        public TableSize Size
        {
            get => _size;
            set
            {
                _size = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SizeText));
            }
        }

        public string SizeText => _size.ToString();
    }
}
