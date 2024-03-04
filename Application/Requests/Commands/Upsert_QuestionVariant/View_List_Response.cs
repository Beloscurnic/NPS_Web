using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVariant_Upsert
    {
        public class View_List_Response: BaseResponse
        {
            public IList<View_Response> ResultsResponse { get; set; }
        }
    }
}
