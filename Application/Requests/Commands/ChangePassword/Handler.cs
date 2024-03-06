using Application.Global_Models;
using Application.Service.Token;
using Application.Service.URL_API;
using Application.Service;
using Domain;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Commands.Add_Response.Response_Add;

namespace Application.Requests.Commands.ChangePassword
{
    public partial class Password_Change
    {
        public class Handler : IRequestHandler<Command, BaseResponse>
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

            public async Task<BaseResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.ChangePassword();
                    var credential = "";
                    // var token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                    var addlincense = new ChangePassword_Model
                    {
                        NewPassword = request.NewPassword,
                        OldPassword = request.OldPassword,
                        Token =request.BaseQueryModel.Token 

                    };
                    var json = JsonConvert.SerializeObject(addlincense);
                    QueryDataPost queryDataPost = new QueryDataPost()
                    {
                        JSON = json,
                        URL = url,
                        Credentials = ""
                    };

                    var queryResponse = await _globalQuery.PostAsync(queryDataPost);
                    var jsonObj = JsonConvert.DeserializeObject<BaseResponse>(queryResponse);

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
                    var addlincense = new BaseResponse()
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
