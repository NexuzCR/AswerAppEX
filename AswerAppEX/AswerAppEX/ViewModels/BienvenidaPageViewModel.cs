using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using AswerAppEX.Models;

namespace AswerAppEX.ViewModels
{
    public class BienvenidaPageViewModel : BaseViewModel
    {
        public User myUser { get; set; }
        public BienvenidaPageViewModel()
        { 
            myUser = new User();
        }


        public async Task<ObservableCollection<User>> GetUsersAsync(int pUserID)
        {
            if (IsBusy) return null;
            IsBusy = true;
            try
            {
                ObservableCollection<User> users = new ObservableCollection<User>();
                myUser.UserID = pUserID;
                users = await myUser.GetUserListByUserID();
                if (users == null)

                {
                    return null;

                }
                return users;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
