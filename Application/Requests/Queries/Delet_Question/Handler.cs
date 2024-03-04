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

namespace Application.Requests.Queries.Delet_Question
{
    public partial class Question_Delet {
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
                    var url = authURLs.Delet_Question(request.IdQuestion, request.BaseQuery.Token);
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
                        var token = _tokenService.Refresh_token(request.BaseQuery.Token, request.BaseQuery._Delegat);
                        request.BaseQuery.Token = token.Token;
                        return await Handle(request, cancellationToken);
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