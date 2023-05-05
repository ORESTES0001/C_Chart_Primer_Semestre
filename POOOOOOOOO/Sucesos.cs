using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Suceso
{
    // Atributos
    public DateTime fecha_hora_suceso { get; set; }
    public TimeSpan duracion { get; set; }

    // Métodos
    public Suceso() { } // Constructor sin parámetros

    public Suceso(DateTime fecha, TimeSpan dur) // Constructor que acepta dos parámetros
    {
        // Asignar los parámetros del constructor a los datos de la clase
        fecha_hora_suceso = fecha;
        duracion = dur;
    }
}

class Temblor : Suceso
{
    private float magnitud;
    private float profundidad;
    private int intensidad;

    // Atributos
    public Int32 latitud { get; set; }
    public Int32 longitud { get; set; }
    public int escala_ritcher { get; set; }

    // Métodos
    // Constructor sin parámetros de Temblor, con llamada al constructor sin parámetros de la clase base
    public Temblor() : base() { }

    // Constructor con 3 parámetros de Temblor y con llamada al constructor de la clase base con 2 parámetros
    public Temblor(Int32 lat, Int32 longit, int escala, DateTime fecha, TimeSpan dur)
        : base(fecha, dur)
    {
        // Asignar los parámetros del constructor a los datos de la clase
        latitud = lat;
        longitud = longit;
        escala_ritcher = escala;
    }

    public Temblor(DateTime fecha_hora_suceso, float magnitud, float profundidad, int intensidad)
    {
        this.fecha_hora_suceso = fecha_hora_suceso;
        this.magnitud = magnitud;
        this.profundidad = profundidad;
        this.intensidad = intensidad;
    }
}

class Lluvia : Suceso
{
    private TimeSpan duracion_suceso;
    private int milimetros_agua;

    // ATRIBUTOS
    // parametro para milimetros de agua de tipo entero con obtenedor y establecedor
    public Int32 milimetros_agua_por_hora { get; set; }
    // parametro para tipo de lluvia de tipo cadena de caracteres con GET Y SET
    public String tipo_lluvia { get; set; }

    // METODOS
    // constructor sin parametros con llamada al constructor sin parametros de la clase base
    public Lluvia() : base() { }
    // constructor con parametros con llamada al constructor con parametros de la clase base
    public Lluvia(Int32 mm, String tipo, DateTime fecha_suceso, TimeSpan duracion)
        : base(fecha_suceso, duracion) // el constructor de la clase base acepta dos parametros
    {
        // establezca los valores usando los datos pasados en la llamada al constructor
        milimetros_agua_por_hora = mm;
        tipo_lluvia = tipo;
    }

    public Lluvia(TimeSpan duracion_suceso, int milimetros_agua)
    {
        this.duracion_suceso = duracion_suceso;
        this.milimetros_agua = milimetros_agua;
    }
}

class Municipio
{
    //ATRIBUTOS
    public String nombre_municipio { get; set; } //nombre municipio de tipo cadena
    public Single extension_territorial { get; set; } //extension tipo coma flotante
    //Representa una lista de objetos Suceso en cada municipio
    //donde cada municpio puede tener sucesos diferentes
    public List<Suceso> sucesos { get; set; }

    //CONSTRUCTOR
    public Municipio()
    {
        sucesos = new List<Suceso>();
    }

    public Municipio(string nombre_municipio, float extension_territorial)
    {
        this.nombre_municipio = nombre_municipio;
        this.extension_territorial = extension_territorial;
        sucesos = new List<Suceso>();
    }
}
