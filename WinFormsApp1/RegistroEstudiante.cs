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
    using System.Data;
    using static CapaPresentacion.RegistroEstudiante;
    using CapaNegocio;
    using System.Text.RegularExpressions;


    namespace CapaPresentacion
    {

    public partial class RegistroEstudiante : Form
    {
        private bool esNuevo = true;
        public string connectionString = "Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"; // Aqui abro nuevamente la cadena de conexion, para que el metodo pueda acceder a la base de datos correctamente
        SqlConnection connection = new SqlConnection("Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"); //
        SqlDataAdapter adapt;                                                                                                                                 //SqlConnection connection = new SqlConnection("Server=.;Database=SistemaEvaluacionesDB;Integrated Security=true" + " ;TrustServerCertificate=True;"); //
                                                                                                                                                              // SqlDataAdapter adapt;
        public RegistroEstudiante()
        {
            InitializeComponent();
            ConfigurarDataGridViewNoEditable();


        }

        private void ConfigurarDataGridViewNoEditable()
        {
            // Reemplaza 'tuDataGridView' con el nombre de tu DataGridView
            DGVESTUDIANTES.ReadOnly = true;
            DGVESTUDIANTES.AllowUserToAddRows = false;
            DGVESTUDIANTES.AllowUserToDeleteRows = false;

            // Opcional: Otras propiedades útiles para un DataGridView de solo lectura
            DGVESTUDIANTES.AllowUserToResizeColumns = true;  // ¿Permitir cambiar el tamaño de las columnas?
            DGVESTUDIANTES.AllowUserToResizeRows = false;   // ¿Permitir cambiar el tamaño de las filas?
            DGVESTUDIANTES.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Ajuste automático de la altura de la cabecera
            DGVESTUDIANTES.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Seleccionar fila completa al hacer clic
            DGVESTUDIANTES.MultiSelect = false; // Permitir seleccionar solo una fila a la vez
            DGVESTUDIANTES.EditMode = DataGridViewEditMode.EditProgrammatically; // Solo se puede editar programáticamente
        }
        private void BTNCERRAR1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DGVESTUDIANTES_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Nos aseguramos de que no sea el encabezado
            {
                esNuevo = false; // Cambiamos a modo "Editar"
                DataGridViewRow fila = DGVESTUDIANTES.Rows[e.RowIndex];

                // Cargamos los datos de la fila en los TextBox
                TXTMATRICULA.Text = fila.Cells["Matricula"].Value.ToString();
                TXTNOMBRE.Text = fila.Cells["Nombres"].Value.ToString();
                TXTAPELLIDO.Text = fila.Cells["Apellidos"].Value.ToString();

                // Bloqueamos la matrícula para no poder cambiar la clave primaria al editar
                TXTMATRICULA.ReadOnly = true;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarGrid(); // Llama a tu método consistente para cargar datos
                          // Filtrar el texto para que solo admita letras  


            // Filtrar el texto para que solo admita letras  



        }

        private void BTNELIMINAR_Click(object sender, EventArgs e)
        {

            // PASO 1: VERIFICAR SI HAY UNA FILA SELECCIONADA
            // Esto debe ser lo PRIMERO que haces.
            if (DGVESTUDIANTES.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione el estudiante que desea eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución del método aquí.
            }

            // PASO 2: PEDIR CONFIRMACIÓN AL USUARIO
            // Guardamos el resultado del diálogo en una variable para usarla después.
            DialogResult dialogoResultado = MessageBox.Show("¿Está seguro que desea eliminar este registro? Esta acción es permanente.",
                                                        "Confirmar Eliminación",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

            // PASO 3: VERIFICAR SI EL USUARIO CONFIRMÓ
            if (dialogoResultado == DialogResult.Yes)
            {
                // Solo si el usuario hace clic en "Sí", procedemos a eliminar.
                try
                {
                    // PASO 4: OBTENER LA MATRÍCULA DE LA FILA SELECCIONADA
                    // Aquí es donde creamos la variable que te faltaba.
                    string matriculaParaEliminar = DGVESTUDIANTES.CurrentRow.Cells["Matricula"].Value.ToString();

                    // PASO 5: LLAMAR AL MÉTODO DE NEGOCIO PARA ELIMINAR
                    // Usamos la instancia _estudianteNegocio que ya teníamos en el formulario.
                    MetodoParaEliminaraEstudiante eliminar1 = new MetodoParaEliminaraEstudiante();
                    eliminar1.EliminarEstudiante(matriculaParaEliminar);

                    // PASO 6: ACTUALIZAR EL GRID Y NOTIFICAR AL USUARIO
                    CargarGrid(); // Refrescamos el grid para que el registro desaparezca.
                    MessageBox.Show("Estudiante eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Si el usuario presiona "No", el método simplemente termina y no pasa nada.
        }




        private void CargarGrid()
        {
            try
            {
                var negocio = new MetodoParaObtenerEstudiantesActivos();
                // Esto ahora devolverá List<Estudiante>, que tiene las propiedades Nombres y Apellidos
                var listaEstudiantes = negocio.ObtenerEstudiantesActivos();
                DGVESTUDIANTES.DataSource = null;
                DGVESTUDIANTES.DataSource = listaEstudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            // Asigna una cadena vacía a la propiedad Text de cada TextBox
            TXTMATRICULA.Text = string.Empty; // Usar string.Empty es una buena práctica
            TXTNOMBRE.Text = string.Empty;
            TXTAPELLIDO.Text = string.Empty;

            // Opcional pero muy recomendado:
            // Coloca el cursor (foco) en el primer campo de texto para que el
            // usuario pueda empezar a escribir inmediatamente.
            TXTMATRICULA.Focus();
        }
        private void BTNGUARDAR_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Crear un objeto Estudiante con los datos del formulario
                // (Asumo que tienes TextBoxes llamados txtMatricula, txtNombres, etc.)
                Estudiante estudianteNuevo = new Estudiante
                {
                    Matricula = TXTMATRICULA.Text,
                    Nombres = TXTNOMBRE.Text,
                    Apellidos = TXTAPELLIDO.Text
                    // Activo = true // Asigna el valor que necesites
                };

                if (ValidarFormatoMatricula())
                {
                    // Si la matrícula es válida, procede con la lógica de guardar/procesar
                    MessageBox.Show("Matrícula válida. Procediendo a guardar/procesar.");
                    // 2. Crear una instancia de la clase de negocio
                    MetodoParaGuardarEstudiante logicaDeGuardado = new MetodoParaGuardarEstudiante();

                    // 3. Llamar al método para guardar el estudiante
                    logicaDeGuardado.GuardarEstudiante(estudianteNuevo);

                    // 4. Mostrar un mensaje de éxito
                    MessageBox.Show("¡Estudiante guardado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid(); //Metodo que Actualiza El Datagreview cadaque añaden una persona nueva
                }
                else
                {
                    // La validación falló, el mensaje ya se mostró con ErrorProvider
                    // Puedes poner el foco de nuevo en el campo si quieres
                    TXTMATRICULA.Focus();
                }

            }


            catch (Exception ex)
            {
                // Si algo sale mal (ej: datos vacíos, error de base de datos), muestra el error.
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNNUEVO_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private ErrorProvider errorProviderMatricula = new ErrorProvider(); // Si lo usas

        // Método para validar el formato de la matrícula
        private bool ValidarFormatoMatricula()
        {
            string matricula = TXTMATRICULA.Text.Trim();
            string patronMatricula = @"^[A-Z]{2}\d{4}-\d{4}$";
            Regex regex = new Regex(patronMatricula);

            if (!regex.IsMatch(matricula))
            {
                // Muestra el error con ErrorProvider (más suave que MessageBox)
                errorProviderMatricula.SetError(TXTMATRICULA, "El formato de la matrícula es incorrecto. Debe ser como 'LLAAAA-BBBB' (Ej: RL2024-0453).");
                return false; // Indica que la validación falló
            }
            else
            {
                errorProviderMatricula.SetError(TXTMATRICULA, ""); // Limpia el error
                return true; // Indica que la validación fue exitosa
            }
        }

        private void TXTMATRICULA_Validating(object sender, CancelEventArgs e)
        {
            /*// Obtén el texto del TextBox de la matrícula
            string matricula = TXTMATRICULA.Text.Trim(); // .Trim() para quitar espacios al inicio/final

            // Define la expresión regular para el formato "LLDDDD-DDDD"
            // Explicación de la Regex:
            // ^      : Inicio de la cadena
            // [A-Z]{2}: Exactamente dos letras mayúsculas (RL)
            // \d{4}  : Exactamente cuatro dígitos (2024)
            // -      : Un guion literal
            // \d{4}  : Exactamente cuatro dígitos (0453)
            // $      : Fin de la cadena
            string patronMatricula = @"^[A-Z]{2}\d{4}-\d{4}$";

            // Crea un objeto Regex
            Regex regex = new Regex(patronMatricula);

            // Verifica si la matrícula coincide con el patrón
            if (!regex.IsMatch(matricula))
            {
                // Si no coincide, muestra un mensaje de error
                MessageBox.Show("El formato de la matrícula es incorrecto. Debe ser como 'LLAAAA-BBBB' (Ej: RL2024-0453).",
                                "Formato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Cancela el evento Validating, lo que significa que el foco NO puede salir del TextBox
                // hasta que el formato sea correcto.
                e.Cancel = true;

                // Opcional: selecciona todo el texto para que el usuario pueda corregirlo fácilmente
                TXTMATRICULA.SelectAll();
            }*/
        }

        private void TXTNOMBRE_TextChanged(object sender, EventArgs e)
        {


        }

        private void TXTAPELLIDO_TextChanged(object sender, EventArgs e)
        {


        }



        private void TXTNOMBRE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es una letra, espacio o control (como Backspace)
                MessageBox.Show("Solo se permiten letras y espacios en el campo Nombre.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TXTAPELLIDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter si no es una letra, espacio o control (como Backspace)
                MessageBox.Show("Solo se permiten letras y espacios en el campo Nombre.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TXTMATRICULA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
