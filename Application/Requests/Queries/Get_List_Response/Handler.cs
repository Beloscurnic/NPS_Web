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

namespace Application.Requests.Queries.Get_List_Response
{
    public partial class List_Response_Get
    {
        public class Handler : IRequestHandler<Query, View_List_Model>
        {
            // private readonly URL_Admin_NPS authURLs;
            private readonly URL_User_NPS user_NPS;
            private readonly GlobalQuery _globalQuery;
            private readonly ITokenService _tokenService;
            public Handler(URL_User_NPS _User_NPS, GlobalQuery _GlobalQuery, ITokenService tokenService)
            {
                user_NPS = _User_NPS;
                _globalQuery = _GlobalQuery;
                _tokenService = tokenService;
            }

            public async Task<View_List_Model> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = user_NPS.GetListResponse(request.ID_Oprostnik, request.BaseQueryModel.Token);
                    var credentials = user_NPS.Get_Credential();
                    QueryDataGet queryDataGet = new QueryDataGet()
                    {
                        URL = url,
                        Credentials = credentials
                    };

                    var queryResponse = await _globalQuery.GetAsync(queryDataGet);
                    var jsonObj = JsonConvert.DeserializeObject<View_List_Model>(queryResponse);

                    if (jsonObj.ErrorCode == 143)
                    {
                        var token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                        request.BaseQueryModel.Token = token.Token;
                        return await Handle(new Query
                        {
                            ID_Oprostnik = request.ID_Oprostnik,
                            BaseQueryModel = request.BaseQueryModel
                        }, cancellationToken);
                    }
                    return jsonObj;
                }
                catch (Exception ex)
                {
                    View_List_Model baseResponse = new View_List_Model()
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