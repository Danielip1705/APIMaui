using APIMaui.Models.utils;
using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
        public DelegateCommand detallesCommand { get; set; }

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
                borrarCommand.RaiseCanExecuteChanged();
                detallesCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }
        public PersonaVM()
        {
            crearPersona = new DelegateCommand(createPersonaExecute);
            actualizarLista = new DelegateCommand(CargarPersonas);
            editarCommand = new DelegateCommand(editarExecute, canEditarPersona);
            borrarCommand = new DelegateCommand(eliminarPersonaExecute,canExecuteEliminar);
            detallesCommand = new DelegateCommand(detallesExecute,canExecuteDetalles);
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

        private async void eliminarPersonaExecute()
        {
            bool confirmado;
            bool eliminar = await Application.Current.MainPage.DisplayAlert(
                       "Eliminar",
                       $"¿Estás seguro que quieres eliminar a {personaSeleccionada.Nombre}?",
                       "Sí",
                       "No"
                   );
            if (eliminar)
            {
                confirmado = await ManejadoraAPI.EliminarPersona(personaSeleccionada.Id);
                if (confirmado)
                {
                    await Application.Current.MainPage.DisplayAlert("Confirmado", "Persona eliminada con exito", "OK");
                    CargarPersonas();
                } else
                {
                    await Application.Current.MainPage.DisplayAlert("ERROR", "No se pudo eliminar a la persona", "vaya :[");
                }
            }
        }

        private bool canExecuteEliminar()
        {
            bool res = false;
            if (personaSeleccionada!=null)
            {
                res = true;
            }
            return res;
        }

        private async void detallesExecute()
        {
            Dictionary<string, object> detalles = new Dictionary<string, object>
            {
                { "DetallesPersona",personaSeleccionada }
            };

            await Shell.Current.GoToAsync("//DetallesPage",detalles);            
        }

        private bool canExecuteDetalles()
        {
            bool res = false;
            if (personaSeleccionada!=null)
            {
                res = true;
            }
            return res;
        }

    }
}
