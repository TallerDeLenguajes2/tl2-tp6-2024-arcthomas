
using espacioP;
using System.Data.SqlClient;
using espacioPDetalle;
using espacioProductos;
using Microsoft.Data.Sqlite;
using espacioInterfaz;

public class ProductosRepository : IProductosRepository
{
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
                    Productos producto = new Productos();
                    producto.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    producto.Descripcion = reader["Descripcion"].ToString();
                    producto.Precio = Convert.ToInt32(reader["Precio"]);
                    listaProductos.Add(producto);
                }
            }
            connection.Close();
        }
        return listaProductos;
    }
    public void Create(Productos prod)
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "INSERT INTO Productos (Descripcion, Precio) VALUES (@desc, @precio);";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@desc", prod.Descripcion);
            command.Parameters.AddWithValue("@precio", prod.Precio);
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
            string queryString = "UPDATE Productos SET Descripcion = @desc, Precio = @precio WHERE idProducto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@desc", prod.Descripcion);
            command.Parameters.AddWithValue("@id", prod.IdProducto);
            command.Parameters.AddWithValue("@precio", prod.Precio);
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
            string queryString = "SELECT Descripcion, Precio FROM Productos WHERE idProducto = @id;";
            var command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Productos Producto = new Productos();
                    Producto.Descripcion = reader["Descripcion"].ToString();
                    Producto.IdProducto = id;
                    Producto.Precio = Convert.ToInt32(reader["Precio"]);
                    connection.Close();
                    return Producto;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
        }
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
