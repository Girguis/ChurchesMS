using ChurchMS.Application.Common.Dtos.Document;
using ChurchMS.Application.Contracts.Documents;
using ChurchMS.Application.Contracts.Helper;
using ChurchMS.Infrastructure.Documents.Extensions;
using QuestPDF.Fluent;

namespace ChurchMS.Infrastructure.Documents;

public class PDFDocument(IFileHelper fileHelper) : IPDFDocument
{
    private DocumentOptions _options = new();
    private readonly IFileHelper _fileHelper = fileHelper;

    public void SetDocumentOptions(DocumentOptions options)
    {
        _options = options;
    }

    public byte[] Generate<TModel>(IEnumerable<TModel> data)
    {
        var dataTable = data.ToDataTable(_options.TableColumnsOptions);
        var document = Document.Create(container =>
        {
            container
                .Page(page =>
                {
                    page.SetPageDefaults(_options.PageSize);
                    page.CreateHeader(_fileHelper, _options);
                    page.Content()
                      .Column(col =>
                      {
                          col
                          .Item()
                          .Table(table =>
                                    table.GenerateTable(dataTable,
                                                        _options.FixedColumnsWidth,
                                                        _options.FooterData)
                                );
                      });
                    page.CreateFooter();
                });
        });

        return document.GeneratePdf();
    }
}