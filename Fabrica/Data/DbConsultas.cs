using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

class DbConsultas
{
    private readonly DbConnection dbConnection;

    public DbConsultas()
    {
        dbConnection = new DbConnection(); 
    }

    // MODELOS HONDA #############################################################################################################################
    public List<ModeloHonda> ObtenerModelos() 
    {
        var lista = new List<ModeloHonda>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT Id, nombre, codigo_modelo, segmento FROM ModeloHonda ORDER BY Id";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new ModeloHonda
            {
                Id = reader.GetInt32("Id"),
                Nombre = reader.GetString("nombre"),
                CodigoModelo = reader.GetString("codigo_modelo"), // Corregido: CodigoModelo
                Segmento = reader.IsDBNull(reader.GetOrdinal("segmento")) ? null : reader.GetString("segmento")
            });
        }
        return lista;
    }

    public void InsertarModelo(ModeloHonda m) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO ModeloHonda (nombre, codigo_modelo, segmento) VALUES (@nombre, @codigo_modelo, @segmento)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nombre", m.Nombre); // Corregido: Nombre
        cmd.Parameters.AddWithValue("@codigo_modelo", m.CodigoModelo); // Corregido: CodigoModelo
        cmd.Parameters.AddWithValue("@segmento", (object)m.Segmento ?? DBNull.Value); 
        cmd.ExecuteNonQuery();
    }

    public void ActualizarModelo(ModeloHonda m) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE ModeloHonda SET nombre=@nombre, codigo_modelo=@codigo_modelo, segmento=@segmento WHERE Id=@Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", m.Id);
        cmd.Parameters.AddWithValue("@nombre", m.Nombre); // Corregido: Nombre
        cmd.Parameters.AddWithValue("@codigo_modelo", m.CodigoModelo); // Corregido: CodigoModelo
        cmd.Parameters.AddWithValue("@segmento", (object)m.Segmento ?? DBNull.Value);
        cmd.ExecuteNonQuery();
    }

    // COLORES #############################################################################################################################
    public List<Color> ObtenerColores() 
    {
        var lista = new List<Color>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT Id, nombre, codigo_pintura, acabado FROM Color ORDER BY Id";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Color
            {
                Id = reader.GetInt32("Id"),
                Nombre = reader.GetString("nombre"), // Corregido: Nombre
                CodigoPintura = reader.GetString("codigo_pintura"), // Corregido: CodigoPintura
                Acabado = reader.GetString("acabado") // Corregido: Acabado
            });
        }
        return lista;
    }

    public void InsertarColor(Color c) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO Color (nombre, codigo_pintura, acabado) VALUES (@nombre, @codigo_pintura, @acabado)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nombre", c.Nombre); // Corregido: Nombre
        cmd.Parameters.AddWithValue("@codigo_pintura", c.CodigoPintura); // Corregido: CodigoPintura
        cmd.Parameters.AddWithValue("@acabado", c.Acabado); // Corregido: Acabado
        cmd.ExecuteNonQuery();
    }

    public void ActualizarColor(Color c) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE Color SET nombre=@nombre, codigo_pintura=@codigo_pintura, acabado=@acabado WHERE Id=@Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", c.Id);
        cmd.Parameters.AddWithValue("@nombre", c.Nombre); // Corregido: Nombre
        cmd.Parameters.AddWithValue("@codigo_pintura", c.CodigoPintura); // Corregido: CodigoPintura
        cmd.Parameters.AddWithValue("@acabado", c.Acabado); // Corregido: Acabado
        cmd.ExecuteNonQuery();
    }

    // PAQUETES EXTRAS #############################################################################################################################
    public List<PaqueteExtras> ObtenerPaquetes() 
    {
        var lista = new List<PaqueteExtras>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT Id, nombre, descripcion FROM PaqueteExtras ORDER BY Id";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new PaqueteExtras
            {
                Id = reader.GetInt32("Id"),
                Nombre = reader.GetString("nombre"), // Corregido: Nombre
                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("descripcion") // Corregido: Descripcion
            });
        }
        return lista;
    }

    public void InsertarPaquete(PaqueteExtras p) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO PaqueteExtras (nombre, descripcion) VALUES (@nombre, @descripcion)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@nombre", p.Nombre); // Corregido: Nombre
        cmd.Parameters.AddWithValue("@descripcion", (object)p.Descripcion ?? DBNull.Value); // Corregido: Descripcion
        cmd.ExecuteNonQuery();
    }

    public void ActualizarPaquete(PaqueteExtras p) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE PaqueteExtras SET nombre=@nombre, descripcion=@descripcion WHERE Id=@Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", p.Id);
        cmd.Parameters.AddWithValue("@nombre", p.Nombre); // Corregido: Nombre
        cmd.Parameters.AddWithValue("@descripcion", (object)p.Descripcion ?? DBNull.Value); // Corregido: Descripcion
        cmd.ExecuteNonQuery();
    }

    // MOTORES #############################################################################################################################
    public List<Motor> ObtenerMotores() 
    {
        var lista = new List<Motor>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT num_serie, motor_tipo_id, fecha_fabricacion, potencia_kw, emisiones_wltp FROM Motor ORDER BY num_serie";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Motor
            {
                NumSerie = reader.GetString("num_serie"), // Corregido: NumSerie
                MotorTipoId = reader.GetInt32("motor_tipo_id"), // Corregido: MotorTipoId
                FechaFabricacion = reader.GetDateTime("fecha_fabricacion"), // Corregido: FechaFabricacion
                PotenciaKW = reader.GetDecimal("potencia_kw"), // Corregido: PotenciaKW
                EmisionesWLTP = reader.IsDBNull(reader.GetOrdinal("emisiones_wltp")) ? (decimal?)null : reader.GetDecimal("emisiones_wltp") // Corregido: EmisionesWLTP
            });
        }
        return lista;
    }

    public void InsertarMotor(Motor m) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO Motor (num_serie, motor_tipo_id, fecha_fabricacion, potencia_kw, emisiones_wltp) " +
                     "VALUES (@num_serie, @motor_tipo_id, @fecha_fabricacion, @potencia_kw, @emisiones_wltp)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@num_serie", m.NumSerie); // Corregido: NumSerie
        cmd.Parameters.AddWithValue("@motor_tipo_id", m.MotorTipoId); // Corregido: MotorTipoId
        cmd.Parameters.AddWithValue("@fecha_fabricacion", m.FechaFabricacion); // Corregido: FechaFabricacion
        cmd.Parameters.AddWithValue("@potencia_kw", m.PotenciaKW); // Corregido: PotenciaKW
        cmd.Parameters.AddWithValue("@emisiones_wltp", (object)m.EmisionesWLTP ?? DBNull.Value); // Corregido: EmisionesWLTP
        cmd.ExecuteNonQuery();
    }

    // NUEVO: Tipo de Motor #############################################################################################################################
    
    public List<MotorTipo> ObtenerTiposMotor() 
    {
        var lista = new List<MotorTipo>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "SELECT Id, codigo, descripcion, cilindrada_cc, alimentacion FROM MotorTipo ORDER BY Id";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new MotorTipo
            {
                Id = reader.GetInt32("Id"),
                Codigo = reader.GetString("codigo"), // Corregido: Codigo
                Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? null : reader.GetString("descripcion"), // Corregido: Descripcion
                CilindradaCC = reader.GetInt32("cilindrada_cc"), // Corregido: CilindradaCC
                Alimentacion = reader.GetString("alimentacion") // Corregido: Alimentacion
            });
        }
        return lista;
    }


    // COCHES #############################################################################################################################
    public List<Coche> ObtenerCoches() 
    {
        var lista = new List<Coche>();
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = @"
            SELECT c.vin, m.nombre AS modelo, co.nombre AS color, p.nombre AS paquete, 
                   c.motor_serie, c.observaciones, c.fecha_fabricacion
            FROM Coche c
            LEFT JOIN ModeloHonda m   ON c.modelo_id   = m.Id
            LEFT JOIN Color co  ON c.color_id    = co.Id
            LEFT JOIN PaqueteExtras p  ON c.paquete_id  = p.Id
            ORDER BY c.vin"; 
            
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lista.Add(new Coche
            {
                VIN = reader.GetString("vin"),
                ModeloNombre = reader["modelo"]?.ToString(),
                ColorNombre = reader["color"]?.ToString(),
                PaqueteNombre = reader["paquete"]?.ToString(),
                MotorSerie = reader["motor_serie"]?.ToString(), // Corregido: MotorSerie
                Observaciones = reader["observaciones"]?.ToString(), // Corregido: Observaciones
                FechaFabricacion = reader.GetDateTime("fecha_fabricacion") // Corregido: FechaFabricacion
            });
        }
        return lista;
    }

    public void InsertarCoche(Coche c) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "INSERT INTO Coche (vin, modelo_id, color_id, motor_serie, paquete_id, fecha_fabricacion, observaciones) " +
                     "VALUES (@vin, @modelo_id, @color_id, @motor_serie, @paquete_id, @fecha_fabricacion, @observaciones)";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vin", c.VIN);
        cmd.Parameters.AddWithValue("@modelo_id", c.ModeloId); // Corregido: ModeloId
        cmd.Parameters.AddWithValue("@color_id", (object)c.ColorId ?? DBNull.Value); // Corregido: ColorId
        cmd.Parameters.AddWithValue("@motor_serie", (object)c.MotorSerie ?? DBNull.Value); // Corregido: MotorSerie
        cmd.Parameters.AddWithValue("@paquete_id", (object)c.PaqueteId ?? DBNull.Value); // Corregido: PaqueteId
        cmd.Parameters.AddWithValue("@fecha_fabricacion", c.FechaFabricacion); // Corregido: FechaFabricacion
        cmd.Parameters.AddWithValue("@observaciones", (object)c.Observaciones ?? DBNull.Value); // Corregido: Observaciones
        cmd.ExecuteNonQuery();
    }

    public void ActualizarCoche(Coche c) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = @"
                UPDATE Coche
                    SET modelo_id  = @modelo_id,
                        color_id   = @color_id,
                        paquete_id = @paquete_id,
                        motor_serie= @motor_serie,
                        fecha_fabricacion = @fecha_fabricacion,
                        observaciones = @observaciones
                WHERE vin = @vin"; 
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vin", c.VIN);
        cmd.Parameters.AddWithValue("@modelo_id", c.ModeloId); // Corregido: ModeloId
        cmd.Parameters.AddWithValue("@color_id", (object)c.ColorId ?? DBNull.Value); // Corregido: ColorId
        cmd.Parameters.AddWithValue("@paquete_id", (object)c.PaqueteId ?? DBNull.Value); // Corregido: PaqueteId
        cmd.Parameters.AddWithValue("@motor_serie", (object)c.MotorSerie ?? DBNull.Value); // Corregido: MotorSerie
        cmd.Parameters.AddWithValue("@fecha_fabricacion", c.FechaFabricacion); // Corregido: FechaFabricacion
        cmd.Parameters.AddWithValue("@observaciones", (object)c.Observaciones ?? DBNull.Value); // Corregido: Observaciones
        cmd.ExecuteNonQuery();
    }

    public void CambiarColorCoche(string vin, int nuevoColorId) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE Coche SET color_id=@color_id WHERE vin=@vin";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vin", vin);
        cmd.Parameters.AddWithValue("@color_id", nuevoColorId);
        cmd.ExecuteNonQuery();
    }

    public void CambiarPaqueteCoche(string vin, int nuevoPaqueteId) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE Coche SET paquete_id=@paquete_id WHERE vin=@vin";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vin", vin);
        cmd.Parameters.AddWithValue("@paquete_id", nuevoPaqueteId);
        cmd.ExecuteNonQuery();
    }

    public void AsignarMotorCoche(string vin, string motorSerie) 
    {
        using var conn = dbConnection.GetConnection();
        conn.Open();
        string sql = "UPDATE Coche SET motor_serie=@motor_serie WHERE vin=@vin";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@vin", vin);
        cmd.Parameters.AddWithValue("@motor_serie", motorSerie);
        cmd.ExecuteNonQuery();

        // Código de actualización de Motor/disponibilidad eliminado como se comentó antes.
    }
}