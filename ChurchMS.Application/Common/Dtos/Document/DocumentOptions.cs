using ChurchMS.Application.Enums;

namespace ChurchMS.Application.Common.Dtos.Document;

public sealed class DocumentOptions
{
    public string PageTitle { get; set; } = string.Empty;
    public string PageSubTitle { get; set; } = string.Empty;
    public int PageTitleFontSize { get; set; } = 18;
    public string LeftLogoPath { get; set; } = string.Empty;
    public string RightLogoPath { get; set; } = string.Empty;
    public string FileName { get; set; } = $"Report_{DateTime.Now}";
    public PageSizeEnum PageSize { get; set; } = PageSizeEnum.A4Landscape;
    public Dictionary<int, float> FixedColumnsWidth { get; set; } = [];
    public Dictionary<string, object> FooterData { get; set; } = [];
    public TableOptions TableColumnsOptions { get; set; } = new();
}