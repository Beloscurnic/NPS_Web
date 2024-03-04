using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain
{
    public class Lincense
    {
        public Guid LincenseID { get; set; }
        public int CompanyOID { get; set; }
        public virtual GroupQuestionnaire? Group_Questionnaire {get; set;}
        public string ActivationCode { get; set; }
        public DateTime Lincense_Activated {  get; set; }   
        public LicenseStatus License_Status { get; set; }

        public string? Device_Name { get; set; } 
    }
}
