using System.Data;

namespace Security_Feature_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
    
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsLocked { get; set; } = false;

    }
}
