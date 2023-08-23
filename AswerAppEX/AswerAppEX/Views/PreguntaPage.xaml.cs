using AswerAppEX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AswerAppEX.Models;

namespace AswerAppEX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntaPage : ContentPage
    {
        PreguntaViewModel viewModel;
        public PreguntaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PreguntaViewModel();

        }

        private async void BtnAdd_Clicked(object sender, EventArgs p)
        {
            bool R = await viewModel.AddAskAsync(TxtDate.Text.Trim(), TxtAsk.Text.Trim(), TxtImageURL.Text.Trim(), TxtAskDetail.Text.Trim());
            if (R)
            {
                await DisplayAlert(":)", "Ask Create OK!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Somenthig went wrong... ", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}