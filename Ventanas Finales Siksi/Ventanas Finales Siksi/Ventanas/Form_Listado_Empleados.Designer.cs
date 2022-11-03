namespace Ventanas_Finales_Siksi
{
    partial class Form_Listado_Empleados
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
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.btn_MdoEmpleado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_Pue = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Dep = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Nomina = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.tabla_Empleados = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Empleados)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(453, 410);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(152, 29);
            this.btn_Regresar.TabIndex = 35;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btn_MdoEmpleado
            // 
            this.btn_MdoEmpleado.Location = new System.Drawing.Point(453, 445);
            this.btn_MdoEmpleado.Name = "btn_MdoEmpleado";
            this.btn_MdoEmpleado.Size = new System.Drawing.Size(152, 31);
            this.btn_MdoEmpleado.TabIndex = 34;
            this.btn_MdoEmpleado.Text = "Modo empleado";
            this.btn_MdoEmpleado.UseVisualStyleBackColor = true;
            this.btn_MdoEmpleado.Click += new System.EventHandler(this.btn_MdoEmpleado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Lista de empleados registrados:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Pue,
            this.menu_Dep,
            this.menu_Nomina});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(620, 28);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_Pue
            // 
            this.menu_Pue.Name = "menu_Pue";
            this.menu_Pue.Size = new System.Drawing.Size(71, 24);
            this.menu_Pue.Text = "Puestos";
            this.menu_Pue.Click += new System.EventHandler(this.menu_Pue_Click);
            // 
            // menu_Dep
            // 
            this.menu_Dep.Name = "menu_Dep";
            this.menu_Dep.Size = new System.Drawing.Size(124, 24);
            this.menu_Dep.Text = "Departamentos";
            this.menu_Dep.Click += new System.EventHandler(this.menu_Dep_Click);
            // 
            // menu_Nomina
            // 
            this.menu_Nomina.Name = "menu_Nomina";
            this.menu_Nomina.Size = new System.Drawing.Size(74, 24);
            this.menu_Nomina.Text = "Nomina";
            this.menu_Nomina.Click += new System.EventHandler(this.menu_Nomina_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Agregar.Location = new System.Drawing.Point(313, 61);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(292, 58);
            this.btn_Agregar.TabIndex = 39;
            this.btn_Agregar.Text = "Agregar empleado";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Eliminar.Location = new System.Drawing.Point(15, 93);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(292, 26);
            this.btn_Eliminar.TabIndex = 38;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Editar.Location = new System.Drawing.Point(15, 61);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(292, 26);
            this.btn_Editar.TabIndex = 37;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // tabla_Empleados
            // 
            this.tabla_Empleados.AllowUserToAddRows = false;
            this.tabla_Empleados.AllowUserToDeleteRows = false;
            this.tabla_Empleados.AllowUserToResizeColumns = false;
            this.tabla_Empleados.AllowUserToResizeRows = false;
            this.tabla_Empleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Empleados.Location = new System.Drawing.Point(15, 197);
            this.tabla_Empleados.MultiSelect = false;
            this.tabla_Empleados.Name = "tabla_Empleados";
            this.tabla_Empleados.ReadOnly = true;
            this.tabla_Empleados.RowHeadersVisible = false;
            this.tabla_Empleados.RowTemplate.Height = 24;
            this.tabla_Empleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Empleados.Size = new System.Drawing.Size(590, 207);
            this.tabla_Empleados.TabIndex = 44;
            this.tabla_Empleados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Empleados_CellClick);
            // 
            // Form_Listado_Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 487);
            this.Controls.Add(this.tabla_Empleados);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_MdoEmpleado);
            this.Controls.Add(this.label1);
            this.Name = "Form_Listado_Empleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Empleados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Listado_Empleados_Closing);
            this.Load += new System.EventHandler(this.Form_Listado_Empleados_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Empleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_MdoEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Pue;
        private System.Windows.Forms.ToolStripMenuItem menu_Dep;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.DataGridView tabla_Empleados;
        private System.Windows.Forms.ToolStripMenuItem menu_Nomina;
    }
}