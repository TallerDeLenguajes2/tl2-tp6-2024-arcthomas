using System.ComponentModel.DataAnnotations;
namespace espacioProductos;
public class Productos
{
    private int idProducto;
    private string descripcion;
    private int precio;
    public int IdProducto { get => idProducto; set => idProducto = value; }
    [MaxLength(250)]
    public string Descripcion { get => descripcion; set => descripcion = value; }
    [Required]
    [Range(0, 1000000)]
    public int Precio { get => precio; set => precio = value; }
}