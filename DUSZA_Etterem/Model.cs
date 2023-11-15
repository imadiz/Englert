using DUSZA_Etterem.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DUSZA_Etterem
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private ObservableCollection<Table> _alltables = new ObservableCollection<Table>();
        public ObservableCollection<Table> AllTables
        {
            get=> _alltables;
            set
            {
                _alltables = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Reservation> _allreservations = new ObservableCollection<Reservation>();
        public ObservableCollection<Reservation> AllReservations
        {
            get => _allreservations;
            set
            {
                _allreservations = value;
                OnPropertyChanged();
            }
        }

        public void ReadSavedFiles()
        {
            //Asztalok beolvasása
            foreach (string row in File.ReadAllLines("asztalok.txt").Skip(1))
            {
                string[] data = row.Trim().Split(';');
                bool isoutside;
                if (data[2] == "K")
                    isoutside = true;
                else
                    isoutside = false;

                AllTables.Add(new Table { Id = Convert.ToUInt16(data[0]), TablePlaces = Convert.ToUInt16(data[1]), IsOutside = isoutside });
            }

            foreach(string row in File.ReadAllLines("foglalasok.txt"))
            {
                string[] data = row.Trim().Split(';');
                bool isrenounce;
                if (data[1].Equals("L"))
                    isrenounce = true;
                else
                    isrenounce = false;

                

                AllReservations.Add(new Reservation
                {
                    Guest_Name = data[0],
                    IsRenounce = isrenounce,
                    Start = Convert.ToDateTime(data[2]),
                    End = Convert.ToDateTime(data[3]),
                    ChairCount = Convert.ToInt32(data[4]),
                    TableIds = 
                    //itt hagytuk abba, valahogy át kell vinni observablecollection-be
                });
            }
        }
    }
}
