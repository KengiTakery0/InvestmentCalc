using Microsoft.AspNetCore.Identity;

namespace AuthService.Data
{
    public class User: IdentityUser
    {
        
        public string? EmailConfirmationToken { get; set; }//Подтверждение Email
        
    }
}
