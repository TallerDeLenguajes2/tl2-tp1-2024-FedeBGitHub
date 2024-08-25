namespace spaceCliente;

    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string datosReferenciaDireccion;

        public Cliente (string Nombre, string Direccion, string Telefono, string DatosReferenciaDireccion)
        {
            nombre = Nombre;
            direccion = Direccion;
            telefono = Telefono;
            datosReferenciaDireccion = DatosReferenciaDireccion;
        }
    }

    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private string estado;
        public Pedido (int Nro, string Obs, string Estado , string Nombre, string Direccion, string Telefono, string DatosReferenciaDireccion)
        {
            nro = Nro;
            obs = Obs;
            Cliente cliente = new Cliente ( Nombre, Direccion, Telefono,  DatosReferenciaDireccion);
            estado = Estado;
        }
        public void VerDireccionCliente()
        {

        }
        public void VerDatosCliente()
        {

        }
    }

    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> listaPedidos;

        public Cadete(int Id, string Nombre, string Direccion, string Telefono, List<Pedido> ListaPedidos)
        {
            id = Id;
            nombre = Nombre;
            direccion = Direccion;
            telefono = Telefono;
            listaPedidos = ListaPedidos;
        }
        public float JornalACobrar()
        {
            float jornal = 0;
            return jornal;
        }
        
    }

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
    }





    
