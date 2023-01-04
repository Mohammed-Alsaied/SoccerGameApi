using Coaches.Server;
using Common.AssemplyScanning;
using LeagueTeams.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nationalities.Server;
using NationalTeams.Server;
using Persons.Shared;
using Players.Server;
using SoccerManager;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options
        .UseSqlServer(connectionString, builder => builder.MigrationsAssembly("SoccerGame.EF"))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<DbContext, ApplicationDbContext>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})


// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});


builder.Services.AddAutoMapper(typeof(Program).Assembly,
    typeof(Person).Assembly,
    typeof(Player).Assembly,
    typeof(Coach).Assembly,
    typeof(LeagueTeam).Assembly,
    typeof(Nationality).Assembly,
    typeof(NationalTeam).Assembly);


// Add services to the container.
builder.Services.AddInstallerFromAssembly<Program>(builder.Configuration);
builder.Services.AddInstallerFromReferancedAssemblies(builder.Configuration, typeof(Program).Assembly, "*.Server.dll");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();//before UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
