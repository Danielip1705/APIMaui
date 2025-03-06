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
    public class PersonaVM : ClsNotify
    {
        private ObservableCollection<Personas> listaPersonas = new ObservableCollection<Personas>();
        private Personas personaSeleccionada;
        public DelegateCommand crearPersona { get; set; }
        public DelegateCommand actualizarLista { get; set; }
        public DelegateCommand editarCommand { get; set; }
        public DelegateCommand borrarCommand { get; set; }

        public ObservableCollection<Personas> ListaPersonas
        {
            get { return listaPersonas; }
            set
            {
                listaPersonas = value;
                NotifyPropertyChanged("ListaPersonas");
            }
        }
        public Personas PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                editarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }
        public PersonaVM()
        {
            crearPersona = new DelegateCommand(createPersonaExecute);
            CargarPersonas();
            actualizarLista = new DelegateCommand(CargarPersonas);
            editarCommand = new DelegateCommand(editarExecute, canEditarPersona);
        }


        public async void CargarPersonas()
        {
            List<Personas> lista = await ManejadoraAPI.getPersonas();
            listaPersonas.Clear();
            listaPersonas = new ObservableCollection<Personas>(lista);
            NotifyPropertyChanged("ListaPersonas");
        }

        private async void createPersonaExecute()
        {
            await Shell.Current.GoToAsync("//CreatePage");
        }


        private async void editarExecute()
        {
            Dictionary<string, object> editarPersona = new Dictionary<string, object>
            {
                {"editarPersona", personaSeleccionada }
            };

            await Shell.Current.GoToAsync("//EditarPage", editarPersona);

        }

        private bool canEditarPersona()
        {
            bool res = false;
            if (personaSeleccionada != null)
            {
                res = true;
            }
            return res;

        }

    }
}
