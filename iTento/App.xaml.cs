using iTento.Views;
using Xamarin.Forms;

namespace iTento
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ViewModels.Services.IMessageService, Views.Services.MessageService>();

            MainPage = new Home();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
