using APIMaui.Models.utils;
using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace APIMaui.Models
{
    public class PersonaVM : INotifyPropertyChanged
    {
        public ObservableCollection<Personas> listaPersonas { get; set; }
        private DelegateCommand crearPersona;

        public DelegateCommand CrearPersona
        {
            get { return crearPersona; }
         
        }




        public PersonaVM()
        {
            crearPersona = new DelegateCommand(createPersonaExecute);
            CargarPersonas();
        }


        public async Task CargarPersonas()
        {
            List<Personas> lista = await ManejadoraAPI.getPersonas();
            listaPersonas = new ObservableCollection<Personas>(lista);
            NotifyPropertyChanged("listaPersonas");
        }

        private async void createPersonaExecute()
        {
           await Shell.Current.GoToAsync("//CreatePage");
        }
        private bool canExecutePersona()
        {
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
