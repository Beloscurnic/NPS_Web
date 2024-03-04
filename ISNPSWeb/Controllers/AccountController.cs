using Application.Global_Models;
using Domain;
using ISNPSWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Domain.Enums;
using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

using Application.Requests.Commands.Authorize_User;
using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;
using System.Security;

namespace ISNPSWeb.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public async Task<IActionResult> Login()
        {
            var language = GetLanguageCookie();
            if (string.IsNullOrEmpty(language))
            {
                ViewBag.Language = "ru";
            }
            else
            {
                ViewBag.Language = language.ToLower();
            }
            return View("~/Views/Account/_Login.cshtml");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthorizeViewModel_DTO authorizeViewModel)
        {
            try
            {
                var lang = GetLanguageCookie();
                if (string.IsNullOrEmpty(lang))
                {
                    ViewBag.Language = "ru";
                }
                else
                {
                    ViewBag.Language = lang.ToLower();
                }

                if (ModelState.IsValid)
                {
                    authorizeViewModel.Email = authorizeViewModel?.Email?.ToLower().Trim();

                    var command = new User_Authorize.Command(authorizeViewModel.Email, authorizeViewModel.Password);
                    var response = await _mediator.Send(command);

                    if (response.ErrorCode == EnErrorCode.NoError)
                    {
                        var uiLanguage = Enums.EnUiLanguage.RU;

                        List<Claim> userClaims = new List<Claim>();
                        if (response.User != null)
                        {
                            //var groupResponse = await groupQuery.GetSecurityPermissionAsync(response.Token);
                            var query = new Application.Requests.Queries.Get_Permission.Permissions_Get.Query { Token = response.Token};
                            var groupResponse= await _mediator.Send(query);
                            if (groupResponse.ErrorCode != EnErrorCode.NoError)
                            {
                                ModelState.AddModelError("Password", response.ErrorMessage + ". " + "ContactAdministrator");
                                return PartialView("~/Views/Account/_Login.cshtml", authorizeViewModel);
                            }
                            else if (groupResponse.ErrorCode == EnErrorCode.NoError)
                            {
                                var naviations = JsonConvert.SerializeObject(groupResponse.Permission.Navigations);

                                userClaims.Add(new Claim("IsAdministrator", groupResponse.Permission.IsAdministrator.ToString()));
                                userClaims.Add(new Claim("Navigations", naviations));
                            }

                            //userClaims.Add(new Claim("IsAdministrator", "true"));
                            //userClaims.Add(new Claim("Navigations", "Allow"));

                            uiLanguage = response.User.UiLanguage;

                            if (lang != null)
                            {
                                if (lang.ToUpper() != response.User.UiLanguage.ToString())
                                {
                                    switch (lang.ToUpper())
                                    {
                                        case "EN":
                                            uiLanguage = EnUiLanguage.EN;
                                            break;
                                        case "RO":
                                            uiLanguage = EnUiLanguage.RO;
                                            break;
                                        case "RU":
                                            uiLanguage = EnUiLanguage.RU;
                                            break;
                                        default:
                                            uiLanguage = EnUiLanguage.RU;
                                            break;
                                    }

                                    var token = response.Token;

                                   var command_change = new Application.Requests.Commands.ChangeLanguage.ChangeLanguage.Command { Token = token, Lang = (int)uiLanguage };
                                   var responseLanguage = await _mediator.Send(command_change);                               
                                }
                            }

                            userClaims.Add(new Claim("ID", response.User.ID.ToString()));
                            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, response.User.ID.ToString()));
                            userClaims.Add(new Claim(ClaimTypes.Email, response.User.Email));
                            userClaims.Add(new Claim(ClaimTypes.Name, response.User.FirstName + " " + response.User.LastName));
                            userClaims.Add(new Claim("FullName", response.User.FirstName + " " + response.User.LastName));
                            userClaims.Add(new Claim("Company", response.User.Company));
                            userClaims.Add(new Claim("PhoneNumber", response.User.PhoneNumber));
                            userClaims.Add(new Claim("UiLanguage", uiLanguage.ToString()));
                            userClaims.Add(new Claim("Picture", "/assets/images/no-photo.jpg"));
                            userClaims.Add(new Claim(".AspNetCore.Admin", response.Token));

                            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(uiLanguage.ToString())), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
                        }

                        var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var claimsPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    else if (response.ErrorCode == EnErrorCode.User_name_not_found_or_incorrect_password)
                    {
                        ModelState.AddModelError("Email", "Пользователь не найден или введен неверный пароль");
                        return View("~/Views/Account/_Login.cshtml", authorizeViewModel);
                    }
                    else if (response.ErrorCode == EnErrorCode.Internal_error)
                    {
                        ModelState.AddModelError("Email", "Внутреняя ошибка");
                        return View("~/Views/Account/_Login.cshtml", authorizeViewModel);
                    }
                    else if (response.ErrorCode != EnErrorCode.NoError)
                    {
                        ModelState.AddModelError("Password", response.ErrorMessage + ". " + "Свяжитесь с администратором");

                        return View("~/Views/Account/_Login.cshtml", authorizeViewModel);
                    }
                }

                return View("~/Views/Account/_Login.cshtml", authorizeViewModel);
            }
            catch (Exception ex)
            {
                BaseResponse errorResponse = new BaseResponse()
                {
                    ErrorCode = EnErrorCode.Internal_error,
                    ErrorMessage = ex.Message,
                };
                return PartialView("~/Views/Home/_500.cshtml", errorResponse);
            }
        }

        [AllowAnonymous]
        [HttpGet("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword()
        {
            return View("~/Views/Account/_ForgotPassword.cshtml");
        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel_DTO forgotPasswordViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var command = new Application.Requests.Commands.ForgotPassword.ForgotPas.Command(forgotPasswordViewModel.Email, forgotPasswordViewModel.INFO);
                    var response = await _mediator.Send(command);

                    if (response.ErrorCode == EnErrorCode.User_name_not_found_or_incorrect_Email)
                    {
                        ModelState.AddModelError("Email", "Пользователь не найден или введен неверный пароль");
                        return PartialView("~/Views/Account/_ForgotPassword.cshtml", forgotPasswordViewModel);
                    }
                    else if (response.ErrorCode == EnErrorCode.Internal_error)
                    {
                        ModelState.AddModelError("Email", "Внутреняя ошибка");
                        return PartialView("~/Views/Account/_ForgotPassword.cshtml", forgotPasswordViewModel);
                    }
                    else if (response.ErrorCode != EnErrorCode.NoError)
                    {
                        ModelState.AddModelError("Email", response.ErrorMessage + ". " + "Свяжитесь с администратором");
                        return PartialView("~/Views/Account/_ForgotPassword.cshtml", forgotPasswordViewModel);
                    }

                    return PartialView("~/Views/Account/_Login.cshtml", forgotPasswordViewModel);
                }
                else
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        ModelState.AddModelError("", error.ErrorMessage);
                    }
                }

                return View("~/Views/Account/_ForgotPassword.cshtml", forgotPasswordViewModel);
            }
            catch (Exception ex)
            {
                BaseResponse errorResponse = new BaseResponse()
                {
                    ErrorCode = EnErrorCode.Internal_error,
                    ErrorMessage = ex.Message,
                };

                return PartialView("~/Views/Home/_500.cshtml", errorResponse);
            }
        }

        [HttpGet("TokenLogout")]
        public async Task<IActionResult> TokenLogout()
        {
            //TempData["InvalidToken"] = Localization.SessionTimeout;

            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        [AllowAnonymous]
        [HttpGet("ChangeLang")]
        public async Task<IActionResult> ChangeLang([FromQuery]string shortLang)
        {
            try
            {
                var uiLanguage = EnUiLanguage.RU;
                List<string> cultures = new List<string>() { "en", "ro", "ru" };
                if (!cultures.Contains(shortLang))
                {
                    shortLang = "ru";
                }

                switch (shortLang)
                {
                    case "en":
                        uiLanguage = EnUiLanguage.EN;
                        break;
                    case "ro":
                        uiLanguage = EnUiLanguage.RO;
                        break;
                    case "ru":
                        uiLanguage = EnUiLanguage.RU;
                        break;
                    default:
                        uiLanguage = EnUiLanguage.RU;
                        break;
                }

                Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(shortLang)), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
                return Json(new BaseJsonResponse { Result = ExecutionResult.OK, Message = "Saved" });
            }
            catch (Exception ex)
            {
                //    _logger.Error(ex, ex.Message);
                return Json(new BaseJsonResponse { Result = ExecutionResult.OK, Message = "Error" });
            }
        }
    }
}
