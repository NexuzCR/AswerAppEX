using AswerAppEX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AswerAppEX
{
    public static class GlobalObject
    {

        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

         //objeto global de usuario
        public static UserDTO MyLocalUserDTO = new UserDTO();
        public static User MyLocalUser = new User();
    }
}
