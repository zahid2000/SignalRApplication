using WebSocket.Business;
using WebSocket.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(origin => true);
    });
});
builder.Services.AddSignalR();

builder.Services.AddScoped<MyBusiness>();
builder.Services.AddControllers();
var app = builder.Build();

app.UseCors();
app.UseRouting();
//app.MapGet("/", () => "Hello World!");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageHub>("/messagehub");
    endpoints.MapHub<MyHub>("/myhub");
    endpoints.MapControllers();
});
app.Run();
