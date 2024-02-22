namespace Roticeria.Views;

public partial class PaginaInicio : ContentPage
{
	public PaginaInicio()
	{
		InitializeComponent();
	}

    private async  void Comidas_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InicioApp());
      

    }

    
}