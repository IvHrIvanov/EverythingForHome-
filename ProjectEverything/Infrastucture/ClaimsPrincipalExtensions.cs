using System.Security.Claims;

namespace ProjectEverything.Infrastucture
{
    public static class ClaimsPrincipalExtensions
    {
    
        public static string? GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
   
    }
}
