using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DUSZA_Etterem
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private Model _model = new Model();
        public Model Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }
        public ViewModel()
        {
            Model.ReadSavedFiles();
        }
    }
}
