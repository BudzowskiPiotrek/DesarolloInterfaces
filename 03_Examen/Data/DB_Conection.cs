using MySql.Data.MySqlClient;
class DB_Connection

{
    private readonly string connectionString;

    public DB_Connection()
    {

        connectionString = "";
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}