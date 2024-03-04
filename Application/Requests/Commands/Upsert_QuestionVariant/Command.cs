using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVariant_Upsert
    {
        public class Command
        {
            public int? Questions_VariantID { get; set; }
            public int? Key { get; set; }
            public bool? IsDeleted { get; set; }
            public string Name { get; set; }
        }

        public class Command_List : IRequest<View_List_Response>
        {
            public IList<Command> QuestionVariant_Commands { get; set; }
            public int? QuestionID { get; set; }
            public int? OprostnikID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
