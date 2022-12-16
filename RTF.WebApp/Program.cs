using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using RFT.Services.Extensions;
using RTF.Core.Extensions;
using RTF.Core.Infrastructure;
using RTF.Core.Models.IdentityModels;
using RTF.Core.Repositories;
using RTF.CQS.Converters;
using RTF.CQS.Extensions;
using RTF.Infrastructure;
using RTF.Infrastructure.Helpers;
using RTF.WebApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option => 
{
// Отключаем маршрутизацию конечных точек на основе endpoint-based logic из EndpointMiddleware
// и продолжаем использование маршрутизации на основе IRouter. 
    option.EnableEndpointRouting = false;
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser().RequireAuthenticatedUser().Build();
    option.Filters.Add(new AuthorizeFilter(policy));
}).SetCompatibilityVersion(CompatibilityVersion.Latest);
//builder.Services.AddControllers();


builder.Services.AddDbContext<IdentityContext>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
    {
        opt.Password.RequiredLength = 7;
        opt.Password.RequireDigit = false;
        opt.Password.RequireUppercase = false;
        opt.User.RequireUniqueEmail = true;
        opt.SignIn.RequireConfirmedEmail = false; //TODO добавить подтверждение и изменить на тру
        opt.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
    })
    .AddEntityFrameworkStores<IdentityContext>()
    .AddSignInManager<SignInManager<User>>();
    // .AddDefaultTokenProviders()
    // .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation");

// builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
//     opt.TokenLifespan = TimeSpan.FromHours(2));

builder.Services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
    opt.TokenLifespan = TimeSpan.FromDays(3));

//builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsFactory>();

// Jwt configuration
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Security")["TokenKey"]));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateAudience = false,
                ValidateIssuer = false,
            };
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConnectionContext>()
    .RegisterUnitOfWork()
    .RegisterRepositories();

// Регистрация наших зависимостей
builder.Services.AddAutoMapper(typeof(CqsMappingProfile));
builder.Services.RegisterRequestHandlers();
builder.Services.ConfigureCoreDependencies();
builder.Services.ConfigureServicesDependencies();
builder.Services.AddInfrastructureServicedDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
ServiceLocator.SetProvider(() => app.Services);
var a = new IdentityContext(new NpgsqlProvider(app.Configuration));
a.Database.EnsureCreated();

app.Run();