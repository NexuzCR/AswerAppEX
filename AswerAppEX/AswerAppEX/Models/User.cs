using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AswerAppEX.Models
{
    public class User
    {
        public RestRequest Request { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPasword { get; set; }
        public string StrikeCount { get; set; }
        public string BackUpEmail { get; set; }
        public string JobDescription { get; set; }
        public string UserStatusID { get; set; }
        public string CountryID { get; set; }
        public string UserRoleID { get; set; }

        public async Task<ObservableCollection<User>> GetUserListByUserID()
        {
            try
            {

                string RouteSufix = string.Format("Users/GetUserListByUser?id={0}", this.UserID);
                //armamos la ruta completa al endpoint en el api

                string URL = Services.ApiConetion.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos el mecanismo de seguridad, en este caso api key 
                Request.AddHeader(Services.ApiConetion.ApiKeyName, Services.ApiConetion.ApiKeyValue);

                Request.AddHeader(GlobalObject.ContentType, GlobalObject.MimeType); ;
                //ejecutamos la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {


                    var list = JsonConvert.DeserializeObject<ObservableCollection<User>>(response.Content);


                    return list;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            } 
        
        }

            public async Task<ObservableCollection<User>> GetAskListByID()
            {
                try
                {
                    string RouteSufix = string.Format("Asks/GetAskListByID?id={0}");



                    //armamos la ruta completa al endpoint en el API



                    string URL = Services.ApiConetion.ProductionPrefixURL + RouteSufix;
                    //http://192.168.100.146:45455/api/Users/ValidateLogin?username=issac%40gmail.com&password=123



                    RestClient client = new RestClient(URL);



                    Request = new RestRequest(URL, Method.Get);



                    //agregamos mecanismo de seguridad, en este caso API key
                    Request.AddHeader(Services.ApiConetion.ApiKeyName, Services.ApiConetion.ApiKeyValue);
                    Request.AddHeader(GlobalObject.ContentType, GlobalObject.MimeType);



                    //ejecutar la llamada al API 
                    RestResponse response = await client.ExecuteAsync(Request);



                    //saber si las cosas salieron bien
                    HttpStatusCode statusCode = response.StatusCode;



                    if (statusCode == HttpStatusCode.OK)
                    {
                        // en el API diseñamos el end point de forma que retorne un list <UserDTO>
                        //pero esta funcion retorna solo un objeto del UserDTO por lo tanto debemos
                        //seleccionar de lsa lista el item con index 0



                        var list = JsonConvert.DeserializeObject<ObservableCollection<User>>(response.Content);



                        return list;
                    }
                    else
                    {
                        return null;
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
