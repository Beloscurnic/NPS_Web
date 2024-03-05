using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Check_Version_Oprostnik
{
    public partial class Check_Version_Oprostnik_Get
    {
        public class Query: IRequest<View_Model>
        {
            public int ID_Oprostnik { get; set; }
            public DateTime Data_Used { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
