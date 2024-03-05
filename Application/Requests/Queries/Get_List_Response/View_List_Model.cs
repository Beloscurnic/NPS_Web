using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Response
{
    public partial class List_Response_Get
    {
        public class View_List_Model: ResponseModel
        {
            public IList<View_List_Model> view_Model_Responses { get; set; }
        }
    }
}
