namespace SistemaCadeteria;

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

        public string Direccion { get => direccion; }
        public string DatosReferenciaDireccion { get => direccion; }
        public string Nombre { get => nombre; }
        public string Telefono { get => telefono; }
}





    
