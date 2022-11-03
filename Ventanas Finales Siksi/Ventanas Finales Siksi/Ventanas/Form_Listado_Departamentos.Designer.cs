namespace Ventanas_Finales_Siksi
{
    partial class Form_Listado_Departamentos
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
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_MdoEmlpeado = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_Pue = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Emp = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.cmb_IDGerente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabla_Departamentos = new System.Windows.Forms.DataGridView();
            this.btn_Check = new System.Windows.Forms.Button();
            this.menu_Nomina = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Departamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Agregar.Location = new System.Drawing.Point(313, 61);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(292, 58);
            this.btn_Agregar.TabIndex = 9;
            this.btn_Agregar.Text = "Agregar departamento";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Eliminar.Location = new System.Drawing.Point(15, 93);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(292, 26);
            this.btn_Eliminar.TabIndex = 8;
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
            this.btn_Editar.TabIndex = 7;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lista de departamentos registrados:";
            // 
            // btn_MdoEmlpeado
            // 
            this.btn_MdoEmlpeado.Location = new System.Drawing.Point(453, 445);
            this.btn_MdoEmlpeado.Name = "btn_MdoEmlpeado";
            this.btn_MdoEmlpeado.Size = new System.Drawing.Size(152, 31);
            this.btn_MdoEmlpeado.TabIndex = 13;
            this.btn_MdoEmlpeado.Text = "Modo empleado";
            this.btn_MdoEmlpeado.UseVisualStyleBackColor = true;
            this.btn_MdoEmlpeado.Click += new System.EventHandler(this.btn_MdoEmlpeado_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Pue,
            this.menu_Emp,
            this.menu_Nomina});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(621, 28);
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
            // menu_Emp
            // 
            this.menu_Emp.Name = "menu_Emp";
            this.menu_Emp.Size = new System.Drawing.Size(95, 24);
            this.menu_Emp.Text = "Empleados";
            this.menu_Emp.Click += new System.EventHandler(this.menu_Emp_Click);
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(453, 410);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(152, 29);
            this.btn_Regresar.TabIndex = 29;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // cmb_IDGerente
            // 
            this.cmb_IDGerente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IDGerente.FormattingEnabled = true;
            this.cmb_IDGerente.Location = new System.Drawing.Point(366, 31);
            this.cmb_IDGerente.Name = "cmb_IDGerente";
            this.cmb_IDGerente.Size = new System.Drawing.Size(202, 24);
            this.cmb_IDGerente.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(296, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "Gerente:";
            // 
            // tabla_Departamentos
            // 
            this.tabla_Departamentos.AllowUserToAddRows = false;
            this.tabla_Departamentos.AllowUserToDeleteRows = false;
            this.tabla_Departamentos.AllowUserToResizeColumns = false;
            this.tabla_Departamentos.AllowUserToResizeRows = false;
            this.tabla_Departamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Departamentos.Location = new System.Drawing.Point(15, 197);
            this.tabla_Departamentos.MultiSelect = false;
            this.tabla_Departamentos.Name = "tabla_Departamentos";
            this.tabla_Departamentos.ReadOnly = true;
            this.tabla_Departamentos.RowHeadersVisible = false;
            this.tabla_Departamentos.RowTemplate.Height = 24;
            this.tabla_Departamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Departamentos.Size = new System.Drawing.Size(590, 207);
            this.tabla_Departamentos.TabIndex = 48;
            this.tabla_Departamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Departamentos_CellClick);
            // 
            // btn_Check
            // 
            this.btn_Check.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Check.Location = new System.Drawing.Point(574, 31);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(31, 24);
            this.btn_Check.TabIndex = 49;
            this.btn_Check.Text = "*";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // menu_Nomina
            // 
            this.menu_Nomina.Name = "menu_Nomina";
            this.menu_Nomina.Size = new System.Drawing.Size(74, 24);
            this.menu_Nomina.Text = "Nomina";
            this.menu_Nomina.Click += new System.EventHandler(this.menu_Nomina_Click);
            // 
            // Form_Listado_Departamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 489);
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.tabla_Departamentos);
            this.Controls.Add(this.cmb_IDGerente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_MdoEmlpeado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Editar);
            this.Name = "Form_Listado_Departamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Departamentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Listado_Departamentos_Closing);
            this.Load += new System.EventHandler(this.Form_Listado_Departamentos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Departamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_MdoEmlpeado;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Pue;
        private System.Windows.Forms.ToolStripMenuItem menu_Emp;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.ComboBox cmb_IDGerente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tabla_Departamentos;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.ToolStripMenuItem menu_Nomina;
    }
}