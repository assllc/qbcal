namespace qbcal.DataAccess.Models
{
    public record ApplicationUserRecord
    {
        public string Email { get; set; } = string.Empty;
        public string StatusMessage { get; set; } = string.Empty;
        public bool Authenticated { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public IList<string> Roles { get; set; }
        public string UserId { get; set; } = string.Empty;
    }

    public record ApplicationUserRequestRecord
    {
        public string id { get; set; }
        public string password { get; set; }
    }
}
