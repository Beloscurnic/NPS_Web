﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.URL_API
{
    public class URL_Admin_NPS
    {
        private static string domen = "";
        public string Credentials()
        {
            return "";
        }
        //POST
        public string AuthorizeUser()
        {
            return "/ISAuthService/json/AuthorizeUser";
        }
        //GET
        public string RefreshToken(string Token)
        {
            return "/ISAuthService/json/RefreshToken?Token=" + Token;
        }
        #region LinceseController
        //GET
        public string Get_List_Lincenses(string token)
        {
            return $"{domen}/Lincense/Get_List_Lincenses?token={token}";
        }

        //GET
        public string Get_Lincense(Guid ID_Lincense, string token)
        {
            return $"{domen}/Lincense/Get_Lincense?token={token}&ID_Lincense={ID_Lincense}";
        }

        //POST
        public string Creat_Lincense()
        {
            return domen + "/Lincense/Creat_Lincense";
        }

        //DELET
        public string Delet_Lincense(Guid ID_Lincense, string token)
        {
            return $"{domen}/Lincense/Delet_Lincense?token={token}&ID_Lincense={ID_Lincense}";
        }

        //PUT
        public string Update_Lincense_Status()
        {
            return domen + "/Lincense/Update_Lincense_Status";
        }
        #endregion

        #region GrupQuestion
        //GET
        public string Get_List_GroupQuestionnaire(string token)
        {
            return $"{domen}/GroupQuestionnaire/Get_List_GroupQuestionnaire?token={token}";
        }

        //GET
        public string Get_GroupQuestionnaire(Guid ID_lincense, string token)
        {
            return $"{domen}/GroupQuestionnaire/Get_GroupQuestionnaire?token={token}&ID_lincense={ID_lincense}";
        }

        //POST
        public string Creat_GroupQuestionnaire()
        {
            return domen + "/GroupQuestionnaire/Creat_GroupQuestionnaire";
        }

        //DELET
        public string Delet_GroupQuestionnaire(int ID_GroupQuestionnaire, string token)
        {
            return $"{domen}/GroupQuestionnaire/Delet_GroupQuestionnaire?token={token}&ID_GroupQuestionnaire={ID_GroupQuestionnaire}";
        }
        #endregion

        #region OprostnikController
        //GET 
        public string Check_Version_Oprostnik(int OprostnikId, DateTime Data_Use_Oprosnik, string token)
        {
            return $"{domen}/Oprostnik/Check_Version_Oprostnik?token={token}&OprostnikId={OprostnikId}&Data_Use_Oprosnik={Data_Use_Oprosnik}";
        }

        //GET
        public string Get_List_Oprostnik(string token)
        {
            return $"{domen}/Oprostnik/Get_List_Oprostnik?token={token}";
        }

        //GET
        public string Get_Oprostnik(int ID_Oprostnik, string token)
        {
            return $"{domen}/Oprostnik/Get_Oprostnik?token={token}&ID_Oprostnik={ID_Oprostnik}";
        }

        //POST
        public string Upsert_Oprostnik()
        {
            return domen + "/Oprostnik/Upsert_Oprostnik";
        }

        //DELET
        public string Delet_Oprostnik(int ID_Oprostnik, string token)
        {
            return $"{domen}/Oprostnik/Delet_Oprostnik?token={token}&ID_Oprostnik={ID_Oprostnik}";
        }
        #endregion

        #region Question
        //GET
        public string GetListQuestion(int OprostnikID, string token)
        {
            return $"{domen}/Question/GetListQuestion?token={token}&OprostnikID={OprostnikID}";
        }

        //GET
        public string GetQustion(int Question_ID, string token)
        {
            return $"{domen}/Question/GetQustion?token={token}&Question_ID={Question_ID}";
        }

        //POST
        public string UpsertQuestion()
        {
            return domen + "/Question/UpsertQuestion";
        }

        //DELET
        public string Delet_Question(int Question_ID, string token)
        {
            return $"{domen}/Question/Delet_Question?token={token}&Question_ID={Question_ID}";
        }

        //PUT
        public string Update_Status_Question(int QuestionID)
        {
            return $"{domen}/Question/Update_Status_Question?QuestionID={QuestionID}";
        }
        #endregion

        #region QuestionVariant
        //GET 
        public string GetListQuestionVariant(int QuestionID, string token)
        {
            return $"{domen}/QuestionVariant/GetListQuestionVariant?token={token}&QuestionID={QuestionID}";
        }

        //GET 
        public string GetQuestionVariant(int QuestionVariant_ID, string token)
        {
            return $"{domen}/QuestionVariant/GetQuestionVariant?token={token}&QuestionVariant_ID={QuestionVariant_ID}";
        }

        //POST
        public string UpsertQuestionVariant()
        {
            return $"{domen}/QuestionVariant/UpsertQuestionVariant";
        }

        //PUT
        public string UpdateStatusQuestionVariant(int QuestionVariant_ID, int oprostnikid, string token)
        {
            return $"{domen}/QuestionVariant/UpdateStatusQuestionVariant?token={token}&QuestionVariant_ID={QuestionVariant_ID}&oprostnikid={oprostnikid}";
        }

        //DELETE
        public string DeleteQuestionVariant(int QuestionVariantID, int oprostnikID, string token)
        {
            return $"{domen}/QuestionVariant/DeleteQuestionVariant?token={token}&QuestionVariantID={QuestionVariantID}&oprostnikID={oprostnikID}";
        }
        #endregion
    }
}