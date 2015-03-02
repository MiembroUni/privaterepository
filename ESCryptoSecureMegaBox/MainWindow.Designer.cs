namespace ESCryptoSecureMegaBox
{
    partial class MW_Form_Ventana
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.MW_Button_Encriptar = new System.Windows.Forms.Button();
            this.MW_Button_Desencriptar = new System.Windows.Forms.Button();
            this.MW_Label_Contraseña = new System.Windows.Forms.Label();
            this.MW_TextBox_Contraseña = new System.Windows.Forms.TextBox();
            this.MW_TreeView_Directorios = new System.Windows.Forms.TreeView();
            this.MW_TextBox_Directorio = new System.Windows.Forms.TextBox();
            this.MW_Button_Refresh = new System.Windows.Forms.Button();
            this.MW_ProgressBar_Completado = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // MW_Button_Encriptar
            // 
            this.MW_Button_Encriptar.Location = new System.Drawing.Point(153, 67);
            this.MW_Button_Encriptar.Name = "MW_Button_Encriptar";
            this.MW_Button_Encriptar.Size = new System.Drawing.Size(75, 23);
            this.MW_Button_Encriptar.TabIndex = 3;
            this.MW_Button_Encriptar.Text = "Encriptar";
            this.MW_Button_Encriptar.UseVisualStyleBackColor = true;
            this.MW_Button_Encriptar.Click += new System.EventHandler(this.MW_Button_Encriptar_Click);
            // 
            // MW_Button_Desencriptar
            // 
            this.MW_Button_Desencriptar.Location = new System.Drawing.Point(153, 108);
            this.MW_Button_Desencriptar.Name = "MW_Button_Desencriptar";
            this.MW_Button_Desencriptar.Size = new System.Drawing.Size(75, 23);
            this.MW_Button_Desencriptar.TabIndex = 4;
            this.MW_Button_Desencriptar.Text = "Desencriptar";
            this.MW_Button_Desencriptar.UseVisualStyleBackColor = true;
            this.MW_Button_Desencriptar.Click += new System.EventHandler(this.MW_Button_Desencriptar_Click);
            // 
            // MW_Label_Contraseña
            // 
            this.MW_Label_Contraseña.AutoSize = true;
            this.MW_Label_Contraseña.Location = new System.Drawing.Point(150, 13);
            this.MW_Label_Contraseña.Name = "MW_Label_Contraseña";
            this.MW_Label_Contraseña.Size = new System.Drawing.Size(61, 13);
            this.MW_Label_Contraseña.TabIndex = 2;
            this.MW_Label_Contraseña.Text = "Contraseña";
            // 
            // MW_TextBox_Contraseña
            // 
            this.MW_TextBox_Contraseña.Location = new System.Drawing.Point(153, 29);
            this.MW_TextBox_Contraseña.Name = "MW_TextBox_Contraseña";
            this.MW_TextBox_Contraseña.Size = new System.Drawing.Size(100, 20);
            this.MW_TextBox_Contraseña.TabIndex = 2;
            // 
            // MW_TreeView_Directorios
            // 
            this.MW_TreeView_Directorios.Location = new System.Drawing.Point(13, 67);
            this.MW_TreeView_Directorios.Name = "MW_TreeView_Directorios";
            this.MW_TreeView_Directorios.Size = new System.Drawing.Size(131, 183);
            this.MW_TreeView_Directorios.TabIndex = 0;
            // 
            // MW_TextBox_Directorio
            // 
            this.MW_TextBox_Directorio.Location = new System.Drawing.Point(13, 29);
            this.MW_TextBox_Directorio.Name = "MW_TextBox_Directorio";
            this.MW_TextBox_Directorio.Size = new System.Drawing.Size(102, 20);
            this.MW_TextBox_Directorio.TabIndex = 1;
            this.MW_TextBox_Directorio.Text = "C:\\";
            this.MW_TextBox_Directorio.TextChanged += new System.EventHandler(this.MW_TextBox_Directorio_TextChanged);
            // 
            // MW_Button_Refresh
            // 
            this.MW_Button_Refresh.Location = new System.Drawing.Point(121, 26);
            this.MW_Button_Refresh.Name = "MW_Button_Refresh";
            this.MW_Button_Refresh.Size = new System.Drawing.Size(23, 23);
            this.MW_Button_Refresh.TabIndex = 5;
            this.MW_Button_Refresh.Text = "Refresh";
            this.MW_Button_Refresh.UseVisualStyleBackColor = true;
            this.MW_Button_Refresh.Click += new System.EventHandler(this.MW_Button_Refresh_Click);
            // 
            // MW_ProgressBar_Completado
            // 
            this.MW_ProgressBar_Completado.Location = new System.Drawing.Point(153, 226);
            this.MW_ProgressBar_Completado.Name = "MW_ProgressBar_Completado";
            this.MW_ProgressBar_Completado.Size = new System.Drawing.Size(119, 23);
            this.MW_ProgressBar_Completado.TabIndex = 6;
            // 
            // MW_Form_Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MW_ProgressBar_Completado);
            this.Controls.Add(this.MW_Button_Refresh);
            this.Controls.Add(this.MW_TextBox_Directorio);
            this.Controls.Add(this.MW_TreeView_Directorios);
            this.Controls.Add(this.MW_TextBox_Contraseña);
            this.Controls.Add(this.MW_Label_Contraseña);
            this.Controls.Add(this.MW_Button_Desencriptar);
            this.Controls.Add(this.MW_Button_Encriptar);
            this.Name = "MW_Form_Ventana";
            this.Text = "Ventana";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MW_Button_Encriptar;
        private System.Windows.Forms.Button MW_Button_Desencriptar;
        private System.Windows.Forms.Label MW_Label_Contraseña;
        private System.Windows.Forms.TextBox MW_TextBox_Contraseña;
        private System.Windows.Forms.TreeView MW_TreeView_Directorios;
        private System.Windows.Forms.TextBox MW_TextBox_Directorio;
        private System.Windows.Forms.Button MW_Button_Refresh;
        private System.Windows.Forms.ProgressBar MW_ProgressBar_Completado;
    }
}

