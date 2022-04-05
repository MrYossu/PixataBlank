using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using PixataBlank.Web.Areas.Identity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => {
  options.UseSqlServer(connectionString);
  options.EnableSensitiveDataLogging();
  options.EnableDetailedErrors();
}, ServiceLifetime.Transient);
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
  })
  .AddDefaultTokenProviders()
  .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => {
  options.DetailedErrors = true;
});
builder.Services.AddTelerikBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<User>>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.UseMigrationsEndPoint();
} else {
  app.UseExceptionHandler("/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToAreaPage("/_Host", "General");

using IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
await CreateRoles(roleManager!);
UserManager<User> userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
// TODO - Change the details below to be for the initial admin user
User user = new() {
  UserName = "me@domain.com",
  Email = "me@domain.com",
  FirstName = "Avrohom Yisroel",
  Surname = "Silver"
};
// TODO - Change this to your admin user's initial password
await ConfigureSiteAdmin(user, "TJK_oJd*pKYZq9g7G8VY");

app.Run();

static async Task CreateRoles(RoleManager<IdentityRole> roleManager) {
  foreach (IdentityRole role in Roles.AllRoles) {
    if (await roleManager.RoleExistsAsync(role.Name)) {
      continue;
    }
    if ((await roleManager.CreateAsync(role)).Succeeded) {
      continue;
    }
    throw new Exception($"Could not create '{role.Name}' role");
  }
}

async Task ConfigureSiteAdmin(User user, string password) {
  if (await userManager.FindByEmailAsync(user.Email) != null) {
    return;
  }
  if (!await roleManager.RoleExistsAsync(Roles.Admin)) {
    throw new Exception("The Admin role has not yet been created");
  }
  user.EmailConfirmed = true;
  await userManager.CreateAsync(user, password);
  await userManager.AddToRoleAsync(user, Roles.Admin);
  await userManager.AddToRoleAsync(user, Roles.User);
}