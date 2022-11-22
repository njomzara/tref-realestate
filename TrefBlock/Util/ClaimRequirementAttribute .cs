using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TrefBlock.Util
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public const string CREATE_EMPLOYEE = "CreateEmployee";

        public enum PermissionItem
        {
            User,
            Product,
            Contact,
            Review,
            Client
        }

        public ClaimRequirementAttribute(string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}
