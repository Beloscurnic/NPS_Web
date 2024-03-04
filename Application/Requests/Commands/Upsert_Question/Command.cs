using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class Command: IRequest<View_List_Response>
        {
            public IList<CommandQuestion> Commands { get; set; } = new List<CommandQuestion>();
            public int OprostnikID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }

        public class CommandQuestion
        {
            public int? QuestionID { get; set; }
            public int? Key { get; set; }
            public bool Insert_before { get; set; }
            public Status_Question IsDeleted { get; set; }
            public TypeQuestion TypeQuestion { get; set; }
            public string? Name_Question { get; set; }     
        }
    }
}
