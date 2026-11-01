using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    public static class Database
    {

        public const string ConnectionString =
           @"Data Source=.\SQLEXPRESS;Initial Catalog=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True";
        public static SqlConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}
