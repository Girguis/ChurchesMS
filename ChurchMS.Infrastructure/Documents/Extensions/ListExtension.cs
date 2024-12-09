using ChurchMS.Application.Common.Dtos.Document;
using System.Data;

namespace ChurchMS.Infrastructure.Documents.Extensions;

public static class ListExtension
{
    public static DataTable ToDataTable<T>(this IEnumerable<T> data, TableOptions tableColumnsOptions)
    {
        //Get All Props of the Class Except for Excluded
        var props = typeof(T)
                        .GetProperties()
                        .Where(x => !tableColumnsOptions.AttributesToExclude.Contains(x.Name));

        //Create a new DataTable With Columns to be Displayed Only
        var dataTable = new DataTable();
        foreach (var prop in props)
        {
            tableColumnsOptions.ColumnsDisplayNames.TryGetValue(prop.Name, out string colName);

            if (string.IsNullOrEmpty(colName))
                colName = prop.Name;

            dataTable.Columns.Add(colName);
            dataTable.Columns[colName].DataType = prop.GetPropertyType();
        }

        //Fill DataTable
        foreach (var rowData in data)
        {
            var row = dataTable.NewRow();
            foreach (var col in props)
            {
                var attributeValue = rowData
                                    ?.GetType()
                                    ?.GetProperty(col.Name)
                                    ?.GetValue(rowData, null);

                row[col.Name] = attributeValue;
            }
            dataTable.Rows.Add(row);
        }

        return dataTable;
    }
}