using APITaller1.src.Data;
using APITaller1.src.Interfaces;
using APITaller1.src.Repositories;
using APITaller1.src.Services;

using Microsoft.EntityFrameworkCore;

using Serilog;

Log.Logger = new LoggerConfiguration()
    .CreateLogger();

try
{
    Log.Information("starting server.");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddDbContext<StoreContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    var corsSettings = builder.Configuration.GetSection("CorsSettings");
    var allowedOrigins = corsSettings.GetSection("AllowedOrigins").Get<string[]>();
    var allowedHeaders = corsSettings.GetSection("AllowedHeaders").Get<string[]>();
    var allowedMethods = corsSettings.GetSection("AllowedMethods").Get<string[]>();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("DefaultCorsPolicy", policy =>
        {
            policy.WithOrigins(allowedOrigins!)
                  .WithHeaders(allowedHeaders!)
                  .WithMethods(allowedMethods!)
                  .AllowCredentials(); // Si usas cookies para el basket
        });
    });

    builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithThreadId()
            .Enrich.WithMachineName();
    });

    var app = builder.Build();

    app.UseCors("DefaultCorsPolicy");
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
        db.Database.Migrate();
    }

    DbInitializer.InitDb(app);

    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}