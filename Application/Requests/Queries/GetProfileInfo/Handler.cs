using Application.Global_Models;
using Application.Service.Token;
using Application.Service.URL_API;
using Application.Service;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application.Requests.Queries.GetProfileInfo
{
    public partial class ProfileInfo_Get
    {
        public class Handler : IRequestHandler<Query, View_Model>
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

            public async Task<View_Model> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.GetProfileInfo(request.BaseQueryModel.Token);
                    var credentials = authURLs.Credentials();
                    QueryDataGet queryDataGet = new QueryDataGet()
                    {
                        URL = url,
                        Credentials = credentials
                    };

                    var queryResponse = await _globalQuery.GetAsync(queryDataGet);
                    var jsonObj = JsonConvert.DeserializeObject<View_Model>(queryResponse);

                    if (jsonObj.ErrorCode == EnErrorCode.Expired_token)
                    {
                       var token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                        request.BaseQueryModel.Token = token.Token;
                        return await Handle(request, cancellationToken);
                    }
                    return jsonObj;
                }
                catch (Exception ex)
                {
                    var addlincense = new View_Model()
                    {
                        ErrorCode = EnErrorCode.Expired_token,
                        ErrorMessage = ex.Message,
                    };
                    return addlincense;
                }
            }
        }
    }
}
