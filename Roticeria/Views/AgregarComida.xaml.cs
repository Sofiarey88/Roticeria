using Roticeria.Modelos;
using Roticeria.Repositories;

namespace Roticeria.Views;

public partial class AgregarComida : ContentPage
{
    RepositoryComida repositoryComida = new RepositoryComida();

	public AgregarComida()
	{
		InitializeComponent();
	}

    private  async void GuardarBtn_Clicked(object sender, EventArgs e)
    {
        Comida nuevaComida = new Comida()
        {
            nombre = txtNombre.Text,
            ingredientes = txtIngredientes.Text,
            precio = Convert.ToInt32(txtPrecio.Text),
            puntaje = Convert.ToInt32(txtPuntaje.Text),
            portada_url = txtPortadaUrl.Text,
        };
       

        //enviamos por POST el objeto que creamos a la URL de la API
        var roticeria = await repositoryComida.AddAsync(nuevaComida);


        if (roticeria)
        {
            await DisplayAlert("Notificación", "Comida guardado", "OK");
            await Navigation.PopAsync();
        }
    }

    private async  void CancelarBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}