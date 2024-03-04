using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.URL_API
{
    public class URL_User_NPS
    {
        private static string domen = "";

        #region Respons
        //GET
        public string GetListResponse(int OprostnikID, string token)
        {
            return $"{domen}/Respons/GetListResponse?token={token}&OprostnikID={OprostnikID}";
        }

        //GET
        public string GetResponse(int Response_ID, string token)
        {
            return $"{domen}/Respons/GetResponse?token={token}&Response_ID={Response_ID}";
        }

        //POST
        public string Add_Response()
        {
            return $"{domen}/Respons/Add_Response";
        }

        //DELETE 
        public string Delete_Response(int Response_ID, string token)
        {
            return $"{domen}/Respons/Delete_Response?token={token}&Response_ID={Response_ID}";
        }
        #endregion

        #region Answert
        //GET
        public string GetAnswert(int answertID, string token)
        {
            return $"{domen}/Answert/GetAnswert?token={token}&answertID={answertID}";
        }

        //DELETE 
        public string Delete_Answert(int answertID, string token)
        {
            return $"{domen}/Answert/Delete_Answert?token={token}&answertID={answertID}";
        }
        #endregion
    }
}
