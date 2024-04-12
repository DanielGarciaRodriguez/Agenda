using System.Data.SqlClient;
using Agenda.DataLayer.Entities;

namespace Agenda.DataLayer;
public class ContactoRepository {
    private readonly SqlConnection connection;
    private const string ddbb = "Agenda";

    public ContactoRepository() {
        connection = ContextDB.CreateConnection(ddbb);
    }

    private void OpenConnection() => connection.Open();
    private void CloseConnection() => connection.Close();

    #region GetAll
    public List<Contacto> GetAll() {
        OpenConnection();

        string query = "select * from Contacto";
        List<Contacto> list = new();

        try {
            SqlCommand cmd = new(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            AddContacts(list, reader);
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
        } finally {
            CloseConnection();
        }

        return list;
    }

    private static void AddContacts(List<Contacto> list, SqlDataReader reader) {
        while (reader.Read()) {
            object observaciones = reader.GetValue(4);
            list.Add(new Contacto(
                id: reader.GetInt32(0),
                nombre: reader.GetString(1),
                fechaNacimiento: reader.GetDateTime(2),
                telefono: reader.GetString(3),
                observaciones: observaciones is DBNull ? null : (string) observaciones
            ));
        }
    }
    #endregion GetAll

    #region GetById
    public Contacto? GetById(int id) {
        OpenConnection();

        string query = "select * from Contacto where Id = @id"; 

        try {
            SqlCommand cmd = new(query, connection);
            SubstituteCommandID(id, cmd);

            SqlDataReader reader = cmd.ExecuteReader();
            return new Contacto(
                id: reader.GetInt32(0),
                nombre: reader.GetString(1),
                fechaNacimiento: reader.GetDateTime(2),
                telefono: reader.GetString(3),
                observaciones: reader.GetString(4)
            );
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
        } finally {
            CloseConnection();
        }

        return null;
    }
    #endregion GetById

    #region Create
    public void Create(Contacto nuevoContacto) {
        OpenConnection();
        string values = nuevoContacto.ToInsertQueryFormat();
        string query = nuevoContacto.Observaciones is null
            ? $"insert into Contacto (Nombre, FechaNacimiento, Telefono) values ({values})"
            : $"insert into Contacto (Nombre, FechaNacimiento, Telefono, Observaciones) values ({values})";
        SqlCommand cmd;
        SqlTransaction? transaction = null;
        try {
            transaction = connection.BeginTransaction();
            cmd = new(query, connection) {
                Transaction = transaction
            };

            SubstituteSQLCommandParams(nuevoContacto, cmd);
            _ = cmd.ExecuteNonQuery();

            transaction.Commit();
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
            transaction?.Rollback();
        } finally {
            CloseConnection();
        }
    }
    #endregion Create

    #region Update
    public void Update(Contacto nuevoContacto) {
        OpenConnection();
        string query = $"update Contacto set Nombre = @nombre, " +
                       $"FechaNacimiento = @fechaNacimiento, " +
                       $"Telefono = @telefono, " + 
                       $"Observaciones = @observaciones" + 
                       $" where Id = @id";
        SqlCommand cmd;
        SqlTransaction? transaction = null;
        try {
            transaction = connection.BeginTransaction();
            cmd = new(query, connection) {
                Transaction = transaction
            };
            SubstituteSQLCommandParams(nuevoContacto, cmd);
            SubstituteCommandID(nuevoContacto.Id, cmd);

            _ = cmd.ExecuteNonQuery();
            transaction.Commit();
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
            transaction?.Rollback();
        } finally {
            CloseConnection();
        }
    }
    #endregion Update

    #region DeleteById
    public void DeleteById(int id) {
        OpenConnection();

        string query = "delete from Contacto where Id = @id";
        SqlCommand cmd;
        SqlTransaction? transaction = null;
        try {
            transaction = connection.BeginTransaction();
            cmd = new(query, connection) {
                Transaction = transaction
            };

            SubstituteCommandID(id, cmd);
            _ = cmd.ExecuteNonQuery();
            transaction.Commit();
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
            transaction?.Rollback();
        } finally {
            CloseConnection();
        }
    }
    #endregion DeleteById

    #region Substitute command params
    private static void SubstituteSQLCommandParams(Contacto nuevoContacto, SqlCommand cmd) {
        cmd.Parameters.AddWithValue("nombre", nuevoContacto.Nombre);
        cmd.Parameters.AddWithValue("fechaNacimiento", nuevoContacto.FechaNacimiento);
        cmd.Parameters.AddWithValue("telefono", nuevoContacto.Telefono);
        cmd.Parameters.AddWithValue("observaciones",
            nuevoContacto.Observaciones is null ? DBNull.Value : $"{nuevoContacto.Observaciones}"
        );
    }

    private static void SubstituteCommandID(int id, SqlCommand cmd) {
        cmd.Parameters.AddWithValue("id", id);
    }
    #endregion Substitute command params
}
