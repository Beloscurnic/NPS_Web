using Application.Global_Models;
using MediatR;
using static Domain.Enums;

namespace Application.Requests.Commands.AddLincense
{
    public partial class Lincense_Add
    {
        public class Command :IRequest<View_Response>
        {
            public int CompanyOID { get; set; }
            public string ActivationCode { get; set; }
            public DateTime Lincense_Activated { get; set; }
            public LicenseStatus License_Status { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }

                public string? Device_Name { get; set; }
           

        }
    }
}
