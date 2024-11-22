
using espacioP;
using System.Data.SqlClient;
using espacioPDetalle;
using espacioProductos;
using Microsoft.Data.Sqlite;
using espacioInterfaz;

public class ProductosRepository : IProductosRepository
{
    // Listar presupuestos
    public List<Productos> GetAll()
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        List<Productos> listaProductos = new List<Productos>();
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "SELECT idProducto, Descripcion, Precio FROM Productos";
            var command = new SqliteCommand(queryString, connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Productos presupuesto = new Productos();
                    presupuesto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    presupuesto.Descripcion = reader["Descripcion"].ToString();
                    presupuesto.Precio = Convert.ToInt32(reader["Precio"]);
                    listaProductos.Add(presupuesto);
                }
            }
            connection.Close();
        }
        return listaProductos;
    }
    //Crear Productos 
    public void Create(Productos prod)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "INSERT INTO Productos (Descripcion, Precio) VALUES (@nombreDest, @fecha);";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@nombreDest", prod.Descripcion);
            command.Parameters.AddWithValue("@fecha", prod.Precio);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public void Update(Productos prod)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "UPDATE Productos SET Descripcion = @nombreDest, Precio = @fecha WHERE idProducto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@nombreDest", prod.Descripcion);
            command.Parameters.AddWithValue("@id", prod.IdProducto);
            command.Parameters.AddWithValue("@fecha", prod.Precio);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
    public Productos GetById(int id)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "SELECT Descripcion FROM Productos WHERE idProducto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Productos presupuesto = new Productos();
                    presupuesto.Descripcion = reader[0].ToString();
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
            string queryString = "DELETE FROM Productos WHERE idProducto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}