using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Permission
{
    public partial class Permissions_Get
    {
        public class View_Model_Permissions : BaseResponse
        {
            public Model_Permissions Permission { get; set; }
        }
    }
}
