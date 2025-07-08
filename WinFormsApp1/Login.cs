using CapaNegocio;
using CapaPresentacion;
using System.Runtime.InteropServices;
using System.Security.Principal;
namespace WinFormsApp1
{
    public partial class Login : Form
    {
        private MetodoParaValidarCredenciales metodoValidarCredenciales = new MetodoParaValidarCredenciales(); // Instancia de la clase MetodoParaValidarCredenciales  

        public Login()
        {
            InitializeComponent();
            TXTCONTRASENA.PasswordChar = '*';
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void TXTUSUARIO_Leave(object sender, EventArgs e)
        {
            if (TXTUSUARIO.Text == "")
            {
                TXTUSUARIO.Text = "USUARIO";
                TXTUSUARIO.ForeColor = Color.LightGray;
            }
        }

        private void TXTUSUARIO_Enter(object sender, EventArgs e)
        {
            if (TXTUSUARIO.Text == "USUARIO")
            {
                TXTUSUARIO.Text = "";
                TXTUSUARIO.ForeColor = Color.LightBlue;
            }
        }

        private void TXTCONTRASENA_Enter(object sender, EventArgs e)
        {
            if (TXTCONTRASENA.Text == "CONTRASE�A")
            {
                TXTCONTRASENA.Text = "";
                TXTCONTRASENA.ForeColor = Color.LightBlue;
                TXTCONTRASENA.UseSystemPasswordChar = true;
            }
        }

        private void TXTCONTRASENA_Leave(object sender, EventArgs e)
        {
            if (TXTCONTRASENA.Text == "")
            {
                TXTCONTRASENA.Text = "CONTRASE�A";
                TXTCONTRASENA.ForeColor = Color.LightGray;
                TXTCONTRASENA.UseSystemPasswordChar = false;
            }
        }

        private void BTNCERRAR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BTNACCEDER_Click(object sender, EventArgs e)
        {
            string usuario = TXTUSUARIO.Text.Trim(); // .Trim() elimina espacios en blanco al inicio/final  
            string contrasena = TXTCONTRASENA.Text; // No .Trim() para la contrase�a, los espacios pueden ser intencionales  

            // Validaci�n de campos vac�os  
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contrase�a.", "Campos Vac�os", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecuci�n  
            }

            // Llamar al m�todo de la capa de negocio para validar las credenciales  
            if (metodoValidarCredenciales.ValidarCredenciales(usuario, contrasena))
            {
                MessageBox.Show("�Bienvenido al sistema!", "Acceso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // *** AQU� ABRES TU FORMULARIO PRINCIPAL / MEN� ***  
                // Reemplaza 'CNPRINCIPAL' con el nombre de tu formulario principal o men�  
                Menu formPrincipal = new Menu();
                formPrincipal.Show(); // Muestra el formulario principal  
                this.Hide(); // Oculta el formulario de login  
                             // Opcional: this.Close(); para cerrar el login form completamente (siempre que formPrincipal no se abra como un di�logo)  
            }
            else
            {
                MessageBox.Show("Usuario o contrase�a incorrectos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTCONTRASENA.Clear(); // Limpia el campo de contrase�a  
                TXTUSUARIO.Focus(); // Vuelve el foco al campo de usuario  
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TXTUSUARIO_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTCONTRASENA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    