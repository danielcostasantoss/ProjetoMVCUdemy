using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoMVCUdemy.Data;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjetoMVCUdemyContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ProjetoMVCUdemyContext"),
    new MySqlServerVersion(new Version(8, 0, 21))));

// Add services to the container.
builder.Services.AddScoped<SeedingService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();

    // Configura o pipeline de requisi��o HTTP.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        seedingService.Seed();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // O valor padr�o do HSTS � 30 dias. Voc� pode querer mudar isso para cen�rios de produ��o, veja https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
