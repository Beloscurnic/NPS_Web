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
using Domain;

namespace Application.Requests.Commands.ChangeLanguage
{
    public partial class ChangeLanguage
    {
        public class Handler : IRequestHandler<Command, BaseResponse>
        {
            private readonly URL_Admin_NPS authURLs;
            private readonly GlobalQuery GlobalQuery;
            public Handler(URL_Admin_NPS _authURLs, GlobalQuery _GlobalQuery)
            {
                authURLs = _authURLs;
                GlobalQuery = _GlobalQuery;
            }

            public async Task<BaseResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.ChangeUILanguage(request.Token, request.Lang);
                    var credentials = authURLs.Credentials();

                    QueryDataGet queryDataGet = new QueryDataGet()
                    {
                        URL = url,
                        Credentials = credentials
                    };

                    var queryResponse = await GlobalQuery.GetAsync(queryDataGet);
                    var jsonObj = JsonConvert.DeserializeObject<BaseResponse>(queryResponse);

                    return  jsonObj;
                }
                catch (Exception ex)
                {
                  //  _logger.Error(ex, ex.Message);
                    BaseResponse baseResponse = new BaseResponse()
                    {
                        ErrorCode = EnErrorCode.Internal_error,
                        ErrorMessage = ex.Message,
                    };
                    return baseResponse;
                }
            }
        }
    }
}
