using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalc.Services.UserServices.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        // TO DO DataToSave
    }

}