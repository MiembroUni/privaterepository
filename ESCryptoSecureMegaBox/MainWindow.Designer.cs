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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MW_Form_Ventana));
            this.MW_Button_Encriptar = new System.Windows.Forms.Button();
            this.MW_Button_Desencriptar = new System.Windows.Forms.Button();
            this.MW_Label_Contraseña = new System.Windows.Forms.Label();
            this.MW_TextBox_Contraseña = new System.Windows.Forms.TextBox();
            this.MW_TreeView_Directorios = new System.Windows.Forms.TreeView();
            this.MW_ImageList_IconosDirectorios = new System.Windows.Forms.ImageList(this.components);
            this.MW_ProgressBar_Completado = new System.Windows.Forms.ProgressBar();
            this.MW_SplitContainer_Explorador = new System.Windows.Forms.SplitContainer();
            this.MW_ListView_Archivos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.MW_SplitContainer_Explorador)).BeginInit();
            this.MW_SplitContainer_Explorador.Panel1.SuspendLayout();
            this.MW_SplitContainer_Explorador.Panel2.SuspendLayout();
            this.MW_SplitContainer_Explorador.SuspendLayout();
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
            this.MW_TextBox_Contraseña.TextChanged += new System.EventHandler(this.MW_TextBox_Contraseña_TextChanged);
            // 
            // MW_TreeView_Directorios
            // 
            this.MW_TreeView_Directorios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MW_TreeView_Directorios.ImageIndex = 0;
            this.MW_TreeView_Directorios.ImageList = this.MW_ImageList_IconosDirectorios;
            this.MW_TreeView_Directorios.Location = new System.Drawing.Point(0, 0);
            this.MW_TreeView_Directorios.Name = "MW_TreeView_Directorios";
            this.MW_TreeView_Directorios.SelectedImageIndex = 0;
            this.MW_TreeView_Directorios.Size = new System.Drawing.Size(116, 262);
            this.MW_TreeView_Directorios.TabIndex = 0;
            this.MW_TreeView_Directorios.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.MW_TreeView_Directorios_NodeMouseClick);
            // 
            // MW_ImageList_IconosDirectorios
            // 
            this.MW_ImageList_IconosDirectorios.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MW_ImageList_IconosDirectorios.ImageStream")));
            this.MW_ImageList_IconosDirectorios.TransparentColor = System.Drawing.Color.Transparent;
            this.MW_ImageList_IconosDirectorios.Images.SetKeyName(0, "stock_lock.png");
            this.MW_ImageList_IconosDirectorios.Images.SetKeyName(1, "stock_lock_open.png");
            // 
            // MW_ProgressBar_Completado
            // 
            this.MW_ProgressBar_Completado.Location = new System.Drawing.Point(153, 226);
            this.MW_ProgressBar_Completado.Name = "MW_ProgressBar_Completado";
            this.MW_ProgressBar_Completado.Size = new System.Drawing.Size(119, 23);
            this.MW_ProgressBar_Completado.TabIndex = 6;
            // 
            // MW_SplitContainer_Explorador
            // 
            this.MW_SplitContainer_Explorador.Dock = System.Windows.Forms.DockStyle.Right;
            this.MW_SplitContainer_Explorador.Location = new System.Drawing.Point(292, 0);
            this.MW_SplitContainer_Explorador.Name = "MW_SplitContainer_Explorador";
            // 
            // MW_SplitContainer_Explorador.Panel1
            // 
            this.MW_SplitContainer_Explorador.Panel1.Controls.Add(this.MW_TreeView_Directorios);
            // 
            // MW_SplitContainer_Explorador.Panel2
            // 
            this.MW_SplitContainer_Explorador.Panel2.Controls.Add(this.MW_ListView_Archivos);
            this.MW_SplitContainer_Explorador.Size = new System.Drawing.Size(348, 262);
            this.MW_SplitContainer_Explorador.SplitterDistance = 116;
            this.MW_SplitContainer_Explorador.TabIndex = 7;
            // 
            // MW_ListView_Archivos
            // 
            this.MW_ListView_Archivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.MW_ListView_Archivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MW_ListView_Archivos.Location = new System.Drawing.Point(0, 0);
            this.MW_ListView_Archivos.Name = "MW_ListView_Archivos";
            this.MW_ListView_Archivos.Size = new System.Drawing.Size(228, 262);
            this.MW_ListView_Archivos.SmallImageList = this.MW_ImageList_IconosDirectorios;
            this.MW_ListView_Archivos.TabIndex = 0;
            this.MW_ListView_Archivos.UseCompatibleStateImageBehavior = false;
            this.MW_ListView_Archivos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nombre";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tipo";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fecha de modificación";
            // 
            // MW_Form_Ventana
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 262);
            this.Controls.Add(this.MW_SplitContainer_Explorador);
            this.Controls.Add(this.MW_ProgressBar_Completado);
            this.Controls.Add(this.MW_TextBox_Contraseña);
            this.Controls.Add(this.MW_Label_Contraseña);
            this.Controls.Add(this.MW_Button_Desencriptar);
            this.Controls.Add(this.MW_Button_Encriptar);
            this.Name = "MW_Form_Ventana";
            this.Text = "Ventana";
            this.MW_SplitContainer_Explorador.Panel1.ResumeLayout(false);
            this.MW_SplitContainer_Explorador.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MW_SplitContainer_Explorador)).EndInit();
            this.MW_SplitContainer_Explorador.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MW_Button_Encriptar;
        private System.Windows.Forms.Button MW_Button_Desencriptar;
        private System.Windows.Forms.Label MW_Label_Contraseña;
        private System.Windows.Forms.TextBox MW_TextBox_Contraseña;
        private System.Windows.Forms.TreeView MW_TreeView_Directorios;
        private System.Windows.Forms.ProgressBar MW_ProgressBar_Completado;
        private System.Windows.Forms.SplitContainer MW_SplitContainer_Explorador;
        private System.Windows.Forms.ImageList MW_ImageList_IconosDirectorios;
        private System.Windows.Forms.ListView MW_ListView_Archivos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

