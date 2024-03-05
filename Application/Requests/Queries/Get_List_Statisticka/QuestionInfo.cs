using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Queries.Get_List_Statisticka
{
    public partial class List_Statisticka_Get
    {
        public class QuestionInfo
        {
            public TypeQuestion TypeQuestion { get; set; }
            public string? Name_Question { get; set; } //json
            public IList<Answert_List> Info_ListAnswerts { get; set; }
            public IDictionary<int, Answert_Dictionary>? Info_DictionaryAnswerts { get; set; }
        }
        public class Answert_List
        {
            public int IDAnswert { get; set; }
            public int Count { get; set; }
            public string Name { get; set; }

        }
        public class Answert_Dictionary
        {
            public int Count { get; set; }
            public string Name { get; set; }
        }
    }

}