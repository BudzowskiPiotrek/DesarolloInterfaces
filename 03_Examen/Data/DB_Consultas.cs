using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;

public class DB_Consultas
{
    private readonly DB_Connection db_Connection;

    public DB_Consultas()
    {
        db_Connection = new DB_Connection();

    }
    public void ProbarConexion()
    {
        using (var conn = db_Connection.GetConnection())
        {
            try
            {
                conn.Open();
                Console.WriteLine("✔ Conexión exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al conectar: " + ex.Message);
            }
        }
    }

    public List<Dictionary<string, object>> LeerDatos(string tabla)
    {
        var lista = new List<Dictionary<string, object>>();

        using (var conn = db_Connection.GetConnection())
        {
            conn.Open();
            string query = $"SELECT * FROM {tabla}";
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var registro = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        registro[reader.GetName(i)] = reader.GetValue(i);
                    lista.Add(registro);
                }
            }
        }

        return lista;
    }
    public List<Dictionary<string, object>> LeerDatosCon(string tabla, string condicion)
    {
        var lista = new List<Dictionary<string, object>>();

        using (var conn = db_Connection.GetConnection())
        {
            conn.Open();
            string query = $"SELECT * FROM {tabla} Where {condicion}";
            using (var cmd = new MySqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var registro = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        registro[reader.GetName(i)] = reader.GetValue(i);
                    lista.Add(registro);
                }
            }
        }

        return lista;
    }

    public void Insertar(string tabla, Dictionary<string, object> datos)
    {
        using (var conn = db_Connection.GetConnection())
        {
            conn.Open();
            var columnas = string.Join(",", datos.Keys);
            var parametros = string.Join(",", datos.Keys.Select(k => "@" + k));

            string query = $"INSERT INTO {tabla} ({columnas}) VALUES ({parametros})";

            using (var cmd = new MySqlCommand(query, conn))
            {
                foreach (var kvp in datos)
                    cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);

                cmd.ExecuteNonQuery();
            }
        }
    }
    public void Borrar(string tabla, string columnaId, object valorId)
    {
        using (var conn = db_Connection.GetConnection())
        {
            conn.Open();
            string query = $"DELETE FROM {tabla} WHERE {columnaId} = @valorId";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@valorId", valorId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Actualizar(string tabla, string columnaId, object valorId, Dictionary<string, object> datos)
    {
        using (var conn = db_Connection.GetConnection())
        {
            conn.Open();
            var setClause = string.Join(",", datos.Keys.Select(k => $"{k}=@{k}"));

            string query = $"UPDATE {tabla} SET {setClause} WHERE {columnaId}=@valorId";

            using (var cmd = new MySqlCommand(query, conn))
            {
                foreach (var kvp in datos)
                    cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);

                cmd.Parameters.AddWithValue("@valorId", valorId);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static Dictionary<string, object> ConvertirObjetoADiccionario<T>(T obj) where T : class
    {
        var dictionary = new Dictionary<string, object>();

        var propiedades = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanRead);

        foreach (var prop in propiedades)
        {
            // Solo si son en pequeño todas en la tabla
            if (prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)) continue;

            string nombreColumna = prop.Name;
            object? valorColumna = prop.GetValue(obj);

            if (valorColumna == null)
            {
                dictionary.Add(nombreColumna, DBNull.Value);
            }
            else
            {
                dictionary.Add(nombreColumna, valorColumna);
            }
        }
        return dictionary;
    }

}