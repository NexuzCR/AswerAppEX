using AswerAppEX.Models;
using AswerAppEX.Services;
using AswerAppEX.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AswerAppEX
{
    public partial class App : Application
    {
        public static User CurrentUser { get; internal set; }

        public App()
        {
            InitializeComponent();

           // DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new BienvenidoPage());
            //MainPage = new AppShell();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
