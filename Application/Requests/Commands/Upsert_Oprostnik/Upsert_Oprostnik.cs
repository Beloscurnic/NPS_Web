using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Oprostnik
{
    public partial class Oprostnik_Upsert
    {
        public class Upsert_Oprostnik
        {
            public int? OprostnikID { get; set; }
            public int? GroupQuestionnaireID { get; set; }
            public DateTime? DateRedaction { get; set; }
            public string Token { get; set; }
        }
    }
}
