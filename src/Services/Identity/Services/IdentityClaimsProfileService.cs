using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Models;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services
{
    public class IdentityClaimsProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<User> claimsFactory;
        private readonly UserManager<User> userManager;


        public IdentityClaimsProfileService(UserManager<User> userManager,
            IUserClaimsPrincipalFactory<User> claimsFactory)
        {
            this.userManager = userManager;
            this.claimsFactory = claimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            var principal = await claimsFactory.CreateAsync(user);
            var userClaim = await userManager.GetClaimsAsync(user);
            var roles = userClaim.Where(c => c.Type == "role").ToList();

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            //Add custom role claims for user.
            if (roles.Count() > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Value));
                }
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
