using System.Collections.Generic;
using espacioPDetalle;

namespace espacioP;
public class Presupuestos
{
    private int idPresupuesto;
    private int clienteId;
    private List<PresupuestosDetalle> detalle;
    private DateTime fechacreacion;

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value;}
    public int ClienteId { get => clienteId; set => clienteId = value;}
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