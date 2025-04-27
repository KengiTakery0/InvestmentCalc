namespace InvestmentCalc.Services.UserServices
{
    public class UserModel
    {
        public int UserID { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        // TO DO DataToSave
    }
}
