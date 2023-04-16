using AutoMapper;
using kocluk.DOMAIN;
using kocluk.SERVICES.Mapper;
using koclukyonetim.Helpers;
using koclukyonetim.Helpers.AuthorizationHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;


IConfiguration _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false).Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options => { options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()); });

builder.Services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Latest);

builder.Services.AddDbContextDI(_configuration);
builder.Services.AddInjections();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
    options.CheckConsentNeeded = context => false;
    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
});

builder.Services.AddAuthentication("FormAuthenticationWithCookie")
.AddCookie("FormAuthenticationWithCookie", config =>
{
    config.Cookie.Name = "FormAuthenticationWithCookie";
    config.LoginPath = new PathString("/yonetim/girisyap");
    config.AccessDeniedPath = "/yonetim/girisyap";

});

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("UserPolicy", policyBuilder =>
    {
        policyBuilder.UserRequireCustomClaim(ClaimTypes.Email);
        policyBuilder.UserRequireCustomClaim(ClaimTypes.Name);
    });

});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new GeneralMapper());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/hata/404");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        var headers = context.Context.Response.GetTypedHeaders();
        headers.CacheControl = new CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromDays(30),
        };

        headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));
    }
});

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=yonetim}/{action=anasayfa}/{id?}");

app.Run();