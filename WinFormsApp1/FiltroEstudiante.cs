using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio; // Assuming this namespace contains your business logic methods and model classes

namespace CapaPresentacion
{
    public partial class FiltroEstudiante : Form
    {
        // Instances of your business logic classes
        private MetodoParaObtenerEstudiantesActivos metodoparaobtenerEstudiantesActivos = new MetodoParaObtenerEstudiantesActivos();
        private MetodoParaObtenerEvaluaciones metodoparaobtenerevaluaciones = new MetodoParaObtenerEvaluaciones();
        // This seems to be your update method, ensure it actually updates
        private MetodoparaActualizarCalificacion metodoparaactualizarcalificaciones = new MetodoparaActualizarCalificacion();
        private MetodoParaEliminarEvaluacion metodoparaeliminarevaluaciones = new MetodoParaEliminarEvaluacion();

        public FiltroEstudiante()
        {
            InitializeComponent();

            // Initial DataGridView setup (these are good)
            DVGEVALUACIONES.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DVGEVALUACIONES.AllowUserToAddRows = false;
            DVGEVALUACIONES.AllowUserToDeleteRows = false;
            DVGEVALUACIONES.MultiSelect = false; // Only allow one row to be selected at a time

            // *** IMPORTANT: Remove the conflicting ReadOnly = false here or the call to ConfigurarDataGridViewNoEditable() below.
            // We will set ReadOnly = false on the main DGV in ConfigurarDataGridView() and then explicitly for columns.

            // *** AÑADE ESTA LÍNEA PARA ASOCIAR EL EVENTO MANUALMENTE (esto ya estaba, es correcto) ***
            DVGEVALUACIONES.CellEndEdit += DVGEVALUACIONES_CellEndEdit;
            // Also subscribe CellBeginEdit if you want to control which cells are editable on manual clicks
            DVGEVALUACIONES.CellBeginEdit += DVGEVALUACIONES_CellBeginEdit;

            // Configure ComboBox DropDownStyle (this is correct)
            if (this.CBFILTROMATERIA != null)
            {
                this.CBFILTROMATERIA.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (this.CBFILTROESTUDIANTE != null)
            {
                this.CBFILTROESTUDIANTE.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            // Call the refined configuration method for DataGridView
            ConfigurarDataGridView(); // Renombrado de 'ConfigurarDataGridViewNoEditable'
        }

        // Renombrado y ajustado este método para la configuración general del DataGridView
        private void ConfigurarDataGridView()
        {
            // ¡CRÍTICO! El DataGridView DEBE ser no-read-only a nivel global para que cualquier celda sea editable.
            DVGEVALUACIONES.ReadOnly = false;

            // Estas ya estaban en el constructor y son correctas para evitar añadir/eliminar por el usuario
            DVGEVALUACIONES.AllowUserToAddRows = false;
            DVGEVALUACIONES.AllowUserToDeleteRows = false;

            // Otras propiedades opcionales que tenías
            DVGEVALUACIONES.AllowUserToResizeColumns = true;
            DVGEVALUACIONES.AllowUserToResizeRows = false;
            DVGEVALUACIONES.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DVGEVALUACIONES.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DVGEVALUACIONES.MultiSelect = false;

            // Keep EditProgrammatically so the "Editar" button explicitly triggers editing.
            DVGEVALUACIONES.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            RefrescarGrid();
        }

        private void CargarFiltros()
        {
            // Cargar estudiantes
            CBFILTROESTUDIANTE.DataSource = metodoparaobtenerEstudiantesActivos.ObtenerEstudiantesActivos();
            CBFILTROESTUDIANTE.DisplayMember = "Nombres"; // Asumo que Estudiante tiene Nombres, o NombreCompleto si lo generas
            CBFILTROESTUDIANTE.ValueMember = "Matricula";
            CBFILTROESTUDIANTE.SelectedIndex = -1;

            // Cargar materias
            CBFILTROMATERIA.Items.Clear(); // Limpia antes de añadir para evitar duplicados
            CBFILTROMATERIA.Items.AddRange(new object[] { "Matemáticas", "Lengua Española", "Sociales", "Naturales" });
            CBFILTROMATERIA.SelectedIndex = -1;
        }

        private void RefrescarGrid()
        {
            string matricula = CBFILTROESTUDIANTE.SelectedValue?.ToString();
            string materia = CBFILTROMATERIA.SelectedItem?.ToString();
            DateTime? fechaDesde = DTPFECHADESDE.Checked ? DTPFECHADESDE.Value : (DateTime?)null;
            DateTime? fechaHasta = DTPFECHAHASTA.Checked ? DTPFECHAHASTA.Value : (DateTime?)null;

            DVGEVALUACIONES.DataSource = metodoparaobtenerevaluaciones.ObtenerEvaluaciones(matricula, materia, fechaDesde, fechaHasta);

            // OCULTAR COLUMNAS (¡Hazlo después de asignar el DataSource!)
            if (DVGEVALUACIONES.Columns.Contains("IDEvaluacion"))
            {
                DVGEVALUACIONES.Columns["IDEvaluacion"].Visible = false;
            }
            // Oculta otras columnas que no quieres que se vean si existen en tu objeto de Evaluación
            // if (DVGEVALUACIONES.Columns.Contains("MatriculaEstudiante")) // Podrías ocultarla si ya tienes el nombre del estudiante
            // {
            //     DVGEVALUACIONES.Columns["MatriculaEstudiante"].Visible = false;
            // }


            // Configurar la propiedad ReadOnly de CADA COLUMNA después de que se cargan los datos
            // Esto es CRÍTICO y debe hacerse cada vez que recargas el DataSource si las columnas no están definidas manualmente.
            foreach (DataGridViewColumn column in DVGEVALUACIONES.Columns)
            {
                // Por defecto, todas las columnas serán de solo lectura...
                column.ReadOnly = true;

                // ...EXCEPTO la columna "Calificacion" (asegúrate que el nombre coincide con tu modelo/consulta)
                if (column.Name == "Calificacion") // Usa el nombre de la propiedad en tu objeto de modelo
                {
                    column.ReadOnly = false; // Hace la columna de Calificación editable
                }
            }

            DVGEVALUACIONES.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // *** IMPORTANTE: Controla qué celdas pueden ser editadas cuando se intenta iniciar la edición
        private void DVGEVALUACIONES_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Solo permite editar si la columna es "Calificacion"
            if (DVGEVALUACIONES.Columns[e.ColumnIndex].Name != "Calificacion")
            {
                e.Cancel = true; // Cancela la edición para cualquier otra columna
            }
            // Puedes agregar más lógica aquí, por ejemplo, si la calificación ya está finalizada, etc.
        }

        // Este es el evento que se dispara cuando terminas de editar una celda.
        private void DVGEVALUACIONES_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si la columna editada es "Calificacion"
            if (DVGEVALUACIONES.Columns[e.ColumnIndex].Name == "Calificacion")
            {
                try
                {
                    // Obtener el ID de la evaluación y la nueva calificación
                    int idEvaluacion = Convert.ToInt32(DVGEVALUACIONES.Rows[e.RowIndex].Cells["IDEvaluacion"].Value); // Asumiendo que IDEvaluacion contiene el ID

                    decimal newGrade;
                    // Intenta parsear el nuevo valor de la celda a decimal
                    if (decimal.TryParse(DVGEVALUACIONES.Rows[e.RowIndex].Cells["Calificacion"].Value?.ToString(), out newGrade))
                    {
                        // **Validación Adicional:** Asegúrate de que la calificación esté en un rango válido (ej. 0-100)
                        if (newGrade >= 0 && newGrade <= 100) // Ajusta tu rango de calificación según sea necesario
                        {
                            bool success = metodoparaactualizarcalificaciones.ActualizarCalificacion(idEvaluacion, newGrade);

                            if (success)
                            {
                                MessageBox.Show("Calificación actualizada correctamente en la base de datos.");
                                // Opcional: Refrescar solo la fila o el grid si es necesario para sincronización visual
                                // RefrescarGrid(); // Esto podría causar que la celda pierda el foco de edición, úsalo con cuidado.
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar la calificación en la base de datos.");
                                // Opcional: Revertir el valor de la celda a su estado original si la actualización falla
                                // Para ello, necesitarías almacenar el valor original antes de editar.
                            }
                        }
                        else
                        {
                            MessageBox.Show("La calificación debe ser un valor entre 0 y 100.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Revertir el valor de la celda al original si no es válido
                            // Esto es más complejo sin almacenar el valor original.
                            // Por ahora, simplemente no actualizamos y dejamos el mensaje.
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato de calificación inválido. Por favor, ingrese un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Revertir el valor de la celda al original
                        // Puedes usar selectedRow.Cells["Calificacion"].Value = oldValue; si lo guardas.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Se produjo un error al guardar la calificación: {ex.Message}", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Puedes re-lanzar la excepción o manejarla apropiadamente.
                }
            }
        }

        // Evento de clic para el botón "Aplicar Filtros"
        private void BTNAPLICARFILTROS_Click(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        // Evento de clic para el botón "Limpiar Filtros"
        private void BTNLIMPIARFILTRO_Click(object sender, EventArgs e)
        {
            CBFILTROESTUDIANTE.SelectedIndex = -1;
            CBFILTROMATERIA.SelectedIndex = -1;
            DTPFECHADESDE.Checked = false;
            DTPFECHAHASTA.Checked = false;
            RefrescarGrid();
        }

        // Evento de clic para el botón "Editar"
        private void BTNEDITAR_Click(object sender, EventArgs e)
        {
            if (DVGEVALUACIONES.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DVGEVALUACIONES.SelectedRows[0];

                // Obtener el índice de la columna "Calificacion"
                int calificacionColumnIndex = -1;
                if (DVGEVALUACIONES.Columns.Contains("Calificacion"))
                {
                    calificacionColumnIndex = DVGEVALUACIONES.Columns["Calificacion"].Index;
                }

                if (calificacionColumnIndex != -1)
                {
                    // Asegurarse de que la celda no esté marcada como ReadOnly (aunque ya se configura en RefrescarGrid)
                    selectedRow.Cells["Calificacion"].ReadOnly = false;

                    // Poner el foco en la celda y entrar en modo de edición
                    DVGEVALUACIONES.CurrentCell = selectedRow.Cells[calificacionColumnIndex];
                    DVGEVALUACIONES.BeginEdit(true);

                    // Opcional: Deshabilitar el botón "Editar" mientras una celda está en edición
                    // BTNEDITAR.Enabled = false;
                }
                else
                {
                    MessageBox.Show("La columna 'Calificacion' no se encontró en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BTNELIMINAR_Click_1(object sender, EventArgs e) // Asumo que este es el evento del botón Eliminar
        {
            if (DVGEVALUACIONES.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DVGEVALUACIONES.SelectedRows[0];
                int idEvaluacion = Convert.ToInt32(selectedRow.Cells["IDEvaluacion"].Value);

                DialogResult confirmacion = MessageBox.Show(
                    "¿Está seguro que desea eliminar la evaluación seleccionada?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        bool success = metodoparaeliminarevaluaciones.EliminarEvaluacion(idEvaluacion);

                        if (success)
                        {
                            MessageBox.Show("Evaluación eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefrescarGrid(); // Vuelve a cargar el DataGridView para reflejar el cambio
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la evaluación. Verifique la conexión o el ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al intentar eliminar la evaluación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una evaluación para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Otros eventos que tenías, como CellContentClick, SelectedIndexChanged, etc.
        // No es necesario modificar estos si ya funcionan como deseas.
        private void DVGEVALUACIONES_CellContentClick(object sender, DataGridViewCellEventArgs e) { /* No necesitas código aquí a menos que quieras alguna acción específica al hacer clic en el contenido de la celda */ }
        private void CBFILTROESTUDIANTE_SelectedIndexChanged(object sender, EventArgs e) { /* Puedes llamar a RefrescarGrid(); aquí si quieres que el filtro se aplique al cambiar el estudiante */ }
        private void BTNELIMINAR_Click(object sender, EventArgs e) { /* Este parece un duplicado del BTNELIMINAR_Click_1, elimina uno. */ }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}