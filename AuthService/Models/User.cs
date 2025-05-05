using Microsoft.AspNetCore.Identity;

namespace AuthService.Models
{
    public class User: IdentityUser
    {
        public bool IsEmailConfirmed { get; set; } = false;
        public string? EmailConfirmationToken { get; set; }

    }
}
