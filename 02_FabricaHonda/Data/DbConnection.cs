using MySql.Data.MySqlClient;
class DbConnection

{
    private readonly string connectionString;

    public DbConnection()
    {

        connectionString = "Server=82.223.102.153;Port=3306;Database=FabricaHonda;Uid=fabrica_user;Pwd=Honda2025!;";
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}