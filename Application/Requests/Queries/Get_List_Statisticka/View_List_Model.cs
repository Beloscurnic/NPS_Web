using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Queries.Get_List_Statisticka.List_Statisticka_Get;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class List_Statisticka_Get
    {
        public class View_List_Model: ResponseModel
        {
            public IDictionary<int, QuestionInfo>? Questions_Variants { get; set; }
        }
    }
}
