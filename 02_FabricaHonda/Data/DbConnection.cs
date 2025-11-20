using MySql.Data.MySqlClient;
class DbConnection

{
    private readonly string connectionString;

    public DbConnection()
    {

        connectionString = "";
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}