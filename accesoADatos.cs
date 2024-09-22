using SistemaCadeteria;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Datos
{
    public abstract class AccesoADatos ()
    {
        public abstract List<Cadete> CargarCadetes(string archivoCadetes);
        public abstract Cadeteria CargarCadeteria(string archivoCaderia, string archivoCadetes);
    }

    public class AccesoCSV : AccesoADatos
    {
        
        public override List<Cadete> CargarCadetes(string archivoCadetes)
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
        public override Cadeteria CargarCadeteria(string archivoCadeteria, string archivoCadete)
            {
                List<Cadete> listadoCadetes = CargarCadetes(archivoCadete);
                // Leemos todas las líneas del archivo CSV
                string [] lineas = File.ReadAllLines(archivoCadeteria);
                
                // Ignoramos la primera línea (el encabezado)
                var datos = lineas[1].Split(','); // esto por que hay una sola cadeteria sino deberia usar un for o foreach
                Cadeteria cadeteria = new Cadeteria(datos[0], datos[1],listadoCadetes);
                return cadeteria;
            }
    }

    public class AccesoJSON : AccesoADatos
    {
        /*
        public static void guardarJson(List<Cadete> listaCadetes, string archivoCadetes)
        {
            string cadeteJson =  JsonSerializer.Serialize(listaCadetes);
            File.WriteAllText(archivoCadetes,cadeteJson);
            
        }
        public static void guardarCadeteria(Cadeteria cadeteria, string archivoCaderia)
        {
            string cadeteriaJson =  JsonSerializer.Serialize(cadeteria);
            File.WriteAllText(archivoCaderia,cadeteriaJson);
            
        }*/
        public override List<Cadete> CargarCadetes(string archivoCadetes)
        {
            List<Cadete> listaCadetes = new List<Cadete>();
            string cadetesJson = File.ReadAllText(archivoCadetes);
            listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(cadetesJson);
            return listaCadetes;
        }
        public override Cadeteria CargarCadeteria(string archivoCadeteria, string archivoCadetes)
        {
            string [] datosCadeteria;
            string cadeteriaJson = File.ReadAllText(archivoCadeteria);
            datosCadeteria = JsonSerializer.Deserialize<string []>(cadeteriaJson);
            string nomCadeteria = datosCadeteria[0];
            string telCadeteria = datosCadeteria[1];

            List<Cadete> listaCadetes = CargarCadetes(archivoCadetes);
            Cadeteria cadeteria = new Cadeteria(nomCadeteria,telCadeteria,listaCadetes);
            return cadeteria;
            
        }
    }
}