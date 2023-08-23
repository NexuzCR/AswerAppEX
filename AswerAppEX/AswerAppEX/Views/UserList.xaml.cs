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
    public partial class UserList : ContentPage
    {
        BienvenidaPageViewModel BienvenidaPageViewModel;
        public UserList()
        {
            InitializeComponent();
            BindingContext = BienvenidaPageViewModel = new BienvenidaPageViewModel();
            LoadUserList();
         
        }
        private void LoadUserList()
        {
            //LvList.ItemsSource = await BienvenidaPageViewModel.GetUsersAsync(GlobalObject.MyLocalUser.UserID);
            LblUserName.Text = GlobalObject.MyLocalUserDTO.IDUsuario.ToString();
        }
    }
}