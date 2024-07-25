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

    // Configura o pipeline de requisição HTTP.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        seedingService.Seed();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // O valor padrão do HSTS é 30 dias. Você pode querer mudar isso para cenários de produção, veja https://aka.ms/aspnetcore-hsts.
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
