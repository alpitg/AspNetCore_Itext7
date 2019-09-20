using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IText7PdfDemo.WebApi.Extensions;
using IText7PdfDemo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IText7PdfDemo.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        private readonly IPdfExportService _pdfExportService;


        public SampleDataController(IPdfExportService pdfExportService)
        {
            _pdfExportService = pdfExportService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> PdfExport()
        {

            EmployeeDetails obj = new EmployeeDetails
            {
                Id = 1,
                EmployeeName = "Jack Sparrow",
                Address = "NYC"
            };

            var fileData = await _pdfExportService.ExportToPdf(obj, "Pages/PdfTemplates/Report.cshtml");
            return File(fileData, "application/pdf", "Report.pdf");
        }






        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
