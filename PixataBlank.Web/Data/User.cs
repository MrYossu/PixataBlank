using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PixataBlank.Web.Data; 

public class User : IdentityUser {
  [Required]
  public string FirstName { get; set; } = "";

  [Required]
  public string Surname { get; set; } = "";
  public string FullName =>
    FirstName + " " + Surname;

  public override string ToString() =>
    FullName;

}