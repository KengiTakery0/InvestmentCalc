using InvestmentCalc.Services.PropertyServices.Model;

namespace InvestmentCalc.Services.UserServices.Model
{
    public class User
    {
        public int UserId { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        public ICollection<Property> Properties { get; set; } = new List<Property>();

    }

}