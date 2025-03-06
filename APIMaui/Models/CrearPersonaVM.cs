using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using ENT;
using System.Text;
using System.Threading.Tasks;
using APIMaui.Models.utils;


namespace APIMaui.Models
{
    public class CrearPersonaVM : ClsNotify
    {
        private string nombre;
        private string direccion; 
        public DelegateCommand crearPersonaCommand { get; set; }
        public DelegateCommand volver { get; set; }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; 
                NotifyPropertyChanged("Nombre");
                crearPersonaCommand.RaiseCanExecuteChanged(); 
            }
        }
        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                NotifyPropertyChanged("Direccion");
                crearPersonaCommand.RaiseCanExecuteChanged();
            }
        }

        public CrearPersonaVM()
        {
            crearPersonaCommand = new DelegateCommand(createPersonaExecute, canExecute);
            volver = new DelegateCommand(volverExecute);
        }


        private async void createPersonaExecute()
        {
            List<Personas> lista = await ManejadoraAPI.getPersonas();
            int id = lista.Count + 1;
            Personas persona = new Personas(id, nombre, direccion);
            await ManejadoraAPI.insertarPersona(persona);
            await Application.Current.MainPage.DisplayAlert("Persona creada", "La persona ha sido creada correctamente", "Aceptar");
            nombre = "";
            direccion = "";
            NotifyPropertyChanged("Nombre");
            NotifyPropertyChanged("Direccion");
        }
        private bool canExecute()
        {
            return !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(direccion);
        }

        private async void volverExecute()
        {
            await Shell.Current.GoToAsync("//Listado");
        }
    }
}
