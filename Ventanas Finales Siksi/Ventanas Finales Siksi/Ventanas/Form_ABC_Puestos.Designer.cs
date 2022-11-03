namespace Ventanas_Finales_Siksi
{
    partial class Form_ABC_Puestos
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
            this.txt_NS = new System.Windows.Forms.TextBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Depto = new System.Windows.Forms.ComboBox();
            this.btn_Check = new System.Windows.Forms.Button();
            this.lbl_Sueldo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_NS
            // 
            this.txt_NS.Location = new System.Drawing.Point(110, 87);
            this.txt_NS.Name = "txt_NS";
            this.txt_NS.Size = new System.Drawing.Size(209, 22);
            this.txt_NS.TabIndex = 17;
            this.txt_NS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cantidades_KeyPress);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(78, 59);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(241, 22);
            this.txt_Nombre.TabIndex = 16;
            this.txt_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloLetras_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nivel Salarial:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "MXN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Salario Diario:     $";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(177, 153);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(142, 32);
            this.btn_Cancelar.TabIndex = 25;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(13, 153);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(142, 32);
            this.btn_Aceptar.TabIndex = 24;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Departamento:";
            // 
            // cmb_Depto
            // 
            this.cmb_Depto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Depto.FormattingEnabled = true;
            this.cmb_Depto.Items.AddRange(new object[] {
            "CONTADURIA"});
            this.cmb_Depto.Location = new System.Drawing.Point(118, 30);
            this.cmb_Depto.Name = "cmb_Depto";
            this.cmb_Depto.Size = new System.Drawing.Size(166, 24);
            this.cmb_Depto.TabIndex = 27;
            // 
            // btn_Check
            // 
            this.btn_Check.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Check.Location = new System.Drawing.Point(290, 30);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(31, 25);
            this.btn_Check.TabIndex = 50;
            this.btn_Check.Text = "*";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_Check_Click);
            // 
            // lbl_Sueldo
            // 
            this.lbl_Sueldo.AutoSize = true;
            this.lbl_Sueldo.Location = new System.Drawing.Point(133, 115);
            this.lbl_Sueldo.Name = "lbl_Sueldo";
            this.lbl_Sueldo.Size = new System.Drawing.Size(142, 17);
            this.lbl_Sueldo.TabIndex = 51;
            this.lbl_Sueldo.Text = "Click para ver Salario";
            this.lbl_Sueldo.Click += new System.EventHandler(this.lbl_Sueldo_Click);
            // 
            // Form_ABC_Puestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 215);
            this.Controls.Add(this.lbl_Sueldo);
            this.Controls.Add(this.btn_Check);
            this.Controls.Add(this.cmb_Depto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_NS);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_ABC_Puestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABC Puestos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ABC_Puestos_Closing);
            this.Load += new System.EventHandler(this.Form_ABC_Puestos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_NS;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Depto;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.Label lbl_Sueldo;
    }
}