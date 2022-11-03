namespace Ventanas_Finales_Siksi.Ventanas
{
    partial class Form_Nomina_PerDed
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
            this.cmb_Empleados = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabla_Percepciones = new System.Windows.Forms.DataGridView();
            this.tabla_Deducciones = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_Percepciones = new System.Windows.Forms.ComboBox();
            this.cmb_Deducciones = new System.Windows.Forms.ComboBox();
            this.btn_Agregar_Percep = new System.Windows.Forms.Button();
            this.btn_Agregar_Dedu = new System.Windows.Forms.Button();
            this.btn_Eliminar_Percep = new System.Windows.Forms.Button();
            this.btn_Eliminar_Dedu = new System.Windows.Forms.Button();
            this.btn_Calcu_Nomina = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Check = new System.Windows.Forms.Button();
            this.btn_Admin = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_frecuencia = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Percepciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Deducciones)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(710, 605);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(268, 32);
            this.btn_Regresar.TabIndex = 0;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // cmb_Empleados
            // 
            this.cmb_Empleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Empleados.FormattingEnabled = true;
            this.cmb_Empleados.Location = new System.Drawing.Point(97, 12);
            this.cmb_Empleados.Name = "cmb_Empleados";
            this.cmb_Empleados.Size = new System.Drawing.Size(230, 24);
            this.cmb_Empleados.TabIndex = 1;
            this.cmb_Empleados.SelectedIndexChanged += new System.EventHandler(this.cmb_Empleados_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Empleado:";
            // 
            // tabla_Percepciones
            // 
            this.tabla_Percepciones.AllowUserToAddRows = false;
            this.tabla_Percepciones.AllowUserToDeleteRows = false;
            this.tabla_Percepciones.AllowUserToResizeColumns = false;
            this.tabla_Percepciones.AllowUserToResizeRows = false;
            this.tabla_Percepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Percepciones.Location = new System.Drawing.Point(275, 120);
            this.tabla_Percepciones.MultiSelect = false;
            this.tabla_Percepciones.Name = "tabla_Percepciones";
            this.tabla_Percepciones.ReadOnly = true;
            this.tabla_Percepciones.RowHeadersVisible = false;
            this.tabla_Percepciones.RowTemplate.Height = 24;
            this.tabla_Percepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Percepciones.Size = new System.Drawing.Size(402, 207);
            this.tabla_Percepciones.TabIndex = 49;
            this.tabla_Percepciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Percepciones_CellClick);
            // 
            // tabla_Deducciones
            // 
            this.tabla_Deducciones.AllowUserToAddRows = false;
            this.tabla_Deducciones.AllowUserToDeleteRows = false;
            this.tabla_Deducciones.AllowUserToResizeColumns = false;
            this.tabla_Deducciones.AllowUserToResizeRows = false;
            this.tabla_Deducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Deducciones.Location = new System.Drawing.Point(275, 430);
            this.tabla_Deducciones.MultiSelect = false;
            this.tabla_Deducciones.Name = "tabla_Deducciones";
            this.tabla_Deducciones.ReadOnly = true;
            this.tabla_Deducciones.RowHeadersVisible = false;
            this.tabla_Deducciones.RowTemplate.Height = 24;
            this.tabla_Deducciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Deducciones.Size = new System.Drawing.Size(402, 207);
            this.tabla_Deducciones.TabIndex = 50;
            this.tabla_Deducciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Deducciones_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Percepciones:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 52;
            this.label3.Text = "Deducciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 17);
            this.label4.TabIndex = 53;
            this.label4.Text = "AGREGAR PERCEPCION:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 17);
            this.label5.TabIndex = 54;
            this.label5.Text = "AGREGAR DEDUCCION:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Motivo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 430);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "Motivo:";
            // 
            // cmb_Percepciones
            // 
            this.cmb_Percepciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Percepciones.Enabled = false;
            this.cmb_Percepciones.FormattingEnabled = true;
            this.cmb_Percepciones.Location = new System.Drawing.Point(19, 141);
            this.cmb_Percepciones.Name = "cmb_Percepciones";
            this.cmb_Percepciones.Size = new System.Drawing.Size(212, 24);
            this.cmb_Percepciones.TabIndex = 57;
            this.cmb_Percepciones.SelectedIndexChanged += new System.EventHandler(this.cmb_Percepciones_SelectedIndexChanged);
            // 
            // cmb_Deducciones
            // 
            this.cmb_Deducciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Deducciones.Enabled = false;
            this.cmb_Deducciones.FormattingEnabled = true;
            this.cmb_Deducciones.Location = new System.Drawing.Point(19, 451);
            this.cmb_Deducciones.Name = "cmb_Deducciones";
            this.cmb_Deducciones.Size = new System.Drawing.Size(212, 24);
            this.cmb_Deducciones.TabIndex = 58;
            this.cmb_Deducciones.SelectedIndexChanged += new System.EventHandler(this.cmb_Deducciones_SelectedIndexChanged);
            // 
            // btn_Agregar_Percep
            // 
            this.btn_Agregar_Percep.Enabled = false;
            this.btn_Agregar_Percep.Location = new System.Drawing.Point(19, 236);
            this.btn_Agregar_Percep.Name = "btn_Agregar_Percep";
            this.btn_Agregar_Percep.Size = new System.Drawing.Size(212, 52);
            this.btn_Agregar_Percep.TabIndex = 59;
            this.btn_Agregar_Percep.Text = "Agregar";
            this.btn_Agregar_Percep.UseVisualStyleBackColor = true;
            this.btn_Agregar_Percep.Click += new System.EventHandler(this.btn_Agregar_Percep_Click);
            // 
            // btn_Agregar_Dedu
            // 
            this.btn_Agregar_Dedu.Enabled = false;
            this.btn_Agregar_Dedu.Location = new System.Drawing.Point(19, 545);
            this.btn_Agregar_Dedu.Name = "btn_Agregar_Dedu";
            this.btn_Agregar_Dedu.Size = new System.Drawing.Size(212, 52);
            this.btn_Agregar_Dedu.TabIndex = 60;
            this.btn_Agregar_Dedu.Text = "Agregar";
            this.btn_Agregar_Dedu.UseVisualStyleBackColor = true;
            this.btn_Agregar_Dedu.Click += new System.EventHandler(this.btn_Agregar_Dedu_Click);
            // 
            // btn_Eliminar_Percep
            // 
            this.btn_Eliminar_Percep.Enabled = false;
            this.btn_Eliminar_Percep.Location = new System.Drawing.Point(19, 294);
            this.btn_Eliminar_Percep.Name = "btn_Eliminar_Percep";
            this.btn_Eliminar_Percep.Size = new System.Drawing.Size(212, 33);
            this.btn_Eliminar_Percep.TabIndex = 62;
            this.btn_Eliminar_Percep.Text = "Eliminar";
            this.btn_Eliminar_Percep.UseVisualStyleBackColor = true;
            this.btn_Eliminar_Percep.Click += new System.EventHandler(this.btn_Eliminar_Percep_Click);
            // 
            // btn_Eliminar_Dedu
            // 
            this.btn_Eliminar_Dedu.Enabled = false;
            this.btn_Eliminar_Dedu.Location = new System.Drawing.Point(19, 603);
            this.btn_Eliminar_Dedu.Name = "btn_Eliminar_Dedu";
            this.btn_Eliminar_Dedu.Size = new System.Drawing.Size(212, 33);
            this.btn_Eliminar_Dedu.TabIndex = 64;
            this.btn_Eliminar_Dedu.Text = "Eliminar";
            this.btn_Eliminar_Dedu.UseVisualStyleBackColor = true;
            this.btn_Eliminar_Dedu.Click += new System.EventHandler(this.btn_Eliminar_Dedu_Click);
            // 
            // btn_Calcu_Nomina
            // 
            this.btn_Calcu_Nomina.Location = new System.Drawing.Point(710, 236);
            this.btn_Calcu_Nomina.Name = "btn_Calcu_Nomina";
            this.btn_Calcu_Nomina.Size = new System.Drawing.Size(268, 361);
            this.btn_Calcu_Nomina.TabIndex = 65;
            this.btn_Calcu_Nomina.Text = "CALCULAR NOMINA DE EMPRESA";
            this.btn_Calcu_Nomina.UseVisualStyleBackColor = true;
            this.btn_Calcu_Nomina.Click += new System.EventHandler(this.btn_Calcu_Nomina_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 365);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(643, 17);
            this.label8.TabIndex = 66;
            this.label8.Text = "---------------------------------------------------------------------------------" +
    "----------------------------------------------";
            // 
            // btn_Check
            // 
            this.btn_Check.Location = new System.Drawing.Point(334, 12);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(39, 23);
            this.btn_Check.TabIndex = 67;
            this.btn_Check.Text = "***";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // btn_Admin
            // 
            this.btn_Admin.Location = new System.Drawing.Point(710, 12);
            this.btn_Admin.Name = "btn_Admin";
            this.btn_Admin.Size = new System.Drawing.Size(268, 79);
            this.btn_Admin.TabIndex = 74;
            this.btn_Admin.Text = "Administrar Percepciones y deducciones";
            this.btn_Admin.UseVisualStyleBackColor = true;
            this.btn_Admin.Click += new System.EventHandler(this.btn_Admin_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(710, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 17);
            this.label9.TabIndex = 75;
            this.label9.Text = "Selecciona una frecuencia";
            this.label9.Visible = false;
            // 
            // cmb_frecuencia
            // 
            this.cmb_frecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_frecuencia.FormattingEnabled = true;
            this.cmb_frecuencia.Location = new System.Drawing.Point(713, 141);
            this.cmb_frecuencia.Name = "cmb_frecuencia";
            this.cmb_frecuencia.Size = new System.Drawing.Size(265, 24);
            this.cmb_frecuencia.TabIndex = 76;
            this.cmb_frecuencia.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(713, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 77;
            this.label10.Text = "Hora Actual:";
            this.label10.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(713, 193);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 78;
            this.dateTimePicker1.Visible = false;
            // 
            // Form_Nomina_PerDed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 647);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmb_frecuencia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Admin);
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_Calcu_Nomina);
            this.Controls.Add(this.btn_Eliminar_Dedu);
            this.Controls.Add(this.btn_Eliminar_Percep);
            this.Controls.Add(this.btn_Agregar_Dedu);
            this.Controls.Add(this.btn_Agregar_Percep);
            this.Controls.Add(this.cmb_Deducciones);
            this.Controls.Add(this.cmb_Percepciones);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabla_Deducciones);
            this.Controls.Add(this.tabla_Percepciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_Empleados);
            this.Controls.Add(this.btn_Regresar);
            this.Name = "Form_Nomina_PerDed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nomina";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Nomina_PerDed_Closing);
            this.Load += new System.EventHandler(this.Form_Nomina_PerDed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Percepciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Deducciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.ComboBox cmb_Empleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tabla_Percepciones;
        private System.Windows.Forms.DataGridView tabla_Deducciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_Percepciones;
        private System.Windows.Forms.ComboBox cmb_Deducciones;
        private System.Windows.Forms.Button btn_Agregar_Percep;
        private System.Windows.Forms.Button btn_Agregar_Dedu;
        private System.Windows.Forms.Button btn_Eliminar_Percep;
        private System.Windows.Forms.Button btn_Eliminar_Dedu;
        private System.Windows.Forms.Button btn_Calcu_Nomina;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Button btn_Admin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_frecuencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}