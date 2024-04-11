namespace Agenda.DataLayer;
public class Contacto {
    /*
        [Id] [int] IDENTITY(1,1) NOT NULL Primary Key,
	    [Nombre] [nvarchar](100) NOT NULL,
	    [FechaNacimiento] [date] NOT NULL,
	    [Telefono] [varchar](9) NOT NULL,
	    [Observaciones] [nvarchar](500) NULL
     */
    private const int NOMBRE_MAX_LENGTH = 100;
    private const int TELEFONO_MAX_LENGTH = 9;
    private const int OBSERVACIONES_MAX_LENGTH = 500;

    private readonly int id;
    private string nombre;
    private string telefono;
    private string? observaciones;

    public Contacto(int id, string nombre, DateTime fechaNacimiento, string telefono) {
        this.id = id;
        Nombre = nombre;
        FechaNacimiento = fechaNacimiento;
        Telefono = telefono;
    }

    public Contacto(int id, string nombre, DateTime fechaNacimiento, string telefono, string observaciones)
        : this(id, nombre, fechaNacimiento, telefono) {
        Observaciones = observaciones;
    }

    public int Id {
        get { return id; }
    }
    public string Nombre {
        get { return nombre; }
        set {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            else if (value.Length > NOMBRE_MAX_LENGTH)
                throw new ArgumentException($"{nameof(value)} exceeded max length {NOMBRE_MAX_LENGTH}");
            nombre = value;
        }
    }

    public DateTime FechaNacimiento { get; set; }

    public string Telefono {
        get { return telefono; }
        set {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            else if (value.Length > NOMBRE_MAX_LENGTH)
                throw new ArgumentException($"{nameof(value)} exceeded max length {TELEFONO_MAX_LENGTH}");
            telefono = value;
        }
    }

    public string? Observaciones {
        get { return observaciones; }
        set {
            if (value is not null && value.Length > OBSERVACIONES_MAX_LENGTH)
                throw new ArgumentException($"{nameof(value)} exceeded max length {OBSERVACIONES_MAX_LENGTH}");
            observaciones = value;
        }
    }

    public string ToInsertQueryFormat() => $"{Nombre}, {FechaNacimiento}, {Telefono}, {Observaciones}";
}
