using Application.Global_Models;
using MediatR;

namespace Application.Requests.Queries.Get_Lincense
{
    public partial class Lincense
    {
        public class Query :  IRequest<View_Model_Lincense>
        {
            public  Guid ID { get;  }
            public BaseQueryModel BaseQueryModel { get; set; }
            public Query(Guid id, BaseQueryModel baseQueryModel)
            {
                ID = id;
                BaseQueryModel = baseQueryModel;
            }
        }
    }
}
