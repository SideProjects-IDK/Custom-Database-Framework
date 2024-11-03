using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain_View_Controller.App.Assets.db.Master
{
    public class DATASCHEMA
    {
        private static Dictionary<string, INFORMATIONSCHEMA.Register.__Storage_Medium.Database> databases =
            new Dictionary<string, INFORMATIONSCHEMA.Register.__Storage_Medium.Database>();

        // Populate the databases dictionary from INFORMATIONSCHEMA
        public static void LoadDataFromInformationSchema()
        {
            foreach (var db in INFORMATIONSCHEMA.Get.Info.GetAllDatabases())
            {
                databases[db.ID] = db;
            }
        }

        // Select all records from a specified table
        public static List<Dictionary<string, string>> SelectAllFrom(string path)
        {
            var parts = path.Split('/');
            if (parts.Length != 2)
                throw new ArgumentException("Path format should be '$dbname/$tablename'");

            string dbName = parts[0];
            string tableName = parts[1];

            if (databases.TryGetValue(dbName, out var database))
            {
                var table = database.Tables.FirstOrDefault(t => t.Name == tableName || t.ID == tableName);
                if (table != null)
                {
                    // Convert rows to dictionaries with column names as keys
                    return table.Rows.Select(row =>
                        table.Columns.ToDictionary(
                            column => column.Name,
                            column => row.GetType().GetProperty(column.Name)?.GetValue(row, null)?.ToString() ?? "")
                    ).ToList();
                }
            }

            return new List<Dictionary<string, string>>();
        }

        // Select records from a specified table with a WHERE clause
        public static List<Dictionary<string, string>> SelectFromWhere(string path, Func<INFORMATIONSCHEMA.Register.__Storage_Medium.Row, bool> whereClause)
        {
            var parts = path.Split('/');
            if (parts.Length != 2)
                throw new ArgumentException("Path format should be '$dbname/$tablename'");

            string dbName = parts[0];
            string tableName = parts[1];

            if (databases.TryGetValue(dbName, out var database))
            {
                var table = database.Tables.FirstOrDefault(t => t.Name == tableName || t.ID == tableName);
                if (table != null)
                {
                    // Filter rows based on the WHERE clause
                    return table.Rows
                        .Where(whereClause)
                        .Select(row =>
                            table.Columns.ToDictionary(
                                column => column.Name,
                                column => row.GetType().GetProperty(column.Name)?.GetValue(row, null)?.ToString() ?? "")
                        ).ToList();
                }
            }

            return new List<Dictionary<string, string>>();
        }

        // Print results to the console in table format
        public static void PrintResults(List<Dictionary<string, string>> results)
        {
            if (!results.Any())
            {
                Console.WriteLine("No results found.");
                return;
            }

            // Print headers
            var headers = results.First().Keys;
            Console.WriteLine(string.Join(" | ", headers));
            Console.WriteLine(new string('-', headers.Count() * 10));

            // Print rows
            foreach (var row in results)
            {
                Console.WriteLine(string.Join(" | ", row.Values));
            }
        }
    }
}
