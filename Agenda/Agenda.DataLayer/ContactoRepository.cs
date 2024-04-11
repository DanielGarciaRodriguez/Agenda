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
            list.Add(new Contacto(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetDateTime(2),
                reader.GetString(3),
                reader.GetString(4)
            ));
        }
    }
    #endregion GetAll

    #region GetById
    public Contacto? GetById(int id) {
        OpenConnection();

        string query = $"select * from Contacto where Id = {id}"; //TODO

        try {
            if (connection is not null) {
                SqlCommand cmd = new(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                return new Contacto(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetDateTime(2),
                    reader.GetString(3),
                    reader.GetString(4)
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
        throw new NotImplementedException();
    }
    #endregion Create

    public void Update(Contacto nuevoContacto) {
        throw new NotImplementedException();
    }

    public void DeleteById(int id) {
        throw new NotImplementedException();
    }
}
