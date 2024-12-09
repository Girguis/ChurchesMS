using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;

namespace ChurchMS.Infrastructure.Documents.Extensions;

public static class QuestTableExtension
{
    public static TableDescriptor GenerateTable(this TableDescriptor table, DataTable dataTable, Dictionary<int, float> columnsWidth, Dictionary<string, object>? footerData = null)
    {
        table.ColumnsDefinition(def =>
        {
            for (int i = 0; i < dataTable.Columns.Count; i++)
                if (columnsWidth is not null && columnsWidth.TryGetValue(i, out float width))
                    def.ConstantColumn(width, Unit.Centimetre);
                else
                    def.RelativeColumn();
        });

        //Create Headers of the Table by Using the DataTable Columns
        table.Header(header =>
        {
            for (int i = 0; i < dataTable.Columns.Count; i++)
                header
                    .Cell()
                    .Row(1)
                    .Column((uint)(i + 1))
                    .Background(Colors.Grey.Lighten2)
                    .BorderAndAlign()
                    .Text(dataTable.Columns[i].ColumnName)
                    .SetFontProps(fontSize: 16, isBold: true);
        });

        //Fill Table with Data from DataTable
        for (int row = 0; row < dataTable.Rows.Count; row++)
        {
            for (int col = 0; col < dataTable.Columns.Count; col++)
                if (dataTable.Rows[row][col].IsPrimitive())
                    table
                    .Cell()
                    .Row((uint)row + 2)
                    .Column((uint)col + 1)
                    .BorderAndAlign("#000")
                    .Text(string.IsNullOrEmpty(dataTable.Rows[row][col]?.ToString()) ? "-" : dataTable.Rows[row][col].ToString())
                    .SetFontProps();
                else
                    table.GenerateInternalTable(dataTable.Rows[row][col]);
        }

        if (footerData != null)
        {
            table.Footer(footer =>
            {
                footer.GenerateInternalTable(footerData);
            });
        }

        return table;
    }

    private static TableDescriptor GenerateInternalTable(this TableDescriptor table, object objectData)
    {
        table
        .Cell()
        .Table(internalTable =>
        {
            internalTable.ColumnsDefinition(def =>
            {
                def.RelativeColumn();
                def.RelativeColumn();
            });

            var props = objectData.GetObjectProperties();
            //Fill Table with Data from Object
            foreach (var prop in props)
            {
                internalTable
                        .Cell()
                        .Background(Colors.Grey.Lighten3)
                        .BorderColor(Colors.Black)
                        .Border(1)
                        .Padding(4)
                        .AlignCenter()
                        .Text(prop.Name)
                        .SetFontProps(isBold: true);

                var propertyValue = objectData.GetPropertyValue(prop)?.ToString();

                if (propertyValue.IsPrimitive())
                    internalTable
                        .Cell()
                        .Background(Colors.White)
                        .BorderColor(Colors.Black)
                        .Border(1)
                        .Padding(4)
                        .AlignCenter()
                        .Text(string.IsNullOrEmpty(propertyValue?.ToString()) ? "-" : propertyValue.ToString())
                        .SetFontProps();
                else
                    table.GenerateInternalTable(propertyValue);
            }
        });

        return table;
    }

    private static TableCellDescriptor GenerateInternalTable(this TableCellDescriptor table, Dictionary<string, object> objectData)
    {
        for (int i = 0; i < objectData.Count; i++)
            table
            .Cell()
            .ColumnSpan(2)
            .Table(internalTable =>
            {
                internalTable.ColumnsDefinition(def =>
                {
                    def.RelativeColumn();
                    def.RelativeColumn();
                });

                //Fill Table with Data from Object
                internalTable
                      .Cell()
                      .Background(Colors.Grey.Lighten3)
                      .BorderColor(Colors.Black)
                      .Border(1)
                      .Padding(4)
                      .AlignCenter()
                      .Text(objectData.ElementAt(i).Key)
                      .SetFontProps(isBold: true);

                internalTable
                      .Cell()
                      .Background(Colors.White)
                      .BorderColor(Colors.Black)
                      .Border(1)
                      .Padding(4)
                      .AlignCenter()
                      .Text(string.IsNullOrEmpty(objectData.ElementAt(i).Value?.ToString()) ? "-" : objectData.ElementAt(i).Value.ToString())
                      .SetFontProps();
            });

        return table;
    }
}