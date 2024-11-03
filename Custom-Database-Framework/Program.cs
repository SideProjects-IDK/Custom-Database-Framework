using Blockchain_View_Controller.App.Assets.db.Master; // using some code from my revious app, you can sheck it out here https://github.com/SideProjects-IDK/Blokchain-View-Controller--FRAMEWORK-

namespace Custom_Database_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ///////////////////////////////////////////////////////
            //                                                   //  
            // You can create amazing apps using this frmaework, //
            //                                                   //
            // A example program will be published soon!         //   
            //                                                   //
            ///////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Go visit: https://hmza-sfyn.github.io/sideprojects_idk/custom_database_framework/index.html for more info  //
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Register a new database
            var dbCreated = INFORMATIONSCHEMA.Register.New.db.fromConf("TestDB", "db1");
            Console.WriteLine($"Database created: {dbCreated}");

            // Register a new table in the database
            var tableCreated = INFORMATIONSCHEMA.Register.New.table.fromConf("db1", "Users", "tbl1");
            Console.WriteLine($"Table created in TestDB: {tableCreated}");

            // Add columns to the "Users" table
            var column1Added = INFORMATIONSCHEMA.Update.AddColumnToTable("db1", "tbl1", "UserID", "col1");
            var column2Added = INFORMATIONSCHEMA.Update.AddColumnToTable("db1", "tbl1", "UserName", "col2");
            Console.WriteLine($"Column UserID added: {column1Added}");
            Console.WriteLine($"Column UserName added: {column2Added}");

            // <more>
            var column3Added = INFORMATIONSCHEMA.Update.AddColumnToTable("db1", "tbl1", "Balance", "col3");
            var column4Added = INFORMATIONSCHEMA.Update.AddColumnToTable("db1", "tbl1", "Account_Address", "col4");

            Console.WriteLine($"Column Balance added: {column3Added}");
            Console.WriteLine($"Column Account_Address added: {column4Added}");
            // </more>

            // Add rows to the "Users" table
            var row1Added = INFORMATIONSCHEMA.Update.AddRowToTable("db1", "tbl1", "Alice", "row1");
            var row2Added = INFORMATIONSCHEMA.Update.AddRowToTable("db1", "tbl1", "Bob", "row2");
            Console.WriteLine($"Row Alice added: {row1Added}");
            Console.WriteLine($"Row Bob added: {row2Added}");


            // Add 100 dummy entries to the "Users" table
            for (int i = 1; i <= 100; i++)
            {
                string userName = $"User{i}"; // Generate a dummy user name like User1, User2, ..., User100
                var rowAdded = INFORMATIONSCHEMA.Update.AddRowToTable("db1", "tbl1", userName, $"row{i}");
                Console.WriteLine($"Row {userName} added: {rowAdded}");
            }

            // Print the database schema
            Console.WriteLine("\nDatabase Schema:");
            INFORMATIONSCHEMA.Get.Info.Print();

            // Get the database schema as a string and display it
            string schemaInfo = INFORMATIONSCHEMA.Get.Info.Return();
            Console.WriteLine("\nSchema Information (as a string):");
            Console.WriteLine(schemaInfo);


            //
            // QUERIES AND STUFF
            //

            Console.WriteLine("========>>> QUERIES AND STUFF <<<========");

            // Load database schema data
            DATASCHEMA.LoadDataFromInformationSchema();

            // Select all rows from a table
            Console.WriteLine("All rows in TestDB/Users:");
            var allResults = DATASCHEMA.SelectAllFrom("TestDB/Users");
            DATASCHEMA.PrintResults(allResults);

            // Select rows with a where clause
            Console.WriteLine("\nRows in TestDB/Users where Name = 'Alice':");
            var whereResults = DATASCHEMA.SelectFromWhere("TestDB/Users", row => row.Name == "Alice");
            DATASCHEMA.PrintResults(whereResults);
        }
    }
}
