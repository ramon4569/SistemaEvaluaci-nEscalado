namespace CapaPresentacion
{
    partial class FormReporte
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartDistribucionTipo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnExportarExcel = new Button();
            dgvDesempenoEstudiante = new DataGridView();
            BTNCERRAR1 = new Button();
            ((System.ComponentModel.ISupportInitialize)chartDistribucionTipo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDesempenoEstudiante).BeginInit();
            SuspendLayout();
            // 
            // chartDistribucionTipo
            // 
            chartArea2.Name = "ChartArea1";
            chartDistribucionTipo.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartDistribucionTipo.Legends.Add(legend2);
            chartDistribucionTipo.Location = new Point(570, 32);
            chartDistribucionTipo.Name = "chartDistribucionTipo";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartDistribucionTipo.Series.Add(series2);
            chartDistribucionTipo.Size = new Size(426, 308);
            chartDistribucionTipo.TabIndex = 0;
            chartDistribucionTipo.Text = "chart1";
            chartDistribucionTipo.Click += chartDistribucionTipo_Click_1;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = SystemColors.ActiveCaptionText;
            btnExportarExcel.ForeColor = SystemColors.ButtonFace;
            btnExportarExcel.Location = new Point(78, 293);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(358, 78);
            btnExportarExcel.TabIndex = 1;
            btnExportarExcel.Text = "Exportar(Excel)";
            btnExportarExcel.UseVisualStyleBackColor = false;
            btnExportarExcel.Click += btnExportarExcel_Click;
            // 
            // dgvDesempenoEstudiante
            // 
            dgvDesempenoEstudiante.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDesempenoEstudiante.Location = new Point(42, 32);
            dgvDesempenoEstudiante.Name = "dgvDesempenoEstudiante";
            dgvDesempenoEstudiante.RowHeadersWidth = 51;
            dgvDesempenoEstudiante.Size = new Size(468, 250);
            dgvDesempenoEstudiante.TabIndex = 3;
            // 
            // BTNCERRAR1
            // 
            BTNCERRAR1.Location = new Point(891, 12);
            BTNCERRAR1.Name = "BTNCERRAR1";
            BTNCERRAR1.Size = new Size(105, 32);
            BTNCERRAR1.TabIndex = 16;
            BTNCERRAR1.Text = "CERRAR";
            BTNCERRAR1.UseVisualStyleBackColor = true;
            BTNCERRAR1.Click += BTNCERRAR1_Click;
            // 
            // FormReporte
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 383);
            Controls.Add(BTNCERRAR1);
            Controls.Add(dgvDesempenoEstudiante);
            Controls.Add(btnExportarExcel);
            Controls.Add(chartDistribucionTipo);
            Name = "FormReporte";
            Text = "Form6";
            Load += Form6_Load;
            ((System.ComponentModel.ISupportInitialize)chartDistribucionTipo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDesempenoEstudiante).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDistribucionTipo;
        private Button btnExportarExcel;
        private DataGridView dgvDesempenoEstudiante;
        private Button BTNCERRAR1;
    }
}