namespace CapaPresentacion
{
    partial class FiltroEstudiante
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
            CBFILTROESTUDIANTE = new ComboBox();
            CBFILTROMATERIA = new ComboBox();
            DTPFECHADESDE = new DateTimePicker();
            DTPFECHAHASTA = new DateTimePicker();
            BTNAPLICARFILTROS = new Button();
            BTNLIMPIARFILTRO = new Button();
            BTNEDITAR = new Button();
            BTNELIMINAR = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            DVGEVALUACIONES = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DVGEVALUACIONES).BeginInit();
            SuspendLayout();
            // 
            // CBFILTROESTUDIANTE
            // 
            CBFILTROESTUDIANTE.FormattingEnabled = true;
            CBFILTROESTUDIANTE.Location = new Point(102, 47);
            CBFILTROESTUDIANTE.Name = "CBFILTROESTUDIANTE";
            CBFILTROESTUDIANTE.Size = new Size(151, 25);
            CBFILTROESTUDIANTE.TabIndex = 1;
            CBFILTROESTUDIANTE.SelectedIndexChanged += CBFILTROESTUDIANTE_SelectedIndexChanged;
            // 
            // CBFILTROMATERIA
            // 
            CBFILTROMATERIA.FormattingEnabled = true;
            CBFILTROMATERIA.Location = new Point(351, 47);
            CBFILTROMATERIA.Name = "CBFILTROMATERIA";
            CBFILTROMATERIA.Size = new Size(151, 25);
            CBFILTROMATERIA.TabIndex = 2;
            // 
            // DTPFECHADESDE
            // 
            DTPFECHADESDE.Location = new Point(102, 142);
            DTPFECHADESDE.Name = "DTPFECHADESDE";
            DTPFECHADESDE.Size = new Size(151, 25);
            DTPFECHADESDE.TabIndex = 3;
            // 
            // DTPFECHAHASTA
            // 
            DTPFECHAHASTA.Location = new Point(351, 142);
            DTPFECHAHASTA.Name = "DTPFECHAHASTA";
            DTPFECHAHASTA.Size = new Size(151, 25);
            DTPFECHAHASTA.TabIndex = 4;
            // 
            // BTNAPLICARFILTROS
            // 
            BTNAPLICARFILTROS.BackColor = SystemColors.ActiveCaptionText;
            BTNAPLICARFILTROS.ForeColor = SystemColors.ButtonFace;
            BTNAPLICARFILTROS.Location = new Point(570, 286);
            BTNAPLICARFILTROS.Name = "BTNAPLICARFILTROS";
            BTNAPLICARFILTROS.Size = new Size(204, 29);
            BTNAPLICARFILTROS.TabIndex = 5;
            BTNAPLICARFILTROS.Text = "Aplicar Filtro";
            BTNAPLICARFILTROS.UseVisualStyleBackColor = false;
            BTNAPLICARFILTROS.Click += BTNAPLICARFILTROS_Click;
            // 
            // BTNLIMPIARFILTRO
            // 
            BTNLIMPIARFILTRO.BackColor = SystemColors.ActiveCaptionText;
            BTNLIMPIARFILTRO.ForeColor = SystemColors.ButtonFace;
            BTNLIMPIARFILTRO.Location = new Point(791, 286);
            BTNLIMPIARFILTRO.Name = "BTNLIMPIARFILTRO";
            BTNLIMPIARFILTRO.Size = new Size(204, 29);
            BTNLIMPIARFILTRO.TabIndex = 6;
            BTNLIMPIARFILTRO.Text = "Limpiar Filtro";
            BTNLIMPIARFILTRO.UseVisualStyleBackColor = false;
            BTNLIMPIARFILTRO.Click += BTNLIMPIARFILTRO_Click;
            // 
            // BTNEDITAR
            // 
            BTNEDITAR.BackColor = SystemColors.ActiveCaptionText;
            BTNEDITAR.ForeColor = SystemColors.ButtonFace;
            BTNEDITAR.Location = new Point(791, 321);
            BTNEDITAR.Name = "BTNEDITAR";
            BTNEDITAR.Size = new Size(204, 29);
            BTNEDITAR.TabIndex = 7;
            BTNEDITAR.Text = "Editar";
            BTNEDITAR.UseVisualStyleBackColor = false;
            BTNEDITAR.Click += BTNEDITAR_Click;
            // 
            // BTNELIMINAR
            // 
            BTNELIMINAR.BackColor = SystemColors.ActiveCaptionText;
            BTNELIMINAR.ForeColor = SystemColors.ButtonFace;
            BTNELIMINAR.Location = new Point(570, 321);
            BTNELIMINAR.Name = "BTNELIMINAR";
            BTNELIMINAR.Size = new Size(204, 29);
            BTNELIMINAR.TabIndex = 8;
            BTNELIMINAR.Text = "Eliminar Evaluacion";
            BTNELIMINAR.UseVisualStyleBackColor = false;
            BTNELIMINAR.Click += BTNELIMINAR_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(CBFILTROESTUDIANTE);
            groupBox1.Controls.Add(CBFILTROMATERIA);
            groupBox1.Controls.Add(DTPFECHAHASTA);
            groupBox1.Controls.Add(DTPFECHADESDE);
            groupBox1.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(511, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(523, 250);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros de Busqueda";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(278, 148);
            label4.Name = "label4";
            label4.Size = new Size(52, 17);
            label4.TabIndex = 5;
            label4.Text = "Hasta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 148);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 4;
            label3.Text = "Desde";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 50);
            label2.Name = "label2";
            label2.Size = new Size(67, 17);
            label2.TabIndex = 3;
            label2.Text = "Materia";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 50);
            label1.Name = "label1";
            label1.Size = new Size(90, 17);
            label1.TabIndex = 2;
            label1.Text = "Estudiante";
            // 
            // DVGEVALUACIONES
            // 
            DVGEVALUACIONES.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DVGEVALUACIONES.Location = new Point(28, 12);
            DVGEVALUACIONES.Name = "DVGEVALUACIONES";
            DVGEVALUACIONES.RowHeadersWidth = 51;
            DVGEVALUACIONES.Size = new Size(465, 326);
            DVGEVALUACIONES.TabIndex = 0;
            DVGEVALUACIONES.CellContentClick += DVGEVALUACIONES_CellContentClick;
            // 
            // FiltroEstudiante
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 383);
            Controls.Add(groupBox1);
            Controls.Add(BTNELIMINAR);
            Controls.Add(BTNEDITAR);
            Controls.Add(BTNLIMPIARFILTRO);
            Controls.Add(DVGEVALUACIONES);
            Controls.Add(BTNAPLICARFILTROS);
            Name = "FiltroEstudiante";
            Text = "Form5";
            Load += Form5_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DVGEVALUACIONES).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox CBFILTROESTUDIANTE;
        private ComboBox CBFILTROMATERIA;
        private DateTimePicker DTPFECHADESDE;
        private DateTimePicker DTPFECHAHASTA;
        private Button BTNAPLICARFILTROS;
        private Button BTNLIMPIARFILTRO;
        private Button BTNEDITAR;
        private Button BTNELIMINAR;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView DVGEVALUACIONES;
    }
}