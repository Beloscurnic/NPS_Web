using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Lincense
{
    public partial class List_Lincense_Get
    {
        public class View_List_Model_Lincense: ResponseModel
        {
            public IList<View_Model_Lincese> view_List_Model_Lincense { get; set; }
        }
    }
}
