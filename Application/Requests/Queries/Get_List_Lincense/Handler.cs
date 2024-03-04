using Application.Global_Models;
using Application.Service;
using Application.Service.Token;
using Application.Service.URL_API;
using MediatR;
using Newtonsoft.Json;
using static Application.Requests.Queries.Get_Lincense.Lincense;

namespace Application.Requests.Queries.Get_List_Lincense
{

    public partial class List_Lincense_Get {
        public class Handler : IRequestHandler<Query, View_List_Model_Lincense>
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

            public async Task<View_List_Model_Lincense> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.Get_List_Lincenses(request.BaseQueryModel.Token);
                    var credentials = authURLs.Credentials();
                    QueryDataGet queryDataGet = new QueryDataGet()
                    {
                        URL = url,
                        Credentials = credentials
                    };

                    var queryResponse = await _globalQuery.GetAsync(queryDataGet);
                    var jsonObj = JsonConvert.DeserializeObject<View_List_Model_Lincense>(queryResponse);

                    if (jsonObj.ErrorCode == 143)
                    {
                        var token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                        request.BaseQueryModel.Token = token.Token;
                        return await Handle(new Query(request.BaseQueryModel), cancellationToken);
                    }
                    return jsonObj;
                }
                catch (Exception ex)
                {
                    View_List_Model_Lincense baseResponse = new View_List_Model_Lincense()
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