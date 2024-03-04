using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Response
    {

        public int ResponseID { get; set; }

        public int CompanyOID { get; set; }
        public DateTime? Data_Creat_Response { get; set; }
        public IList<Answer>? Answers { get; set; }


        public int OprostnikID { get; set; }
        public virtual Oprostnik Oprostnik { get; set; }

    }
}
