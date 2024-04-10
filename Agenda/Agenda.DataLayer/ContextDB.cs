using System.Data.SqlClient;

namespace Agenda.DataLayer;
internal static class ContextDB {
    private const string connectionServer = "WINAPCLJ3AIJFYN\\SQLEXPRESS";

    internal static SqlConnection CreateConnection(string db) => new(BuildConnectionString(db));
    private static string BuildConnectionString(string db) => 
        $"Server={connectionServer};Database={db};Trusted_Connection=True;";
}
