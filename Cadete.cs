namespace SistemaCadeteria;

public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;
        public int Id { get => id; }
        public string Nombre { get => nombre; }
        public string Direccion { get => direccion; }
        public string Telefono { get => telefono; }
        public Cadete(int Id, string Nombre, string Direccion, string Telefono)
        {
            id = Id;
            nombre = Nombre;
            direccion = Direccion;
            telefono = Telefono;
        }
    public void datosCadete()
        {
            Console.WriteLine($"{this.id}           {this.nombre}           {this.direccion}            {this.telefono}");
        }
        
    }





    
