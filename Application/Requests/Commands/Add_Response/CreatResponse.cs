using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class CreatResponse
        {
            public IList<CommandAnswert>? Answers { get; set; }
            public int OprostnikID { get; set; }
            public string Token { get; set; }
        }
    }
}
