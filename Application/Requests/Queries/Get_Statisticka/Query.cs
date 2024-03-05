using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Statisticka
{
    public partial class Statisticka_Get
    {
        public class Query: IRequest<View_Model>
        {
            public int Oprostnik_ID { get; set; }
            public int QuestionID { get; set; }
            public DateTime? Data_Start { get; set; }
            public DateTime? Data_End { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
