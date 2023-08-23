using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AswerAppEX.Models
{
    public class UserDTO
    {
        public RestRequest Request {  get; set; }
        public int IDUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string PrimerNUsuario { get; set; }
        public string UltimoNUduario { get; set; }
        public string Telefono { get; set; }
        public string ContrasenniaUsuario { get; set; }
        public string Errores { get; set; }
        public string COrreoRespaldo { get; set; }
        public string DescripcionTrabajo { get; set; }
        public string IDUsuariEstado { get; set; }
        public string PaisID { get; set; }
        public int RoleUsuarioID { get; set; }

        public async Task<UserDTO> GetUserInfo(string PUser)
        {
            try
            {

                string RouteSufix = string.Format("Users/GetUserInfoByUser?PUser={0}", PUser);
                //armamos la ruta completa al endpoint en el api

                string URL = Services.ApiConetion.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos el mecanismo de seguridad, en este caso api key 
                Request.AddHeader(Services.ApiConetion.ApiKeyName, Services.ApiConetion.ApiKeyValue);

                Request.AddHeader(GlobalObject.ContentType, GlobalObject.MimeType) ;
                //ejecutamos la llamada al api
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //en el api diseñamos el end point de forma que retorne un list<UIserDTO>
                    //peroesta funcion retorna solo un objeto de userDTO por lo tanto
                    //debemos seleccionar de la lista el item con el index 0

                    //esto puede servir para multitud de propocitos donde un api retorna uno o muchos registros
                    //pero nesecitamos solo uno de ellos

                    var list = JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);

                    var item = list[0];
                    return item;
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
