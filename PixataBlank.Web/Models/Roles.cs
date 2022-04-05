using Microsoft.AspNetCore.Identity;

namespace PixataBlank.Web.Models; 

public class Roles {
  public const string Admin = "Admin";
  public const string User = "User";

  public static List<IdentityRole> AllRoles = new() {
    new() { Name = Admin },
    new() { Name = User }
  };

}