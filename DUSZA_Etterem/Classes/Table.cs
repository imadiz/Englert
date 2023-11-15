using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DUSZA_Etterem.Classes
{
    /// <summary>
    /// Egy foglalható asztal adatai.
    /// </summary>
    public class Table : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int _id;//Azonosító
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private int _tableplaces;//Asztali férőhelyek
        public int TablePlaces
        {
            get=> _tableplaces;
            set
            {
                _tableplaces = value;
                OnPropertyChanged();
            }
        }

        private bool _isoutside;//Kültéri-e
        public bool IsOutside
        {
            get => _isoutside;
            set
            {
                _isoutside = value;
                OnPropertyChanged();
            }
        }
    }
}
