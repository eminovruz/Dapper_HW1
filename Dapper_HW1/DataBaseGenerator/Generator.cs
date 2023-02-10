using Dapper;
using System.Data.SqlClient;

namespace Dapper_HW1.DataBaseGenerator;

static public class Generator
{
    static public void CreateDataBase(SqlConnection? connection)
    {
		try
		{
			connection.Execute("Create DataBase BookShopDB");

			connection.Execute(@"
						use [BookShopDB]

						Create Table [dbo].[Book] (
						[Id]	INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
						[Name]	NVARCHAR(100) NOT NULL,
						[Page]	INT NOT NULL,
						[Author] NVARCHAR(MAX) NOT NULL,
						[Price] INT NOT NULL,
						[Stock] INT NOT NULL
			)
			");
			connection.Execute(@"
			use [BookShopDB]
INSERT INTO [BOOK] VALUES('Holywood Story', 190, 'Emin Novruz', 15, 7);
INSERT INTO [BOOK] VALUES('Dede Qorqud', 55, 'Eli Veliyev', 12, 18);
INSERT INTO [BOOK] VALUES('c#', 85, 'Alex', 20, 11);
");
		}
		catch (Exception ex)
		{
			MessageBox.Show("DataBase Artıq sizdə mövcuddur!");
		}
    }
}
