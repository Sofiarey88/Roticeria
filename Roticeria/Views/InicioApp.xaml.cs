using Roticeria.Modelos;
using Roticeria.Repositories;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Roticeria.Views;

public partial class InicioApp : ContentPage
{
    public ObservableCollection<Comida> Comidas { get; set; }
    public Comida ComidaSeleccionada { get; set; }
    RepositoryComida repositoryComidas = new RepositoryComida();
    
    public InicioApp()
    {
        InitializeComponent();
        Comidas = new ObservableCollection<Comida>();
        ComidasCollectionView.SelectionChanged += SeleccionarComida;
    }

    private void SeleccionarComida(object sender, SelectionChangedEventArgs e)
    {
        if (ComidasCollectionView.SelectedItems != null)
        {
            ComidaSeleccionada = (Comida)ComidasCollectionView.SelectedItem;
        }
    }

    public async void GetAllComidas(object sender, EventArgs e)
    {
        Comidas = await repositoryComidas.GetAllAsync();
        ComidasCollectionView.ItemsSource = Comidas;
    }

    private void SeleccionarComidaEnCollectionView()
    {
        foreach (var comida in Comidas)
        {
            if (comida._id == ComidaSeleccionada._id)
            {
                ComidasCollectionView.SelectedItem = comida;
                break;
            }
        }
    }

    protected override void OnAppearing()
    {
        NetworkAccess conexionInternet = Connectivity.Current.NetworkAccess;

        if (conexionInternet == NetworkAccess.Internet)
        {
            GetAllComidas(this, EventArgs.Empty);
        }

    }
    protected override bool OnBackButtonPressed()
    {
        Debug.Print(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> se ha pulsado el botón de atrás");
        return false;
    }
    protected override void OnDisappearing()
    {
        Debug.Print(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> se ha cerrado la ventana de la lista de películas");
    }
   
   

   

   
    

    private async void EditarComida_Clicked(Object sender, EventArgs e)
    {
        if (ComidaSeleccionada != null)
        {
            await Navigation.PushAsync(new EditarComida(ComidaSeleccionada));
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Editar", "Error: debe seleccionar la comida a editar", "ok");
        }
    }

    private async void EliminarComida_Clicked_1(object sender, EventArgs e)
    {
        if (ComidaSeleccionada != null)
        {
            ComidaSeleccionada = (Comida)ComidasCollectionView.SelectedItem;
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Eliminar",
                $"¿Está seguro que desea borrar la comida: {ComidaSeleccionada.nombre}?", "Si", "No");
            if (respuesta)
            {
                var eliminado = await repositoryComidas.RemoveAsync(ComidaSeleccionada._id);
                if (eliminado)
                {
                    await Application.Current.MainPage.DisplayAlert("Eliminar",
                        $"Se ha eliminado la comida: {ComidaSeleccionada.nombre} correctamente", "Ok");
                    GetAllComidas(this, EventArgs.Empty);
                }
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Eliminar",
                "Error: debe seleccionar la comida que desea borrar", "Ok");
        }
    }

    private async void AgregarComida_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarComida());
    }
}