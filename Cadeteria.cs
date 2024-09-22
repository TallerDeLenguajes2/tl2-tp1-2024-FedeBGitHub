using System.Data.Common;
using System.IO.Compression;

namespace SistemaCadeteria;

public class Cadeteria
    {
        private string nombre;
        private string telefono;
        public string Telefono { get => telefono; }
        public string Nombre { get => nombre; }
        private List<Cadete> listaCadetes;
        private List<Pedido> listaPedidos;
        public Cadeteria (string Nombre, string Telefono, List<Cadete> ListaCadetes)
        {
            nombre = Nombre;
            telefono = Telefono;
            listaCadetes = ListaCadetes;
            listaPedidos = new List<Pedido>();
        }
        public List<Cadete> ListaCadetes { get => listaCadetes; }
        public List<Pedido> ListaPedidos { get => listaPedidos; }

        public bool GuardarPedido(Pedido pedido)
        {
            try
            {
                listaPedidos.Add(pedido);
                return true;
            }
            catch
            {
                return false;
            }
        }


    public bool AsignarPedido(int idCadete, int idPedido)
        {
            bool asignado = false;
            Pedido pedidoElegido = listaPedidos.Find(p => p.Nro == idPedido);
            if (pedidoElegido == null || pedidoElegido.IdCadeteAsignado != -999)
            {
                return asignado;
            }else{
                if(pedidoElegido.IdCadeteAsignado == -999)
                {
                    pedidoElegido.Estado = "asignado";
                    pedidoElegido.IdCadeteAsignado = idCadete;
                    asignado = true;
                }
            }
            return asignado;
            
        }


        public bool CambiarEstadoPedido(int nroElegido)
        {
            bool asignado = false;
            Pedido pedidoElegido = listaPedidos.Find(p => p.Nro == nroElegido);
            if (pedidoElegido != null)
            {
                if (pedidoElegido.Estado == "asignado" || pedidoElegido.Estado == "entregado" ) // un pedido debe estar asignado a un cadete para cambiar su estado a entregado
                {
                    pedidoElegido.Estado = "entregado";
                    asignado = true;
                }
                
            }
            return asignado;
        }

        public bool ReasignarPedido(int nroElegido,int idCadete)
        {
            bool asignado = false;
            Pedido pedidoElegido = listaPedidos.Find(p => p.Nro == nroElegido);
            if (pedidoElegido != null)
            {
                pedidoElegido.IdCadeteAsignado = idCadete;
                asignado = true;
            }
            return asignado;
        }


        public int CalculoPedidosCompletados(int idCadete)
        {
            List<Pedido> pedidosEntregados = listaPedidos.Where(p => p.Estado == "entregado").ToList();
            int numPedidosCompletados = pedidosEntregados.Count(p => p.IdCadeteAsignado == idCadete);
            return numPedidosCompletados;
        }

        public float JornalACobrar(int pedidosCompletados)
        {
            return 500*pedidosCompletados;
        }

}





    
