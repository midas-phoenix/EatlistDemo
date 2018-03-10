using EatListDataService.DataBase;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerWithAspNetIdentity.Extensions
{
    public class IdentityWithAdditionalClaimsProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        readonly ILogger<IdentityWithAdditionalClaimsProfileService> _log;
        public IdentityWithAdditionalClaimsProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, ILogger<IdentityWithAdditionalClaimsProfileService> log)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
            _log = log;
        }
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var sub = context.Subject.GetSubjectId();

                var user = await _userManager.FindByIdAsync(sub);
                var principal = await _claimsFactory.CreateAsync(user);

                var claims = principal.Claims.ToList();

                claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

                claims.Add(new Claim(JwtClaimTypes.Name, user.IsRestaurant ? user.RestaurantName: user.FullName));
                claims.Add(new Claim("UserName", user.UserName));
                //claims.Add(new Claim(JwtClaimTypes.GivenName, user.UserName));
                claims.Add(new Claim(JwtClaimTypes.Role, user.IsRestaurant? "Restaurant": "user"));
                claims.Add(new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
                context.IssuedClaims = claims;
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message + "\n" + ex.StackTrace);
            }

        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
