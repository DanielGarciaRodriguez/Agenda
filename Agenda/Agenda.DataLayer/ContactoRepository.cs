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

    public List<Contacto> GetAll() {
        OpenConnection();

        string query = "select * from Contacto";
        List<Contacto> list = new();

        try {
            if (connection is not null) {
                SqlCommand cmd = new(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

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
        } catch (Exception ex) {
            Console.WriteLine(ex.ToString()); //TODO
        } finally {
            CloseConnection();
        }

        return list;
    }

    public Contacto GetById(int id) {
        throw new NotImplementedException();
    }

    public void Create(Contacto nuevoContacto) {
        throw new NotImplementedException();
    }

    public void Update(Contacto nuevoContacto) {
        throw new NotImplementedException();
    }

    public void DeleteById(int id) {
        throw new NotImplementedException();
    }
}
