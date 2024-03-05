using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Statisticka
{
    public partial class Statisticka_Get
    {
        public class View_Model:ResponseModel
        {
            public int QuestionID { get; set; }
            public string? Name_Question { get; set; }
            public IDictionary<int, InfoAnswert>? Questions_Variants { get; set; } 
            public int OprostnikID { get; set; }
        }
    }
}
