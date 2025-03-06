using APIMaui.Models;

namespace APIMaui.Vistas;

public partial class Listado : ContentPage
{
	private PersonaVM vm;
	public Listado()
	{
        InitializeComponent();
		vm = new PersonaVM();
		BindingContext = vm;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        vm.CargarPersonas(); // Llama al método del ViewModel
    }
}