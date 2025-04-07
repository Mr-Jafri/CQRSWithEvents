
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Logging.ClearProviders()
    .AddConsole(options =>
    {
        options.FormatterName = "default";
    })
    .AddDebug()
    .AddConfiguration(builder.Configuration.GetSection("Logging"));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
