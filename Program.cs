using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Raul_Moldovan_Medii.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddDbContext<ServiceAutoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceAutoContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ServiceAutoContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
