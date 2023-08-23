using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AswerAppEX.Models;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Essentials;

namespace AswerAppEX.ViewModels
{
    internal class PreguntaViewModel : BaseViewModel
    {
   
        public ASK MyASK { get; set; }

        public PreguntaViewModel()
        {
            MyASK = new ASK();
        }
        public async Task<bool> AddAskAsync(string pDate,string pAsk,string pImageURL,string pAskDetail)
        {
            if (IsBusy) return false;
            IsBusy = true;

            try
            {

                MyASK = new ASK();

                MyASK.Date = pDate;
                MyASK.Ask = pAsk;
                //MyASK.AskStatusID = pAskStatusID;
                MyASK.ImageURL = pImageURL;
                MyASK.AskDetail = pAskDetail;

                bool R = await MyASK.AddAskAsync();
                return R;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            { IsBusy = false; }
        }


    }
}
