using Application.Global_Models;
using Application.Service;
using Application.Service.Token;
using Application.Service.URL_API;
using MediatR;
using Newtonsoft.Json;

namespace Application.Requests.Queries.Get_Oprostnik
{
    public partial class Oprostnik_Get
    {
        public class Handler : IRequestHandler<Query, View_Model_Oprostnik>
        {
            private readonly URL_Admin_NPS authURLs;
            private readonly GlobalQuery _globalQuery;
            private readonly ITokenService _tokenService;
            public Handler(URL_Admin_NPS _authURLs, GlobalQuery _GlobalQuery, ITokenService tokenService)
            {
                authURLs = _authURLs;
                _globalQuery = _GlobalQuery;
                _tokenService = tokenService;
            }

            public async Task<View_Model_Oprostnik> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.Get_Oprostnik(request.ID_Oprostnik, request.BaseQueryModel.Token);
                    var credentials = authURLs.Credentials();
                    QueryDataGet queryDataGet = new QueryDataGet()
                    {
                        URL = url,
                        Credentials = credentials
                    };

                    var queryResponse = await _globalQuery.GetAsync(queryDataGet);
                    var jsonObj = JsonConvert.DeserializeObject<View_Model_Oprostnik>(queryResponse);

                    if (jsonObj.ErrorCode == 143)
                    {
                        var token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                        request.BaseQueryModel.Token = token.Token;
                        return await Handle(new Query { ID_Oprostnik=request.ID_Oprostnik, BaseQueryModel= request.BaseQueryModel }, cancellationToken);
                    }
                    return jsonObj;
                }
                catch (Exception ex)
                {
                    View_Model_Oprostnik baseResponse = new View_Model_Oprostnik()
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
