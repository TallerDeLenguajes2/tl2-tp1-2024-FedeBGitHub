using System.IO;
using SistemaCadeteria;
using LecturaCsv;

//------------------ Cargar datos ------------------------------------
string direccionCadeteriaCSV = "../../../datos_cadeteria.csv";
Cadeteria cadeteria = lecturaCSV.CargarCadeteriaDesdeCSV(direccionCadeteriaCSV);

//---------------------- Menu --------------------------------------
int opcion;
List<Pedido> listaPedidos = new List<Pedido>(); // Tiene todos los pedidos independientemente de cual sea el cadete al que sean asignados
do
{
    Console.WriteLine("------- Gestionar Pedidos -------");
    Console.WriteLine("1 - Dar alta un pedido");
    Console.WriteLine("2 - Asignar un pedido a un cadete");
    Console.WriteLine("3 - Cambiar estado del pedido");
    Console.WriteLine("4 - Reasignar pedido a otro cadete");
    Console.WriteLine("5 - Informe de pedidos");
    Console.WriteLine("6 - Mostrar Todos los pedidos"); // Lo agregue yo
    Console.WriteLine("7 - Salir");

    
    do
    {
        Console.Write("Selecciones una opcion: ");
        int.TryParse(Console.ReadLine(), out opcion);
    } while (opcion<1 || opcion>7 );

    switch (opcion)
    {
        case 1:
            cadeteria.TomarPedido(listaPedidos);
        break;
        case 2:
            cadeteria.AsignarPedido(listaPedidos);
        break;
        case 3:
            cadeteria.CambiarEstadoPedido(listaPedidos);
        break;
        case 4:
            cadeteria.ReasignarPedido(listaPedidos);
        break;
        case 5:
            cadeteria.Informe(listaPedidos);
        break;
        case 6:
            Console.WriteLine("\n---------- Mostrar Pedidos ----------");
            foreach (Pedido item in listaPedidos)
            {   
                item.VerPedido();
            }
            Console.WriteLine(" ");
        break;
    }
} while (opcion!=7);


/*
//---------------------- Escribir Archivo CSV ----------------------------------
string path2 = "../../../prueba.csv";
        using (var writer = new StreamWriter(path2))
        {
            // Escribir la cabecera
            writer.WriteLine("Nombre,Edad,Pais");

            // Escribir datos
            writer.WriteLine("Juan,30,España");
            writer.WriteLine("Ana,25,México");
            writer.WriteLine("Pedro,28,Argentina");
        }

*/

/*----------------- Leer CSV usando Stream -----------------------------------
int cont = 0;
List<Cadete> listadoCadetes = new List<Cadete>();
        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();
                string [] values = linea.Split(',');
            
            if (cont>0)
            {
                    Cadete C = new Cadete(int.Parse(values[0]),values[1],values[2],values[3]);
                    listadoCadetes.Add(C);
            }
            cont++;
            }
        }
*/
