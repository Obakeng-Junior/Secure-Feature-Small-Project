namespace Security_Feature_Project.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int LockedAccounts { get; set; }
        public int TotalAuditLogs { get; set; }
        public int FailedLoginAttempts { get; set; }
        public int SuccessfulLogins { get; set; }
    }
}
