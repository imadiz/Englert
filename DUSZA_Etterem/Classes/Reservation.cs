using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DUSZA_Etterem.Classes
{
    public class Reservation
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string _guestname = "";
        public string Guest_Name
        {
            get => _guestname;
            set
            {
                _guestname = value;
                OnPropertyChanged();
            }
        }

        private bool _isrenounce = false;
        public bool IsRenounce
        {
            get => _isrenounce;
            set
            {
                _isrenounce = value;
                OnPropertyChanged();
            }
        }

        private DateTime _start;
        public DateTime Start
        {
            get=> _start;
            set
            {
                _start = value;
                OnPropertyChanged();
            }
        }

        private DateTime _end;
        public DateTime End
        {
            get => _end;
            set
            {
                _end = value;
                OnPropertyChanged();
            }
        }

        private int _chaircount;
        public int ChairCount
        {
            get => _chaircount;
            set
            {
                _chaircount = value;
                OnPropertyChanged();
            }
        }

        private List<Table> _tableids = new List<Table>();
        public List<Table> TableIds
        {
            get => _tableids;
            set
            {
                _tableids = value;
                OnPropertyChanged();
            }
        }
    }
}
