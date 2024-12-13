using espacioClientes;
using espacioP;

namespace PresViewModel;

public class PresupuestoViewModel
{
    public int ClienteId { get; set; }
    public DateTime FechaCreacion { get; set; }
    public List<Clientes> Clientes { get; set; }
}
