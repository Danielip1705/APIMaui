using Apiprueba.Models.utils;
using DAL;
using ENT;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Apiprueba.Models
{
    public class PersonaVM : INotifyPropertyChanged
    {
        public ObservableCollection<Personas> listaPersonas { get; set; }
        public DelegateCommand crearPersonaCommand { get; }

        public PersonaVM()
        {
            crearPersonaCommand = new DelegateCommand(createPersonaExecute);
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
            await Shell.Current.GoToAsync("//CrearPage"); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}