using Firebase.Auth.Providers;
using Firebase.Auth;
using Microsoft.Extensions.Logging;

namespace Roticeria
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyAG2a64Un5gcNaSrHdS3NmQKsEgmOQ1tj4",
                AuthDomain = "fir-autenticacion-262a8.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
          {
                new EmailProvider()
          }
            }));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}