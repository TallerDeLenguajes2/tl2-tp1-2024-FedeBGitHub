namespace SistemaCadeteria;

public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedido> listaPedidos;
        public int Id { get => id; }
        public string Nombre { get => nombre; }
        public Cadete(int Id, string Nombre, string Direccion, string Telefono/*, List<Pedido> ListaPedidos*/)
        {
            id = Id;
            nombre = Nombre;
            direccion = Direccion;
            telefono = Telefono;
            listaPedidos = new List<Pedido>();
        }

    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public void datosCadete()
        {
            Console.WriteLine($"{this.id}           {this.nombre}           {this.direccion}            {this.telefono}");
        }
        public float JornalACobrar()
        {
            float jornal = 0;
            foreach (Pedido pedido in ListaPedidos)
            {
                if (pedido.Estado == "entregado")
                {
                    jornal += 500;
                }
            }
            return jornal;
        }
        
    }





    
