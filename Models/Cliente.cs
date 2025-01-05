using System.ComponentModel.DataAnnotations;

namespace espacioClientes;

public class Clientes
{
    private int id;
    private string nombre;
    private string email;
    private string telefono;
    public int Id { get => id; set => id = value; }
    [Required]
    public string Nombre { get => nombre; set => nombre = value; }
    [EmailAddress]
    public string Email { get => email; set => email = value; }
    [Phone]
    public string Telefono { get => telefono; set => telefono = value; }
}