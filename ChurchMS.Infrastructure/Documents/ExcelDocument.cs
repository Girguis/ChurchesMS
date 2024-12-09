using ChurchMS.Application.Common.Dtos.Document;
using ChurchMS.Application.Contracts.Appsettings;
using ChurchMS.Application.Contracts.Documents;
using ChurchMS.Infrastructure.Documents.Extensions;
using ClosedXML.Excel;

namespace ChurchMS.Infrastructure.Documents;

public class ExcelDocument : IExcelDocument
{
    public DocumentOptions _options = new();

    public void SetDocumentOptions(DocumentOptions options)
    {
        _options = options;
    }

    public byte[] Generate<TModel>(IEnumerable<TModel> data)
    {
        var dataTable = data.ToDataTable(_options.TableColumnsOptions);
        MemoryStream stream = new();
        using (var wb = new XLWorkbook())
        {
            wb.RightToLeft = true;
            var ws = wb.Worksheets.Add();

            // Insert title
            ws.Cell(1, 1).Value = _options.PageTitle;
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = _options.PageTitleFontSize;
            ws.Range(1, 1, 1, dataTable.Columns.Count).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Insert subtitle if provided
            if (!string.IsNullOrEmpty(_options.PageSubTitle))
            {
                ws.Cell(2, 1).Value = _options.PageSubTitle;
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Cell(2, 1).Style.Font.FontSize = _options.PageTitleFontSize - 2;
                ws.Range(2, 1, 2, dataTable.Columns.Count).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int headerRow = !string.IsNullOrEmpty(_options.PageSubTitle) ? 3 : 2;

            ws.Cell(headerRow, 1).InsertTable(dataTable, "MainTable", true);

            ws.Table("MainTable").Style.Font.FontName = FontOptions.DefaultFont;
            ws.Table("MainTable").Style.Font.FontSize = 16;

            ws.Table("MainTable").Row(1).Style.Font.SetBold();
            ws.Table("MainTable").Row(1).Style.Font.FontSize = 18;

            ws.Columns().AdjustToContents();
            ws.Rows().AdjustToContents();

            wb.SaveAs(stream);
        }

        return stream.ToArray();
    }
}