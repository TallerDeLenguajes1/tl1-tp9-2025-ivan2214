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
            {// itero sobre las carpetas que existen en el path
                string carpetaNombre = Path.GetFileName(dir);
                // saco el nombre de las carpetas y lo muestro
                Console.WriteLine($"- {carpetaNombre}");
            }


            Console.WriteLine("\n📄 Archivos:");
            // obtengo todos los archivos dentrodel path
            string[] archivos = Directory.GetFiles(path);
            foreach (string archivo in archivos)
            {
                string archivoNombre = Path.GetFileName(archivo);
                Console.WriteLine($"- {archivoNombre}");
            }
        }



    }


}
