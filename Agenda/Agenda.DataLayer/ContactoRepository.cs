using System.Data.SqlClient;

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
            if (connection is not null) {
                SqlCommand cmd = new(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                AddContacts(list, reader);
            }
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

        string query = $"select * from Contacto where Id = {id}"; //TODO upgrade to avoid SQL injection

        try {
            if (connection is not null) {
                SqlCommand cmd = new(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                return new Contacto(
                    id: reader.GetInt32(0),
                    nombre: reader.GetString(1),
                    fechaNacimiento: reader.GetDateTime(2),
                    telefono: reader.GetString(3),
                    observaciones: reader.GetString(4)
                );
            }
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
        //TODO upgrade to avoid SQL injection
        string query = nuevoContacto.Observaciones is null
            ? $"insert into Contacto (Nombre, FechaNacimiento, Telefono) values ({values})"
            : $"insert into Contacto (Nombre, FechaNacimiento, Telefono, Observaciones) values ({values})";
        try {
            if (connection is not null) {
                SqlCommand cmd = new(query, connection);
                _ = cmd.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
        } finally {
            CloseConnection();
        }
    }
    #endregion Create

    #region Update
    public void Update(Contacto nuevoContacto) {
        OpenConnection();
        //TODO upgrade to avoid SQL injection
        string query = $"update Contacto set Nombre = '{nuevoContacto.Nombre}', " +
                       $"FechaNacimiento = '{nuevoContacto.FechaNacimiento}', " +
                       $"Telefono = '{nuevoContacto.Telefono}'";

        if (nuevoContacto.Observaciones is not null)
            query += $", Observaciones = '{nuevoContacto.Observaciones}'";

        query += $" where Id = {nuevoContacto.Id}";

        try {
            if (connection is not null) {
                SqlCommand cmd = new(query, connection);
                _ = cmd.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
        } finally {
            CloseConnection();
        }
    }
    #endregion Update

    #region DeleteById
    public void DeleteById(int id) {
        OpenConnection();

        string query = $"delete from Contacto where Id = {id}"; //TODO upgrade to avoid SQL injection
        try {
            if (connection is not null) {
                SqlCommand cmd = new(query, connection);
                _ = cmd.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
        } finally {
            CloseConnection();
        }
    }
    #endregion DeleteById
}
