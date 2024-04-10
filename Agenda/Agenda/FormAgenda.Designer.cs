namespace Agenda {
    partial class FormAgenda {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            grContacto = new GroupBox();
            lblID = new Label();
            lblNombre = new Label();
            lblFechaNacimiento = new Label();
            lblTelefono = new Label();
            lblObservaciones = new Label();
            tboxID = new TextBox();
            tboxNombre = new TextBox();
            tboxTelefono = new TextBox();
            dtBirthday = new DateTimePicker();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tboxObservaciones = new TextBox();
            grContacto.SuspendLayout();
            SuspendLayout();
            // 
            // grContacto
            // 
            grContacto.Controls.Add(tboxObservaciones);
            grContacto.Controls.Add(dtBirthday);
            grContacto.Controls.Add(tboxTelefono);
            grContacto.Controls.Add(tboxNombre);
            grContacto.Controls.Add(tboxID);
            grContacto.Controls.Add(lblObservaciones);
            grContacto.Controls.Add(lblTelefono);
            grContacto.Controls.Add(lblFechaNacimiento);
            grContacto.Controls.Add(lblNombre);
            grContacto.Controls.Add(lblID);
            grContacto.Location = new Point(40, 12);
            grContacto.Name = "grContacto";
            grContacto.Size = new Size(590, 230);
            grContacto.TabIndex = 0;
            grContacto.TabStop = false;
            grContacto.Text = "Contacto";
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(18, 24);
            lblID.Name = "lblID";
            lblID.Size = new Size(21, 15);
            lblID.TabIndex = 0;
            lblID.Text = "ID:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(18, 53);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(18, 85);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(120, 15);
            lblFechaNacimiento.TabIndex = 2;
            lblFechaNacimiento.Text = "Fecha de nacimiento:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(18, 111);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(55, 15);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Teléfono:";
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Location = new Point(18, 140);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(87, 15);
            lblObservaciones.TabIndex = 4;
            lblObservaciones.Text = "Observaciones:";
            // 
            // tboxID
            // 
            tboxID.Location = new Point(165, 21);
            tboxID.Name = "tboxID";
            tboxID.Size = new Size(67, 23);
            tboxID.TabIndex = 1;
            // 
            // tboxNombre
            // 
            tboxNombre.Location = new Point(165, 50);
            tboxNombre.Name = "tboxNombre";
            tboxNombre.Size = new Size(206, 23);
            tboxNombre.TabIndex = 5;
            // 
            // tboxTelefono
            // 
            tboxTelefono.Location = new Point(165, 108);
            tboxTelefono.Name = "tboxTelefono";
            tboxTelefono.Size = new Size(150, 23);
            tboxTelefono.TabIndex = 6;
            // 
            // dtBirthday
            // 
            dtBirthday.Location = new Point(165, 79);
            dtBirthday.MaxDate = new DateTime(3000, 12, 31, 0, 0, 0, 0);
            dtBirthday.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtBirthday.Name = "dtBirthday";
            dtBirthday.Size = new Size(150, 23);
            dtBirthday.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // tboxObservaciones
            // 
            tboxObservaciones.Location = new Point(165, 137);
            tboxObservaciones.Multiline = true;
            tboxObservaciones.Name = "tboxObservaciones";
            tboxObservaciones.Size = new Size(296, 77);
            tboxObservaciones.TabIndex = 8;
            // 
            // FormAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grContacto);
            Name = "FormAgenda";
            Text = "Agenda";
            grContacto.ResumeLayout(false);
            grContacto.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grContacto;
        private Label lblObservaciones;
        private Label lblTelefono;
        private Label lblFechaNacimiento;
        private Label lblNombre;
        private Label lblID;
        private DateTimePicker dtBirthday;
        private TextBox tboxTelefono;
        private TextBox tboxNombre;
        private TextBox tboxID;
        private TextBox tboxObservaciones;
        private ContextMenuStrip contextMenuStrip1;
    }
}
