using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string? Response_QuestionVariant_ID { get; set; }//json


        public int ResponseID { get; set; }
        public virtual Response Response { get; set; }


        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
