using Client.Models;

namespace Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Resources.Add("Base64ToImageConverter", new Base64ToImageConverter());
            MainPage = new AppShell();
        }
    }
}
