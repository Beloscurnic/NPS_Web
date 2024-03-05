using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class CommandAnswert
        {
            public List<int> Response_Question_ID { get; set; }
            public int QuestionID { get; set; }
        }
    }
}
