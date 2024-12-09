using ChurchMS.Application.Contracts.Documents;
using ChurchMS.Application.Contracts.Helper;
using ChurchMS.Infrastructure.Documents;
using ChurchMS.Infrastructure.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace ChurchMS.Infrastructure.Extensions;

internal static class DocumentService
{
    internal static IServiceCollection AddDocumentService(this IServiceCollection services)
    {
        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

        services.AddSingleton(typeof(IFileHelper), typeof(FileHelper));
        services.AddSingleton(typeof(IPDFDocument), typeof(PDFDocument));
        services.AddSingleton(typeof(IExcelDocument), typeof(ExcelDocument));
        services.AddSingleton(typeof(IDocuments), typeof(Documents.Documents));

        return services;
    }
}