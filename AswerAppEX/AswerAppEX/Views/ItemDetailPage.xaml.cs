using AswerAppEX.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AswerAppEX.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}