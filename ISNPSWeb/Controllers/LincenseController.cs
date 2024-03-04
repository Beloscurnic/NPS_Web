
using Application.Global_Models;
using Application.Service.Token;
using Domain;
using ISNPSWeb.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ISNPSWeb.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class LincenseController :BaseController
    {

        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;
        private readonly RefreshToken _refreshToken;
        public LincenseController(ITokenService tokenService, RefreshToken refreshToken)
        {
            _tokenService = tokenService;
            _refreshToken = refreshToken;
        }

        //public async Task<IActionResult> Get_Lincense(Guid ID)
        //{
        //    string token = GetToken();

        //}
    }
}
