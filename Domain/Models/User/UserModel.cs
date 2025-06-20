using System.ComponentModel.DataAnnotations;

namespace Domain.Models.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
    }
}
