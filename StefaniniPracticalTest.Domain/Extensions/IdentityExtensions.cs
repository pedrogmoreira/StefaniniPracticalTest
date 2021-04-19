using System.Security.Claims;
using System.Security.Principal;

namespace StefaniniPracticalTest.Domain.Extensions
{
    public static class IdentityExtensions
    {
        /// <summary>
        /// Gets the ID from the authenticated user.
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static int GetUserId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("UserId");

            return int.Parse(claim?.Value);
        }
    }
}
