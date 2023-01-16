using Microsoft.AspNetCore.Identity;

namespace TCSH.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string ?FirstName { get; set; }
        public string ?SecoundName { get; set; }
        public string ?Locstion { get; set; }
        public byte[] ?ProfilePicture { get; set; }
    }
}
