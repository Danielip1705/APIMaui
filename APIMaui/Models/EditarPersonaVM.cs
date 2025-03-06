using APIMaui.Models.utils;
using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMaui.Models
{
    [QueryProperty(nameof(PersonaEditar), "editarPersona")]
    public class EditarPersonaVM : ClsNotify
    {
        private Personas personaEditar;
        public DelegateCommand editarPersonaCommand { get; set; }
        public Personas PersonaEditar
        {
            get { return personaEditar; }
            set
            {
                personaEditar = value;
                NotifyPropertyChanged("PersonaEditar");
                editarPersonaCommand.RaiseCanExecuteChanged();
            }
        }
        public EditarPersonaVM()
        {
            editarPersonaCommand = new DelegateCommand(editarPersonaExecute);
        }


        private async void editarPersonaExecute()
        {
            bool res = await ManejadoraAPI.actualizarPersona(personaEditar);
            if (res)
            {
            Application.Current.MainPage.DisplayAlert("Persona actualizada", "La persona ha sido actualizada correctamente", "Aceptar");    
            } else
            {
                Application.Current.MainPage.DisplayAlert("Persona no actualizada", "La persona no se ha podido actualizar", "Aceptar");
            }
        }
    }
}
