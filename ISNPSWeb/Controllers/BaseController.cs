using ISNPSWeb.Service;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using static Domain.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Domain;
using ISNPSWeb.Models;
using Microsoft.AspNetCore.Localization;
using System.Threading;

namespace ISNPSWeb.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public static string refreshedToken = "";


        public string GetLanguageCookie()
        {
            var cookie = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            if (cookie == null)
            {
                return "ru";
            }
            else
            {
                var c_uic = cookie.Split('|');
                var culture = c_uic[0].Split("=");

                return culture[1];
            }
        }
        [AllowAnonymous]
        public async Task<UserClaim> GetUserClaims()
        {
            try
            {
                var cookie = "ru";

                var claimPrincipal = User as ClaimsPrincipal;

                var claimIdentity = claimPrincipal.Identity as ClaimsIdentity;

                UserClaim userClaim = new UserClaim();
                if (claimIdentity?.Claims.Count() != 0)
                {
                    var IdClaim = claimIdentity.Claims.Single(c => c.Type == "ID");
                    var FullNameClaim = claimIdentity.Claims.Single(c => c.Type == "FullName");
                    var UiLanguageClaim = claimIdentity.Claims.Single(c => c.Type == "UiLanguage");
                    var EmailClaim = claimIdentity.Claims.Single(c => c.Type == ClaimTypes.Email);
                    var PictureClaim = claimIdentity.Claims.Single(c => c.Type == "Picture");

                    userClaim.Id = int.Parse(IdClaim.Value);
                    userClaim.FullName = FullNameClaim.Value;
                    userClaim.UiLanguage = UiLanguageClaim.Value;
                    userClaim.Email = EmailClaim.Value;
                    userClaim.Picture = PictureClaim.Value;
                }
                else
                {

                    userClaim.Id = 0;
                    userClaim.FullName = string.Empty;
                    userClaim.UiLanguage = cookie;
                    userClaim.Email = string.Empty;
                    userClaim.Picture = string.Empty;
                }

                return userClaim;
            }
            catch (Exception ex)
            {
                var cookie = "ru";
                UserClaim userClaim = new UserClaim()
                {
                    Id = 0,
                    FullName = string.Empty,
                    UiLanguage = cookie,
                    Email = string.Empty,
                    Picture = string.Empty,
                };
                return userClaim;
            }
        }

        public string GetToken()
        {
            try
            {
                MutexToken.Mutex.WaitOne();
                var claimPrincipal = User as ClaimsPrincipal;
                var claimIdentity = claimPrincipal.Identity as ClaimsIdentity;

                var claim = (from c in claimPrincipal.Claims
                             where c.Type == ".AspNetCore.Admin"
                             select c).FirstOrDefault();
                //преобразует строку в безопасную для использования в URI форму. 
                return Uri.EscapeDataString(claim.Value.ToString());
            }
            finally
            {
                MutexToken.Mutex.ReleaseMutex();
            }
        }

        public async Task<bool> UpdateUserClaims(Update_UserViewModel settingsView)
        {
            bool retObject = true;
            try
            {
                var claimPrincipal = User as ClaimsPrincipal;

                var claimIdentity = claimPrincipal.Identity as ClaimsIdentity;

                // Получаем полное имя из клаймов
                var claimFullName = claimPrincipal.Claims.Single(c => c.Type == ClaimTypes.Name);

                var claimEmail = claimPrincipal.Claims.Single(c => c.Type == ClaimTypes.Email);

                var claimPhoneNumber = claimPrincipal.Claims.Single(c => c.Type == "PhoneNumber");

                var claimPicture = claimPrincipal.Claims.Single(c => c.Type == "Picture");

                //Выход текущего пользователя из системы
                await HttpContext.SignOutAsync();

                claimIdentity.TryRemoveClaim(claimFullName);
                claimIdentity.TryRemoveClaim(claimEmail);
                claimIdentity.TryRemoveClaim(claimPhoneNumber);
                claimIdentity.TryRemoveClaim(claimPicture);

                var userPic = "/assets/images/no-photo.jpg";

                claimIdentity.AddClaim(new Claim(ClaimTypes.Name, settingsView.FirstName + " " + settingsView.LastName));
                claimIdentity.AddClaim(new Claim(ClaimTypes.Email, settingsView.Email));
                claimIdentity.AddClaim(new Claim("PhoneNumber", settingsView.PhoneNumber));
                claimIdentity.AddClaim(new Claim("Picture", userPic));

                //Вход пользователя в систему с обновленными утверждениями (claims)
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);

                return retObject;
            }
            catch (Exception ex)
            {
                retObject = false;
                return retObject;
            }
        }

    }
}
