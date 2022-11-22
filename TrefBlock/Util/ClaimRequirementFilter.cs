using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace TrefBlock.Util
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAdmin = context.HttpContext.User.Claims.Any(
                        c => c.Type == new IdentityOptions().ClaimsIdentity.RoleClaimType &&
                        c.Value == AppUtil.Role.Admin);

            if (isAdmin)
            {
                return;
            }

            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
