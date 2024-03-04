using Application.Global_Models;
using Application.Service.URL_API;
using Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Token
{
    public class TokenService : ITokenService
    {
        private readonly URL_User_NPS _User_NPS;
        private readonly URL_Admin_NPS _Admin_NPS;
        private readonly GlobalQuery _globalQuery;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public static object __refreshTokenLock2 = new object();
        public TokenService(URL_User_NPS _user_NPS, URL_Admin_NPS _admin_NPS, GlobalQuery globalQuery)
        {
            _User_NPS = _user_NPS;
            _Admin_NPS = _admin_NPS;
            _globalQuery = globalQuery;
        }

        public Model_Token_Response Refresh_token(string requestToken, Func<string, bool> delegat)
        {
            Monitor.Enter(__refreshTokenLock2);
            try
            {
                var urltoken = _Admin_NPS.RefreshToken(requestToken);
                var credentialstoken = _Admin_NPS.Credentials();

                QueryDataGet queryDataGettoken = new QueryDataGet()
                {
                    URL = urltoken,
                    Credentials = credentialstoken
                };

                var queryResponsetoken = _globalQuery.Get(queryDataGettoken);

                var token = JsonConvert.DeserializeObject<Model_Token_Response>(queryResponsetoken);

                if (token.ErrorCode == EnErrorCode.Expired_token)
                {
                    Refresh_token(requestToken, delegat);
                }

                else if (token.ErrorCode == EnErrorCode.Internal_error)
                {
                    throw new Exception(token.ErrorMessage);
                }
                bool result = delegat(token.Token);
                return token;
            }
            finally
            {
                Monitor.Exit(__refreshTokenLock2);
            }
        }
    }
}
