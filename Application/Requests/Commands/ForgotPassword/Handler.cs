using Application.Global_Models;
using Application.Service;
using Application.Service.URL_API;
using Domain;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.ForgotPassword
{
    public partial class ForgotPas
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
                    var url = authURLs.AuthorizeUser();
                    var credential = "";
                    var json = JsonConvert.SerializeObject(request);

                    QueryDataPost queryDataPost = new QueryDataPost()
                    {
                        JSON = json,
                        URL = url,
                        Credentials = ""
                    };

                    var queryResponse = await GlobalQuery.PostAsync(queryDataPost);
                    return JsonConvert.DeserializeObject<BaseResponse>(queryResponse);
                }
                catch (Exception ex)
                {
                    BaseResponse baseResponse = new BaseResponse()
                    {
                        ErrorCode = EnErrorCode.Internal_error,
                        ErrorMessage = ex.Message
                    };
                    return baseResponse;
                }
            }
        }
    }
}
