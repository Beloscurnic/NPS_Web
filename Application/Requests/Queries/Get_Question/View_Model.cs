using Application.Global_Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Queries.Get_Question
{
    public partial class Question_Get
    {
        public class View_Model: ResponseModel
        {
            public int QuestionID { get; set; }
            public int Key { get; set; }
            public Status_Question isDeleted { get; set; }
            public TypeQuestion TypeQuestion { get; set; }
            public string Name_Question { get; set; }
            public IList<Questions_Variant> Questions_Variants { get; set; }
            public int? OprostnikID { get; set; }
        }
    }
}
