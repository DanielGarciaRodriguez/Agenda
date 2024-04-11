using Agenda.DataLayer;

namespace Agenda {
    public partial class FormAgenda : Form {
        private readonly ContactoRepository _contactoRepo;
        private FormState _formState;
        public FormAgenda() {
            InitializeComponent();

            _formState = FormState.Viewing;
            UpdateReadonly();

            SetInputsMaxLengths();

            _contactoRepo = new ContactoRepository();
            UpdateDatagridviews();
        }

        private void SetInputsMaxLengths() {
            tboxNombre.MaxLength = Contacto.GetNombreMaxLength();
            tboxTelefono.MaxLength = Contacto.GetTelefonoMaxLength();
            tboxObservaciones.MaxLength = Contacto.GetObservacionesMaxLength();
        }

        private void UpdateDatagridviews() => dgvContactos.DataSource = _contactoRepo.GetAll();

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

                    bool selected = dgvContactos.SelectedRows.Count > 0;
                    bModificar.Enabled = selected;
                    bEliminar.Enabled = selected;

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

        #region Eliminar Button
        private void BEliminar_Click(object sender, EventArgs e) {
            if (dgvContactos.SelectedRows.Count == 0) {
                _formState = FormState.Viewing;
                UpdateReadonly();
                return;
            }

            _formState = FormState.Deleting;
            UpdateReadonly();

            /*
            var selectedId = dgvContactos.SelectedRows[0].Cells[0].Value;
            Contacto? selected = _contactoRepo.GetById((int) selectedId) ?? throw new InvalidDataException("ID no válida");
            */
            var selectedCells = dgvContactos.SelectedRows[0].Cells;

            tboxID.Text = ((int) selectedCells[0].Value).ToString();
            tboxNombre.Text = (string) selectedCells[1].Value;
            dtBirthday.Value = (DateTime) selectedCells[2].Value;
            tboxTelefono.Text = (string) selectedCells[3].Value;
            tboxObservaciones.Text = (string) selectedCells[4].Value ?? string.Empty;
        }
        #endregion Eliminar Button

        #region Guardar Button
        private void BGuardar_Click(object sender, EventArgs e) {
            try {
                if (_formState == FormState.Deleting) {
                    _contactoRepo.DeleteById(int.Parse(tboxID.Text));
                } else {
                    Contacto contacto = new(
                        id: tboxID.Text.Length > 0 ? int.Parse(tboxID.Text) : -1,
                        nombre: tboxNombre.Text,
                        fechaNacimiento: dtBirthday.Value,
                        telefono: tboxTelefono.Text,
                        observaciones: tboxObservaciones.Text
                    );

                    if (contacto.Id == -1)
                        _contactoRepo.Create(contacto);
                    else
                        _contactoRepo.Update(contacto);
                }

                _formState = FormState.Viewing;
                UpdateReadonly();
                UpdateDatagridviews();
            } catch (Exception ex) {
                Console.WriteLine(ex); //TODO
            }
        }
        #endregion Guardar Button

        #region Cancel Button
        private void BCancelar_Click(object sender, EventArgs e) {
            _formState = FormState.Viewing;
            dgvContactos.ClearSelection();
            UpdateReadonly();
            UpdateDatagridviews();
        }
        #endregion Cancel Button

        private void DgvContactos_SelectionChanged(object sender, EventArgs e) {
            UpdateReadonly();
        }
    }

    enum FormState {
        Viewing, Writing, Deleting
    }
}
