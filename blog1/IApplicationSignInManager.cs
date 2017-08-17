using System.Security.Claims;
using System.Threading.Tasks;
using blog1.Models;

namespace blog1
{
    public interface IApplicationSignInManager
    {
        Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user);
    }
}