using PdfReportPupeteerApi.Contacts;
using PuppeteerSharp;

namespace PdfReportPupeteerApi.Services
{
    public class PdfReportService : IPdfReportService
    {
        public PdfReportService() { }


        public async Task<byte[]> GeneratePdfReportAsync(string htmlContent)
        {
            // Inside your async method or service constructor
            //var options = new LaunchOptions
            //{
            //    Headless = true,
            //    ExecutablePath = Path.Combine(Directory.GetCurrentDirectory(), "Chromium", "chrome.exe")
            //};

            var options = new LaunchOptions
            {
                Headless = true,
                ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
            };

            //await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
            //using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var browser = await Puppeteer.LaunchAsync(options);

            using var page = await browser.NewPageAsync();
            await page.SetContentAsync(htmlContent);
            var pdfStream = await page.PdfStreamAsync();

            return ConvertStreamToByteArray(pdfStream);
        }

        private byte[] ConvertStreamToByteArray(Stream input)
        {
            using var memoryStream = new MemoryStream();
            input.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
