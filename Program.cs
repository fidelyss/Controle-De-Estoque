using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<EstoqueWeb>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-SOBFS7Q;Initial Catalog=testedb;Integrated Security=True");
});
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseStaticFiles();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute("HomeController", "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
