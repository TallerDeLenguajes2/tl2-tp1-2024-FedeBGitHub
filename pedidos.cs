namespace spaceCliente;

    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string DatosReferenciaDireccion;
    }

     public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private string estado;
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
        private Cliente direccion;
        private string telefono;
        private List<Pedido> listaPedidos;

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
    }





    
