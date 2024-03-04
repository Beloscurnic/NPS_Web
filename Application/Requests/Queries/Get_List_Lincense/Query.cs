using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Lincense
{
    public partial class List_Lincense_Get
    {
        public class Query: IRequest<View_List_Model_Lincense>
        {
            public BaseQueryModel BaseQueryModel { get; set; }
            public Query(BaseQueryModel baseQueryModel)
            {
                BaseQueryModel = baseQueryModel;
            }
        }
    }
}
