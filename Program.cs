using System.IO;
using SistemaCadeteria;
using Datos;


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
            cadeteria.TomarPedido();
        break;
        case 2:
            int nroPedido = cadeteria.ElegirPedido();
            int idCadete = cadeteria.ElegirCadete();
            cadeteria.AsignarPedido(idCadete,nroPedido);
        break;
        case 3:
            cadeteria.CambiarEstadoPedido();
        break;
        case 4:
            cadeteria.ReasignarPedido();
        break;
        case 5:
            cadeteria.Informe();
        break;
        case 6:
            Console.WriteLine("\n---------- Mostrar Pedidos ----------");
            cadeteria.MostrarTodosLosPedidos();
        break;
    }
} while (opcion!=7);


