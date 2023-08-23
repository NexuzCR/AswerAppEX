using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AswerAppEX.Models
{
    public class ASK
    {
        public RestRequest Request { get; set; }    
        public int AskID { get; set; }
        public string Date { get; set; }
        public string Ask { get; set; }
        public int UserID { get; set; }
        //public int AskStatusID { get; set; }
        public bool IsStrike { get; set; }
        public string ImageURL { get; set; }
        public string AskDetail { get; set; }

        public async Task<bool> AddAskAsync()
        {
            try
            {

                string RouteSufix = string.Format("Users");
                //armamos la ruta completa al endpoint en el api

                string URL = Services.ApiConetion.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos el mecanismo de seguridad, en este caso api key 
                Request.AddHeader(Services.ApiConetion.ApiKeyName, Services.ApiConetion.ApiKeyValue);

                //en el caso de una operacion post debemos serializar el objeto para pasarlo como
                //json al api

                string SerealizedModelObject = JsonConvert.SerializeObject(this);
                //Agregamos el objeto serializado en el cuerpo del request
                Request.AddBody(SerealizedModelObject, GlobalObject.MimeType);


                //ejecutamos la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }
    }
}
