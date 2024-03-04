using Application.Global_Models;
using Application.Service;
using Application.Service.Token;
using Application.Service.URL_API;
using Domain;
using MediatR;
using Newtonsoft.Json;
using static Application.Requests.Commands.AddLincense.Lincense_Add;

namespace Application.Requests.Commands.Upsert_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Upsert
    {
        public class Handler : IRequestHandler<Command, View_Response>
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

            public async Task<View_Response> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var url = authURLs.Creat_GroupQuestionnaire();
                    var credential = "";
                    var token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                    var addlincense = new Upsert_GroupQuestionnaire
                    {
                        GroupQuestionnaireID = request.GroupQuestionnaireID,
                        Name = request.Name,
                        LincenseID = request.LincenseID,
                        Token = request.BaseQueryModel.Token
                    };
                    var json = JsonConvert.SerializeObject(addlincense);
                    QueryDataPost queryDataPost = new QueryDataPost()
                    {
                        JSON = json,
                        URL = url,
                        Credentials = ""
                    };

                    var queryResponse = await _globalQuery.PostAsync(queryDataPost);
                    var jsonObj = JsonConvert.DeserializeObject<View_Response>(queryResponse);

                    if (jsonObj.ErrorCode == EnErrorCode.Expired_token)
                    {
                        token = _tokenService.Refresh_token(request.BaseQueryModel.Token, request.BaseQueryModel._Delegat);
                        request.BaseQueryModel.Token = token.Token;
                        return await Handle(request, cancellationToken);
                    }
                    return jsonObj;
                }
                catch (Exception ex)
                {
                    var addlincense = new View_Response()
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
