namespace Ventanas_Finales_Siksi
{
    partial class Form_Listado_Empresas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Listado_Empresas));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Propiedades = new System.Windows.Forms.Button();
            this.btn_Reportes = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.tabla_Empresas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_IDGerente = new System.Windows.Forms.ComboBox();
            this.btn_Check = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Empresas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Name = "label1";
            // 
            // btn_Propiedades
            // 
            resources.ApplyResources(this.btn_Propiedades, "btn_Propiedades");
            this.btn_Propiedades.Name = "btn_Propiedades";
            this.btn_Propiedades.UseVisualStyleBackColor = true;
            this.btn_Propiedades.Click += new System.EventHandler(this.btn_Propiedades_Click);
            // 
            // btn_Reportes
            // 
            resources.ApplyResources(this.btn_Reportes, "btn_Reportes");
            this.btn_Reportes.Name = "btn_Reportes";
            this.btn_Reportes.UseVisualStyleBackColor = true;
            this.btn_Reportes.Click += new System.EventHandler(this.btn_Reportes_Click);
            // 
            // btn_Agregar
            // 
            resources.ApplyResources(this.btn_Agregar, "btn_Agregar");
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click_1);
            // 
            // btn_Eliminar
            // 
            resources.ApplyResources(this.btn_Eliminar, "btn_Eliminar");
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click_1);
            // 
            // btn_Editar
            // 
            resources.ApplyResources(this.btn_Editar, "btn_Editar");
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // tabla_Empresas
            // 
            this.tabla_Empresas.AllowUserToAddRows = false;
            this.tabla_Empresas.AllowUserToDeleteRows = false;
            this.tabla_Empresas.AllowUserToResizeColumns = false;
            this.tabla_Empresas.AllowUserToResizeRows = false;
            this.tabla_Empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.tabla_Empresas, "tabla_Empresas");
            this.tabla_Empresas.MultiSelect = false;
            this.tabla_Empresas.Name = "tabla_Empresas";
            this.tabla_Empresas.ReadOnly = true;
            this.tabla_Empresas.RowHeadersVisible = false;
            this.tabla_Empresas.RowTemplate.Height = 24;
            this.tabla_Empresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Empresas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Empresas_CellClick);
            this.tabla_Empresas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Empresas_CellContentClick);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmb_IDGerente
            // 
            this.cmb_IDGerente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IDGerente.FormattingEnabled = true;
            this.cmb_IDGerente.Items.AddRange(new object[] {
            resources.GetString("cmb_IDGerente.Items"),
            resources.GetString("cmb_IDGerente.Items1"),
            resources.GetString("cmb_IDGerente.Items2"),
            resources.GetString("cmb_IDGerente.Items3"),
            resources.GetString("cmb_IDGerente.Items4")});
            resources.ApplyResources(this.cmb_IDGerente, "cmb_IDGerente");
            this.cmb_IDGerente.Name = "cmb_IDGerente";
            // 
            // btn_Check
            // 
            resources.ApplyResources(this.btn_Check, "btn_Check");
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // Form_Listado_Empresas
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.cmb_IDGerente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabla_Empresas);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Reportes);
            this.Controls.Add(this.btn_Propiedades);
            this.Controls.Add(this.label1);
            this.Name = "Form_Listado_Empresas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dlg_Principal_Closing);
            this.Load += new System.EventHandler(this.Dlg_Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Empresas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Propiedades;
        private System.Windows.Forms.Button btn_Reportes;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.DataGridView tabla_Empresas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_IDGerente;
        private System.Windows.Forms.Button btn_Check;
    }
}