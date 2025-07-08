using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
using WinFormsApp1;


namespace CapaPresentacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private Form FormActivo = null;
        private void AbrirFormulario(Form formularioHijo)
        {
            // 1. Si ya existe un formulario activo, lo cerramos.
            if (FormActivo != null)
            {
                FormActivo.Close();
            }

            // 2. Asignamos el nuevo formulario como el activo y lo configuramos.
            FormActivo = formularioHijo;

            // Propiedad para que no sea un formulario de nivel superior (es decir, puede ser contenido).
            formularioHijo.TopLevel = false;

            // Le quitamos los bordes y la barra de título.
            formularioHijo.FormBorderStyle = FormBorderStyle.None;

            // Hacemos que ocupe todo el espacio del panel que lo contiene.
            formularioHijo.Dock = DockStyle.Fill;

            // 3. Lo agregamos al panel contenedor.
            // (Asegúrate de que tu panel se llame "ContenedorDeFormularios" en las propiedades)
            ContenedorDeFormularios.Controls.Add(formularioHijo);
            ContenedorDeFormularios.Tag = formularioHijo;

            // 4. Lo traemos al frente y lo mostramos.
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTNGESTION_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new RegistroEstudiante());


        }

        private void ContenedorDeFormularios_Paint(object sender, PaintEventArgs e)
        {

        }


        private void BTNREGISTRAR_Click(object sender, EventArgs e)
        {

            AbrirFormulario(new RegistroEvaluacion());

        }

        private void BTNVISUALIZAR_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FiltroEstudiante());
        }

        private void BTNREPORTES_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReporte());
        }

        private void BTNREGISTRAR_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new RegistroEvaluacion());
        }

        private void BTNVISUALIZAR_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FiltroEstudiante());

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        bool sidebarExpand;
        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                // Si el sidebar está expandido, minimízalo gradualmente
                MenuLateral.Width -= 10; // Ajusta este valor para una velocidad diferente

                // Cuando alcance el ancho mínimo, deten el timer y actualiza el estado
                if (MenuLateral.Width == MenuLateral.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                // Si el sidebar está colapsado, expándelo gradualmente
                MenuLateral.Width += 10; // Ajusta este valor para una velocidad diferente

                // Cuando alcance el ancho máximo, deten el timer y actualiza el estado
                if (MenuLateral.Width == MenuLateral.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SidebarTimer.Stop();
                }

            }
        }

        private void CerrarMenuLateral()
        {
            if (sidebarExpand) // Si el menú está expandido (sidebarExpand es true)
            {
                // Establece sidebarExpand en false para que el Timer inicie la contracción
                sidebarExpand = false;
                SidebarTimer.Start(); // Inicia el timer para contraer el menú
            }
            // Si ya está colapsado (sidebarExpand es false), no hacemos nada
        }

        private void MENUBOTON_Click(object sender, EventArgs e)
        {
            SidebarTimer.Start();
        }

        private void BTNREPORTES_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReporte());
            CerrarMenuLateral();
        }

        private void BTNGESTION_Leave(object sender, EventArgs e)
        {

        }

        private void BTNGESTION_MouseLeave(object sender, EventArgs e)
        {
            BTNGESTION.BackColor = Color.Transparent; BTNGESTION.ForeColor = Color.Transparent; //Esto es solamente para diseño


        }

        private void BTNGESTION_MouseClick(object sender, MouseEventArgs e)
        {
            CerrarMenuLateral();
        }

        private void BTNGESTION_Move(object sender, EventArgs e)
        {

        }

        private void BTNGESTION_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void BTNGESTION_MouseEnter(object sender, EventArgs e)
        {
            BTNGESTION.BackColor = Color.FromArgb(43, 49, 58);//Esto es solamente para diseño

        }

        private void BTNREGISTRAR_MouseEnter(object sender, EventArgs e)
        {
            BTNREGISTRAR.BackColor = Color.FromArgb(43, 49, 58);//Esto es solamente para diseño

        }

        private void BTNVISUALIZAR_MouseEnter(object sender, EventArgs e)
        {
            BTNVISUALIZAR.BackColor = Color.FromArgb(43, 49, 58);//Esto es solamente para diseño

        }

        private void BTNREPORTES_MouseEnter(object sender, EventArgs e)
        {
            BTNREPORTES.BackColor = Color.FromArgb(43, 49, 58);//Esto es solamente para diseño

        }

        private void BTNREGISTRAR_MouseLeave(object sender, EventArgs e)
        {
            BTNREGISTRAR.BackColor = Color.Transparent; BTNREGISTRAR.ForeColor = Color.Transparent;//Esto es solamente para diseño
        }

        private void BTNVISUALIZAR_MouseLeave(object sender, EventArgs e)
        {
            BTNVISUALIZAR.BackColor = Color.Transparent; BTNVISUALIZAR.ForeColor = Color.Transparent;//Esto es solamente para diseño
        }

        private void BTNREPORTES_MouseLeave(object sender, EventArgs e)
        {
            BTNREPORTES.BackColor = Color.Transparent; BTNREPORTES.ForeColor = Color.Transparent; //Esto es solamente para diseño
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new RegistroEstudiante());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new RegistroEvaluacion());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FiltroEstudiante());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormReporte());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Paso 1: Preguntar al usuario si realmente quiere cerrar sesión (opcional pero recomendado)
            DialogResult result = MessageBox.Show("¿Estás seguro que quieres cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Paso 2: Crear una nueva instancia del formulario de Login
                Login formLogin = new Login(); // Asume que tu formulario de Login se llama 'Login'

                // Paso 3: Mostrar el formulario de Login
                formLogin.Show();

                // Paso 4: Ocultar o cerrar el formulario actual (Menu)
                // Ocultar el formulario actual:
                this.Close();
                // Cerrar el formulario actual (esto también oculta automáticamente):
            

            }
        }

        private void BTNCERRAR_MouseLeave(object sender, EventArgs e)
        {
            BTNCERRAR.BackColor = Color.Transparent; BTNCERRAR.ForeColor = Color.Transparent;//Esto es solamente para diseño

        }

        private void BTNCERRAR_MouseEnter(object sender, EventArgs e)
        {
            BTNCERRAR.BackColor = Color.FromArgb(43, 49, 58);//Esto es solamente para diseño

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // Paso 1: Preguntar al usuario si realmente quiere cerrar sesión (opcional pero recomendado)
            DialogResult result = MessageBox.Show("¿Estás seguro que quieres cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Paso 2: Crear una nueva instancia del formulario de Login
                Login formLogin = new Login(); // Asume que tu formulario de Login se llama 'Login'

                // Paso 3: Mostrar el formulario de Login
                formLogin.Show();

                // Paso 4: Ocultar o cerrar el formulario actual (Menu)
                // Ocultar el formulario actual:
                this.Close();
                // Cerrar el formulario actual (esto también oculta automáticamente):


            }
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            //pictureBox7.BackColor = Color.FromArgb(43, 49, 58);//Esto es solamente para diseño

        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
           // pictureBox7.BackColor = Color.Transparent; pictureBox7.ForeColor = Color.Transparent;//Esto es solamente para diseño

        }
    }
}
