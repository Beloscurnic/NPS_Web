using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain
{
    public class Enums
    {
        public enum ExecutionResult
        {
            OK = 1,
            KO = 2,
            ERROR = 3,
            NOTVALID = 4,
            EXCEPTION = 5,
            LOGOUT = 6,
        }
        public enum EUserStatus
        {
            [Display(Name = "Новая регистрация")]
            NewRegistered = 0,
            [Display(Name = "Пользователь активен")]
            Active = 1,
            [Display(Name = "Деактивировано")]
            Disabled = 2,
        }

        public enum EnUiLanguage
        {
            EN = 0,
            RO = 1,
            RU = 2,

        }

        public enum ECompanyStatus
        {
            [Display(Name = "NewRegistered")]
            NewRegistered = 0,
            [Display(Name = "Activated")]
            Active = 1,
            [Display(Name = "Disabled")]
            Disabled = 2,

        }

        public enum EnSecurityPermissionState
        {
            [Display(Name = "Deny")]
            Deny = 0,
            [Display(Name = "ReadOnly")]
            Read_only = 1,
            [Display(Name = "Allow")]
            Allow = 2,
        }

        public enum LicenseStatus : byte
        {
            Active = 0,
            Disabled = 1,
        }
        public enum TypeQuestion : byte
        {
            TrueFalse = 0,
            Question5 = 1,
            Question10 = 2,
            Choose = 3,
            MultiChoose = 4,
        }

        public enum Status_Question : byte
        {
            New = 0,
            Diseible = 1,
            Active = 2,
        }
    }
}
