namespace Ventanas_Finales_Siksi
{
    partial class Form_Listado_Puestos
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
            this.menu_Dep = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Emp = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.tabla_Puestos = new System.Windows.Forms.DataGridView();
            this.btn_Check = new System.Windows.Forms.Button();
            this.cmb_IDDeptos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menu_Nomina = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Puestos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(453, 436);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(152, 29);
            this.btn_Regresar.TabIndex = 23;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btn_MdoEmpleado
            // 
            this.btn_MdoEmpleado.Location = new System.Drawing.Point(453, 471);
            this.btn_MdoEmpleado.Name = "btn_MdoEmpleado";
            this.btn_MdoEmpleado.Size = new System.Drawing.Size(152, 31);
            this.btn_MdoEmpleado.TabIndex = 22;
            this.btn_MdoEmpleado.Text = "Modo empleado";
            this.btn_MdoEmpleado.UseVisualStyleBackColor = true;
            this.btn_MdoEmpleado.Click += new System.EventHandler(this.btn_MdoEmpleado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Lista de puestos registrados:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Dep,
            this.menu_Emp,
            this.menu_Nomina});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(620, 28);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_Dep
            // 
            this.menu_Dep.Name = "menu_Dep";
            this.menu_Dep.Size = new System.Drawing.Size(124, 24);
            this.menu_Dep.Text = "Departamentos";
            this.menu_Dep.Click += new System.EventHandler(this.menu_Dep_Click);
            // 
            // menu_Emp
            // 
            this.menu_Emp.Name = "menu_Emp";
            this.menu_Emp.Size = new System.Drawing.Size(95, 24);
            this.menu_Emp.Text = "Empleados";
            this.menu_Emp.Click += new System.EventHandler(this.menu_Emp_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Agregar.Location = new System.Drawing.Point(313, 61);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(292, 58);
            this.btn_Agregar.TabIndex = 31;
            this.btn_Agregar.Text = "Agregar puesto";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Eliminar.Location = new System.Drawing.Point(15, 93);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(292, 26);
            this.btn_Eliminar.TabIndex = 30;
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
            this.btn_Editar.TabIndex = 29;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // tabla_Puestos
            // 
            this.tabla_Puestos.AllowUserToAddRows = false;
            this.tabla_Puestos.AllowUserToDeleteRows = false;
            this.tabla_Puestos.AllowUserToResizeColumns = false;
            this.tabla_Puestos.AllowUserToResizeRows = false;
            this.tabla_Puestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Puestos.Location = new System.Drawing.Point(15, 223);
            this.tabla_Puestos.MultiSelect = false;
            this.tabla_Puestos.Name = "tabla_Puestos";
            this.tabla_Puestos.ReadOnly = true;
            this.tabla_Puestos.RowHeadersVisible = false;
            this.tabla_Puestos.RowTemplate.Height = 24;
            this.tabla_Puestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Puestos.Size = new System.Drawing.Size(587, 207);
            this.tabla_Puestos.TabIndex = 44;
            this.tabla_Puestos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Puestos_CellClick);
            // 
            // btn_Check
            // 
            this.btn_Check.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Check.Location = new System.Drawing.Point(571, 167);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(31, 25);
            this.btn_Check.TabIndex = 49;
            this.btn_Check.Text = "*";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // cmb_IDDeptos
            // 
            this.cmb_IDDeptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IDDeptos.FormattingEnabled = true;
            this.cmb_IDDeptos.Items.AddRange(new object[] {
            "05",
            "673",
            "892",
            "43",
            "5"});
            this.cmb_IDDeptos.Location = new System.Drawing.Point(212, 168);
            this.cmb_IDDeptos.Name = "cmb_IDDeptos";
            this.cmb_IDDeptos.Size = new System.Drawing.Size(353, 24);
            this.cmb_IDDeptos.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(11, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Seleccione un Departamento:";
            // 
            // menu_Nomina
            // 
            this.menu_Nomina.Name = "menu_Nomina";
            this.menu_Nomina.Size = new System.Drawing.Size(74, 24);
            this.menu_Nomina.Text = "Nomina";
            this.menu_Nomina.Click += new System.EventHandler(this.menu_Nomina_Click);
            // 
            // Form_Listado_Puestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 518);
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.cmb_IDDeptos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabla_Puestos);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_MdoEmpleado);
            this.Controls.Add(this.label1);
            this.Name = "Form_Listado_Puestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Puestos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Listado_Puestos_Closing);
            this.Load += new System.EventHandler(this.Form_Listado_Puestos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Puestos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_MdoEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Dep;
        private System.Windows.Forms.ToolStripMenuItem menu_Emp;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.DataGridView tabla_Puestos;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.ComboBox cmb_IDDeptos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem menu_Nomina;
    }
}