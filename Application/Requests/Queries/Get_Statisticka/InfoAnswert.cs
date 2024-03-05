using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Statisticka
{
    public partial class Statisticka_Get
    {
        public class InfoAnswert
        {
            public int Count { get; set; }
            public string Name_QuestionVariant { get; set; }
        }
    }
}
