using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Fixed Window
builder.Services.AddRateLimiter((options) =>
{
    options.AddFixedWindowLimiter("WindowsLimitter", (windowsOption) =>
    {
        windowsOption.Window = TimeSpan.FromSeconds(10);
        windowsOption.PermitLimit = 1; // her 10 saniyede yanlýzca 1 isteðe izin ver
        windowsOption.QueueLimit = 2; // 4 istek dýþýnda istek gelirse 2 tanesini kuyruða al
        windowsOption.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
    });
});
#endregion

#region Sliding Window
//builder.Services.AddRateLimiter(options =>
//{
//    options.AddSlidingWindowLimiter("Sliding", _options =>
//    {
//        _options.Window = TimeSpan.FromSeconds(12);
//        _options.PermitLimit = 4;
//        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        _options.QueueLimit = 2;
//        _options.SegmentsPerWindow = 2;
//    });
//});
#endregion
#region Token Bucket
//builder.Services.AddRateLimiter(options =>
//{
//    options.AddTokenBucketLimiter("Token", _options =>
//    {
//        _options.TokenLimit = 4;
//        _options.TokensPerPeriod = 4;
//        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//        _options.QueueLimit = 2;
//        _options.ReplenishmentPeriod = TimeSpan.FromSeconds(12);
//    });
//});
#endregion
#region Concurrency
//builder.Services.AddRateLimiter(options =>
//{
//    options.AddConcurrencyLimiter("Conccurency", _options =>
//    {
//        _options.PermitLimit = 4;
//        _options.QueueLimit = 2;
//        _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//    });
//});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () =>
{

}).RequireRateLimiting("...");

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
