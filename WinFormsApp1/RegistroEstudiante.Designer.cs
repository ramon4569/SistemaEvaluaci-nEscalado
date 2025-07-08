namespace CapaPresentacion
{
    partial class RegistroEstudiante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            BTNCERRAR1 = new Button();
            groupBox1 = new GroupBox();
            TXTAPELLIDO = new TextBox();
            TXTNOMBRE = new TextBox();
            TXTMATRICULA = new TextBox();
            LBLAPELLIDO = new Label();
            LBLNOMBRE = new Label();
            LBLMATRICULA = new Label();
            BTNNUEVO = new Button();
            BTNGUARDAR = new Button();
            BTNELIMINAR = new Button();
            DGVESTUDIANTES = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVESTUDIANTES).BeginInit();
            SuspendLayout();
            // 
            // BTNCERRAR1
            // 
            BTNCERRAR1.Location = new Point(893, 12);
            BTNCERRAR1.Name = "BTNCERRAR1";
            BTNCERRAR1.Size = new Size(141, 46);
            BTNCERRAR1.TabIndex = 0;
            BTNCERRAR1.Text = "CERRAR";
            BTNCERRAR1.UseVisualStyleBackColor = true;
            BTNCERRAR1.Click += BTNCERRAR1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TXTAPELLIDO);
            groupBox1.Controls.Add(TXTNOMBRE);
            groupBox1.Controls.Add(TXTMATRICULA);
            groupBox1.Controls.Add(LBLAPELLIDO);
            groupBox1.Controls.Add(LBLNOMBRE);
            groupBox1.Controls.Add(LBLMATRICULA);
            groupBox1.Font = new Font("Lucida Fax", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(28, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 289);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Estudiante";
            // 
            // TXTAPELLIDO
            // 
            TXTAPELLIDO.Location = new Point(88, 189);
            TXTAPELLIDO.Name = "TXTAPELLIDO";
            TXTAPELLIDO.Size = new Size(125, 25);
            TXTAPELLIDO.TabIndex = 5;
            TXTAPELLIDO.KeyPress += TXTAPELLIDO_KeyPress;
            // 
            // TXTNOMBRE
            // 
            TXTNOMBRE.Location = new Point(88, 116);
            TXTNOMBRE.Name = "TXTNOMBRE";
            TXTNOMBRE.Size = new Size(125, 25);
            TXTNOMBRE.TabIndex = 4;
            TXTNOMBRE.KeyPress += TXTNOMBRE_KeyPress;
            // 
            // TXTMATRICULA
            // 
            TXTMATRICULA.Location = new Point(88, 54);
            TXTMATRICULA.Name = "TXTMATRICULA";
            TXTMATRICULA.Size = new Size(125, 25);
            TXTMATRICULA.TabIndex = 3;
            TXTMATRICULA.TextChanged += TXTMATRICULA_TextChanged;
            TXTMATRICULA.Validating += TXTMATRICULA_Validating;
            // 
            // LBLAPELLIDO
            // 
            LBLAPELLIDO.AutoSize = true;
            LBLAPELLIDO.Location = new Point(4, 189);
            LBLAPELLIDO.Name = "LBLAPELLIDO";
            LBLAPELLIDO.Size = new Size(73, 17);
            LBLAPELLIDO.TabIndex = 2;
            LBLAPELLIDO.Text = "Apellido";
            // 
            // LBLNOMBRE
            // 
            LBLNOMBRE.AutoSize = true;
            LBLNOMBRE.Location = new Point(4, 116);
            LBLNOMBRE.Name = "LBLNOMBRE";
            LBLNOMBRE.Size = new Size(71, 17);
            LBLNOMBRE.TabIndex = 1;
            LBLNOMBRE.Text = "Nombre";
            // 
            // LBLMATRICULA
            // 
            LBLMATRICULA.AutoSize = true;
            LBLMATRICULA.Location = new Point(6, 61);
            LBLMATRICULA.Name = "LBLMATRICULA";
            LBLMATRICULA.Size = new Size(82, 17);
            LBLMATRICULA.TabIndex = 0;
            LBLMATRICULA.Text = "Matricula";
            // 
            // BTNNUEVO
            // 
            BTNNUEVO.BackColor = SystemColors.Desktop;
            BTNNUEVO.ForeColor = SystemColors.ButtonFace;
            BTNNUEVO.Location = new Point(628, 311);
            BTNNUEVO.Name = "BTNNUEVO";
            BTNNUEVO.Size = new Size(150, 43);
            BTNNUEVO.TabIndex = 2;
            BTNNUEVO.Text = "Nuevo";
            BTNNUEVO.UseVisualStyleBackColor = false;
            BTNNUEVO.Click += BTNNUEVO_Click;
            // 
            // BTNGUARDAR
            // 
            BTNGUARDAR.BackColor = SystemColors.Desktop;
            BTNGUARDAR.ForeColor = SystemColors.ButtonFace;
            BTNGUARDAR.Location = new Point(359, 311);
            BTNGUARDAR.Name = "BTNGUARDAR";
            BTNGUARDAR.Size = new Size(150, 43);
            BTNGUARDAR.TabIndex = 3;
            BTNGUARDAR.Text = "Guardar";
            BTNGUARDAR.UseVisualStyleBackColor = false;
            BTNGUARDAR.Click += BTNGUARDAR_Click;
            // 
            // BTNELIMINAR
            // 
            BTNELIMINAR.BackColor = SystemColors.Desktop;
            BTNELIMINAR.ForeColor = SystemColors.ButtonFace;
            BTNELIMINAR.Location = new Point(884, 312);
            BTNELIMINAR.Name = "BTNELIMINAR";
            BTNELIMINAR.Size = new Size(150, 43);
            BTNELIMINAR.TabIndex = 4;
            BTNELIMINAR.Text = "Eliminar";
            BTNELIMINAR.UseVisualStyleBackColor = false;
            BTNELIMINAR.Click += BTNELIMINAR_Click;
            // 
            // DGVESTUDIANTES
            // 
            DGVESTUDIANTES.BackgroundColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVESTUDIANTES.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVESTUDIANTES.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVESTUDIANTES.Location = new Point(359, 64);
            DGVESTUDIANTES.Name = "DGVESTUDIANTES";
            DGVESTUDIANTES.RowHeadersWidth = 51;
            DGVESTUDIANTES.Size = new Size(681, 216);
            DGVESTUDIANTES.TabIndex = 5;
            DGVESTUDIANTES.CellContentClick += DGVESTUDIANTES_CellContentClick;
            // 
            // RegistroEstudiante
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1084, 430);
            Controls.Add(DGVESTUDIANTES);
            Controls.Add(BTNELIMINAR);
            Controls.Add(BTNGUARDAR);
            Controls.Add(BTNNUEVO);
            Controls.Add(groupBox1);
            Controls.Add(BTNCERRAR1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegistroEstudiante";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form3";
            Load += Form3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVESTUDIANTES).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BTNCERRAR1;
        private GroupBox groupBox1;
        private TextBox TXTAPELLIDO;
        private TextBox TXTNOMBRE;
        private TextBox TXTMATRICULA;
        private Label LBLAPELLIDO;
        private Label LBLNOMBRE;
        private Label LBLMATRICULA;
        private Button BTNNUEVO;
        private Button BTNGUARDAR;
        private Button BTNELIMINAR;
        private DataGridView DGVESTUDIANTES;
    }
}