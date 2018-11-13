using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DllExporter.Core
{
    public class Exportor
    {
        public void Export(params string[] fullPaths)
        {
            var members = fullPaths.SelectMany(fullPath => Assembly.LoadFile(fullPath).GetTypes()).Where(x => x.IsInterface).SelectMany(x => x.GetMembers());

            DataTable data = new DataTable();

            data.Columns.Add("Name", typeof(string));
            data.Columns.Add("DeclaringType", typeof(string));

            foreach (var info in members)
            {
                DataRow row = data.NewRow();

                row["Name"] = info.Name;
                row["DeclaringType"] = info.DeclaringType.Name;

                data.Rows.Add(row);
            }

            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(new Random(Environment.TickCount).Next() + ".xlsx"))
                {
                    int count = excelHelper.DataTableToExcel(data, "Sheet1", true);

                    Console.WriteLine("OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
