namespace PdfReportPupeteerApi.Contacts
{
    public interface IPdfReportService
    {
        public Task<byte[]> GeneratePdfReportAsync(string htmlContent);
    }
}