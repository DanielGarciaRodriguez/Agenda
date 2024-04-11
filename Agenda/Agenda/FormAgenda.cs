using Agenda.DataLayer;

namespace Agenda {
    public partial class FormAgenda : Form {
        private readonly ContactoRepository _contactoRepo;
        private FormState _formState;
        public FormAgenda() {
            InitializeComponent();
            _formState = FormState.Viewing;
            UpdateReadonly();

            _contactoRepo = new ContactoRepository();
            List<Contacto> contacts = _contactoRepo.GetAll();
            dgvContactos.DataSource = contacts;
        }

        private void BNuevo_Click(object sender, EventArgs e) {
            _formState = FormState.Writing;
            UpdateReadonly();

            dgvContactos.ClearSelection();
            tboxID.Text = string.Empty;
            tboxNombre.Text = string.Empty;
            dtBirthday.Value = DateTime.Now;
            tboxTelefono.Text = string.Empty;
            tboxObservaciones.Text = string.Empty;
        }

        private void UpdateReadonly() {
            switch (_formState) {
                case FormState.Viewing:
                    tboxNombre.ReadOnly = true;
                    dtBirthday.Enabled = false;
                    tboxTelefono.ReadOnly = true;
                    tboxObservaciones.ReadOnly = true;

                    dgvContactos.Enabled = true;

                    bNuevo.Enabled = true;
                    bModificar.Enabled = true;
                    bEliminar.Enabled = true;
                    bGuardar.Enabled = false;
                    bCancelar.Enabled = false;

                    break;
                case FormState.Deleting:
                    //---- Technically not necessary ----//
                    tboxNombre.ReadOnly = true;
                    dtBirthday.Enabled = false;
                    tboxTelefono.ReadOnly = true;
                    tboxObservaciones.ReadOnly = true;
                    //---- Technically not necessary ----//

                    dgvContactos.Enabled = false;

                    bNuevo.Enabled = false;
                    bModificar.Enabled = false;
                    bEliminar.Enabled = false;
                    bGuardar.Enabled = true;
                    bCancelar.Enabled = true;

                    break;
                case FormState.Writing:
                    tboxNombre.ReadOnly = false;
                    dtBirthday.Enabled = true;
                    tboxTelefono.ReadOnly = false;
                    tboxObservaciones.ReadOnly = false;

                    dgvContactos.Enabled = false;

                    bNuevo.Enabled = false;
                    bModificar.Enabled = false;
                    bEliminar.Enabled = false;
                    bGuardar.Enabled = true;
                    bCancelar.Enabled = true;

                    break;
            }
        }
    }

    enum FormState {
        Viewing, Writing, Deleting
    }
}
