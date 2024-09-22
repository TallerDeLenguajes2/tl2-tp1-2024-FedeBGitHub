using SistemaCadeteria;
using Datos;

namespace UInterfaz;
public class Interfaz 
{
    public static Pedido TomarPedido(int nroPedido)
        {   
            //----Datos del pedido
            Console.WriteLine("\n----------- Tomar Pedido -----------");
            Console.Write("Ingrese la observacion: ");
            string obs = Console.ReadLine();
            string estado = "sin asignar";
            //----Datos del cliente
            Console.WriteLine("Datos del cliente");
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el direccion: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el telefono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese datos de referencia de la direccion: ");
            string datosReferencia = Console.ReadLine();
            Console.WriteLine(" ");
            //----Creo un pedido con esos datos
            Pedido pedido = new Pedido(nroPedido,obs,estado,nombre,direccion,telefono,datosReferencia);
            return pedido;
        }
    public static bool pedidosAsignadosSinEntregar(List<Pedido> listaPedidos)
    {
        bool respuesta = false;
        List<Pedido> pedidosSinEntregar = listaPedidos.Where(p => p.Estado == "asignado").ToList();

        if(pedidosSinEntregar.Count==0)
        {
            return respuesta;
        }else{
            respuesta = true;
        }
        foreach (Pedido pedido in pedidosSinEntregar)
            {   
                pedido.VerPedido();
            }
        return respuesta;
    }

    public static void Informe(Cadeteria cadeteria)
    {
        int totalEntregado = 0;
        Console.WriteLine("\n--------- Informe ---------");
        foreach (Cadete cadete in cadeteria.ListaCadetes)
        {
            int numPedidosCompletados = cadeteria.CalculoPedidosCompletados(cadete.Id);
            float pago = cadeteria.JornalACobrar(numPedidosCompletados);
            Console.WriteLine($"{cadete.Nombre}-${pago}");
            totalEntregado += numPedidosCompletados;
            float promedioEnvios =  (numPedidosCompletados * 100) / cadeteria.ListaPedidos.Count;
            Console.WriteLine("Promedio de envios: {0} %",promedioEnvios);
        }
        float promedioEnviosPorCadete = (float)totalEntregado/cadeteria.ListaCadetes.Count;
        Console.WriteLine($"Total Envios: {totalEntregado}\n"); 
    }

    public static void MostrarTodosLosPedidos(Cadeteria cadeteria)
        {
            if (cadeteria.ListaPedidos.Count == 0)
            {
                Console.WriteLine("Todavia no hay pedidos");
                return;
            }else{
                foreach (Pedido item in cadeteria.ListaPedidos)
                {   
                    item.VerPedido();
                }
            }
            
        }

    public static int ElegirPedido(Cadeteria cadeteria)
        {
            int nroPedido;
            Console.WriteLine("\n----- Elegir Pedido -----");
            MostrarTodosLosPedidos(cadeteria);
            Console.Write("\nSeleccione el pedido (Nro de Pedido): ");
            int.TryParse(Console.ReadLine(), out nroPedido);
            return nroPedido;
        }

        public static int ElegirCadete(Cadeteria cadeteria)
        {
            int idCadete;
            Console.WriteLine("\n----- Cadetes Disponibles -----");
            foreach (var cadete in cadeteria.ListaCadetes)
            {
                cadete.datosCadete();
            }
            Console.Write("Seleccione el id del cadete: ");
            int.TryParse(Console.ReadLine(), out idCadete);
            return idCadete;
        }
}