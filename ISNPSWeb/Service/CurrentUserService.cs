using Domain;
using Newtonsoft.Json;
using System.Security.Claims;
using static Domain.Enums;

namespace ISNPSWeb.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            string userId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isValidGuid = Int32.TryParse(userId, out int parserUserId);
            bool value = false;
            bool.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("IsAdministrator"), out value);

            ////TO DO
            var naviations = JsonConvert.DeserializeObject<PermissionNavigation[]>("[]");
            var navigationList = httpContextAccessor.HttpContext?.User?.FindFirstValue("Navigations");
            if (navigationList != null)
            {
                naviations = JsonConvert.DeserializeObject<PermissionNavigation[]>(httpContextAccessor.HttpContext?.User?.FindFirstValue("Navigations"));
            }
            if (isValidGuid)
            {
                UserId = parserUserId;
            }

            FullName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            Company = httpContextAccessor.HttpContext?.User?.FindFirstValue("Company");
            EnUiLanguage = Enum.Parse<EnUiLanguage>(httpContextAccessor.HttpContext?.User?.FindFirstValue("UiLanguage"));
            IsAdministrator = value;
            Navigations = naviations;
            Picture = httpContextAccessor.HttpContext?.User?.FindFirstValue("Picture");


        }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }
        public string Picture { get; set; }
        public EnUiLanguage EnUiLanguage { get; set; }
        public bool IsAuthenticated { get; }
        public int UserId { get; }
        public bool IsAdministrator { get; }
        public PermissionNavigation[] Navigations { get; set; }

    }
}
