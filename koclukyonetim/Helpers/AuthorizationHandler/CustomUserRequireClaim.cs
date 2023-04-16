using Microsoft.AspNetCore.Authorization;

namespace koclukyonetim.Helpers.AuthorizationHandler
{
    public class CustomUserRequireClaim : IAuthorizationRequirement
    {
        public CustomUserRequireClaim(string claimType)
        {
            this.ClaimType = claimType;
        }
        public string ClaimType { get; set; }
    }
}
