using Microsoft.AspNetCore.Authorization;

namespace koclukyonetim.Helpers.AuthorizationHandler
{
    public class PoliciesAuthorizationHandler : AuthorizationHandler<CustomUserRequireClaim>
    {
        protected override Task HandleRequirementAsync(
                AuthorizationHandlerContext context,
                CustomUserRequireClaim requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var hasClaim = context.User.Claims.Any(x => x.Type == requirement.ClaimType);

            if (!hasClaim)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
