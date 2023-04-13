using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace PriceAnalisator.Pres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ReadExcelFile(IFormFile file)
        {
            // Получите поток данных из файла
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            // Откройте пакет Excel из потока данных
            using var excelPackage = new ExcelPackage(stream);

            // Получите первый лист в книге
            var worksheet = excelPackage.Workbook.Worksheets[0];

            // Получите общее количество строк и столбцов на листе
            var rowCount = worksheet.Dimension.End.Row;
            var columnCount = worksheet.Dimension.End.Column;

            // Цикл по каждой строке на листе
            for (int row = 1; row <= rowCount; row++)
            {
                // Цикл по каждому столбцу в текущей строке
                for (int col = 1; col <= columnCount; col++)
                {
                    // Получить значение текущей ячейки и обработать его по мере необходимости
                    var cellValue = worksheet.Cells[row, col].Value?.ToString() ?? string.Empty;
                    Console.WriteLine(cellValue);
                }
            }

            return Ok();
        }

    }
}
