using ChurchMS.Application.Common.Dtos.Document;

namespace ChurchMS.Application.Contracts.Documents;

public interface IPDFDocument
{
    byte[] Generate<TModel>(IEnumerable<TModel> data);
    void SetDocumentOptions(DocumentOptions options);
}