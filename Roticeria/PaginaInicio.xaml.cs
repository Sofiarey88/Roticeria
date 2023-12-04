namespace Roticeria;

public partial class InicioApp : ContentPage
{
	public InicioApp()
	{
		InitializeComponent();
        ComidasBtn.Clicked += ComidasBtn_Clicked;

    }

    private void ComidasBtn_Clicked(object sender, EventArgs e)
    {
        ContenidoLbl.Text = "Comidas";

    }
}