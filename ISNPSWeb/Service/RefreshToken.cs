using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ISNPSWeb.Service
{
    public class RefreshToken
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public static string refreshedToken = "";
        public RefreshToken(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public bool RefreshTokenClaim(string token)
        {
            MutexToken.Mutex.WaitOne();
            bool retObject = true;
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;

                var claimPrincipal = httpContext.User as ClaimsPrincipal;

                var claimIdentity = claimPrincipal.Identity as ClaimsIdentity;

                var claim = (from c in claimPrincipal.Claims
                             where c.Type == ".AspNetCore.Admin"
                             select c).FirstOrDefault();

                if (!string.IsNullOrEmpty(token))
                {
                    // Обновляем токен
                    refreshedToken = token;

                    // Снимаем аутентификацию, чтобы изменить клаймы
                    httpContext.SignOutAsync();

                    // Удаляем старый клайм
                    Task.Run(() => claimIdentity.RemoveClaim(claim));

                    // Создаем новый клайм с обновленным токеном
                    var claimNew = new Claim(".AspNetCore.Admin", token);

                    // Добавляем новый клайм
                    claimIdentity.AddClaim(claimNew);

                    // Аутентифицируем пользователя с обновленными клаймами
                    httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
                }
                else
                {
                    retObject = false;
                }
                return retObject;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { MutexToken.Mutex.ReleaseMutex(); }

        }
    }
}
