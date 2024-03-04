using Application.Service.URL_API;
using Application.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Commands.Authorize_User.User_Authorize;
using Application.Global_Models;
using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;

namespace Application.Requests.Queries.Get_Permission
{
    public partial class Permissions_Get
    {
        public class Handler : IRequestHandler<Query, View_Model_Permissions>
        {
            private readonly URL_Admin_NPS authURLs;
            private readonly GlobalQuery GlobalQuery;
            public Handler(URL_Admin_NPS _authURLs, GlobalQuery _GlobalQuery)
            {
                authURLs = _authURLs;
                GlobalQuery = _GlobalQuery;
            }

            public async Task<View_Model_Permissions> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.Security_GetPermission(request.Token);
                    var Credentials = authURLs.Credentials();

                    QueryDataGet queryDataGet = new QueryDataGet()
                    {
                        URL = url,
                        Credentials = Credentials
                    };

                    var queryResponse = await GlobalQuery.GetAsync(queryDataGet);
                    var jsonObj = JsonConvert.DeserializeObject<View_Model_Permissions>(queryResponse);

                    return jsonObj;
                }
                catch (Exception ex)
                {
                 //   _logger.Error(ex, ex.Message);

                    View_Model_Permissions permissionResponse = new View_Model_Permissions()
                    {
                        ErrorCode = Domain.EnErrorCode.Internal_error,
                        ErrorMessage = ex.Message + "|||" + ex.StackTrace,
                    };

                    return permissionResponse;
                }
            }
        }
    }
}
