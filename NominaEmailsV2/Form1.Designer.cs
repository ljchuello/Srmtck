namespace NominaEmailsV2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtRutaDestino = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.lblFaltantes = new MetroFramework.Controls.MetroLabel();
            this.lblTotal = new MetroFramework.Controls.MetroLabel();
            this.lblFallidos = new MetroFramework.Controls.MetroLabel();
            this.lblExitosos = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtRutaOrigen = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtUsuario = new MetroFramework.Controls.MetroTextBox();
            this.chSsl = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtPuertoSalida = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtServidorSalida = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtContrasenia = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCorreo = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 67);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(340, 374);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroLabel7);
            this.metroTabPage1.Controls.Add(this.txtRutaDestino);
            this.metroTabPage1.Controls.Add(this.metroButton1);
            this.metroTabPage1.Controls.Add(this.lblFaltantes);
            this.metroTabPage1.Controls.Add(this.lblTotal);
            this.metroTabPage1.Controls.Add(this.lblFallidos);
            this.metroTabPage1.Controls.Add(this.lblExitosos);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.txtRutaOrigen);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(332, 332);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Principal";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(4, 63);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(81, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Ruta destino";
            // 
            // txtRutaDestino
            // 
            // 
            // 
            // 
            this.txtRutaDestino.CustomButton.Image = null;
            this.txtRutaDestino.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.txtRutaDestino.CustomButton.Name = "";
            this.txtRutaDestino.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRutaDestino.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRutaDestino.CustomButton.TabIndex = 1;
            this.txtRutaDestino.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRutaDestino.CustomButton.UseSelectable = true;
            this.txtRutaDestino.CustomButton.Visible = false;
            this.txtRutaDestino.Lines = new string[0];
            this.txtRutaDestino.Location = new System.Drawing.Point(3, 85);
            this.txtRutaDestino.MaxLength = 32767;
            this.txtRutaDestino.Name = "txtRutaDestino";
            this.txtRutaDestino.PasswordChar = '\0';
            this.txtRutaDestino.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRutaDestino.SelectedText = "";
            this.txtRutaDestino.SelectionLength = 0;
            this.txtRutaDestino.SelectionStart = 0;
            this.txtRutaDestino.ShortcutsEnabled = true;
            this.txtRutaDestino.Size = new System.Drawing.Size(325, 23);
            this.txtRutaDestino.TabIndex = 9;
            this.txtRutaDestino.UseSelectable = true;
            this.txtRutaDestino.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRutaDestino.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(4, 191);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(324, 23);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Enviar";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // lblFaltantes
            // 
            this.lblFaltantes.AutoSize = true;
            this.lblFaltantes.Location = new System.Drawing.Point(4, 168);
            this.lblFaltantes.Name = "lblFaltantes";
            this.lblFaltantes.Size = new System.Drawing.Size(62, 19);
            this.lblFaltantes.TabIndex = 7;
            this.lblFaltantes.Text = "Faltantes:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(4, 149);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(39, 19);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total:";
            // 
            // lblFallidos
            // 
            this.lblFallidos.AutoSize = true;
            this.lblFallidos.Location = new System.Drawing.Point(4, 130);
            this.lblFallidos.Name = "lblFallidos";
            this.lblFallidos.Size = new System.Drawing.Size(55, 19);
            this.lblFallidos.TabIndex = 5;
            this.lblFallidos.Text = "Fallidos:";
            // 
            // lblExitosos
            // 
            this.lblExitosos.AutoSize = true;
            this.lblExitosos.Location = new System.Drawing.Point(3, 111);
            this.lblExitosos.Name = "lblExitosos";
            this.lblExitosos.Size = new System.Drawing.Size(58, 19);
            this.lblExitosos.TabIndex = 4;
            this.lblExitosos.Text = "Exitosos:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(4, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(77, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Ruta origen";
            // 
            // txtRutaOrigen
            // 
            // 
            // 
            // 
            this.txtRutaOrigen.CustomButton.Image = null;
            this.txtRutaOrigen.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.txtRutaOrigen.CustomButton.Name = "";
            this.txtRutaOrigen.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRutaOrigen.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRutaOrigen.CustomButton.TabIndex = 1;
            this.txtRutaOrigen.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRutaOrigen.CustomButton.UseSelectable = true;
            this.txtRutaOrigen.CustomButton.Visible = false;
            this.txtRutaOrigen.Lines = new string[0];
            this.txtRutaOrigen.Location = new System.Drawing.Point(3, 37);
            this.txtRutaOrigen.MaxLength = 32767;
            this.txtRutaOrigen.Name = "txtRutaOrigen";
            this.txtRutaOrigen.PasswordChar = '\0';
            this.txtRutaOrigen.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRutaOrigen.SelectedText = "";
            this.txtRutaOrigen.SelectionLength = 0;
            this.txtRutaOrigen.SelectionStart = 0;
            this.txtRutaOrigen.ShortcutsEnabled = true;
            this.txtRutaOrigen.Size = new System.Drawing.Size(325, 23);
            this.txtRutaOrigen.TabIndex = 2;
            this.txtRutaOrigen.UseSelectable = true;
            this.txtRutaOrigen.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRutaOrigen.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtRutaOrigen.Click += new System.EventHandler(this.txtRuta_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLabel6);
            this.metroTabPage2.Controls.Add(this.txtUsuario);
            this.metroTabPage2.Controls.Add(this.chSsl);
            this.metroTabPage2.Controls.Add(this.metroButton2);
            this.metroTabPage2.Controls.Add(this.metroLabel5);
            this.metroTabPage2.Controls.Add(this.txtPuertoSalida);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.txtServidorSalida);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.txtContrasenia);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.Controls.Add(this.txtCorreo);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(332, 332);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Configuración";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(5, 61);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(53, 19);
            this.metroLabel6.TabIndex = 16;
            this.metroLabel6.Text = "Usuario";
            // 
            // txtUsuario
            // 
            // 
            // 
            // 
            this.txtUsuario.CustomButton.Image = null;
            this.txtUsuario.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.txtUsuario.CustomButton.Name = "";
            this.txtUsuario.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsuario.CustomButton.TabIndex = 1;
            this.txtUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsuario.CustomButton.UseSelectable = true;
            this.txtUsuario.CustomButton.Visible = false;
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(4, 83);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(325, 23);
            this.txtUsuario.TabIndex = 15;
            this.txtUsuario.UseSelectable = true;
            this.txtUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chSsl
            // 
            this.chSsl.AutoSize = true;
            this.chSsl.Location = new System.Drawing.Point(5, 255);
            this.chSsl.Name = "chSsl";
            this.chSsl.Size = new System.Drawing.Size(41, 15);
            this.chSsl.TabIndex = 14;
            this.chSsl.Text = "SSL";
            this.chSsl.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(3, 276);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(324, 23);
            this.metroButton2.TabIndex = 12;
            this.metroButton2.Text = "Probar y Guardar";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(5, 202);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(105, 19);
            this.metroLabel5.TabIndex = 11;
            this.metroLabel5.Text = "Puerto de salida";
            // 
            // txtPuertoSalida
            // 
            // 
            // 
            // 
            this.txtPuertoSalida.CustomButton.Image = null;
            this.txtPuertoSalida.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.txtPuertoSalida.CustomButton.Name = "";
            this.txtPuertoSalida.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPuertoSalida.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPuertoSalida.CustomButton.TabIndex = 1;
            this.txtPuertoSalida.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPuertoSalida.CustomButton.UseSelectable = true;
            this.txtPuertoSalida.CustomButton.Visible = false;
            this.txtPuertoSalida.Lines = new string[0];
            this.txtPuertoSalida.Location = new System.Drawing.Point(4, 224);
            this.txtPuertoSalida.MaxLength = 32767;
            this.txtPuertoSalida.Name = "txtPuertoSalida";
            this.txtPuertoSalida.PasswordChar = '\0';
            this.txtPuertoSalida.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPuertoSalida.SelectedText = "";
            this.txtPuertoSalida.SelectionLength = 0;
            this.txtPuertoSalida.SelectionStart = 0;
            this.txtPuertoSalida.ShortcutsEnabled = true;
            this.txtPuertoSalida.Size = new System.Drawing.Size(325, 23);
            this.txtPuertoSalida.TabIndex = 10;
            this.txtPuertoSalida.UseSelectable = true;
            this.txtPuertoSalida.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPuertoSalida.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(5, 156);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(115, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Servidor de salida";
            // 
            // txtServidorSalida
            // 
            // 
            // 
            // 
            this.txtServidorSalida.CustomButton.Image = null;
            this.txtServidorSalida.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.txtServidorSalida.CustomButton.Name = "";
            this.txtServidorSalida.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtServidorSalida.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtServidorSalida.CustomButton.TabIndex = 1;
            this.txtServidorSalida.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtServidorSalida.CustomButton.UseSelectable = true;
            this.txtServidorSalida.CustomButton.Visible = false;
            this.txtServidorSalida.Lines = new string[0];
            this.txtServidorSalida.Location = new System.Drawing.Point(4, 178);
            this.txtServidorSalida.MaxLength = 32767;
            this.txtServidorSalida.Name = "txtServidorSalida";
            this.txtServidorSalida.PasswordChar = '\0';
            this.txtServidorSalida.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtServidorSalida.SelectedText = "";
            this.txtServidorSalida.SelectionLength = 0;
            this.txtServidorSalida.SelectionStart = 0;
            this.txtServidorSalida.ShortcutsEnabled = true;
            this.txtServidorSalida.Size = new System.Drawing.Size(325, 23);
            this.txtServidorSalida.TabIndex = 8;
            this.txtServidorSalida.UseSelectable = true;
            this.txtServidorSalida.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtServidorSalida.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(5, 110);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(75, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Contraseña";
            // 
            // txtContrasenia
            // 
            // 
            // 
            // 
            this.txtContrasenia.CustomButton.Image = null;
            this.txtContrasenia.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.txtContrasenia.CustomButton.Name = "";
            this.txtContrasenia.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtContrasenia.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContrasenia.CustomButton.TabIndex = 1;
            this.txtContrasenia.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContrasenia.CustomButton.UseSelectable = true;
            this.txtContrasenia.CustomButton.Visible = false;
            this.txtContrasenia.Lines = new string[0];
            this.txtContrasenia.Location = new System.Drawing.Point(4, 132);
            this.txtContrasenia.MaxLength = 32767;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '\0';
            this.txtContrasenia.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContrasenia.SelectedText = "";
            this.txtContrasenia.SelectionLength = 0;
            this.txtContrasenia.SelectionStart = 0;
            this.txtContrasenia.ShortcutsEnabled = true;
            this.txtContrasenia.Size = new System.Drawing.Size(325, 23);
            this.txtContrasenia.TabIndex = 6;
            this.txtContrasenia.UseSelectable = true;
            this.txtContrasenia.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContrasenia.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(5, 15);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(41, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Email";
            // 
            // txtCorreo
            // 
            // 
            // 
            // 
            this.txtCorreo.CustomButton.Image = null;
            this.txtCorreo.CustomButton.Location = new System.Drawing.Point(303, 1);
            this.txtCorreo.CustomButton.Name = "";
            this.txtCorreo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCorreo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCorreo.CustomButton.TabIndex = 1;
            this.txtCorreo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCorreo.CustomButton.UseSelectable = true;
            this.txtCorreo.CustomButton.Visible = false;
            this.txtCorreo.Lines = new string[0];
            this.txtCorreo.Location = new System.Drawing.Point(4, 37);
            this.txtCorreo.MaxLength = 32767;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PasswordChar = '\0';
            this.txtCorreo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCorreo.SelectedText = "";
            this.txtCorreo.SelectionLength = 0;
            this.txtCorreo.SelectionStart = 0;
            this.txtCorreo.ShortcutsEnabled = true;
            this.txtCorreo.Size = new System.Drawing.Size(325, 23);
            this.txtCorreo.TabIndex = 4;
            this.txtCorreo.UseSelectable = true;
            this.txtCorreo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCorreo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "v2021.08.03.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 487);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTextBox txtRutaOrigen;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel lblFaltantes;
        private MetroFramework.Controls.MetroLabel lblTotal;
        private MetroFramework.Controls.MetroLabel lblFallidos;
        private MetroFramework.Controls.MetroLabel lblExitosos;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtPuertoSalida;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtServidorSalida;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtContrasenia;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCorreo;
        private MetroFramework.Controls.MetroCheckBox chSsl;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtUsuario;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox txtRutaDestino;
        private System.Windows.Forms.Label label1;
    }
}

