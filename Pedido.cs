namespace SistemaCadeteria;

public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private string estado;
        private int idCadeteAsignado;
        public string Estado { get => estado; set => estado = value; }
        public int Nro { get => nro; }
        public string Obs { get => obs; }
        public int IdCadeteAsignado { get => idCadeteAsignado; set => idCadeteAsignado = value; }

    public Pedido (int Nro, string Obs, string Estado , string cNombre, string cDireccion, string cTelefono, string cDatosReferenciaDireccion)
        {
            nro = Nro;
            obs = Obs;
            estado = Estado;
            Cliente client = new Cliente ( cNombre, cDireccion, cTelefono,  cDatosReferenciaDireccion);
            cliente = client;
            IdCadeteAsignado = -999; //indefinido
        }
        public void VerDireccionCliente()
        {
            Console.WriteLine("Direccion: "+cliente.Direccion);
            Console.WriteLine("Datos de referencia: "+cliente.DatosReferenciaDireccion);
        }
        public void VerDatosCliente()
        {
            Console.WriteLine("Nombre: "+cliente.Nombre);
            Console.WriteLine("Telefono: "+cliente.Telefono);
        }
        public void VerPedido()
        {
            Console.WriteLine("  ---- Pedido {0} ----",this.nro);
            Console.WriteLine("Estado: "+this.estado);
            Console.WriteLine("Observacion: "+this.obs);
            Console.WriteLine("Id del cadete asignado: "+IdCadeteAsignado);
            VerDatosCliente();
            VerDireccionCliente();
        }
    }





    
