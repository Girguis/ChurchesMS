using ChurchMS.Application.Common.Dtos.Document;
using ChurchMS.Application.Contracts.Appsettings;
using ChurchMS.Application.Contracts.Helper;
using ChurchMS.Application.Enums;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ChurchMS.Infrastructure.Documents.Extensions;

public static class QuestContentExtension
{
    private static string FontFamily = FontOptions.DefaultFont;

    public static TextSpanDescriptor SetFontProps(this TextSpanDescriptor descriptor, float fontSize = 14, float lineHeight = 1, bool isBold = false)
    {
        descriptor.FontFamily(FontFamily);

        if (isBold)
            descriptor.Bold();

        descriptor.FontSize(fontSize);
        descriptor.LineHeight(lineHeight);

        return descriptor;
    }

    public static void SetPageDefaults(this PageDescriptor page, PageSizeEnum pageSize = PageSizeEnum.A4Landscape)
    {
        page.Size(GetPageSize(pageSize));
        page.Margin(1, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.ContentFromRightToLeft();
    }

    public static IContainer BorderAndAlign(this IContainer container, string borderColor = "#ddd")
    {
        return container
            .Border(1)
            .BorderColor(borderColor)
            .MinHeight(0.6f)
            .ShowOnce()
            .AlignCenter()
            .AlignMiddle();
    }
    public static void CreateFooter(this PageDescriptor page)
    {
        page.Footer()
            .AlignMiddle()
            .Row(row =>
            {
                row.RelativeItem(6)
                    .AlignRight()
                    .AlignMiddle()
                    .Text(DateTime.Now.ToString("yyyy/MM/dd,hh:mm:sstt"));

                row.RelativeItem(6)
                    .AlignLeft()
                    .AlignMiddle()
                    .Text(x =>
                    {
                        x.Span("Page ").SetFontProps();
                        x.CurrentPageNumber().SetFontProps();
                        x.Span("/").SetFontProps();
                        x.TotalPages().SetFontProps();
                    });
            });
    }

    public static void CreateHeader(this PageDescriptor page, IFileHelper fileHelper, DocumentOptions options)
    {
        page.Header()
            .Row(row =>
            {
                // Right Logo
                if (!string.IsNullOrEmpty(options.RightLogoPath))
                    row.RelativeItem(0.5f).Image(fileHelper.GetFileBytes(options.RightLogoPath)).FitWidth();
                else
                    row.RelativeItem(); // Empty column to balance layout

                // Title and Subtitle
                row.RelativeItem(4).Column(column =>
                {
                    column.Item().Text(options.PageTitle).FontSize(options.PageTitleFontSize).Bold().AlignCenter();
                    if (!string.IsNullOrEmpty(options.PageSubTitle))
                        column.Item().Text(options.PageSubTitle).FontSize(options.PageTitleFontSize - 2).AlignCenter();
                });

                // Left Logo
                if (!string.IsNullOrEmpty(options.LeftLogoPath))
                    row.RelativeItem(0.5f).Image(fileHelper.GetFileBytes(options.LeftLogoPath)).FitWidth();
                else
                    row.RelativeItem(); // Empty column to balance layout
            });
    }

    private static PageSize GetPageSize(PageSizeEnum pageSize)
    {
        return pageSize switch
        {
            PageSizeEnum.A3Portrait => PageSizes.A3,
            PageSizeEnum.A3Landscape => PageSizes.A3.Landscape(),
            PageSizeEnum.A4Portrait => PageSizes.A4,
            PageSizeEnum.A4Landscape => PageSizes.A4.Landscape(),
            PageSizeEnum.A5Portrait => PageSizes.A5,
            PageSizeEnum.A5Landscape => PageSizes.A5.Landscape(),
            PageSizeEnum.LetterPortrait => PageSizes.Letter,
            PageSizeEnum.LetterLandscape => PageSizes.Letter.Landscape(),
            _ => PageSizes.A4.Landscape(),
        };
    }
}