using Microsoft.AspNetCore.Authorization;

namespace WILD.SLOTH.Api.Security
{
    public class HasScopeRequirements : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirements(String scope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}