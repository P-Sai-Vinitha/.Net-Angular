using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register Controllers
builder.Services.AddControllers();

// Register Repository
builder.Services.AddScoped<IEventDetailsRepo<EventDetails>, EventDetailsRepo>();
builder.Services.AddScoped<IParticipantEventDetailsRepo<ParticipantEventDetails>, ParticipantEventDetailsRepo>();
builder.Services.AddScoped<IUserInfoRepo<UserInfo>, UserInfoRepo>();


// To Congigure Swagger Services
builder.Services.AddSwaggerGen(options =>
{ 
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Event Api",
            Description = "Event Application",
            TermsOfService = new Uri("https://www.hexawaew.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "sai vinitha",
                Email = "saivinitha@gmail.com",
                Url = new Uri("https://linkedin.com")
            },
            License = new OpenApiLicense
            {
                Name = "Hexaware",
                Url = new Uri("https://hexaware.com/license")
            }
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'Bearer' followed by space and JWT token."
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
});



//Configure CORS once with named policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGetAndPost", builder =>
    {
        builder.WithOrigins("http://localhost:60685", "http://localhost:4200")
               .AllowAnyHeader()
               .WithMethods("GET", "POST");
    });
});

//Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


//API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});


// Build App
var app = builder.Build();

// Dev Exception Page
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Routing
app.UseRouting();
app.UseCors("AllowGetAndPost");
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My App v1");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
