using ChurchMS.Application.Common.Dtos.Document;

namespace ChurchMS.Application.Contracts.Documents;

public interface IExcelDocument
{
    void SetDocumentOptions(DocumentOptions options);
    byte[] Generate<TModel>(IEnumerable<TModel> data);
}