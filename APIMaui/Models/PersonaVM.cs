using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMaui.Models
{
    public class PersonaVM : INotifyPropertyChanged
    {
        public ObservableCollection<Personas> listaPersonas { get; set; }




        public PersonaVM()
        {
            CargarPersonas();
        }


        public async Task CargarPersonas()
        {
            List<Personas> lista = await ManejadoraAPI.getPersonas();
            listaPersonas = new ObservableCollection<Personas>(lista);
            NotifyPropertyChanged("listaPersonas");
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
