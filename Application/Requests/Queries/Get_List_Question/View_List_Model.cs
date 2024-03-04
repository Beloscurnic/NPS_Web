using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Question
{
    public partial class List_Question_Get
    {
        public class View_List_Model :ResponseModel
        {
            public IList<View_Model > View_Model_List { get; set; }
        }
    }
}
