using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using AswerAppEX.ViewModels;
using AswerAppEX.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AswerAppEX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BienvenidoPage : ContentPage
    {
        public BienvenidoPage()
        {
            InitializeComponent();
        }
        public class Root
        {
            public int userId { get; set; }

        }

       

        private async void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserList());
            
        }

        private async void BtnAddAsk_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PreguntaPage());
        }

        private async void BtnAskList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserASKList());  
       
        }
    }
}