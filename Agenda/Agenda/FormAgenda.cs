using Agenda.DataLayer;

namespace Agenda {
    public partial class FormAgenda : Form {
        private readonly ContactoRepository _contactoRepo;
        public FormAgenda() {
            InitializeComponent();

            _contactoRepo = new ContactoRepository();
            List<Contacto> contacts = _contactoRepo.GetAll();
            dgvContactos.DataSource = contacts;
        }
    }
}
