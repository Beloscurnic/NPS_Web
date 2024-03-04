using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Oprostnik
{
    public partial class List_Oprostnik_Get
    {
        public class View_List_Model_Oprostnik: ResponseModel
        {
            public IList<View_Model_Oprostnik> ListV_iew_Model_Oprostnik { get; set; }
        }
    }
}
