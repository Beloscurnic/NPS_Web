using Application.Global_Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Permission
{

    public partial class Permissions_Get
    {
        public class Model_Permissions : BaseResponse
        {
            public string[] Actions { get; set; }
            public bool IsAdministrator { get; set; }
            public Permissions[] Navigations { get; set; }
            public PermissionNavigation[] Permissions { get; set; }
        }
    }
}
