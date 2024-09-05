using SistemaCadeteria;
namespace LecturaCsv
{
    public class lecturaCSV
    {
        // Leer CSV usando ReadAllLines------------------------------------------
        public static List<Cadete> CargarCadetesDesdeCSV(string archivoCadetes)
            {
                List<Cadete> ListadoCadetes = new List<Cadete>();
                // Leemos todas las líneas del archivo CSV
                string [] lineas = File.ReadAllLines(archivoCadetes);
                
                // Ignoramos la primera línea (el encabezado)
                for (int i = 1; i < lineas.Length; i++)
                {
                    var datos = lineas[i].Split(',');
                    
                    // Creamos un nuevo objeto Cadete usando los datos del archivo
                    Cadete cadete = new Cadete(int.Parse(datos[0]), datos[1], datos[2], datos[3]);
                    
                    // Agregamos el cadete a la lista de cadetes
                    ListadoCadetes.Add(cadete);
                }
                return ListadoCadetes;
            }
        public static Cadeteria CargarCadeteriaDesdeCSV(string archivoCadeteria)
            {
                List<Cadete> listadoCadetes = lecturaCSV.CargarCadetesDesdeCSV("../../../datos_cadete.csv");
                // Leemos todas las líneas del archivo CSV
                string [] lineas = File.ReadAllLines(archivoCadeteria);
                
                // Ignoramos la primera línea (el encabezado)
                var datos = lineas[1].Split(','); // esto por que hay una sola cadeteria sino deberia usar un for o foreach
                Cadeteria cadeteria = new Cadeteria(datos[0], datos[1],listadoCadetes);
                return cadeteria;
            }
    }
}