using FinalProjectService.API.BackgroundServices;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
// Add services to the container.
builder.Services.AddControllers().AddControllersAsServices();
builder.Services.AddMvc();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version.ToString(),
        Title = "FinalProject"
    });

    var basePath = AppContext.BaseDirectory;
    var commentFiles = Directory.GetFiles(basePath, "*API.xml");
    foreach (var commentFile in commentFiles)
    {
        c.IncludeXmlComments(commentFile);
    }
});
builder.Services.AddHostedService<FinalProjectBackgroundService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "Final Project");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks(string.Empty);
});

await app.RunAsync();
