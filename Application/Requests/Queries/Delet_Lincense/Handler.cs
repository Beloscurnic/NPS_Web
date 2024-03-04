using Application.Global_Models;
using Application.Service;
using Application.Service.Token;
using Application.Service.URL_API;
using MediatR;
using Newtonsoft.Json;
using static Application.Requests.Queries.Get_Lincense.Lincense;

namespace Application.Requests.Commands.Delet_Lincense
{
    public partial class Lincense_Delet
    {
        public class Handler : IRequestHandler<Query, ResponseModel>
        {
            private readonly URL_Admin_NPS authURLs;
            private readonly GlobalQuery _globalQuery;
            private readonly ITokenService _tokenService;

            public Handler(URL_Admin_NPS _authURLs, GlobalQuery globalQuery, ITokenService tokenService)
            {
                authURLs = _authURLs;
                _globalQuery = globalQuery;
                _tokenService = tokenService;
            }

            public async Task<ResponseModel> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.Delet_Lincense(request.ID, request.BaseQueryModel.Token);
                    var credential = "";
                   // var token = _tokenService.Refresh_token(request.Token, request._Delegat);

                    QueryDataGet queryDataGet = new QueryDataGet()
                    {
                        URL = url,
                        Credentials = ""
                    };

                    var queryResponse = await _globalQuery.GetAsync(queryDataGet);
                    var jsonObj = JsonConvert.DeserializeObject<ResponseModel>(queryResponse);

                    if (jsonObj.ErrorCode == 143)
                    {
                        var token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                        request.BaseQueryModel.Token = token.Token;
                        return await Handle(request, cancellationToken) ;
                    }
                    return jsonObj;
                }

                catch (Exception ex)
                {
                    ResponseModel baseResponse = new ResponseModel()
                    {
                        ErrorCode = 143,
                        ErrorMessage = ex.Message,
                    };

                    return baseResponse;
                }
            }
        }
    }

}