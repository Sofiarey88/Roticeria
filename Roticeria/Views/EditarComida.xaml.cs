using Roticeria.Modelos;
using Roticeria.Repositories;

namespace Roticeria.Views;

public partial class EditarComida : ContentPage
{
    RepositoryComida repositoryComida = new RepositoryComida();
    public Comida ComidaSeleccionada { get; }

    public EditarComida()
    {
        InitializeComponent();
    }

    public EditarComida(Comida comidaSeleccionada)
    {
        InitializeComponent ();
        ComidaSeleccionada = comidaSeleccionada;
        CargarDatosEnPantalla();
    }

    private void CargarDatosEnPantalla()
    {
        txtNombre.Text = ComidaSeleccionada.nombre;
        txtIngredientes.Text = ComidaSeleccionada.ingredientes;
        txtPrecio.Text = ComidaSeleccionada.precio.ToString();
        txtPuntaje.Text = ComidaSeleccionada.puntaje.ToString();
        txtPortadaUrl.Text = ComidaSeleccionada.portada_url;
    }

    private async void GuardarBtn_Clicked(object sender, EventArgs e)
    {
        Comida nuevaComida = new Comida()
        {
            _id = ComidaSeleccionada._id,
            nombre = txtNombre.Text,
            ingredientes = txtIngredientes.Text,
            precio = Convert.ToInt32(txtPrecio.Text),
            puntaje = Convert.ToInt32(txtPuntaje.Text),
            portada_url = txtPortadaUrl.Text,
        };


        //enviamos por POST el objeto que creamos a la URL de la API
        var roticeria = await repositoryComida.UpdateAsync(nuevaComida);


        if (roticeria)
        {
            await DisplayAlert("Notificación", "Comida guardado", "OK");
            await Navigation.PopAsync();
        }
    }


    private async void CancelarBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}