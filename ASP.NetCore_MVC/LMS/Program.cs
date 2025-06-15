var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Middleware
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Enable attribute-based routing
    endpoints.MapControllers();
});

app.Run();
