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
//---------------------------------------------------------------------------------
        public void TomarPedido()
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
//-------------------------------------------------------------------------------
        public void AsignarPedido(int idCadete, int idPedido)
        {
            foreach (Pedido pedido in listaPedidos)
            {
                if (pedido.Nro == idPedido)
                {
                    if (pedido.Estado == "asignado")
                    {
                        Console.WriteLine("El pedido ya está asignado a un cadete");
                        return;
                    }
                    if (pedido.Estado == "entregado")
                    {
                        Console.WriteLine("El pedido ya fue entregado, por lo tanto no se puede asignar de nuevo");
                        return;
                    }
                    pedido.Estado = "asignado";
                    pedido.IdCadeteAsignado = idCadete;
                }
            }
        }
//--------------------------------------------------------------------------------
        public void CambiarEstadoPedido()
        {
            int nroPedido;
            Console.WriteLine("\n--- Cambiar Estado a entregado ---");
            if (listaPedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos disponibles");
                return;
            }
            //---Elegir pedido
                nroPedido = ElegirPedido();
            
            //--Cambiar estado
            foreach (Pedido pedido in listaPedidos)
            {   
                if (pedido.Nro == nroPedido)
                {
                    if (pedido.Estado =="sin asignar")
                    {
                        Console.WriteLine("El pedido debe estar asignado a un cadete para cambiar su estado a entregado ");
                        return;
                    }else{
                        pedido.Estado="entregado";
                    }
                    
                }
            }
        }
//--------------------------------------------------------------------------------
        public void ReasignarPedido()
        {
            int nroPedido;
            int idCadete;
            Console.WriteLine("\n----- Reasignar Pedido -----");
            nroPedido = ElegirPedido();
            //Mostrar Cadetes disponibles para elegir a cual asignarle el pedido
            idCadete = ElegirCadete();

            // cambio el id del cadete asociado
            AsignarPedido(idCadete,nroPedido);
        }
//--------------------------------------------------------------------------------
        public float JornalACobrar(int idCadete)
        {
            float jornal = 0;
            foreach (Pedido pedido in listaPedidos)
            {
                if (pedido.IdCadeteAsignado == idCadete && pedido.Estado =="entregado")
                {
                    jornal += 500;
                }
            }
            return jornal;
        }
//--------------------------------------------------------------------------------
        public void Informe()
        {
            Console.WriteLine("----- Informe -----");
            if (listaPedidos.Count > 0)
            {
                Console.WriteLine("Total de pedidos: " + listaPedidos.Count);
                foreach (Cadete cadete in listaCadetes)
                {
                    Console.WriteLine("\n --- Id Cadete {0} ---",cadete.Id);
                    Console.WriteLine("Nombre: " + cadete.Nombre);
                    float jornal = JornalACobrar(cadete.Id);
                    int cantEnviosCadete = listaPedidos.Count(p => p.IdCadeteAsignado == cadete.Id);
                    Console.WriteLine("Cantidad Envios: " + cantEnviosCadete);
                    Console.WriteLine("Monto ganado: " + jornal);
                    float promedioEnvios =  (cantEnviosCadete * 100) / listaPedidos.Count;
                    Console.WriteLine("Promedio de envios: {0} %",promedioEnvios);
                }
            }else{
                Console.WriteLine("Todavia no se hicieron pedidos por lo tanto no se puede realizar el informe");
            }
        }
//--------------------------------------------------------------------------------
        public void MostrarTodosLosPedidos()
        {
            foreach (Pedido item in listaPedidos)
            {   
                item.VerPedido();
            }
        }
//--------------------------------------------------------------------------------
        public int ElegirPedido()
        {
            int nroPedido;
            Console.WriteLine("\n----- Elegir Pedido -----");
            MostrarTodosLosPedidos();
            Console.Write("\nSeleccione el pedido (Nro de Pedido): ");
            int.TryParse(Console.ReadLine(), out nroPedido);
            return nroPedido;
        }

        public int ElegirCadete()
        {
            int idCadete;
            Console.WriteLine("\n----- Cadetes Disponibles -----");
            foreach (var cadete in ListaCadetes)
            {
                cadete.datosCadete();
            }
            Console.Write("Seleccione el id del cadete: ");
            int.TryParse(Console.ReadLine(), out idCadete);
            return idCadete;
        }
}





    
