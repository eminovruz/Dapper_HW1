using Dapper;
using System.Data.SqlClient;
using Z.Dapper.Plus;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        var conStr = "Data Source=DESKTOP-8V8B7U4\\MSSQLSERVER01;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        var connection = new SqlConnection(conStr);
        connection.Execute("DROP DATABASE AuthorDb");
        
    }
}