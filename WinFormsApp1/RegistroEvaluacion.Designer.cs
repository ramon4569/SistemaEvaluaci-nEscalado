namespace CapaPresentacion
{
    partial class RegistroEvaluacion
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
            CBESTUDIANTE = new ComboBox();
            label1 = new Label();
            CBMATERIA = new ComboBox();
            label2 = new Label();
            MTBCALIFIACION = new MaskedTextBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            BTNGUARDAR = new Button();
            DGVEVALUACION = new DataGridView();
            label5 = new Label();
            CBEVALUACION = new ComboBox();
            TXTCOMENTARIO = new TextBox();
            label6 = new Label();
            BTNCERRAR1 = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVEVALUACION).BeginInit();
            SuspendLayout();
            // 
            // CBESTUDIANTE
            // 
            CBESTUDIANTE.FormattingEnabled = true;
            CBESTUDIANTE.Location = new Point(242, 52);
            CBESTUDIANTE.Name = "CBESTUDIANTE";
            CBESTUDIANTE.Size = new Size(151, 28);
            CBESTUDIANTE.TabIndex = 0;
            CBESTUDIANTE.SelectedIndexChanged += CBESTUDIANTE_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            label1.Location = new Point(50, 57);
            label1.Name = "label1";
            label1.Size = new Size(186, 17);
            label1.TabIndex = 1;
            label1.Text = "Seleccionar Estudiante";
            // 
            // CBMATERIA
            // 
            CBMATERIA.FormattingEnabled = true;
            CBMATERIA.Location = new Point(242, 136);
            CBMATERIA.Name = "CBMATERIA";
            CBMATERIA.Size = new Size(151, 28);
            CBMATERIA.TabIndex = 2;
            CBMATERIA.SelectedIndexChanged += CBMATERIA_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            label2.Location = new Point(50, 138);
            label2.Name = "label2";
            label2.Size = new Size(138, 17);
            label2.TabIndex = 3;
            label2.Text = "Ingresar Materia";
            // 
            // MTBCALIFIACION
            // 
            MTBCALIFIACION.Location = new Point(242, 245);
            MTBCALIFIACION.Mask = "99999";
            MTBCALIFIACION.Name = "MTBCALIFIACION";
            MTBCALIFIACION.Size = new Size(125, 27);
            MTBCALIFIACION.TabIndex = 4;
            MTBCALIFIACION.ValidatingType = typeof(int);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            label3.Location = new Point(50, 194);
            label3.Name = "label3";
            label3.Size = new Size(158, 34);
            label3.TabIndex = 5;
            label3.Text = "Tipo de Evaluación\n\n";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(242, 348);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            label4.Location = new Point(50, 254);
            label4.Name = "label4";
            label4.Size = new Size(102, 17);
            label4.TabIndex = 7;
            label4.Text = "Calificacion";
            // 
            // BTNGUARDAR
            // 
            BTNGUARDAR.BackColor = SystemColors.ActiveCaptionText;
            BTNGUARDAR.ForeColor = SystemColors.ButtonFace;
            BTNGUARDAR.Location = new Point(540, 336);
            BTNGUARDAR.Name = "BTNGUARDAR";
            BTNGUARDAR.Size = new Size(422, 54);
            BTNGUARDAR.TabIndex = 8;
            BTNGUARDAR.Text = "Agregar/Guardar Evaluacion";
            BTNGUARDAR.UseVisualStyleBackColor = false;
            BTNGUARDAR.Click += BTNGUARDAR_Click;
            // 
            // DGVEVALUACION
            // 
            DGVEVALUACION.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVEVALUACION.Location = new Point(540, 68);
            DGVEVALUACION.Name = "DGVEVALUACION";
            DGVEVALUACION.RowHeadersWidth = 51;
            DGVEVALUACION.Size = new Size(422, 224);
            DGVEVALUACION.TabIndex = 9;
            DGVEVALUACION.CellContentClick += DGVEVALUACION_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            label5.Location = new Point(50, 350);
            label5.Name = "label5";
            label5.Size = new Size(168, 17);
            label5.TabIndex = 11;
            label5.Text = "Fecha de Evaluacion";
            // 
            // CBEVALUACION
            // 
            CBEVALUACION.FormattingEnabled = true;
            CBEVALUACION.Location = new Point(242, 189);
            CBEVALUACION.Name = "CBEVALUACION";
            CBEVALUACION.Size = new Size(151, 28);
            CBEVALUACION.TabIndex = 12;
            CBEVALUACION.SelectedIndexChanged += CBEVALUACION_SelectedIndexChanged;
            // 
            // TXTCOMENTARIO
            // 
            TXTCOMENTARIO.Location = new Point(242, 299);
            TXTCOMENTARIO.Name = "TXTCOMENTARIO";
            TXTCOMENTARIO.Size = new Size(125, 27);
            TXTCOMENTARIO.TabIndex = 13;
            TXTCOMENTARIO.TextChanged += TXTCOMENTARIO_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Fax", 9F, FontStyle.Bold);
            label6.Location = new Point(50, 308);
            label6.Name = "label6";
            label6.Size = new Size(100, 17);
            label6.TabIndex = 14;
            label6.Text = "Comentario";
            // 
            // BTNCERRAR1
            // 
            BTNCERRAR1.Location = new Point(885, 12);
            BTNCERRAR1.Name = "BTNCERRAR1";
            BTNCERRAR1.Size = new Size(77, 32);
            BTNCERRAR1.TabIndex = 15;
            BTNCERRAR1.Text = "CERRAR";
            BTNCERRAR1.UseVisualStyleBackColor = true;
            BTNCERRAR1.Click += BTNCERRAR1_Click;
            // 
            // RegistroEvaluacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 450);
            Controls.Add(BTNCERRAR1);
            Controls.Add(label6);
            Controls.Add(TXTCOMENTARIO);
            Controls.Add(CBEVALUACION);
            Controls.Add(label5);
            Controls.Add(DGVEVALUACION);
            Controls.Add(BTNGUARDAR);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(MTBCALIFIACION);
            Controls.Add(label2);
            Controls.Add(CBMATERIA);
            Controls.Add(label1);
            Controls.Add(CBESTUDIANTE);
            Name = "RegistroEvaluacion";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)DGVEVALUACION).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CBESTUDIANTE;
        private Label label1;
        private ComboBox CBMATERIA;
        private Label label2;
        private MaskedTextBox MTBCALIFIACION;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Button BTNGUARDAR;
        private DataGridView DGVEVALUACION;
        private Label label5;
        private ComboBox CBEVALUACION;
        private TextBox TXTCOMENTARIO;
        private Label label6;
        private Button BTNCERRAR1;
    }
}