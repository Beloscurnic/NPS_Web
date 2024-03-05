using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Response
{
    public partial class Response_Get
    {
        public class View_Model: ResponseModel
        {
            public int ResponseID { get; set; }
            public int CompanyOID { get; set; }
            public DateTime? Data_Creat_Response { get; set; }
            public IList<Answer_Model>? Answers { get; set; }
            public int OprostnikID { get; set; }
        }
    }
}
