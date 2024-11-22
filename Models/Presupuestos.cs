using System.Collections.Generic;
using espacioPDetalle;

namespace espacioP;
public class Presupuestos
{
    private int idPresupuesto;
    private string nombreDestinatario;
    private List<PresupuestosDetalle> detalle;
    private DateTime fechacreacion;

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value;}
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value;}
    public List<PresupuestosDetalle> Detalle { get => detalle; set => detalle = value;}
    public DateTime FechaCreacion { get => fechacreacion; set => fechacreacion = value;}

    public void MontoPresupuesto()
    {
    }
    public void MontoPresupuestoConIva()
    {
    }
    public void CantidadProductos()
    {
    }
}