using Microsoft.AspNetCore.Authorization;

namespace koclukyonetim.Helpers.AuthorizationHandler
{
    public static class AuthorizationPolicyBuilderExtensionHandler
    {
        public static AuthorizationPolicyBuilder UserRequireCustomClaim(this AuthorizationPolicyBuilder builder, string claimType)
        {
            builder.AddRequirements(new CustomUserRequireClaim(claimType));

            return builder;
        }

    }
}
