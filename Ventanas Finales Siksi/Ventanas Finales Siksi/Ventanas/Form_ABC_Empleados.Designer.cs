namespace Ventanas_Finales_Siksi
{
    partial class Form_ABC_Empleados
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
            this.txt_CURP = new System.Windows.Forms.TextBox();
            this.txt_ApPaterno = new System.Windows.Forms.TextBox();
            this.txt_Nombres = new System.Windows.Forms.TextBox();
            this.txt_Contrasenia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ApMaterno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_Puesto = new System.Windows.Forms.ComboBox();
            this.date_FNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txt_NumSegSocial = new System.Windows.Forms.TextBox();
            this.txt_Tel = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Colonia = new System.Windows.Forms.TextBox();
            this.txt_NumCasa = new System.Windows.Forms.TextBox();
            this.txt_Calle = new System.Windows.Forms.TextBox();
            this.txt_RFC = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_Municipio = new System.Windows.Forms.TextBox();
            this.txt_Estado = new System.Windows.Forms.TextBox();
            this.txt_CP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_Banco = new System.Windows.Forms.TextBox();
            this.txt_NumCuenta = new System.Windows.Forms.TextBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.date_FInicio = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Deptos = new System.Windows.Forms.ComboBox();
            this.btn_Check = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_FrePago = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_CURP
            // 
            this.txt_CURP.Location = new System.Drawing.Point(68, 335);
            this.txt_CURP.Name = "txt_CURP";
            this.txt_CURP.Size = new System.Drawing.Size(372, 22);
            this.txt_CURP.TabIndex = 30;
            this.txt_CURP.Visible = false;
            // 
            // txt_ApPaterno
            // 
            this.txt_ApPaterno.Location = new System.Drawing.Point(134, 83);
            this.txt_ApPaterno.Name = "txt_ApPaterno";
            this.txt_ApPaterno.Size = new System.Drawing.Size(306, 22);
            this.txt_ApPaterno.TabIndex = 27;
            this.txt_ApPaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_Nombres
            // 
            this.txt_Nombres.Location = new System.Drawing.Point(87, 55);
            this.txt_Nombres.Name = "txt_Nombres";
            this.txt_Nombres.Size = new System.Drawing.Size(353, 22);
            this.txt_Nombres.TabIndex = 26;
            this.txt_Nombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_Contrasenia
            // 
            this.txt_Contrasenia.Location = new System.Drawing.Point(103, 27);
            this.txt_Contrasenia.Name = "txt_Contrasenia";
            this.txt_Contrasenia.Size = new System.Drawing.Size(337, 22);
            this.txt_Contrasenia.TabIndex = 25;
            this.txt_Contrasenia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetrasNumeros_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Apellido Materno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Apellido Paterno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Nombres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Contraseña:";
            // 
            // txt_ApMaterno
            // 
            this.txt_ApMaterno.Location = new System.Drawing.Point(134, 111);
            this.txt_ApMaterno.Name = "txt_ApMaterno";
            this.txt_ApMaterno.Size = new System.Drawing.Size(306, 22);
            this.txt_ApMaterno.TabIndex = 28;
            this.txt_ApMaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 17);
            this.label9.TabIndex = 36;
            this.label9.Text = "Numero de Seguro Social:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "CURP:";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Fecha de Nacimiento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "Puesto:";
            // 
            // cmb_Puesto
            // 
            this.cmb_Puesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Puesto.FormattingEnabled = true;
            this.cmb_Puesto.Location = new System.Drawing.Point(74, 170);
            this.cmb_Puesto.Name = "cmb_Puesto";
            this.cmb_Puesto.Size = new System.Drawing.Size(366, 24);
            this.cmb_Puesto.TabIndex = 38;
            // 
            // date_FNacimiento
            // 
            this.date_FNacimiento.Location = new System.Drawing.Point(164, 199);
            this.date_FNacimiento.Name = "date_FNacimiento";
            this.date_FNacimiento.Size = new System.Drawing.Size(276, 22);
            this.date_FNacimiento.TabIndex = 39;
            // 
            // txt_NumSegSocial
            // 
            this.txt_NumSegSocial.Location = new System.Drawing.Point(193, 227);
            this.txt_NumSegSocial.Name = "txt_NumSegSocial";
            this.txt_NumSegSocial.Size = new System.Drawing.Size(247, 22);
            this.txt_NumSegSocial.TabIndex = 40;
            this.txt_NumSegSocial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // txt_Tel
            // 
            this.txt_Tel.Location = new System.Drawing.Point(562, 308);
            this.txt_Tel.Name = "txt_Tel";
            this.txt_Tel.Size = new System.Drawing.Size(356, 22);
            this.txt_Tel.TabIndex = 62;
            this.txt_Tel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(488, 308);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 58;
            this.label13.Text = "Telefono:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(488, 280);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 17);
            this.label14.TabIndex = 57;
            this.label14.Text = "Email:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(488, 252);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 17);
            this.label15.TabIndex = 56;
            this.label15.Text = "Numero de Cuenta:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(747, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 17);
            this.label16.TabIndex = 55;
            this.label16.Text = "CP:";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(540, 280);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(378, 22);
            this.txt_Email.TabIndex = 52;
            this.txt_Email.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_Colonia
            // 
            this.txt_Colonia.Location = new System.Drawing.Point(553, 110);
            this.txt_Colonia.Name = "txt_Colonia";
            this.txt_Colonia.Size = new System.Drawing.Size(365, 22);
            this.txt_Colonia.TabIndex = 51;
            this.txt_Colonia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_NumCasa
            // 
            this.txt_NumCasa.Location = new System.Drawing.Point(815, 82);
            this.txt_NumCasa.Name = "txt_NumCasa";
            this.txt_NumCasa.Size = new System.Drawing.Size(103, 22);
            this.txt_NumCasa.TabIndex = 50;
            this.txt_NumCasa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // txt_Calle
            // 
            this.txt_Calle.Location = new System.Drawing.Point(537, 82);
            this.txt_Calle.Name = "txt_Calle";
            this.txt_Calle.Size = new System.Drawing.Size(204, 22);
            this.txt_Calle.TabIndex = 49;
            this.txt_Calle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetrasNumeros_KeyPress);
            // 
            // txt_RFC
            // 
            this.txt_RFC.Location = new System.Drawing.Point(533, 26);
            this.txt_RFC.Name = "txt_RFC";
            this.txt_RFC.Size = new System.Drawing.Size(385, 22);
            this.txt_RFC.TabIndex = 48;
            this.txt_RFC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LetrasNumeros_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(488, 166);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 17);
            this.label19.TabIndex = 47;
            this.label19.Text = "Estado:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(488, 138);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 17);
            this.label20.TabIndex = 46;
            this.label20.Text = "Municipio:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(488, 110);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 17);
            this.label21.TabIndex = 45;
            this.label21.Text = "Colonia:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(747, 82);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 17);
            this.label22.TabIndex = 44;
            this.label22.Text = "Numero:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(488, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 17);
            this.label23.TabIndex = 43;
            this.label23.Text = "Calle:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(488, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(39, 17);
            this.label25.TabIndex = 41;
            this.label25.Text = "RFC:";
            // 
            // txt_Municipio
            // 
            this.txt_Municipio.Location = new System.Drawing.Point(564, 138);
            this.txt_Municipio.Name = "txt_Municipio";
            this.txt_Municipio.Size = new System.Drawing.Size(354, 22);
            this.txt_Municipio.TabIndex = 63;
            this.txt_Municipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_Estado
            // 
            this.txt_Estado.Location = new System.Drawing.Point(551, 166);
            this.txt_Estado.Name = "txt_Estado";
            this.txt_Estado.Size = new System.Drawing.Size(190, 22);
            this.txt_Estado.TabIndex = 64;
            this.txt_Estado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_CP
            // 
            this.txt_CP.Location = new System.Drawing.Point(784, 166);
            this.txt_CP.Name = "txt_CP";
            this.txt_CP.Size = new System.Drawing.Size(134, 22);
            this.txt_CP.TabIndex = 65;
            this.txt_CP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(488, 223);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 17);
            this.label17.TabIndex = 66;
            this.label17.Text = "Banco:";
            // 
            // txt_Banco
            // 
            this.txt_Banco.Location = new System.Drawing.Point(547, 223);
            this.txt_Banco.Name = "txt_Banco";
            this.txt_Banco.Size = new System.Drawing.Size(371, 22);
            this.txt_Banco.TabIndex = 67;
            this.txt_Banco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // txt_NumCuenta
            // 
            this.txt_NumCuenta.Location = new System.Drawing.Point(626, 252);
            this.txt_NumCuenta.Name = "txt_NumCuenta";
            this.txt_NumCuenta.Size = new System.Drawing.Size(292, 22);
            this.txt_NumCuenta.TabIndex = 68;
            this.txt_NumCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(824, 379);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(94, 32);
            this.btn_Cancelar.TabIndex = 70;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(724, 379);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(94, 32);
            this.btn_Aceptar.TabIndex = 69;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // date_FInicio
            // 
            this.date_FInicio.Enabled = false;
            this.date_FInicio.Location = new System.Drawing.Point(121, 387);
            this.date_FInicio.Name = "date_FInicio";
            this.date_FInicio.Size = new System.Drawing.Size(319, 22);
            this.date_FInicio.TabIndex = 74;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 387);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 17);
            this.label24.TabIndex = 72;
            this.label24.Text = "Fecha de Inicio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "Departamentos:";
            // 
            // cmb_Deptos
            // 
            this.cmb_Deptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Deptos.FormattingEnabled = true;
            this.cmb_Deptos.Location = new System.Drawing.Point(125, 140);
            this.cmb_Deptos.Name = "cmb_Deptos";
            this.cmb_Deptos.Size = new System.Drawing.Size(287, 24);
            this.cmb_Deptos.TabIndex = 76;
            // 
            // btn_Check
            // 
            this.btn_Check.Location = new System.Drawing.Point(418, 139);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(21, 24);
            this.btn_Check.TabIndex = 77;
            this.btn_Check.Text = "*";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 17);
            this.label6.TabIndex = 78;
            this.label6.Text = "Frecuencia de Pago:";
            // 
            // cmb_FrePago
            // 
            this.cmb_FrePago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FrePago.FormattingEnabled = true;
            this.cmb_FrePago.Location = new System.Drawing.Point(158, 255);
            this.cmb_FrePago.Name = "cmb_FrePago";
            this.cmb_FrePago.Size = new System.Drawing.Size(282, 24);
            this.cmb_FrePago.TabIndex = 79;
            // 
            // Form_ABC_Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(938, 424);
            this.Controls.Add(this.cmb_FrePago);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.cmb_Deptos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_FInicio);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.txt_NumCuenta);
            this.Controls.Add(this.txt_Banco);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txt_CP);
            this.Controls.Add(this.txt_Estado);
            this.Controls.Add(this.txt_Municipio);
            this.Controls.Add(this.txt_Tel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_Colonia);
            this.Controls.Add(this.txt_NumCasa);
            this.Controls.Add(this.txt_Calle);
            this.Controls.Add(this.txt_RFC);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txt_NumSegSocial);
            this.Controls.Add(this.date_FNacimiento);
            this.Controls.Add(this.cmb_Puesto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_CURP);
            this.Controls.Add(this.txt_ApMaterno);
            this.Controls.Add(this.txt_ApPaterno);
            this.Controls.Add(this.txt_Nombres);
            this.Controls.Add(this.txt_Contrasenia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form_ABC_Empleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABC Empleados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ABC_Empleados_Closing);
            this.Load += new System.EventHandler(this.Form_ABC_Empleados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_CURP;
        private System.Windows.Forms.TextBox txt_ApPaterno;
        private System.Windows.Forms.TextBox txt_Nombres;
        private System.Windows.Forms.TextBox txt_Contrasenia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ApMaterno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_Puesto;
        private System.Windows.Forms.DateTimePicker date_FNacimiento;
        private System.Windows.Forms.TextBox txt_NumSegSocial;
        private System.Windows.Forms.TextBox txt_Tel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_Colonia;
        private System.Windows.Forms.TextBox txt_NumCasa;
        private System.Windows.Forms.TextBox txt_Calle;
        private System.Windows.Forms.TextBox txt_RFC;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_Municipio;
        private System.Windows.Forms.TextBox txt_Estado;
        private System.Windows.Forms.TextBox txt_CP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_Banco;
        private System.Windows.Forms.TextBox txt_NumCuenta;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.DateTimePicker date_FInicio;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Deptos;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_FrePago;
    }
}