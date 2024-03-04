using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Oprostnik
{
    public partial class Oprostnik_Get
    {
        public class Query:  IRequest<View_Model_Oprostnik>
        {
            public int  ID_Oprostnik {get; set;}
            public BaseQueryModel BaseQueryModel { get; set;}
        }
    }
}
