namespace SistemaCadeteria;

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
            foreach (Pedido pedido in listaPedidos)
            {
                if (pedido.Estado == "entregado")
                {
                    jornal += 500;
                }
            }
            return jornal;
        }
        
    }





    
