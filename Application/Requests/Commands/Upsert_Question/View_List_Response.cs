using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class View_List_Response : BaseResponse
        {
            public IList<View_Response> List_Response { get; set; } 
        }
    }
}
