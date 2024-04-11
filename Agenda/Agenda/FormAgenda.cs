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

        #region Update enabled items according to state
        private void UpdateReadonly() {
            ToggleEnabledInputs();
            ToggleEnabledDatagridviews();
            ToggleEnabledButtons();
        }

        private void ToggleEnabledInputs() {
            switch (_formState) {
                case FormState.Viewing:
                case FormState.Deleting:
                    tboxNombre.ReadOnly = true;
                    dtBirthday.Enabled = false;
                    tboxTelefono.ReadOnly = true;
                    tboxObservaciones.ReadOnly = true;
                    break;
                case FormState.Writing:
                    tboxNombre.ReadOnly = false;
                    dtBirthday.Enabled = true;
                    tboxTelefono.ReadOnly = false;
                    tboxObservaciones.ReadOnly = false;
                    break;
            }
        }

        private void ToggleEnabledDatagridviews() {
            switch (_formState) {
                case FormState.Viewing:
                    dgvContactos.Enabled = true;
                    break;
                case FormState.Deleting:
                case FormState.Writing:
                    dgvContactos.Enabled = false;
                    break;
            }
        }

        private void ToggleEnabledButtons() {
            switch (_formState) {
                case FormState.Viewing:
                    bNuevo.Enabled = true;
                    bModificar.Enabled = true;
                    bEliminar.Enabled = true;
                    bGuardar.Enabled = false;
                    bCancelar.Enabled = false;

                    break;
                case FormState.Deleting:
                case FormState.Writing:
                    bNuevo.Enabled = false;
                    bModificar.Enabled = false;
                    bEliminar.Enabled = false;
                    bGuardar.Enabled = true;
                    bCancelar.Enabled = true;

                    break;
            }
        }
        #endregion Update enabled items according to state

        #region Nuevo Button
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
        #endregion Nuevo Button

        #region Cancel Button
        private void BCancelar_Click(object sender, EventArgs e) {
            _formState = FormState.Viewing;
            UpdateReadonly();
        }
        #endregion Cancel Button
    }

    enum FormState {
        Viewing, Writing, Deleting
    }
}
