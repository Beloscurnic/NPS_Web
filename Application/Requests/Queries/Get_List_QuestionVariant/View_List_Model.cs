using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_QuestionVariant
{
    public partial class List_QuestionVariant_Get
    {
        public class View_List_Model: ResponseModel
        {
            public IList<View_Model> View_Model { get; set; }
        }
    }
}
