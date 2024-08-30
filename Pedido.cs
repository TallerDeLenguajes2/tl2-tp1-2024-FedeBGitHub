namespace SistemaCadeteria;

public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private string estado;

        public string Estado { get => estado; }

        public Pedido (int Nro, string Obs, string Estado , string cNombre, string cDireccion, string cTelefono, string cDatosReferenciaDireccion)
        {
            nro = Nro;
            obs = Obs;
            estado = Estado;
            Cliente cliente = new Cliente ( cNombre, cDireccion, cTelefono,  cDatosReferenciaDireccion);
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
    }





    
