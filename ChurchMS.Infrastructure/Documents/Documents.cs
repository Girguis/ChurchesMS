using ChurchMS.Application.Common.Dtos.Document;
using ChurchMS.Application.Constants;
using ChurchMS.Application.Contracts.Documents;
using ChurchMS.Application.Enums;
using ChurchMS.Application.Results;

namespace ChurchMS.Infrastructure.Documents;

public class Documents(IExcelDocument excelDoc, IPDFDocument pdfDoc) : IDocuments
{
    private readonly IExcelDocument _excelDoc = excelDoc;
    private readonly IPDFDocument _pdfDoc = pdfDoc;

    public FileResult Generate<T>(IEnumerable<T> data, DocumentOptions documentOptions, ExportType exportType)
    {
        switch (exportType)
        {
            case ExportType.Excel:
                _excelDoc.SetDocumentOptions(documentOptions);
                return FileResult.Success(_excelDoc.Generate(data), ContentTypes.Excel, string.Concat(documentOptions.FileName, ".xlsx"));
            case ExportType.PDF:
                _pdfDoc.SetDocumentOptions(documentOptions);
                return FileResult.Success(_pdfDoc.Generate(data), ContentTypes.PDF, string.Concat(documentOptions.FileName, ".pdf"));
            default:
                _pdfDoc.SetDocumentOptions(documentOptions);
                return FileResult.Success(_pdfDoc.Generate(data), ContentTypes.PDF, string.Concat(documentOptions.FileName, ".pdf"));
        }
    }
}