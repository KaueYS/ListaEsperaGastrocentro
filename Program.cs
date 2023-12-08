using ListaEsperaGastrocentro.Context;
using ListaEsperaGastrocentro.Helper;
using ListaEsperaGastrocentro.Interfaces;
using ListaEsperaGastrocentro.Repositories;
using ListaEsperaGastrocentro.Servicos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("8.2.0-mysql")));

builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();  
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();


//(builder.Configuration.GetConnectionString("DefaultConnection")));