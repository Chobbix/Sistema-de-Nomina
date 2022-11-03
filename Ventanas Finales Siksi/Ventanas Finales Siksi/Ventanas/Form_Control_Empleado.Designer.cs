namespace Ventanas_Finales_Siksi
{
    partial class Form_Control_Empleado
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
            this.btn_Nomina = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Incidencia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Dias = new System.Windows.Forms.ComboBox();
            this.Percepciones = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.tabla_Percepciones = new System.Windows.Forms.DataGridView();
            this.tabla_Deducciones = new System.Windows.Forms.DataGridView();
            this.tabla_Incidencias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Percepciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Deducciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Incidencias)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Nomina
            // 
            this.btn_Nomina.Location = new System.Drawing.Point(641, 395);
            this.btn_Nomina.Name = "btn_Nomina";
            this.btn_Nomina.Size = new System.Drawing.Size(264, 105);
            this.btn_Nomina.TabIndex = 0;
            this.btn_Nomina.Text = "Generara Recibo de Nomina";
            this.btn_Nomina.UseVisualStyleBackColor = true;
            this.btn_Nomina.Click += new System.EventHandler(this.btn_Nomina_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(26, 162);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(315, 28);
            this.btn_Agregar.TabIndex = 1;
            this.btn_Agregar.Text = "Agregar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(716, 506);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(120, 28);
            this.btn_Regresar.TabIndex = 2;
            this.btn_Regresar.Text = "Modo Gerente:";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Solicitar:";
            // 
            // cmb_Incidencia
            // 
            this.cmb_Incidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Incidencia.FormattingEnabled = true;
            this.cmb_Incidencia.Location = new System.Drawing.Point(91, 99);
            this.cmb_Incidencia.Name = "cmb_Incidencia";
            this.cmb_Incidencia.Size = new System.Drawing.Size(250, 24);
            this.cmb_Incidencia.TabIndex = 4;
            this.cmb_Incidencia.SelectedIndexChanged += new System.EventHandler(this.cmb_Incidencia_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cantidad de dias:";
            // 
            // cmb_Dias
            // 
            this.cmb_Dias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Dias.FormattingEnabled = true;
            this.cmb_Dias.Location = new System.Drawing.Point(147, 132);
            this.cmb_Dias.Name = "cmb_Dias";
            this.cmb_Dias.Size = new System.Drawing.Size(194, 24);
            this.cmb_Dias.TabIndex = 6;
            this.cmb_Dias.SelectedIndexChanged += new System.EventHandler(this.cmb_Dias_SelectedIndexChanged);
            // 
            // Percepciones
            // 
            this.Percepciones.AutoSize = true;
            this.Percepciones.Location = new System.Drawing.Point(381, 94);
            this.Percepciones.Name = "Percepciones";
            this.Percepciones.Size = new System.Drawing.Size(98, 17);
            this.Percepciones.TabIndex = 8;
            this.Percepciones.Text = "Percepciones:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(789, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Deducciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Incidencias:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nombre Completo:";
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Location = new System.Drawing.Point(158, 13);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(46, 17);
            this.lbl_Nombre.TabIndex = 14;
            this.lbl_Nombre.Text = "label6";
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(26, 193);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(315, 28);
            this.btn_Eliminar.TabIndex = 15;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // tabla_Percepciones
            // 
            this.tabla_Percepciones.AllowUserToAddRows = false;
            this.tabla_Percepciones.AllowUserToDeleteRows = false;
            this.tabla_Percepciones.AllowUserToResizeColumns = false;
            this.tabla_Percepciones.AllowUserToResizeRows = false;
            this.tabla_Percepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Percepciones.Location = new System.Drawing.Point(384, 117);
            this.tabla_Percepciones.MultiSelect = false;
            this.tabla_Percepciones.Name = "tabla_Percepciones";
            this.tabla_Percepciones.ReadOnly = true;
            this.tabla_Percepciones.RowHeadersVisible = false;
            this.tabla_Percepciones.RowTemplate.Height = 24;
            this.tabla_Percepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Percepciones.Size = new System.Drawing.Size(380, 255);
            this.tabla_Percepciones.TabIndex = 49;
            // 
            // tabla_Deducciones
            // 
            this.tabla_Deducciones.AllowUserToAddRows = false;
            this.tabla_Deducciones.AllowUserToDeleteRows = false;
            this.tabla_Deducciones.AllowUserToResizeColumns = false;
            this.tabla_Deducciones.AllowUserToResizeRows = false;
            this.tabla_Deducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Deducciones.Location = new System.Drawing.Point(792, 117);
            this.tabla_Deducciones.MultiSelect = false;
            this.tabla_Deducciones.Name = "tabla_Deducciones";
            this.tabla_Deducciones.ReadOnly = true;
            this.tabla_Deducciones.RowHeadersVisible = false;
            this.tabla_Deducciones.RowTemplate.Height = 24;
            this.tabla_Deducciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Deducciones.Size = new System.Drawing.Size(380, 255);
            this.tabla_Deducciones.TabIndex = 50;
            // 
            // tabla_Incidencias
            // 
            this.tabla_Incidencias.AllowUserToAddRows = false;
            this.tabla_Incidencias.AllowUserToDeleteRows = false;
            this.tabla_Incidencias.AllowUserToResizeColumns = false;
            this.tabla_Incidencias.AllowUserToResizeRows = false;
            this.tabla_Incidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Incidencias.Location = new System.Drawing.Point(26, 258);
            this.tabla_Incidencias.MultiSelect = false;
            this.tabla_Incidencias.Name = "tabla_Incidencias";
            this.tabla_Incidencias.ReadOnly = true;
            this.tabla_Incidencias.RowHeadersVisible = false;
            this.tabla_Incidencias.RowTemplate.Height = 24;
            this.tabla_Incidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Incidencias.Size = new System.Drawing.Size(315, 276);
            this.tabla_Incidencias.TabIndex = 51;
            this.tabla_Incidencias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Incidencias_CellClick);
            // 
            // Form_Control_Empleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 560);
            this.Controls.Add(this.tabla_Incidencias);
            this.Controls.Add(this.tabla_Deducciones);
            this.Controls.Add(this.tabla_Percepciones);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.lbl_Nombre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Percepciones);
            this.Controls.Add(this.cmb_Dias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Incidencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.btn_Nomina);
            this.Name = "Form_Control_Empleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Control_Empleado_Closing);
            this.Load += new System.EventHandler(this.Form_Control_Empleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Percepciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Deducciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Incidencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Nomina;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Incidencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Dias;
        private System.Windows.Forms.Label Percepciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.DataGridView tabla_Percepciones;
        private System.Windows.Forms.DataGridView tabla_Deducciones;
        private System.Windows.Forms.DataGridView tabla_Incidencias;
    }
}