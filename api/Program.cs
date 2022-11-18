using psd_api.Helpers;
using psd_merge;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<FileUploadFilter>();
});

builder.Services.InitialServicesCollections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSD Server Swagger v1");
    c.RoutePrefix = string.Empty;
});
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
