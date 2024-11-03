using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain_View_Controller.App.Assets.db.Master
{
    public class INFORMATIONSCHEMA
    {
        private static List<Register.__Storage_Medium.Database> Databases = new List<Register.__Storage_Medium.Database>();

        public class Register
        {
            public class New
            {
                public class db
                {
                    public static bool fromConf(string name, string id)
                    {
                        if (Databases.Any(d => d.ID == id || d.Name == name))
                            return false;

                        Databases.Add(new __Storage_Medium.Database
                        {
                            Name = name,
                            ID = id,
                            Tables = new List<__Storage_Medium.Table>()
                        });
                        return true;
                    }
                }
                public class table
                {
                    public static bool fromConf(string dbID, string tableName, string tableID)
                    {
                        var database = Databases.FirstOrDefault(d => d.ID == dbID);
                        if (database == null || database.Tables.Any(t => t.ID == tableID || t.Name == tableName))
                            return false;

                        database.Tables.Add(new __Storage_Medium.Table
                        {
                            Name = tableName,
                            ID = tableID,
                            ParentDB = dbID,
                            Columns = new List<__Storage_Medium.Column>(),
                            Rows = new List<__Storage_Medium.Row>()
                        });
                        return true;
                    }
                }
            }

            public class __Storage_Medium
            {
                public class Database
                {
                    public string Name { get; set; }
                    public string ID { get; set; }
                    public List<Table> Tables { get; set; }
                }
                public class Table
                {
                    public string Name { get; set; }
                    public string ID { get; set; }
                    public string ParentDB { get; set; }

                    public List<Column> Columns { get; set; }
                    public List<Row> Rows { get; set; }
                }
                public class Column
                {
                    public string _sNo { get; set; }
                    public string ID { get; set; }
                    public string Name { get; set; }
                }
                public class Row
                {
                    public string _sNo { get; set; }
                    public string ID { get; set; }
                    public string Name { get; set; }
                }
            }
        }

        public class Get
        {
            public class Info
            {
                // New method to get all registered databases
                public static List<Register.__Storage_Medium.Database> GetAllDatabases()
                {
                    // Return a list of all registered databases
                    return Databases;
                }
                public static void Print()
                {
                    foreach (var db in Databases)
                    {
                        Console.WriteLine($"Database: {db.Name} (ID: {db.ID})");
                        foreach (var table in db.Tables)
                        {
                            Console.WriteLine($"\tTable: {table.Name} (ID: {table.ID})");
                            Console.WriteLine("\tColumns:");
                            foreach (var column in table.Columns)
                            {
                                Console.WriteLine($"\t\tColumn: {column.Name} (ID: {column.ID})");
                            }
                            Console.WriteLine("\tRows:");
                            foreach (var row in table.Rows)
                            {
                                Console.WriteLine($"\t\tRow: {row.Name} (ID: {row.ID})");
                            }
                        }
                    }
                }

                public static string Return()
                {
                    var sb = new System.Text.StringBuilder();
                    foreach (var db in Databases)
                    {
                        sb.AppendLine($"Database: {db.Name} (ID: {db.ID})");
                        foreach (var table in db.Tables)
                        {
                            sb.AppendLine($"\tTable: {table.Name} (ID: {table.ID})");
                            sb.AppendLine("\tColumns:");
                            foreach (var column in table.Columns)
                            {
                                sb.AppendLine($"\t\tColumn: {column.Name} (ID: {column.ID})");
                            }
                            sb.AppendLine("\tRows:");
                            foreach (var row in table.Rows)
                            {
                                sb.AppendLine($"\t\tRow: {row.Name} (ID: {row.ID})");
                            }
                        }
                    }
                    return sb.ToString();
                }

                public static Register.__Storage_Medium.Database GetDatabaseByID(string dbID)
                {
                    return Databases.FirstOrDefault(d => d.ID == dbID);
                }

                public static Register.__Storage_Medium.Table GetTableByID(string dbID, string tableID)
                {
                    var db = GetDatabaseByID(dbID);
                    return db?.Tables.FirstOrDefault(t => t.ID == tableID);
                }
            }
        }

        public class Update
        {
            public static bool AddColumnToTable(string dbID, string tableID, string columnName, string columnID)
            {
                var table = Get.Info.GetTableByID(dbID, tableID);
                if (table == null || table.Columns.Any(c => c.ID == columnID || c.Name == columnName))
                    return false;

                table.Columns.Add(new Register.__Storage_Medium.Column
                {
                    _sNo = (table.Columns.Count + 1).ToString(),
                    ID = columnID,
                    Name = columnName
                });
                return true;
            }

            public static bool AddRowToTable(string dbID, string tableID, string rowName, string rowID)
            {
                var table = Get.Info.GetTableByID(dbID, tableID);
                if (table == null || table.Rows.Any(r => r.ID == rowID || r.Name == rowName))
                    return false;

                table.Rows.Add(new Register.__Storage_Medium.Row
                {
                    _sNo = (table.Rows.Count + 1).ToString(),
                    ID = rowID,
                    Name = rowName
                });
                return true;
            }
        }
    }
}
