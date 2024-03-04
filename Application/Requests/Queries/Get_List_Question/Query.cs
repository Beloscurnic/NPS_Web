using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Question
{
    public partial class List_Question_Get
    {
        public class Query: IRequest<View_List_Model>
        {
            public int OprostnikID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
