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
        throw new NotImplementedException();
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
