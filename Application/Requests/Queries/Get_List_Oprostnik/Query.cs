using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Queries.Get_List_Lincense.List_Lincense_Get;

namespace Application.Requests.Queries.Get_List_Oprostnik
{
    public partial class List_Oprostnik_Get
    {
        public class Query : IRequest<View_List_Model_Oprostnik>
        {
            public BaseQueryModel BaseQueryModel { get; set; }
            public Query(BaseQueryModel baseQueryModel)
            {
                BaseQueryModel = baseQueryModel;
               
            }
        }
    }
}
