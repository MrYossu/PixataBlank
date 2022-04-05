using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PixataBlank.Web.Data {
  public class AppDbContext : IdentityDbContext<User> {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {
    }
  }
}