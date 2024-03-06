﻿using Application.Global_Models;
using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Queries.GetProfileInfo
{
    public partial class ProfileInfo_Get
    {

        public class View_Model: BaseResponse
        {
            public UserInfo User { get; set; }
            
        }

        public class UserInfo
        {
            public string Company { get; set; }
            public int CompanyID { get; set; }
            public DateTime CreateDate { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public int ID { get; set; }
            public DateTime LastAuthorize { get; set; }
            public string LastAuthorizeIP { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public byte[] Picture { get; set; }
            public EUserStatus Status { get; set; }
            public EnUiLanguage UiLanguage { get; set; }
        }
    }
}