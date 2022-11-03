namespace Ventanas_Finales_Siksi
{
    partial class Form_ABC_Empresa
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
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_RazonSocial = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_RegPatronal = new System.Windows.Forms.TextBox();
            this.txt_RegFed = new System.Windows.Forms.TextBox();
            this.date_FeInicio = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_FrePago = new System.Windows.Forms.ComboBox();
            this.txt_CP = new System.Windows.Forms.TextBox();
            this.txt_Estado = new System.Windows.Forms.TextBox();
            this.txt_Municipio = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Colonia = new System.Windows.Forms.TextBox();
            this.txt_NumCasa = new System.Windows.Forms.TextBox();
            this.txt_Calle = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmb_FrePago2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(782, 242);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(94, 32);
            this.btn_Aceptar.TabIndex = 0;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(882, 242);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(94, 32);
            this.btn_Cancelar.TabIndex = 1;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razon Social:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email de Contacto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Registro Patronal:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Registro Federal:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Fecha de Inicio de Operaciones:";
            // 
            // txt_RazonSocial
            // 
            this.txt_RazonSocial.Location = new System.Drawing.Point(113, 23);
            this.txt_RazonSocial.Name = "txt_RazonSocial";
            this.txt_RazonSocial.Size = new System.Drawing.Size(407, 22);
            this.txt_RazonSocial.TabIndex = 10;
            this.txt_RazonSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(145, 51);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(375, 22);
            this.txt_Email.TabIndex = 14;
            this.txt_Email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_RegPatronal
            // 
            this.txt_RegPatronal.Location = new System.Drawing.Point(141, 79);
            this.txt_RegPatronal.Name = "txt_RegPatronal";
            this.txt_RegPatronal.Size = new System.Drawing.Size(379, 22);
            this.txt_RegPatronal.TabIndex = 15;
            this.txt_RegPatronal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetrasNumeros_KeyPress);
            // 
            // txt_RegFed
            // 
            this.txt_RegFed.Location = new System.Drawing.Point(135, 107);
            this.txt_RegFed.Name = "txt_RegFed";
            this.txt_RegFed.Size = new System.Drawing.Size(385, 22);
            this.txt_RegFed.TabIndex = 16;
            this.txt_RegFed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetrasNumeros_KeyPress);
            // 
            // date_FeInicio
            // 
            this.date_FeInicio.Location = new System.Drawing.Point(231, 135);
            this.date_FeInicio.Name = "date_FeInicio";
            this.date_FeInicio.Size = new System.Drawing.Size(289, 22);
            this.date_FeInicio.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Frecuencia de Pago 1:";
            // 
            // cmb_FrePago
            // 
            this.cmb_FrePago.AutoCompleteCustomSource.AddRange(new string[] {
            "Semanal",
            "Catorcenal",
            "Quincenal",
            "Mensual"});
            this.cmb_FrePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FrePago.FormattingEnabled = true;
            this.cmb_FrePago.Items.AddRange(new object[] {
            "Semanal",
            "Catorcenal",
            "Quincenal",
            "Mensual"});
            this.cmb_FrePago.Location = new System.Drawing.Point(169, 161);
            this.cmb_FrePago.Name = "cmb_FrePago";
            this.cmb_FrePago.Size = new System.Drawing.Size(351, 24);
            this.cmb_FrePago.TabIndex = 19;
            // 
            // txt_CP
            // 
            this.txt_CP.Location = new System.Drawing.Point(842, 107);
            this.txt_CP.Name = "txt_CP";
            this.txt_CP.Size = new System.Drawing.Size(134, 22);
            this.txt_CP.TabIndex = 77;
            this.txt_CP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros);
            // 
            // txt_Estado
            // 
            this.txt_Estado.Location = new System.Drawing.Point(609, 107);
            this.txt_Estado.Name = "txt_Estado";
            this.txt_Estado.Size = new System.Drawing.Size(190, 22);
            this.txt_Estado.TabIndex = 76;
            this.txt_Estado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_Municipio
            // 
            this.txt_Municipio.Location = new System.Drawing.Point(622, 79);
            this.txt_Municipio.Name = "txt_Municipio";
            this.txt_Municipio.Size = new System.Drawing.Size(354, 22);
            this.txt_Municipio.TabIndex = 75;
            this.txt_Municipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(805, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 17);
            this.label16.TabIndex = 74;
            this.label16.Text = "CP:";
            // 
            // txt_Colonia
            // 
            this.txt_Colonia.Location = new System.Drawing.Point(611, 51);
            this.txt_Colonia.Name = "txt_Colonia";
            this.txt_Colonia.Size = new System.Drawing.Size(365, 22);
            this.txt_Colonia.TabIndex = 73;
            this.txt_Colonia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_NumCasa
            // 
            this.txt_NumCasa.Location = new System.Drawing.Point(873, 23);
            this.txt_NumCasa.Name = "txt_NumCasa";
            this.txt_NumCasa.Size = new System.Drawing.Size(103, 22);
            this.txt_NumCasa.TabIndex = 72;
            this.txt_NumCasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros);
            // 
            // txt_Calle
            // 
            this.txt_Calle.Location = new System.Drawing.Point(595, 23);
            this.txt_Calle.Name = "txt_Calle";
            this.txt_Calle.Size = new System.Drawing.Size(204, 22);
            this.txt_Calle.TabIndex = 71;
            this.txt_Calle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(546, 107);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 17);
            this.label19.TabIndex = 70;
            this.label19.Text = "Estado:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(546, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 17);
            this.label20.TabIndex = 69;
            this.label20.Text = "Municipio:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(546, 51);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 17);
            this.label21.TabIndex = 68;
            this.label21.Text = "Colonia:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(805, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 17);
            this.label22.TabIndex = 67;
            this.label22.Text = "Numero:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(546, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 17);
            this.label23.TabIndex = 66;
            this.label23.Text = "Calle:";
            // 
            // cmb_FrePago2
            // 
            this.cmb_FrePago2.AutoCompleteCustomSource.AddRange(new string[] {
            "Semanal",
            "Catorcenal",
            "Quincenal",
            "Mensual"});
            this.cmb_FrePago2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FrePago2.FormattingEnabled = true;
            this.cmb_FrePago2.Items.AddRange(new object[] {
            "Semanal",
            "Catorcenal",
            "Quincenal",
            "Mensual"});
            this.cmb_FrePago2.Location = new System.Drawing.Point(169, 191);
            this.cmb_FrePago2.Name = "cmb_FrePago2";
            this.cmb_FrePago2.Size = new System.Drawing.Size(351, 24);
            this.cmb_FrePago2.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Frecuencia de Pago 2:";
            // 
            // Form_ABC_Empresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 286);
            this.Controls.Add(this.cmb_FrePago2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_CP);
            this.Controls.Add(this.txt_Estado);
            this.Controls.Add(this.txt_Municipio);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_Colonia);
            this.Controls.Add(this.txt_NumCasa);
            this.Controls.Add(this.txt_Calle);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmb_FrePago);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.date_FeInicio);
            this.Controls.Add(this.txt_RegFed);
            this.Controls.Add(this.txt_RegPatronal);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_RazonSocial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Name = "Form_ABC_Empresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABC Empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ABC_Empresa_Closing);
            this.Load += new System.EventHandler(this.Form_ABC_Empresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_RazonSocial;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_RegPatronal;
        private System.Windows.Forms.TextBox txt_RegFed;
        private System.Windows.Forms.DateTimePicker date_FeInicio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_FrePago;
        private System.Windows.Forms.TextBox txt_CP;
        private System.Windows.Forms.TextBox txt_Estado;
        private System.Windows.Forms.TextBox txt_Municipio;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Colonia;
        private System.Windows.Forms.TextBox txt_NumCasa;
        private System.Windows.Forms.TextBox txt_Calle;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmb_FrePago2;
        private System.Windows.Forms.Label label2;
    }
}