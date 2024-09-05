using System.Data.Common;

namespace SistemaCadeteria;

public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes;

        public Cadeteria (string Nombre, string Telefono, List<Cadete> ListaCadetes)
        {
            nombre = Nombre;
            telefono = Telefono;
            listaCadetes = ListaCadetes;
        }

        public List<Cadete> ListaCadetes { get => listaCadetes; }

        public void TomarPedido(List<Pedido> listaPedidos)
        {   
            //----Datos del pedido
            Console.WriteLine("\n----------- Tomar Pedido -----------");
            int nroPedido = listaPedidos.Count + 1;
            Console.WriteLine("Nro Pedido: " + nroPedido);
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
            //----Agrego esos pedidos a la lista de pedidos
            listaPedidos.Add(pedido);
        }

        public void AsignarPedido(List<Pedido> listaPedidos)
        {
            int opPedido;
            int opCadete;

            if (listaPedidos.Count > 0) // Verifico que haya porlo menos 1 pedido
            {
                //Mostrar pedidos disponibles
                Console.WriteLine("\n---------- Pedidos Disponibles ----------");
                foreach (Pedido item in listaPedidos)
                {   
                    item.VerPedido();
                }
                Console.WriteLine(" ");
                do
                {
                Console.Write("Seleccione un pedido (Nro de Pedido): ");
                int.TryParse(Console.ReadLine(), out opPedido);
                } while (opPedido<1 || opPedido> listaPedidos.Count);

                //Verifico que el pedido no hay sido asignado 
                foreach (Pedido pedido in listaPedidos)
                {
                    if (pedido.Nro == opPedido)
                    {
                        if (pedido.Estado=="asignado")
                        {
                            Console.WriteLine("\nEl pedido ya a sido asignado a un cadete");
                            return;
                        }
                    }
                }

                //Mostrar Cadetes disponibles para elegir a cual asignarle el pedido
                Console.WriteLine("\n----- Cadetes Disponibles -----");
                foreach (var cadete in ListaCadetes)
                {
                    cadete.datosCadete();
                }
                do
                {
                Console.Write("Selecciones el id del cadete al que desea asignar el pedido:  ");
                int.TryParse(Console.ReadLine(), out opCadete);
                } while (opCadete<1 || opCadete> listaCadetes.Count);

                //Cambio el estado del pedido y lo asocio con el cadete asignado
                Pedido pedidoSelec = null;
                foreach (Pedido pedido in listaPedidos)
                {
                    if (pedido.Nro == opPedido)
                    {
                        pedido.Estado="asignado";
                        pedido.IdCadeteAsignado = opCadete;
                        pedidoSelec = pedido;
                        break;
                    }
                }

                // agrego el pedido a la lista del cadete seleccionado
                foreach (Cadete cadete in ListaCadetes)
                {
                    if (cadete.Id == opCadete)
                    {
                        cadete.ListaPedidos.Add(pedidoSelec);
                        break;
                    }
                }

            }else{
                Console.WriteLine("No hay pedidos disponibles");
            }
            Console.WriteLine(" ");
        }
        public void CambiarEstadoPedido(List<Pedido> listaPedidos)
        {
            int opPedido;
            int idCadete = -1;
            Console.WriteLine("\n--- Cambiar Estado a entregado ---");
            if (listaPedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos disponibles");
                return;
            }
            foreach (Pedido pedido in listaPedidos)
            {   
                if (pedido.Estado=="asignado")
                {
                    pedido.VerPedido();
                }
                
            }
            //---Elegir pedido
                Console.Write("\n Seleccione el Nro de pedido que desea cambiar de estado: ");
                int.TryParse(Console.ReadLine(), out opPedido);
            
            //--Cambiar estado
            foreach (Pedido pedido in listaPedidos)
            {   
                if (pedido.Nro == opPedido)
                {
                    idCadete = pedido.IdCadeteAsignado;
                    pedido.Estado="entregado";
                }
            }
            //-- Cambiar de estado en la lista donde del cadete al que fue asignado
            foreach (Cadete cadet in listaCadetes)
            {
                if (cadet.Id == idCadete)
                {
                    foreach (Pedido pedido in cadet.ListaPedidos)
                    {
                        if (pedido.Nro == opPedido)
                        {
                            pedido.Estado="entregado";
                        }
                    }
                }
            }  
        }
        public void ReasignarPedido(List<Pedido> listaPedidos)
        {
            int opPedido;
            int opCadete;
            int idViejo = -1;
            Pedido pRemover = null;
            Pedido pedidoSelec = null;
            Console.WriteLine("\n----- Reasignar Pedido -----");
            foreach (Pedido pedido in listaPedidos)
            {
                if (pedido.Estado=="asignado")
                {
                    pedido.VerPedido();
                }
            }
            Console.Write("\nSeleccione el pedido a reasignar (Nro de Pedido): ");
            int.TryParse(Console.ReadLine(), out opPedido);

            //Mostrar Cadetes disponibles para elegir a cual asignarle el pedido
            Console.WriteLine("\n----- Cadetes Disponibles -----");
            foreach (var cadete in ListaCadetes)
            {
                cadete.datosCadete();
            }
            Console.Write("Seleccione el id del cadete para asignarle el pedido: ");
            int.TryParse(Console.ReadLine(), out opCadete);

            // cambio el id del cadete asociado
            foreach (Pedido pedido in listaPedidos)
            {
                if (pedido.Nro==opPedido)
                {
                    idViejo = pedido.IdCadeteAsignado;
                    pRemover = pedido; // pedido a remover de la lista del cadete que tenia asignado
                    pedido.IdCadeteAsignado = opCadete; // le doy el id del nuevo cadete asignado
                    pedidoSelec = pedido;

                }
            }
            //Agrego el pedido al nuevo cadete seleccionado
            foreach (Cadete cadete in ListaCadetes)
            {
                if (cadete.Id == opCadete)
                {
                    cadete.ListaPedidos.Add(pedidoSelec);
                    break;
                }
            }

            //Busco el cadete asociado para obtener su listaPedidos
            Cadete cadet = null;
            foreach (Cadete c in ListaCadetes)
            {
                if (c.Id == idViejo)
                {
                    cadet = c;
                }
            }
            //Elimono el pedido de su lista
            cadet.ListaPedidos.Remove(pRemover);

        }

        public void Informe(List<Pedido> listaPedidos)
        {
            Console.WriteLine("----- Informe -----");
            if (listaPedidos.Count > 0)
            {
                Console.WriteLine("Total de pedidos: " + listaPedidos.Count);
                foreach (Cadete cadete in listaCadetes)
                {
                    Console.WriteLine("\n --- Id Cadete {0} ---",cadete.Id);
                    Console.WriteLine("Nombre: " + cadete.Nombre);
                    float jornal = cadete.JornalACobrar();
                    Console.WriteLine("Cantidad Envios: " + cadete.ListaPedidos.Count);
                    Console.WriteLine("Monto ganado: " + jornal);
                    float promedioEnvios =  (cadete.ListaPedidos.Count * 100) / listaPedidos.Count;
                    Console.WriteLine("Promedio de envios: {0} %",promedioEnvios);
                }
            }else{
                Console.WriteLine("Todavia no se hicieron pedidos por lo tanto no se puede realizar el informe");
            }
            
        }

}





    
