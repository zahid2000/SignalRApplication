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
var app = builder.Build();

app.UseCors();
app.UseRouting();
//app.MapGet("/", () => "Hello World!");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/myhub");
});
app.Run();
