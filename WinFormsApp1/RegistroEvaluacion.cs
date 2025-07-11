using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using Microsoft.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class RegistroEvaluacion : Form
    {
        public string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"; // Aqui abro nuevamente la cadena de conexion, para que el metodo pueda acceder a la base de datos correctamente
        SqlConnection connection = new SqlConnection("Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"); //
        SqlDataAdapter adapt;  
        public RegistroEvaluacion()
        {

            InitializeComponent();
            ConfigurarDataGridViewNoEditable();
            if (this.CBEVALUACION != null) // Comando para hacer que el ComboBox no se le pueda escribir encima
            {
                this.CBEVALUACION.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            if (this.CBESTUDIANTE != null) // Comando para hacer que el ComboBox no se le pueda escribir encima
            {
                this.CBESTUDIANTE.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            if (this.CBMATERIA != null) // Comando para hacer que el ComboBox no se le pueda escribir encima
            {
                this.CBMATERIA.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void ConfigurarDataGridViewNoEditable()
        {
            // Reemplaza 'tuDataGridView' con el nombre de tu DataGridView
            DGVEVALUACION.ReadOnly = true;
            DGVEVALUACION.AllowUserToAddRows = false;
            DGVEVALUACION.AllowUserToDeleteRows = false;

            // Opcional: Otras propiedades útiles para un DataGridView de solo lectura
            DGVEVALUACION.AllowUserToResizeColumns = true;  // ¿Permitir cambiar el tamaño de las columnas?
            DGVEVALUACION.AllowUserToResizeRows = false;   // ¿Permitir cambiar el tamaño de las filas?
            DGVEVALUACION.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Ajuste automático de la altura de la cabecera
            DGVEVALUACION.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleccionar fila completa al hacer clic
            DGVEVALUACION.MultiSelect = false; // Permitir seleccionar solo una fila a la vez
            DGVEVALUACION.EditMode = DataGridViewEditMode.EditProgrammatically; // Solo se puede editar programáticamente
        }

        private void BTNGUARDAR_Click(object sender, EventArgs e)
        {
            // --- INICIO DE LA VALIDACIÓN DE CAMPOS VACÍOS ---

            // Obtener los valores de los cuadros de texto y eliminar espacios en blanco al principio/final
            string comentario = TXTCOMENTARIO.Text.Trim();
            string calificacionText = MTBCALIFIACION.Text.Trim(); // Obtener el texto de la calificación

            // Validar si los campos 'Comentario' o 'Calificacion' están vacíos
            if (string.IsNullOrEmpty(comentario))
            {
                MessageBox.Show("El campo 'Comentario' no puede quedar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCOMENTARIO.Focus(); // Pone el foco en el campo de comentario
                return; // Detiene la ejecución del método
            }

            if (string.IsNullOrEmpty(calificacionText))
            {
                MessageBox.Show("El campo 'Calificación' no puede quedar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MTBCALIFIACION.Focus(); // Pone el foco en el campo de calificación
                return; // Detiene la ejecución del método
            }

            // --- FIN DE LA VALIDACIÓN DE CAMPOS VACÍOS ---

            // El resto de tu código para guardar la evaluación va dentro del try-catch
            try
            {
                // 1. Crear el objeto Evaluacion con los datos del formulario
                var nuevaEvaluacion = new Evaluacion
                {
                    // Asumes que el ComboBox de estudiantes guarda la Matrícula en su 'SelectedValue'
                    MatriculaEstudiante = CBESTUDIANTE.SelectedValue.ToString(),
                    Materia = CBMATERIA.SelectedItem.ToString(),
                    TipoEvaluacion = CBEVALUACION.SelectedItem.ToString(),
                    Calificacion = decimal.Parse(calificacionText), // Usamos calificacionText ya validado
                    Comentario = comentario, // Usamos comentario ya validado
                    FechaEvaluacion = dateTimePicker1.Value
                };

                // 2. Llamar al método para guardar
                var db = new MetodoParaGuardarEvaluacion();
                db.GuardarEvaluacion(nuevaEvaluacion);

                MessageBox.Show("¡Evaluación registrada exitosamente!");

            }
            catch (FormatException ex)
            {
                // Captura errores si la calificación no es un número válido
                MessageBox.Show($"Error en el formato de la calificación. Por favor, ingrese un número válido. Detalle: {ex.Message}", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MTBCALIFIACION.Focus(); // Pone el foco en el campo de calificación
            }
            catch (ArgumentException ex)
            {
                // Captura errores de validación si tu clase 'MetodoParaGuardarEvaluacion' lanza ArgumentException
                // (Aunque la validación de vacíos ya la manejamos antes)
                MessageBox.Show($"Error de validación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error (ej. de base de datos)
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            connection.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM Estudiantes", connection);
            adapt.Fill(dt);
            DGVEVALUACION.DataSource = dt;
            connection.Close();

            {
                try
                {
                    // 1. Crear una instancia de la clase de acceso a datos.
                    var db = new MetodoParaObtenerEstudiantesActivos();


                    // 2. Obtener la lista de estudiantes.
                    var estudiantes = db.ObtenerEstudiantesActivos();

                    // 3. Configurar el ComboBox.
                    CBESTUDIANTE.DataSource = estudiantes; // Asignar la lista como fuente de datos.
                    CBESTUDIANTE.DisplayMember = "NombreCompleto"; // La propiedad que se mostrará al usuario.
                    CBESTUDIANTE.ValueMember = "Matricula"; // El valor que se usará internamente.

                    // Opcional: Deseleccionar cualquier item al inicio.
                    CBESTUDIANTE.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la lista de estudiantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // --- Cargar Materias (NUEVO) ---
                // Limpiamos por si acaso y agregamos los items uno por uno.
                CBMATERIA.Items.Clear();
                CBMATERIA.Items.Add("Matemáticas");
                CBMATERIA.Items.Add("Lengua Española");
                CBMATERIA.Items.Add("Sociales");
                CBMATERIA.Items.Add("Naturales");

                // --- Cargar Tipos de Evaluación (NUEVO) ---
                CBEVALUACION.Items.Clear();
                CBEVALUACION.Items.Add("Examen");
                CBEVALUACION.Items.Add("Proyecto");
                CBEVALUACION.Items.Add("Trabajo");
            }
        }

        private void DGVEVALUACION_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TXTCOMENTARIO_TextChanged(object sender, EventArgs e)
        {
            // Filtrar el texto para que solo admita letras  
            string textoFiltrado = string.Concat(TXTCOMENTARIO.Text.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
            if (TXTCOMENTARIO.Text != textoFiltrado)
            {
                TXTCOMENTARIO.Text = textoFiltrado;
                TXTCOMENTARIO.SelectionStart = textoFiltrado.Length; // Mantener el cursor al final del texto  
            }
        }

        private void CBEVALUACION_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBESTUDIANTE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBMATERIA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTNCERRAR1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
