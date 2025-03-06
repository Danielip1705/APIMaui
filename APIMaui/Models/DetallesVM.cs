using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMaui.Models.utils;
using ENT;

namespace APIMaui.Models
{
    [QueryProperty(nameof(PersonaDetalles),"DetallesPersona")]
    public class DetallesVM : ClsNotify
    {
        private Personas persona;
        public DelegateCommand volverCommand {  get; set; }

        public Personas PersonaDetalles
        {
            get { return persona; }
            set { persona = value;
                NotifyPropertyChanged("PersonaDetalles");
            }
        }
        public DetallesVM() 
        {
            volverCommand = new DelegateCommand(volverExecute);
        }

        private async void volverExecute()
        {
            await Shell.Current.GoToAsync("//Listado");
        }

    }
}
