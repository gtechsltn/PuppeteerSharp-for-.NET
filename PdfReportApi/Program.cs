using PdfReportPupeteerApi.Services;
using PdfReportPupeteerApi.Contacts;
using PuppeteerSharp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Register the DinkToPdf converter and the PdfReportService
//builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IPdfReportService,PdfReportService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine("system is running....");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Download Chromium when the app starts
//await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

