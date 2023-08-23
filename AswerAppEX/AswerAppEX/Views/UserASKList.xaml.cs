using AswerAppEX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AswerAppEX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserASKList : ContentPage
    {
        UserViewModel UserViewModel { get; set; }
        public UserASKList()
        {
            InitializeComponent();
            BindingContext = UserViewModel = new UserViewModel();
            LoadUserList();
        }
        private async void LoadUserList()
        {
            LvlList.ItemsSource = await UserViewModel.GetAskAsync(GlobalObject.MyLocalUser.UserID) ;
        }

    }
}