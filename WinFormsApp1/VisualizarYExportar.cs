using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;



namespace CapaPresentacion
{


    public partial class FormReporte : Form
    {

        private bool esNuevo = true;
        public string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"; // Aqui abro nuevamente la cadena de conexion, para que el metodo pueda acceder a la base de datos correctamente
        SqlConnection connection = new SqlConnection("Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"); //
        SqlDataAdapter adapt;
        private MetodoparaObtenerDistribucionPorTipoDeEvalaucion metodoparaobtenerdistribucionportipodeevaluacion = new MetodoparaObtenerDistribucionPorTipoDeEvalaucion();
        private MetodoObtenerDesempenoPorEstudiante metodoparadesempenoporestudiante = new MetodoObtenerDesempenoPorEstudiante();



        public FormReporte()
        {
            InitializeComponent(); // Esto inicializa los componentes del diseñador
            ConfigurarDataGridViewNoEditable();


        }


        private void Form6_Load(object sender, EventArgs e)
        {
            CargarGraficoDistribucionTipo();
            // Llama a CargarDesempenoEstudiante sin una matrícula para obtener todas las evaluaciones al inicio
            CargarDesempenoEstudiante(null);
        }

        private void ConfigurarDataGridViewNoEditable()
        {
            // Reemplaza 'tuDataGridView' con el nombre de tu DataGridView
            dgvDesempenoEstudiante.ReadOnly = true;
            dgvDesempenoEstudiante.AllowUserToAddRows = false;
            dgvDesempenoEstudiante.AllowUserToDeleteRows = false;

            // Opcional: Otras propiedades útiles para un DataGridView de solo lectura
            dgvDesempenoEstudiante.AllowUserToResizeColumns = true;  // ¿Permitir cambiar el tamaño de las columnas?
            dgvDesempenoEstudiante.AllowUserToResizeRows = false;   // ¿Permitir cambiar el tamaño de las filas?
            dgvDesempenoEstudiante.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Ajuste automático de la altura de la cabecera
            dgvDesempenoEstudiante.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleccionar fila completa al hacer clic
            dgvDesempenoEstudiante.MultiSelect = false; // Permitir seleccionar solo una fila a la vez
            dgvDesempenoEstudiante.EditMode = DataGridViewEditMode.EditProgrammatically; // Solo se puede editar programáticamente
        }




        private void CargarGraficoDistribucionTipo()
        {
            chartDistribucionTipo.Titles.Clear();
            chartDistribucionTipo.Series.Clear();
            chartDistribucionTipo.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea("DistribucionTipoArea");
            chartDistribucionTipo.ChartAreas.Add(chartArea);
            chartDistribucionTipo.Titles.Add("Distribución de Evaluaciones por Tipo");

            Series series = new Series("Tipos")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true, // Sigue siendo true para mostrar la etiqueta
                LabelFormat = "0", // ¡¡¡CAMBIADO AQUÍ!!! Esto mostrará el valor entero (la Cantidad) directamente.
                                   // También puedes usar "F0" para formato numérico sin decimales.
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            var data = metodoparaobtenerdistribucionportipodeevaluacion.ObtenerDistribucionPorTipoEvaluacion();

            // --- ¡¡¡ESTA SECCIÓN SIGUE SIENDO CRÍTICA PARA DEPURAR LOS VALORES DE CANTIDAD!!! ---
            // POR FAVOR, ejecuta la aplicación y COPIA EL CONTENIDO DE LA VENTANA 'SALIDA' (Output) de Visual Studio.
            Console.WriteLine("--- Depuración: Datos de Distribución por Tipo ---");
            if (data == null || data.Count == 0)
            {
                Console.WriteLine("La lista de datos de distribución está vacía o es nula.");
            }
            else
            {
                foreach (var item in data)
                {
                    Console.WriteLine($"Tipo: {item.TipoEvaluacion}, Cantidad: {item.Cantidad}");

                    DataPoint point = new DataPoint(0, item.Cantidad);
                    // Asegúrate de que NO tienes ninguna línea point.Label = "..." aquí que sobrescriba el LabelFormat.
                    point.LegendText = $"{item.TipoEvaluacion} ({item.Cantidad})"; // Texto para la leyenda
                    series.Points.Add(point);
                }
            }
            Console.WriteLine("--- Fin Depuración ---");


            chartDistribucionTipo.Series.Add(series);

            chartDistribucionTipo.Legends.Clear();
            chartDistribucionTipo.Legends.Add(new Legend("MiLeyenda"));
            chartDistribucionTipo.Series["Tipos"].Legend = "MiLeyenda";

            series.ChartArea = "DistribucionTipoArea";
            series["PieLabelStyle"] = "Outside"; // Etiquetas fuera del pastel para mayor claridad
            series["PieLineColor"] = "Black"; // Línea para conectar etiqueta y porción
            series["PieStartAngle"] = "90"; // Inicia el pastel desde arriba
        }

        private void CargarDesempenoEstudiante(string matricula)
        {
            if (dgvDesempenoEstudiante == null) return;

            // Llama a ObtenerDesempenoPorEstudiante. Si matricula es null, obtendrá todas las evaluaciones.
            var desempeno = metodoparadesempenoporestudiante.ObtenerDesempenoPorEstudiante(matricula);
            dgvDesempenoEstudiante.DataSource = desempeno;

            if (dgvDesempenoEstudiante.Columns.Contains("ID"))
            {
                dgvDesempenoEstudiante.Columns["ID"].Visible = false;
            }
            dgvDesempenoEstudiante.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }


