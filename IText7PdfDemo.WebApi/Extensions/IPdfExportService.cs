using System.Threading.Tasks;

namespace IText7PdfDemo.WebApi.Extensions
{
    public interface IPdfExportService
    {
        Task<byte[]> ExportToPdf(object model, string viewName);
    }
}