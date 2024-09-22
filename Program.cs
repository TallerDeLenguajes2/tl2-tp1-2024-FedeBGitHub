using System.IO;
using SistemaCadeteria;
using Datos;
using UInterfaz;
using System.Drawing;


string dirCadeteriaSinExtension = "../../../datos_cadeteria";
string dirCadetesSinExtension = "../../../datos_cadete";
int opcion,opcionDatos;
string extension = "";
Cadeteria cadeteria;
AccesoADatos accesoADatos = null;


do
{
    Console.WriteLine("Seleccione con que desea trabajar:");
    Console.WriteLine("1-CSV");
    Console.WriteLine("2-JSON");
    int.TryParse(Console.ReadLine(), out opcionDatos);
    if (opcionDatos<1 || opcionDatos>2)
    {
        Console.WriteLine("Seleccione una opcion valida");
    }
} while (opcionDatos<1 || opcionDatos>2);

switch (opcionDatos)
{
    case 1:
        accesoADatos = new AccesoCSV();
        extension = ".csv";
    break;
    case 2:
        accesoADatos = new AccesoJSON();
        extension = ".json";
    break;
}
    
    cadeteria = accesoADatos.CargarCadeteria(dirCadeteriaSinExtension + extension , dirCadetesSinExtension + extension);
    
//---------------------- Menu --------------------------------------


int nroPedido = 0;
int eleccionPedido;
int idCadete;
bool respuesta;
List<Pedido> pedidosSinEntregar = null;
do
{
    Console.WriteLine("------- Gestionar Pedidos -------");
    Console.WriteLine("1 - Dar alta un pedido");
    Console.WriteLine("2 - Asignar un pedido a un cadete");
    Console.WriteLine("3 - Cambiar estado del pedido");
    Console.WriteLine("4 - Reasignar pedido a otro cadete");
    Console.WriteLine("5 - Informe de pedidos");
    Console.WriteLine("6 - Mostrar Todos los pedidos");
    Console.WriteLine("7 - Salir");

    
    do
    {
        Console.Write("Selecciones una opcion: ");
        int.TryParse(Console.ReadLine(), out opcion);
    } while (opcion<1 || opcion>7 );

    switch (opcion)
    {
        case 1:
            nroPedido++;
            Pedido nuevoPedido = Interfaz.TomarPedido(nroPedido);
            cadeteria.GuardarPedido(nuevoPedido);
        break;
        case 2:
            
            eleccionPedido = Interfaz.ElegirPedido(cadeteria);
            idCadete = Interfaz.ElegirCadete(cadeteria);
            respuesta = cadeteria.AsignarPedido(idCadete,eleccionPedido);

            if (respuesta == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pedido asignado con exito");
                Console.ResetColor();
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al asignar el pedido");
                Console.ResetColor();
            }
        break;
        case 3:
            eleccionPedido = Interfaz.ElegirPedido(cadeteria);
            respuesta = cadeteria.CambiarEstadoPedido(eleccionPedido);
            if (respuesta == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cambio de estado exitoso");
                Console.ResetColor();
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al cambiar estado");
                Console.ResetColor();
            }
        break;
        case 4:
            bool hayPedidos = false;
            do
            {
                pedidosSinEntregar = cadeteria.ListaPedidos.Where(p => p.Estado == "asignado").ToList();
                Console.WriteLine("\n----- Elegir Pedido -----");
                hayPedidos = Interfaz.pedidosAsignadosSinEntregar(cadeteria.ListaPedidos);
                if (hayPedidos == true)
                {
                    do
                    {
                        Console.Write("\nSeleccione el pedido (Nro de Pedido): ");
                    } while (!int.TryParse(Console.ReadLine(), out nroPedido));
                } 
            } while (!pedidosSinEntregar.Any(p => p.Nro == nroPedido) && pedidosSinEntregar.Count>0);

            if (pedidosSinEntregar.Count > 0)
            {
                idCadete = Interfaz.ElegirCadete(cadeteria);
                respuesta = cadeteria.ReasignarPedido(nroPedido,idCadete);
                if (respuesta == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Reasignacion exitosa");
                    Console.ResetColor();
                }else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error al reasignar pedido");
                    Console.ResetColor();
                }
            }else{
                Console.WriteLine("No hay pedidos para reasignar");
            }

            
            
        break;
        case 5:
            Interfaz.Informe(cadeteria);
        break;
        case 6:
            Console.WriteLine("\n---------- Mostrar Pedidos ----------");
            Interfaz.MostrarTodosLosPedidos(cadeteria);
        break;
    }
} while (opcion!=7);


