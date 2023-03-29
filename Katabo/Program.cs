using Microsoft.EntityFrameworkCore;
using Katabo.Models;
using NToastNotify;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions
{
	ProgressBar = true,
	TimeOut = 5000
});




builder.Services.AddRouting(options =>
{
	options.AppendTrailingSlash = true;
	options.LowercaseQueryStrings = true;
});

builder.Services.AddDbContext<KataboContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("KataboContext"));
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseNToastNotify();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
