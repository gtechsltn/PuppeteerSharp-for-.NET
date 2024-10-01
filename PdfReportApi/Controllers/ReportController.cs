using Microsoft.AspNetCore.Mvc;
using PdfReportPupeteerApi.Contacts;

namespace PdfReportPupeteerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IPdfReportService _pdfReportService;

        public ReportController(IPdfReportService pdfReportService)
        {
            _pdfReportService = pdfReportService;
        }

        [HttpGet("generate")]
        public async Task<IActionResult> GenerateReport()
        {
            var htmlTemplate = System.IO.File.ReadAllText("Templates/ReportTemplate.html");

            var pdfContent = await _pdfReportService.GeneratePdfReportAsync(htmlTemplate);

            return File(pdfContent, "application/pdf", "report.pdf");
        }
    }
}
