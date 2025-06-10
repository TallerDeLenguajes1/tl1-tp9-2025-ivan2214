using System.Text;

class Program
{
    static void Main()
    {
        string? path;
        bool isValidPath = false;

        do
        {
            Console.Write("Ingrese el path del directorio a analizar: ");
            path = Console.ReadLine();

            if (Directory.Exists(path))
            {
                isValidPath = true;
            }

            Console.WriteLine("El directorio no existe. Intente nuevamente.\n");
        } while (!isValidPath);




        if (path != null)
        {
            Console.WriteLine("\n📁 Carpetas:");

            // obtengo todos los directorios osea las carpetas dentro del path que dio el usuario
            string[] directorios = Directory.GetDirectories(path);
            foreach (string dir in directorios)
            {// itero sobre las carpeta1s que existen en el path
                FileInfo info = new FileInfo(dir);
                string carpetaNombre = info.Name;
                // saco el nombre de las carpetas y lo muestro
                Console.WriteLine($"- {carpetaNombre}");
            }


            Console.WriteLine("\n📄 Archivos:");
            // obtengo todos los archivos dentrodel path
            string[] archivos = Directory.GetFiles(path);
            foreach (string archivo in archivos)
            {
                FileInfo info = new FileInfo(archivo);
                string archivoNombre = info.Name;
                double tamKb = (double)new FileInfo(archivo).Length / 1024;

                Console.WriteLine($"- {archivoNombre} tamaño: ({tamKb} KB)");
            }


            // Geenero el csv

            string nombreCSV = "reporte_archivos.csv";

            GenerarCSV(nombreCSV, archivos, path);




        }


        void GenerarCSV(string nombreCSV, string[] archivos, string path)
        {
            List<string> lineasCSV = new List<string>();
            lineasCSV.Add("Nombre,Tamaño(KB),UltimaModificacion");

            foreach (string archivo in archivos)
            {
                FileInfo info = new FileInfo(archivo);
                string archivoNombre = info.Name;
                double tamKb = info.Length / 1024;
                DateTime ultimaModificacion = info.LastWriteTime;

                lineasCSV.Add($"{archivoNombre},{tamKb},{ultimaModificacion}");
            }

            string rutaCSV = Path.Combine(path, nombreCSV);

            File.WriteAllLines(rutaCSV, lineasCSV);

        }


    }


}
