using MySql.Data.MySqlClient;

class DbConsultas
{
    private readonly DbConnection dbConnection;

    public DbConsultas()
    {
        dbConnection = new DbConnection();
    }

    // MODELOS  #############################################################################################################################
    public List<Modelo> ObtenerModelos()
    {
        var lista = new List<Modelo>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT id_real, id_logico, nombre, descripcion FROM modelos ORDER BY id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Modelo
            {
                IdReal = reader.GetInt32("id_real"),
                IdLogico = reader.GetInt32("id_logico"),
                Nombre = reader.GetString("nombre"),
                Descripcion = reader.GetString("descripcion")
            });
        }
        return lista;
    }
    public void InsertarModelo(Modelo m)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO modelos (id_logico, nombre, descripcion) VALUES (@id_logico, @nombre, @descripcion)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", m.IdLogico);
        cmd.Parameters.AddWithValue("@nombre", m.Nombre);
        cmd.Parameters.AddWithValue("@descripcion", m.Descripcion);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarModelo(Modelo m)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE modelos SET nombre=@nombre, descripcion=@descripcion WHERE id_logico=@id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", m.IdLogico);
        cmd.Parameters.AddWithValue("@nombre", m.Nombre);
        cmd.Parameters.AddWithValue("@descripcion", m.Descripcion);
        cmd.ExecuteNonQuery();
    }

    // COLORES #############################################################################################################################

    public List<ColorCoche> ObtenerColores()
    {
        var lista = new List<ColorCoche>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT id_real, id_logico, nombre, codigo FROM colores ORDER BY id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new ColorCoche
            {
                IdReal = reader.GetInt32("id_real"),
                IdLogico = reader.GetInt32("id_logico"),
                Nombre = reader.GetString("nombre"),
                Codigo = reader.GetString("codigo")
            });
        }
        return lista;
    }

    public void InsertarColor(ColorCoche c)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO colores (id_logico, nombre, codigo) VALUES (@id_logico, @nombre, @codigo)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", c.IdLogico);
        cmd.Parameters.AddWithValue("@nombre", c.Nombre);
        cmd.Parameters.AddWithValue("@codigo", c.Codigo);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarColor(ColorCoche c)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE colores SET nombre=@nombre, codigo=@codigo WHERE id_logico=@id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", c.IdLogico);
        cmd.Parameters.AddWithValue("@nombre", c.Nombre);
        cmd.Parameters.AddWithValue("@codigo", c.Codigo);
        cmd.ExecuteNonQuery();
    }

    // PAQUETES EXTRAS #############################################################################################################################

    public List<PaqueteExtra> ObtenerPaquetes()
    {
        var lista = new List<PaqueteExtra>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT id_real, id_logico, nombre, descripcion FROM paquetes ORDER BY id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new PaqueteExtra
            {
                IdReal = reader.GetInt32("id_real"),
                IdLogico = reader.GetInt32("id_logico"),
                Nombre = reader.GetString("nombre"),
                Descripcion = reader.GetString("descripcion")
            });
        }
        return lista;
    }

    public void InsertarPaquete(PaqueteExtra p)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO paquetes (id_logico, nombre, descripcion) VALUES (@id_logico, @nombre, @descripcion)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", p.IdLogico);
        cmd.Parameters.AddWithValue("@nombre", p.Nombre);
        cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarPaquete(PaqueteExtra p)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE paquetes SET nombre=@nombre, descripcion=@descripcion WHERE id_logico=@id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", p.IdLogico);
        cmd.Parameters.AddWithValue("@nombre", p.Nombre);
        cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
        cmd.ExecuteNonQuery();
    }

    // MOTORES #############################################################################################################################

    public List<Motor> ObtenerMotores()
    {
        var lista = new List<Motor>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT id_real, serie, tipo, disponible FROM motores ORDER BY serie";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Motor
            {
                IdReal = reader.GetInt32("id_real"),
                Serie = reader.GetString("serie"),
                Tipo = reader.GetString("tipo"),
                Disponible = reader.GetBoolean("disponible")
            });
        }
        return lista;
    }

    public void InsertarMotor(Motor m)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO motores (serie, tipo, disponible) VALUES (@serie, @tipo, @disponible)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@serie", m.Serie);
        cmd.Parameters.AddWithValue("@tipo", m.Tipo);
        cmd.Parameters.AddWithValue("@disponible", m.Disponible);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarMotorDisponibilidad(string serie, bool disponible)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE motores SET disponible=@disponible WHERE serie=@serie";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@serie", serie);
        cmd.Parameters.AddWithValue("@disponible", disponible);
        cmd.ExecuteNonQuery();
    }

    // COCHES #############################################################################################################################

    public List<Coche> ObtenerCoches()
    {
        var lista = new List<Coche>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = @"
                SELECT c.id_real, c.id_logico, c.vin, m.nombre AS modelo, co.nombre AS color, p.nombre AS paquete, c.motor_serie, c.observaciones
                    FROM coches c
                    LEFT JOIN modelos m   ON c.modelo_id   = m.id_real
                    LEFT JOIN colores co  ON c.color_id    = co.id_real
                    LEFT JOIN paquetes p  ON c.paquete_id  = p.id_real
                ORDER BY c.id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Coche
            {
                IdReal = reader.GetInt32("id_real"),
                IdLogico = reader.GetInt32("id_logico"),
                VIN = reader.GetString("vin"),
                ModeloNombre = reader["modelo"]?.ToString(),
                ColorNombre = reader["color"]?.ToString(),
                PaqueteNombre = reader["paquete"]?.ToString(),
                MotorSerie = reader["motor_serie"]?.ToString(),
                Observaciones = reader["observaciones"]?.ToString()
            });
        }
        return lista;
    }

    public void InsertarCoche(Coche c)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO coches (id_logico, vin, modelo_id) VALUES (@id_logico, @vin, @modelo_id)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", c.IdLogico);
        cmd.Parameters.AddWithValue("@vin", c.VIN);
        cmd.Parameters.AddWithValue("@modelo_id", c.ModeloId);
        cmd.ExecuteNonQuery();
    }

    public void ActualizarCoche(Coche c)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = @"
                UPDATE coches
                    SET vin        = @vin,
                        modelo_id  = @modelo_id,
                        color_id   = @color_id,
                        paquete_id = @paquete_id,
                        motor_serie= @motor_serie,
                        observaciones = @observaciones
                WHERE id_logico = @id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", c.IdLogico);
        cmd.Parameters.AddWithValue("@vin", c.VIN);
        cmd.Parameters.AddWithValue("@modelo_id", c.ModeloId);
        cmd.Parameters.AddWithValue("@color_id", (object)c.ColorId ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@paquete_id", (object)c.PaqueteId ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@motor_serie", (object)c.MotorSerie ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@observaciones", (object)c.Observaciones ?? DBNull.Value);
        cmd.ExecuteNonQuery();
    }

    public void CambiarColorCoche(int idLogico, int nuevoColorId)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE coches SET color_id=@color_id WHERE id_logico=@id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", idLogico);
        cmd.Parameters.AddWithValue("@color_id", nuevoColorId);
        cmd.ExecuteNonQuery();
    }

    public void CambiarPaqueteCoche(int idLogico, int nuevoPaqueteId)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE coches SET paquete_id=@paquete_id WHERE id_logico=@id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", idLogico);
        cmd.Parameters.AddWithValue("@paquete_id", nuevoPaqueteId);
        cmd.ExecuteNonQuery();
    }

    public void AsignarMotorCoche(int idLogico, string motorSerie)
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE coches SET motor_serie=@motor_serie WHERE id_logico=@id_logico";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id_logico", idLogico);
        cmd.Parameters.AddWithValue("@motor_serie", motorSerie);
        cmd.ExecuteNonQuery();

        string sql2 = "UPDATE motores SET disponible=0 WHERE serie=@motor_serie";
        using var cmd2 = new MySqlCommand(sql2, conn);
        cmd2.Parameters.AddWithValue("@motor_serie", motorSerie);
        cmd2.ExecuteNonQuery();
    }
}