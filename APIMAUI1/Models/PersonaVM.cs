using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using APIMAUI1.Models.utils;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENT;

namespace APIMAUI1.Models
{
    public class PersonaVM : ClsNotify
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
            await Shell.Current.GoToAsync("///EditarPage");
        }


    }
}