        private void ExportarDataGridViewAExcelCSV(DataGridView dgv)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Archivos CSV (*.csv)|*.csv",
                FileName = "ExportacionDatos.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        string delimiter = ";";
                        // ... (el resto del código de exportación a CSV es el mismo que ya tienes) ...
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            sw.Write(dgv.Columns[i].HeaderText);
                            if (i < dgv.Columns.Count - 1) sw.Write(delimiter);
                        }
                        sw.WriteLine();
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                object cellValue = row.Cells[i].Value;
                                string formattedValue = (cellValue == null || cellValue == DBNull.Value) ? "" : cellValue.ToString().Replace("\"", "\"\"");
                                if (formattedValue.Contains(delimiter) || formattedValue.Contains("\"") || formattedValue.Contains("\n") || formattedValue.Contains("\r"))
                                {
                                    formattedValue = $"\"{formattedValue}\"";
                                }
                                sw.Write(formattedValue);
                                if (i < dgv.Columns.Count - 1) sw.Write(delimiter);
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("Datos exportados a CSV correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar a CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportarDataGridViewAExcelXLSX(DataGridView dgv, Image logoImage, string systemName)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Archivos de Excel (*.xlsx)|*.xlsx",
                FileName = "ReporteSistemaEvaluaciones.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Reporte");

                        // 1. Añadir el Logo  
                        if (logoImage != null)
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                logoImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                memoryStream.Position = 0;
                                ExcelPicture excelLogo = worksheet.Drawings.AddPicture("LogoSistema", memoryStream);
                                excelLogo.From.Column = 0; // Columna A  
                                excelLogo.From.Row = 0;    // Fila 1 (0-indexed)  
                                excelLogo.SetSize(100, 100); // Ajusta el tamaño del logo (ancho, alto) en píxeles  
                            }
                        }

                        // 2. Añadir el Nombre del Sistema  
                        int headerRowIndex = (logoImage != null) ? 5 : 1;
                        worksheet.Cells[headerRowIndex, 1].Value = systemName;
                        worksheet.Cells[headerRowIndex, 1].Style.Font.Size = 16;
                        worksheet.Cells[headerRowIndex, 1].Style.Font.Bold = true;
                        worksheet.Cells[headerRowIndex, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        // Añadir un espacio después del nombre del sistema  
                        int dataStartRow = headerRowIndex + 2;

                        // 3. Escribir Encabezados del DataGridView  
                        for (int col = 0; col < dgv.Columns.Count; col++)
                        {
                            worksheet.Cells[dataStartRow, col + 1].Value = dgv.Columns[col].HeaderText;
                            worksheet.Cells[dataStartRow, col + 1].Style.Font.Bold = true;
                            worksheet.Cells[dataStartRow, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[dataStartRow, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        }

                        // 4. Escribir Datos del DataGridView  
                        for (int row = 0; row < dgv.Rows.Count; row++)
                        {
                            if (dgv.Rows[row].IsNewRow) continue;

                            for (int col = 0; col < dgv.Columns.Count; col++)
                            {
                                worksheet.Cells[dataStartRow + row + 1, col + 1].Value = dgv.Rows[row].Cells[col].Value;
                            }
                        }

                        // Ajustar el ancho de las columnas automáticamente  
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Guardar el archivo  
                        FileInfo excelFile = new FileInfo(sfd.FileName);
                        package.SaveAs(excelFile);
                    }
                    MessageBox.Show("Datos exportados a Excel (.xlsx) correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ExportarA_PDF()
        {
            MessageBox.Show(
                "La exportación a PDF es una funcionalidad más compleja que generalmente requiere una librería externa (ej. iTextSharp, PDFsharp) " +
                "y no está completamente implementada en este ejemplo simple. " +
                "Si necesitas una solución rápida para DataGridViews, considera imprimir a una impresora PDF virtual.",
                "Funcionalidad de Exportación a PDF",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void cbEstudianteDesempeno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // 1. Obtener la imagen del logo
            // Asegúrate de que el logo esté añadido a los recursos de tu proyecto
            // (Explorador de Soluciones -> Proyecto -> Propiedades -> Recursos)
            Image logoParaExcel = null;
            try
            {
                // Reemplaza 'NombreDeTuLogoEnRecursos' con el nombre real de tu imagen en Resources.
                // Por ejemplo, si tu logo se llama 'MiLogoSistema.png' y lo añadiste, sería Properties.Resources.MiLogoSistema;
                logoParaExcel = global::CapaPresentacion.Properties.Resources.Gemini_Generated_Image_7n6ikt7n6ikt7n6i_removebg_preview;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Advertencia: No se pudo cargar el logo para exportar a Excel. {ex.Message}", "Logo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Continúa la exportación sin logo
            }

            // 2. Definir el nombre del sistema
            string systemName = "STUDENT FEEDBACK EVALUATION";

            // 3. Llamar al nuevo método de exportación a XLSX
            // *** CAMBIADO: Antes llamaba a ExportarDataGridViewAExcelCSV ***
            ExportarDataGridViewAExcelXLSX(dgvDesempenoEstudiante, logoParaExcel, systemName);
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarA_PDF();
        }

        private void chartDistribucionTipo_Click(object sender, EventArgs e)
        {

        }

        private void chartDistribucionTipo_Click_1(object sender, EventArgs e)
        {

        }

        private void BTNCERRAR1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }


} 