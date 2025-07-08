namespace WinFormsApp1
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            TXTUSUARIO = new TextBox();
            TXTCONTRASENA = new TextBox();
            label1 = new Label();
            BTNACCEDER = new Button();
            BTNCERRAR = new PictureBox();
            btnminimizar = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BTNCERRAR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 529);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(11, 67);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(341, 344);
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // TXTUSUARIO
            // 
            TXTUSUARIO.BackColor = SystemColors.InactiveCaptionText;
            TXTUSUARIO.BorderStyle = BorderStyle.None;
            TXTUSUARIO.ForeColor = SystemColors.WindowFrame;
            TXTUSUARIO.Location = new Point(533, 259);
            TXTUSUARIO.Name = "TXTUSUARIO";
            TXTUSUARIO.Size = new Size(361, 20);
            TXTUSUARIO.TabIndex = 1;
            TXTUSUARIO.Text = "USUARIO";
            TXTUSUARIO.TextChanged += TXTUSUARIO_TextChanged;
            TXTUSUARIO.Enter += TXTUSUARIO_Enter;
            TXTUSUARIO.Leave += TXTUSUARIO_Leave;
            // 
            // TXTCONTRASENA
            // 
            TXTCONTRASENA.BackColor = SystemColors.InactiveCaptionText;
            TXTCONTRASENA.BorderStyle = BorderStyle.None;
            TXTCONTRASENA.ForeColor = SystemColors.WindowFrame;
            TXTCONTRASENA.Location = new Point(533, 336);
            TXTCONTRASENA.Name = "TXTCONTRASENA";
            TXTCONTRASENA.Size = new Size(361, 20);
            TXTCONTRASENA.TabIndex = 2;
            TXTCONTRASENA.Text = "CONTRASEÑA";
            TXTCONTRASENA.TextChanged += TXTCONTRASENA_TextChanged;
            TXTCONTRASENA.Enter += TXTCONTRASENA_Enter;
            TXTCONTRASENA.Leave += TXTCONTRASENA_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.MenuText;
            label1.ForeColor = SystemColors.ControlDark;
            label1.Location = new Point(782, 39);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 3;
            label1.Text = "LOGIN";
            // 
            // BTNACCEDER
            // 
            BTNACCEDER.BackColor = SystemColors.MenuText;
            BTNACCEDER.ForeColor = SystemColors.ActiveBorder;
            BTNACCEDER.Location = new Point(533, 389);
            BTNACCEDER.Name = "BTNACCEDER";
            BTNACCEDER.Size = new Size(551, 53);
            BTNACCEDER.TabIndex = 4;
            BTNACCEDER.Text = "ACEDER";
            BTNACCEDER.UseVisualStyleBackColor = false;
            BTNACCEDER.Click += BTNACCEDER_Click;
            // 
            // BTNCERRAR
            // 
            BTNCERRAR.Image = (Image)resources.GetObject("BTNCERRAR.Image");
            BTNCERRAR.Location = new Point(1177, 25);
            BTNCERRAR.Name = "BTNCERRAR";
            BTNCERRAR.Size = new Size(25, 35);
            BTNCERRAR.SizeMode = PictureBoxSizeMode.Zoom;
            BTNCERRAR.TabIndex = 6;
            BTNCERRAR.TabStop = false;
            BTNCERRAR.Click += BTNCERRAR_Click;
            // 
            // btnminimizar
            // 
            btnminimizar.Image = (Image)resources.GetObject("btnminimizar.Image");
            btnminimizar.Location = new Point(1110, 25);
            btnminimizar.Name = "btnminimizar";
            btnminimizar.Size = new Size(25, 35);
            btnminimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnminimizar.TabIndex = 7;
            btnminimizar.TabStop = false;
            btnminimizar.Click += btnminimizar_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1235, 529);
            Controls.Add(btnminimizar);
            Controls.Add(BTNCERRAR);
            Controls.Add(BTNACCEDER);
            Controls.Add(label1);
            Controls.Add(TXTCONTRASENA);
            Controls.Add(TXTUSUARIO);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += Form1_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)BTNCERRAR).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox TXTUSUARIO;
        private TextBox TXTCONTRASENA;
        private Label label1;
        private Button BTNACCEDER;
        private PictureBox BTNCERRAR;
        private PictureBox pictureBox3;
        private PictureBox btnminimizar;
    }
}
