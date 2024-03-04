using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_GroupQuestionnaire
{
    public partial class List_GroupQuestionnaire_Get
    {
        public class View_List_Model_GroupQuestionnaire : ResponseModel
        {
            public IList<View_Model_GroupQuestionnaire> View_Model_GroupQuestionnaire { get; set; }
        }
    }
}
