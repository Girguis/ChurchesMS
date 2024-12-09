using ChurchMS.Application.Common.Dtos.Document;
using ChurchMS.Application.Enums;
using ChurchMS.Application.Results;

namespace ChurchMS.Application.Contracts.Documents;

public interface IDocuments
{
    FileResult Generate<T>(IEnumerable<T> data, DocumentOptions documentOptions, ExportType exportType);
}