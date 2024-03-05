using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class View_Response: BaseResponse
        {
            public int ResponseID { get; set; }
            public DateTime? Data_Creat_Response { get; set; }
            public IList<ViewAnswertResponse>? Answers { get; set; } 
            public int OprostnikID { get; set; }
        }
    }
}
