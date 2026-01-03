namespace Security_Feature_Project.Models
{
    public class LoginAttempt
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime AttemptedAt { get; set; }
        public bool Success { get; set; }
    }
}
