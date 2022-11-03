namespace Ventanas_Finales_Siksi
{
    partial class Forms_Admin
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
            this.radio_Valor = new System.Windows.Forms.RadioButton();
            this.radio_Por = new System.Windows.Forms.RadioButton();
            this.tabla_Cambios = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Monto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Activar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_PerDed = new System.Windows.Forms.ComboBox();
            this.btn_Regresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Cambios)).BeginInit();
            this.SuspendLayout();
            // 
            // radio_Valor
            // 
            this.radio_Valor.AutoSize = true;
            this.radio_Valor.Location = new System.Drawing.Point(13, 13);
            this.radio_Valor.Name = "radio_Valor";
            this.radio_Valor.Size = new System.Drawing.Size(88, 21);
            this.radio_Valor.TabIndex = 0;
            this.radio_Valor.TabStop = true;
            this.radio_Valor.Text = "Valor Fijo";
            this.radio_Valor.UseVisualStyleBackColor = true;
            // 
            // radio_Por
            // 
            this.radio_Por.AutoSize = true;
            this.radio_Por.Location = new System.Drawing.Point(130, 13);
            this.radio_Por.Name = "radio_Por";
            this.radio_Por.Size = new System.Drawing.Size(97, 21);
            this.radio_Por.TabIndex = 1;
            this.radio_Por.TabStop = true;
            this.radio_Por.Text = "Porcentaje";
            this.radio_Por.UseVisualStyleBackColor = true;
            // 
            // tabla_Cambios
            // 
            this.tabla_Cambios.AllowUserToAddRows = false;
            this.tabla_Cambios.AllowUserToDeleteRows = false;
            this.tabla_Cambios.AllowUserToResizeColumns = false;
            this.tabla_Cambios.AllowUserToResizeRows = false;
            this.tabla_Cambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_Cambios.Location = new System.Drawing.Point(325, 13);
            this.tabla_Cambios.MultiSelect = false;
            this.tabla_Cambios.Name = "tabla_Cambios";
            this.tabla_Cambios.ReadOnly = true;
            this.tabla_Cambios.RowHeadersVisible = false;
            this.tabla_Cambios.RowTemplate.Height = 24;
            this.tabla_Cambios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla_Cambios.Size = new System.Drawing.Size(554, 207);
            this.tabla_Cambios.TabIndex = 50;
            this.tabla_Cambios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_Cambios_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 39);
            this.button1.TabIndex = 51;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Enabled = false;
            this.btn_Eliminar.Location = new System.Drawing.Point(325, 226);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(554, 39);
            this.btn_Eliminar.TabIndex = 52;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(81, 77);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(204, 22);
            this.txt_Nombre.TabIndex = 53;
            this.txt_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "Nombre:";
            // 
            // txt_Monto
            // 
            this.txt_Monto.Location = new System.Drawing.Point(142, 105);
            this.txt_Monto.Name = "txt_Monto";
            this.txt_Monto.Size = new System.Drawing.Size(143, 22);
            this.txt_Monto.TabIndex = 55;
            this.txt_Monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cantidades_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Monto/Porcentaje:";
            // 
            // btn_Activar
            // 
            this.btn_Activar.Enabled = false;
            this.btn_Activar.Location = new System.Drawing.Point(325, 272);
            this.btn_Activar.Name = "btn_Activar";
            this.btn_Activar.Size = new System.Drawing.Size(554, 42);
            this.btn_Activar.TabIndex = 57;
            this.btn_Activar.Text = "Activar/Desactivar";
            this.btn_Activar.UseVisualStyleBackColor = true;
            this.btn_Activar.Click += new System.EventHandler(this.btn_Activar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Seleccione:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmb_PerDed
            // 
            this.cmb_PerDed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PerDed.FormattingEnabled = true;
            this.cmb_PerDed.Items.AddRange(new object[] {
            "Percepcion",
            "Deduccion"});
            this.cmb_PerDed.Location = new System.Drawing.Point(100, 41);
            this.cmb_PerDed.Name = "cmb_PerDed";
            this.cmb_PerDed.Size = new System.Drawing.Size(185, 24);
            this.cmb_PerDed.TabIndex = 59;
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(12, 272);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(273, 41);
            this.btn_Regresar.TabIndex = 60;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // Forms_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 329);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.cmb_PerDed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Activar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Monto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabla_Cambios);
            this.Controls.Add(this.radio_Por);
            this.Controls.Add(this.radio_Valor);
            this.Name = "Forms_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Percepciones y Deducciones";
            this.Load += new System.EventHandler(this.Forms_Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_Cambios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio_Valor;
        private System.Windows.Forms.RadioButton radio_Por;
        private System.Windows.Forms.DataGridView tabla_Cambios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Monto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Activar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_PerDed;
        private System.Windows.Forms.Button btn_Regresar;
    }
}