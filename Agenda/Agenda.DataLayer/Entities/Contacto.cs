namespace Agenda.DataLayer.Entities;
public class Contacto {
    private const int NOMBRE_MAX_LENGTH = 100;
    private const int TELEFONO_MAX_LENGTH = 9;
    private const int OBSERVACIONES_MAX_LENGTH = 500;

    private readonly int id;
    private string nombre;
    private string telefono;
    private string? observaciones;

    #region Constructors
    public Contacto(int id, string nombre, DateTime fechaNacimiento, string telefono) {
        this.id = id;
        Nombre = nombre;
        FechaNacimiento = fechaNacimiento;
        Telefono = telefono;
    }

    public Contacto(int id, string nombre, DateTime fechaNacimiento, string telefono, string? observaciones)
        : this(id, nombre, fechaNacimiento, telefono) {
        Observaciones = observaciones;
    }
    #endregion Constructors

    #region Properties
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
            // Possible check for non-numeric characters
            telefono = value;
        }
    }

    public string? Observaciones {
        get { return observaciones; }
        set {
            if (value is not null && value.Length > OBSERVACIONES_MAX_LENGTH)
                throw new ArgumentException($"{nameof(value)} exceeded max length {OBSERVACIONES_MAX_LENGTH}");
            observaciones = value is not null && value.Length > 0 ? value : null;
        }
    }
    #endregion Properties

    public static int GetNombreMaxLength() => NOMBRE_MAX_LENGTH;
    public static int GetTelefonoMaxLength() => TELEFONO_MAX_LENGTH;
    public static int GetObservacionesMaxLength() => OBSERVACIONES_MAX_LENGTH;

    public string ToInsertQueryFormat() {
        string result = "@nombre, @fechaNacimiento, @telefono";
        if (Observaciones is not null)
            result += ", @observaciones";
        return result;
    }
}
