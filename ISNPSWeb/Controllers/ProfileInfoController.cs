using Application.Global_Models;
using Application.Requests.Queries.GetProfileInfo;
using Application.Service.Token;
using Domain;
using ISNPSWeb.Models.ProfileInfo;
using ISNPSWeb.Service;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISNPSWeb.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ProfileInfoController : BaseController
    {
        public static string refreshedToken = "";
        public static object __refreshTokenLock = new object();
        public static object __getTokenLock = new object();
        bool __lockWasTaken = false;
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;
        private readonly RefreshToken _refreshToken;

        public ProfileInfoController(IMediator mediator, ITokenService tokenService, RefreshToken refreshToken)
        {
            _mediator = mediator;
            _tokenService = tokenService;
            _refreshToken = refreshToken;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Index()
        {
            return View("~/Views/ProfileInfo/Index.cshtml");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ProfileInfo_Get()
        {
            try
            {
                string token = GetToken();
                var basequery = new BaseQueryModel()
                {
                    Token = token,
                    _Delegat = (t) => _refreshToken.RefreshTokenClaim(t)
                };
                var query = new ProfileInfo_Get.Query { BaseQueryModel = basequery };

                var response = await _mediator.Send(query);

                if (response.ErrorCode == EnErrorCode.Expired_token)
                {
                    return CreateJsonLogout();
                }
                else if (response.ErrorCode == EnErrorCode.Invalid_token)
                {
                    return CreateJsonLogout();
                }
                return PartialView("~/Views/ProfileInfo/_ProfileInfo.cshtml", response);
            }
            catch (Exception ex)
            {
                return PartialView("~/Views/ProfileInfo/_ProfileInfo.cshtml");
            }

        }

        [HttpGet("Get_ChangePassword")]
        public async Task<IActionResult> Get_ChangePassword()
        {
            return PartialView("~/Views/ProfileInfo/_ChangePassword.cshtml");
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePassword_DTO viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView("~/Views/ProfileInfo/_ChangePassword.cshtml", viewModel);
                }

                string token = GetToken();
                var basequery = new BaseQueryModel()
                {
                    Token = token,
                    _Delegat = (t) => _refreshToken.RefreshTokenClaim(t)
                };

                var command = new Application.Requests.Commands.ChangePassword.Password_Change.Command
                {
                    NewPassword = token,
                    OldPassword = token,
                    BaseQueryModel = basequery
                };
                var response = await _mediator.Send(command);


                if (response.ErrorCode == EnErrorCode.Expired_token)
                {
                    return await ChangePassword(viewModel);
                }

                return Json("OK");
            }
            catch (Exception ex)
            {
                return PartialView("~/Views/ProfileInfo/_ChangePassword.cshtml", viewModel);
            }
        }
    }
}
