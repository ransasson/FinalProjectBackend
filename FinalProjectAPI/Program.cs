using FinalProjectService.API.BackgroundServices;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FinalProjectService.API.Controllers;
using FinalProjectModel.Services;
using FinalProjectBusinessLogic.Services;
using FinalProjectModel.Workflows;
using FinalProjectModel.Components;
using FinalProjectBusinessLogic.Components;
using FinalProjectBusinessLogic.Workflows;

var builder = WebApplication.CreateBuilder(args);

Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
// Add services to the container.
builder.Services.AddControllers().AddControllersAsServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<FinalProjectBackgroundService>();
builder.Services.AddCors(options =>
 options.AddPolicy("CorsPolicy",
 builderPolicy => builderPolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
LoadDI(builder);

static void LoadDI(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IModelCaller, ModelCaller>();
    builder.Services.AddSingleton<IImageSaver, ImageSaver>();
    builder.Services.AddSingleton<IProcessImageWorkflow, ProcessImageWorkflow>();
    builder.Services.AddSingleton<IImageProcessService, ImageProcessService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty;
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks(string.Empty);
});

await app.RunAsync();
