using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Obs_Proje.Identity
{
    public class WebUser : IdentityUser
    {
        public string Fullname { get; set; }
    }

    public class WebRole : IdentityRole
    {
        public string Title { get; set; }
    }

    public class WebIdentityContext : IdentityDbContext
    {
        public WebIdentityContext(DbContextOptions options) : base(options)
        {
        }
    }
}
