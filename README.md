# Custom-Database-Framework

A custom (little) Framework built for creating and managing custom databases and objects.

> ## **Author: hmZa-Sfyn**
> ## ***Github: [hmZa](https://github.com/hmZa-Sfyn)***

## Motivation

Creating and managing databases can often be complex and tedious, especially when you need a lightweight solution. This framework aims to simplify the process of handling custom databases, making it easier for developers to create and manipulate data without the overhead of larger database management systems.

## Idea And Development Process

The framework was developed with the goal of providing a straightforward way to manage custom databases. The development process involved several key steps:

1. **Requirements Gathering**: Understanding the needs of potential users and defining the core functionalities.
2. **Designing the Architecture**: Creating a modular architecture that allows for easy extension and maintenance.
3. **Implementation**: Writing the core components of the framework while ensuring code quality and readability.
4. **Testing**: Implementing unit tests to ensure the framework functions as expected and handling edge cases.
5. **Documentation**: Writing comprehensive documentation to help users understand and utilize the framework effectively.

## Features

- **Custom Object Management**: Easily create and manage custom objects within the database.
- **Simple API**: A straightforward API that allows for quick database operations without deep learning curves.
- **Lightweight**: Minimal resource requirements, making it suitable for small projects or embedded systems.

## Installation

To install the Custom-Database-Framework, simply clone the repository and include the framework files in your project:

```git clone https://github.com/yourusername/custom-database-framework.git```

## Usage

Here’s a simple example of how to use the Custom-Database-Framework:

```csharp
using Blockchain_View_Controller.App.Assets.db.Master; // using some code from my previous app, you can check it out here https://github.com/SideProjects-IDK/Blokchain-View-Controller--FRAMEWORK-

namespace Custom_Database_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
```

## Contributing

Contributions are welcome! If you have suggestions for improvements or new features, please feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
