using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace malditamierda
{


    public class TareaPOO
    {
        static void Main(string[] args) //todo programa inicia en el main
        {
            Municipio municipio;
            Suceso sucesos = new Suceso();
            List<Suceso> lista_sucesos;
            TimeSpan duracion_suceso = TimeSpan.Zero;
            Temblor temblor = new Temblor();
            Lluvia lluvia = new Lluvia();
            String nombre_municipio = String.Empty, tipo_lluvia = String.Empty;
            Int32 milimetros_agua = 0, latitud_temblor = 0, longitud_temblor = 0;



            DateTime fecha_hora_suceso = new DateTime();

            int extension_territorial = 0, escala_ritcher = 0;
            List<Municipio> lista_municipio = new List<Municipio>();

            //ciclo infinito que se interrumpe por entrada del usuario
            while (true)
            {
                //menu que muestra las opciones principales
                //el menú tendra 3 opciones, según cada una se realiza una acción
                int opcion_menu = menu_principal();
                int opcion_municipio = 0;
                switch (opcion_menu)
                {
                    case 1:
                        Municipio m = new Municipio();
                        Console.WriteLine("Escribir nombre del municipio:");
                        m.nombre_municipio = Console.ReadLine();
                        Console.WriteLine("Escribir extensión territorial del municipio:");
                        m.extension_territorial = int.Parse(Console.ReadLine());
                        lista_municipio.Add(m);

                        Console.WriteLine("Desea agregar un suceso al municipio? (1 para Sí, 2 para No)");
                        int opcion_agregar_suceso = int.Parse(Console.ReadLine());
                        if (opcion_agregar_suceso == 1)
                        {
                            int opcion_seleccionada = 0;
                            Console.WriteLine("\n\t\t\tBIENVENIDO A SUCESOS\n\n");
                            Console.WriteLine("Que suceso agregara?");
                            Console.WriteLine("1. Lluvia");
                            Console.WriteLine("2. Temblor");
                            try { opcion_seleccionada = Convert.ToInt32(Console.ReadLine()); }
                            catch { Console.WriteLine("Opcion Invalida"); }

                            switch (opcion_seleccionada)
                            {
                                case 1:
                                    Console.WriteLine("Ingrese la fecha de la lluvia en formato dd/MM/yyyy:");
                                    fecha_hora_suceso = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.CreateSpecificCulture("es_NI"));
                                    Console.WriteLine("Ingrese la cantidad de lluvia en mm:");
                                    int cantidad = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese el tipo de lluvia:");
                                    string tipo2 = (Console.ReadLine());


                                    // Crea el objeto de tipo Lluvia y lo agrega a la lista de sucesos del municipio correspondiente

                                    lluvia.fecha_hora_suceso = fecha_hora_suceso;
                                    lluvia.duracion = TimeSpan.Zero;
                                    lluvia.milimetros_agua_por_hora = cantidad;
                                    lluvia.tipo_lluvia = tipo2; // Se puede cambiar este valor según lo que se requiera
                                    lista_municipio[lista_municipio.Count - 1].sucesos.Add(lluvia);
                                    break;
                                case 2:

                                    Console.WriteLine("Ingrese la fecha del terremoto en formato dd/MM/yyyy:");
                                    fecha_hora_suceso = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.CreateSpecificCulture("es_NI"));
                                    Console.WriteLine("Ingrese la escala ritcher:");
                                    escala_ritcher = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese la latitud:");
                                    latitud_temblor = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese longitud:");
                                    longitud_temblor = int.Parse(Console.ReadLine());


                                    // Crea el objeto de tipo Lluvia y lo agrega a la lista de sucesos del municipio correspondiente

                                    temblor.fecha_hora_suceso = fecha_hora_suceso;
                                    temblor.duracion = TimeSpan.Zero;
                                    temblor.latitud=latitud_temblor;
                                    temblor.longitud = longitud_temblor;
                                    temblor.escala_ritcher = escala_ritcher;

                                    lista_municipio[lista_municipio.Count - 1].sucesos.Add(temblor);
                                    break;
                            }

                        }
                        break;
                    case 2:

                        int opción_municipio = 0;

                        for (int i = 0; i < lista_municipio.Count; i++)
                        {
                            Console.WriteLine(i + " " + lista_municipio[i].nombre_municipio);
                        }

                        if (opcion_municipio >= 0 && opcion_municipio < lista_municipio.Count)
                        {


                            while (true)
                            {
                                int opcion_menu_especifico = menu_municipio_especifico();
                                switch (opcion_menu_especifico)
                                {
                                    case 1:
                                        Console.Write("Ingrese el nombre del municipio: ");
                                        nombre_municipio = Console.ReadLine();

                                        Console.Write("Ingrese la extensión territorial del municipio: ");
                                        extension_territorial = int.Parse(Console.ReadLine());

                                        municipio = new Municipio(nombre_municipio, extension_territorial);

                                        Console.WriteLine("Ingrese el suceso que desea agregar:");
                                        Console.WriteLine("1. Lluvia");
                                        Console.WriteLine("2. Temblor");
                                        int opcion = int.Parse(Console.ReadLine());

                                        switch (opcion)
                                        {
                                            case 1:

                                                // Pedir el nombre del municipio
                                                Console.WriteLine("Ingrese el nombre del municipio:");
                                                string nombreMunicipioAgregar = Console.ReadLine();

                                                // Buscar el municipio por su nombre
                                                municipio = lista_municipio.Find(m => m.nombre_municipio == nombreMunicipioAgregar);

                                                // Verificar que el municipio existe
                                                if (municipio == null)
                                                {
                                                    Console.WriteLine($"El municipio {nombreMunicipioAgregar} no existe.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Ingrese la fecha de la lluvia en formato dd/MM/yyyy:");
                                                    fecha_hora_suceso = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.CreateSpecificCulture("es_NI"));
                                                    Console.WriteLine("Ingrese la cantidad de lluvia en mm:");
                                                    int cantidad = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("Ingrese el tipo de lluvia:");
                                                    string tipo2 = (Console.ReadLine());

                                                    // Crea el objeto de tipo Lluvia y lo agrega a la lista de sucesos del municipio correspondiente

                                                    lluvia.fecha_hora_suceso = fecha_hora_suceso;
                                                    lluvia.duracion = TimeSpan.Zero;
                                                    lluvia.milimetros_agua_por_hora = cantidad;
                                                    lluvia.tipo_lluvia = tipo2; // Se puede cambiar este valor según lo que se requiera
                                                    lista_municipio[lista_municipio.Count - 1].sucesos.Add(lluvia);
                                                }
                                                break;



                                            case 2:
                                                // Pedir el nombre del municipio
                                                Console.WriteLine("Ingrese el nombre del municipio:");
                                                string nombreMunicipioAgregar2 = Console.ReadLine();

                                                // Buscar el municipio por su nombre
                                                municipio = lista_municipio.Find(m => m.nombre_municipio == nombreMunicipioAgregar2);

                                                // Verificar que el municipio existe
                                                if (municipio == null)
                                                {
                                                    Console.WriteLine($"El municipio {nombreMunicipioAgregar2} no existe.");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Ingrese la fecha del terremoto en formato dd/MM/yyyy:");
                                                    fecha_hora_suceso = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.CreateSpecificCulture("es_NI"));
                                                    Console.WriteLine("Ingrese la escala ritcher:");
                                                    int cantidad = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("Ingrese la longitud:");
                                                    int longi = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("Ingrese la latitud:");
                                                    int lati = int.Parse(Console.ReadLine());

                                                    // Crea el objeto de tipo temblor y lo agrega a la lista de sucesos del municipio correspondiente

                                                    temblor.fecha_hora_suceso = fecha_hora_suceso;
                                                    temblor.duracion = TimeSpan.Zero;
                                                    temblor.escala_ritcher = cantidad;
                                                    temblor.longitud = longi;
                                                    temblor.latitud = lati;
                                                    lista_municipio[lista_municipio.Count - 1].sucesos.Add(temblor);
                                                }
                                                break;

                                            default:
                                                Console.WriteLine("Opción inválida");
                                                break;
                                        }

                                        Console.WriteLine("Suceso agregado correctamente");


                                        Console.WriteLine("Suceso de lluvia agregado con éxito.");
                                        break;
                                    case 2:

                                        Console.WriteLine("Eliminar suceso de un municipio");
                                        Console.WriteLine("Ingrese el nombre del municipio:");
                                        string nombreMunicipio = Console.ReadLine();

                                        // Buscar el municipio en la lista
                                        municipio = lista_municipio.Find(m => m.nombre_municipio == nombreMunicipio);

                                        if (municipio == null)
                                        {
                                            Console.WriteLine("Municipio no encontrado.");
                                            break;
                                        }

                                        // Verificar si el municipio tiene sucesos
                                        if (municipio.sucesos.Count == 0)
                                        {
                                            Console.WriteLine("El municipio no tiene sucesos registrados.");
                                            break;
                                        }

                                        Console.WriteLine("Ingrese la fecha y hora del suceso a eliminar (en formato dd/mm/yyyy hh:mm:ss):");
                                        DateTime fechaHoraSuceso = DateTime.Parse(Console.ReadLine());

                                        // Buscar el suceso en la lista de sucesos del municipio
                                        Suceso sucesoAEliminar = municipio.sucesos.Find(s => s.fecha_hora_suceso == fechaHoraSuceso);

                                        if (sucesoAEliminar == null)
                                        {
                                            Console.WriteLine("El suceso no fue encontrado en el municipio.");
                                            break;
                                        }

                                        municipio.sucesos.Remove(sucesoAEliminar);
                                        Console.WriteLine("El suceso ha sido eliminado del municipio.");
                                        break;


                                    case 3:

                                        // muestra la lluvia de mayor duracion
                                        /* Console.WriteLine("Mostrando la lluvia de mayor duración");


                                         int milimetro_mayor = 0;
                                         foreach (var muni in lista_municipio)
                                         {



                                             foreach (var suceso in muni.sucesos)
                                             {
                                                 int ml = lluvia.milimetros_agua_por_hora;
                                                 if (milimetro_mayor < ml)
                                                     milimetro_mayor = ml;

                                             }
                                             Console.WriteLine($"Lluvia mayor milimetro: {milimetro_mayor}");
                                         }

                                         //Console.WriteLine($"- extension territorial: {muni.extension_territorial}, Cantidad agua en milimetro {lluvia.milimetros_agua_por_hora} mm");*/




                                        /*if (lista_municipio[opcion_municipio].sucesos.Count > 0)
                                        {
                                            Lluvia lluvia_mayor = new Lluvia();
                                            lluvia_mayor = null;
                                            List<Suceso> suc = new List<Suceso>();
                                            try
                                            {
                                                suc = lista_municipio[opcion_municipio].sucesos;
                                            }
                                            catch (Exception e) { }

                                             foreach (var muni in lista_municipio)
                                        {
                                            


                                            foreach (var suceso in muni.sucesos)
                                            {
                                                int ml = lluvia.milimetros_agua_por_hora;
                                                if (milimetro_mayor < ml)
                                                    milimetro_mayor = ml;
                                               
                                            }
                                            Console.WriteLine($"Lluvia mayor milimetro: {milimetro_mayor}");
                                        }

                                            for (int i = 0; i < suc.Count; i++)
                                            {
                                                if (suc[i] is Temblor)
                                                    continue;

                                                Lluvia lluv = (Lluvia)(suc[i]);
                                                if (lluvia_mayor == null)
                                                    lluvia_mayor = lluv;

                                                if (lluvia_mayor.milimetros_agua_por_hora < lluv.milimetros_agua_por_hora)
                                                    lluvia_mayor = lluv;
                                            }

                                            if (lluvia_mayor != null)
                                            {
                                                Console.WriteLine("*-**-*-*-*-*-*-*-*-*-*-*-*-*");
                                                Console.WriteLine("Lluvia mayor\n");
                                                Console.WriteLine($"Tipo de lluvia: {lluvia_mayor} ,Fecha de suceso: {lluvia_mayor.fecha_hora_suceso}");
                                                Console.WriteLine("*-**-*-*-*-*-*-*-*-*-*-*-*-*");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("------------------");
                                            Console.WriteLine("No hay suceso de Lluvia registrado.");
                                            Console.WriteLine("------------------");
                                        }*/


                                        break;

                                    case 4:
                                        // muestra el temblor más fuerte en la escala de ritcher
                                        Temblor temblorMasFuerte = null;
                                        foreach (Suceso suceso in lista_municipio[opción_municipio].sucesos)
                                        {
                                            if (suceso is Temblor temblor1 && (temblorMasFuerte == null || temblor1.escala_ritcher > temblorMasFuerte.escala_ritcher))
                                            {
                                                temblorMasFuerte = temblor1;
                                            }
                                        }
                                        if (temblorMasFuerte != null)
                                        {
                                            Console.WriteLine("El temblor más fuerte en " + lista_municipio[opción_municipio].nombre_municipio + " tuvo una escala de Ritcher de " + temblorMasFuerte.escala_ritcher + ".");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No se registró ningún temblor en " + lista_municipio[opción_municipio].nombre_municipio);
                                        }
                                        break;
                                    case 5:

                                        foreach (var muni in lista_municipio)
                                        {
                                            Console.WriteLine($"Municipio: {muni.nombre_municipio}");
                                            Console.WriteLine("Sucesos:");
                                            foreach (var suceso in muni.sucesos)
                                            {

                                                Console.WriteLine("Sucesos de lluvia");
                                                Console.WriteLine($"- Tipo: {lluvia.tipo_lluvia}, Fecha: {suceso.fecha_hora_suceso}");
                                                Console.WriteLine($"- extension territorial: {muni.extension_territorial}, Cantidad agua en milimetro {lluvia.milimetros_agua_por_hora} mm");
                                                Console.WriteLine("Sucesos de terremoto");
                                                Console.WriteLine($"- Longitud del temblor: {temblor.longitud}, Escala ritcher: {temblor.escala_ritcher}, latitud del temblor {temblor.latitud}");
                                            }
                                        }
                                        break;
                                    case 6:
                                        Console.WriteLine("Saliendo del programa...");
                                        Environment.Exit(0);
                                        break;
                                    default:

                                        break;
                                }
                            }
                        }
                        break;
                }
            }
        }
        private static int menu_principal()
        {
            int opcion_seleccionada = 0;
            Console.WriteLine("\n\n\n\t\t\tBIENVENIDO A INETER\n\n");
            Console.WriteLine("Ingrese una opcion");
            Console.WriteLine("1. Agregar Municipio");
            Console.WriteLine("2. Mostrar Municipios");
            Console.WriteLine("3. Salir");
            try { opcion_seleccionada = Convert.ToInt32(Console.ReadLine()); }
            catch { Console.WriteLine("Opcion Invalida"); return 0; }
            return opcion_seleccionada;
        }


        private static int menu_municipio_especifico()
        {
            int opcion_menu = 0;
            Console.WriteLine("\n\t\tOPCIONES MUNICIPIO");
            Console.WriteLine("1. Agregar Suceso\n" +
            "2. Borrar Suceso\n" +
            "3. Lluvia de Mayor Duracion\n" +
            "4. Temblor mas alto\n" +
            "5. Mostrar todos los sucesos\n" +
            "6. Salir");
            try { opcion_menu = Int32.Parse(Console.ReadLine()); }
            catch { }
            return opcion_menu;
        }

    }
}