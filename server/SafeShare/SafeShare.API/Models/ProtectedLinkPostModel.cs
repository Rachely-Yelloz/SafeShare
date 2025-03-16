using SafeShare.CORE.Entities;

namespace SafeShare.API.Models
{
    public class ProtectedLinkPostModel
    {
        public FileToUpload File { get; set; }
        public User User { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsOneTimeUse { get; set; }
        public int? DownloadLimit { get; set; }
    }
}
