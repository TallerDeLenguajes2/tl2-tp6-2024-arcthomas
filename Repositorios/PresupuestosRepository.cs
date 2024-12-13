
using espacioP;
using System.Data.SqlClient;
using espacioPDetalle;
using espacioProductos;
using Microsoft.Data.Sqlite;
using espacioInterfaz;

public class PresupuestosRepository : IPresupuestosRepository
{
    // Listar presupuestos
    public List<Presupuestos> GetAll()
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        List<Presupuestos> listaPresupuestos = new List<Presupuestos>();
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "SELECT IdPresupuesto, ClienteId, FechaCreacion FROM Presupuestos";
            var command = new SqliteCommand(queryString, connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Presupuestos presupuesto = new Presupuestos();
                    presupuesto.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    presupuesto.ClienteId = Convert.ToInt32(reader["ClienteId"]);
                    presupuesto.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    listaPresupuestos.Add(presupuesto);
                }
            }
            connection.Close();
        }
        return listaPresupuestos;
    }
    //Crear presupuestos 
    public void Create(Presupuestos pres)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "INSERT INTO Presupuestos (ClienteId, FechaCreacion) VALUES (@clienteId, @fecha);";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@clienteId", pres.ClienteId);
            string fecha = pres.FechaCreacion.Date.ToString("yyyy-MM-dd");
            command.Parameters.AddWithValue("@fecha", fecha);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void Update(Presupuestos pres)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "UPDATE Presupuestos SET NombreDestinatario = @nombreDest, FechaCreacion = @fecha WHERE idPresupuesto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@nombreDest", pres.ClienteId);
            command.Parameters.AddWithValue("@id", pres.IdPresupuesto);
            string fecha = pres.FechaCreacion.Date.ToString("yyyy-MM-dd");
            command.Parameters.AddWithValue("@fecha", fecha);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public Presupuestos GetById(int id)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "SELECT NombreDestinatario FROM Presupuestos WHERE idPresupuesto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Presupuestos presupuesto = new Presupuestos();
                    presupuesto.ClienteId = Convert.ToInt32(reader["idPresupuesto"]);
                    Console.WriteLine(reader[0]);
                    return presupuesto;
                }
            }
            connection.Close();
        }
        return null;
    }
    public void Delete(int id)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "DELETE FROM Presupuestos WHERE idPresupuesto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
