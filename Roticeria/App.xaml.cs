using Firebase.Auth;
using Roticeria.Views;

namespace Roticeria
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PaginaInicio());
        }
    }
}