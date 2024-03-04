using Application.Global_Models;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Commands.AddLincense
{
    public partial class Lincense_Add
    {
        public class View_Response : BaseResponse

        {
            public Guid ID { get; set; }
            public int CompanyOID { get; set; }
          
            public string ActivationCode { get; set; }
            public DateTime Lincense_Activated { get; set; }
            public LicenseStatus License_Status { get; set; }

            public string? Device_Name { get; set; }

        
        }
    }
}
