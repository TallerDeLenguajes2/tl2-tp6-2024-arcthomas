using espacioClientes;
using Microsoft.Data.Sqlite;
using espacioInterfaz;

public class ClientesRepository : IClientesRepository
{

    public List<Clientes> GetAll()
    {
        string CadenaDeConexion = "Data Source=db/Tienda.db";
        List<Clientes> listaClientes = new List<Clientes>();
        using (SqliteConnection connection = new SqliteConnection(CadenaDeConexion))
        {
            string queryString = "SELECT ClienteId, Nombre, Email, Telefono FROM Clientes";
            var command = new SqliteCommand(queryString, connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Clientes cliente = new Clientes();
                    cliente.Id = Convert.ToInt32(reader["ClienteId"]);
                    cliente.Nombre = reader["Nombre"].ToString();
                    cliente.Email = reader["Email"].ToString();
                    cliente.Telefono = reader["Telefono"].ToString();
                    listaClientes.Add(cliente);
                }
            }
            connection.Close();
        }
        return listaClientes;
    }
}
