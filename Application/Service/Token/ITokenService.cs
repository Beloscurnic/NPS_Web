using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Token
{
    public interface ITokenService
    {
        public Model_Token_Response Refresh_token(string requestToken, Func<string, bool> delegat);
    }
}
