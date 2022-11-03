using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cassandra;

namespace Ventanas_Finales_Siksi
{
    public partial class Form_ABC_Empresa : Form
    {
        Validaciones val = new Validaciones();

        public Form_ABC_Empresa()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Form_ABC_Empresa_Load(object sender, EventArgs e)
        {
            date_FeInicio.Enabled = false;
            if (AccionesForms.isUpdate == true)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Get_Empresa_By_ID("E", AccionesForms.SQL_ID_Empresa);
                    
                    foreach (DataRow row in lista.Rows)
                    {
                        txt_Email.Text = (string)row["txt_Email"];
                        txt_RegFed.Text = (string)row["txt_RF"];
                        txt_RegPatronal.Text = (string)row["txt_RP"];
                        txt_RazonSocial.Text = (string)row["txt_RS"];
                        date_FeInicio.Value = DateTime.Parse(row["date_FInicio"].ToString());

                        txt_Calle.Text = (string)row["txt_Calle"];
                        txt_Colonia.Text = (string)row["txt_Colonia"];
                        txt_NumCasa.Text = (string)row["txt_Num"];
                        txt_Municipio.Text = (string)row["txt_Municipio"];
                        txt_Estado.Text = (string)row["txt_Estado"];
                        txt_CP.Text = (string)row["txt_CP"];
                        int a = (int)row["int_FP"];
                        int b = (int)row["int_FP2"];

                        if (a == 7)
                        {
                            cmb_FrePago.Text = "Semanal";
                        }
                        if (a == 14)
                        {
                            cmb_FrePago.Text = "Catorcenal";
                        }
                        if (a == 15)
                        {
                            cmb_FrePago.Text = "Quincenal";
                        }
                        if (a == 30)
                        {
                            cmb_FrePago.Text = "Mensual";
                        }

                        if (b == 7)
                        {
                            cmb_FrePago2.Text = "Semanal";
                        }
                        if (b == 14)
                        {
                            cmb_FrePago2.Text = "Catorcenal";
                        }
                        if (b == 15)
                        {
                            cmb_FrePago2.Text = "Quincenal";
                        }
                        if (b == 30)
                        {
                            cmb_FrePago2.Text = "Mensual";
                        }
                        break;
                    }
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Empresas_By_ID(AccionesForms.ID_Empresa);
                    date_FeInicio.Enabled = true;

                    foreach (var row in lista)
                    {
                        txt_Email.Text = row.txt_Email;
                        txt_RegFed.Text = row.txt_RF;
                        txt_RegPatronal.Text = row.txt_RP;
                        txt_RazonSocial.Text = row.txt_RS;
                        date_FeInicio.Value = DateTime.Parse(row.date_FInicio.ToString());

                        txt_Calle.Text = row.txt_Calle;
                        txt_Colonia.Text = row.txt_Colonia;
                        txt_NumCasa.Text = row.txt_Num;
                        txt_Municipio.Text = row.txt_Municipio;
                        txt_Estado.Text = row.txt_Estado;
                        txt_CP.Text = row.txt_CP;
                        int a = row.int_FP.First();
                        int b = row.int_FP.Last();

                        if (a == 7)
                        {
                            cmb_FrePago.Text = "Semanal";
                        }
                        if (a == 14)
                        {
                            cmb_FrePago.Text = "Catorcenal";
                        }
                        if (a == 15)
                        {
                            cmb_FrePago.Text = "Quincenal";
                        }
                        if (a == 30)
                        {
                            cmb_FrePago.Text = "Mensual";
                        }

                        if (b == 7)
                        {
                            cmb_FrePago2.Text = "Semanal";
                        }
                        if (b == 14)
                        {
                            cmb_FrePago2.Text = "Catorcenal";
                        }
                        if (b == 15)
                        {
                            cmb_FrePago2.Text = "Quincenal";
                        }
                        if (b == 30)
                        {
                            cmb_FrePago2.Text = "Mensual";
                        }
                        break;
                    }
                }
            }
        }

        private void Form_ABC_Empresa_Closing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if(ObtenerInfo())
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool ObtenerInfo()
        {
            bool isNotEmpty = ValidacionesVacios();
            if (isNotEmpty == false)
            {
                MessageBox.Show("Campos sin llenar", "ERROR", MessageBoxButtons.OK);
                return false;
            }

            Empresa Emp = new Empresa();
            Domicilio Dom = new Domicilio();

            if (cmb_FrePago.Text == "Semanal") {
                Emp.int_FPago = 7;
            }
            if (cmb_FrePago.Text == "Catorcenal")
            {
                Emp.int_FPago = 14;
            }
            if (cmb_FrePago.Text == "Quincenal")
            {
                Emp.int_FPago = 15;
            }
            if (cmb_FrePago.Text == "Mensual")
            {
                Emp.int_FPago = 30;
            }

            if (cmb_FrePago2.Text == "Semanal")
            {
                Emp.int_FPago2 = 7;
            }
            if (cmb_FrePago2.Text == "Catorcenal")
            {
                Emp.int_FPago2 = 14;
            }
            if (cmb_FrePago2.Text == "Quincenal")
            {
                Emp.int_FPago2 = 15;
            }
            if (cmb_FrePago2.Text == "Mensual")
            {
                Emp.int_FPago2 = 30;
            }

            Emp.txt_Email = txt_Email.Text;
            Emp.txt_RF = txt_RegFed.Text;
            Emp.txt_RP = txt_RegPatronal.Text;
            Emp.txt_RS = txt_RazonSocial.Text;
            Emp.date_FchaInicio = date_FeInicio.Value;


            Dom.txt_Calle = txt_Calle.Text;
            Dom.txt_Colonia = txt_Colonia.Text;
            Dom.txt_NumCasa = txt_NumCasa.Text;
            Dom.txt_Municipio = txt_Municipio.Text;
            Dom.txt_Estado = txt_Estado.Text;
            Dom.txt_CP = txt_CP.Text;

            if (AccionesForms.enlace == false)
            {
                if (!AccionesForms.isUpdate)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    enlace.Acciones_Domicilio("A", Dom);
                    enlace.Acciones_Empresa("A", Emp, Dom, AccionesForms.SQL_ID_Empresa);
                }
                if (AccionesForms.isUpdate)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    enlace.Acciones_Empresa("C", Emp, Dom, AccionesForms.SQL_ID_Empresa);
                }
            }

            if (AccionesForms.enlace == true) {
                if (!AccionesForms.isUpdate)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Agregar_Empresa("A", Emp, Dom);
                }
                if (AccionesForms.isUpdate)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Update_Empresa(Emp, Dom);
                }
            }
            MessageBox.Show("Informacion cargada con exito", "Registro", MessageBoxButtons.OK);
            return true;
        }

        private void txt_RazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloLetras(e);
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloLetras(e);
        }

        private void LetrasNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.LetrasNumeros(e);
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private bool ValidacionesVacios()
        {
            if (txt_RazonSocial.Text == "")
                return false;

            if (txt_Email.Text == "")
                return false;

            if (txt_RegPatronal.Text == "")
                return false;

            if (txt_RegFed.Text == "")
                return false;

            if (cmb_FrePago.Text == "")
                return false;

            if (cmb_FrePago2.Text == "")
                return false;

            if (txt_Calle.Text == "")
                return false;

            if (txt_Colonia.Text == "")
                return false;

            if (txt_NumCasa.Text == "")
                return false;

            if (txt_Colonia.Text == "")
                return false;

            if (txt_Municipio.Text == "")
                return false;

            if (txt_Estado.Text == "")
                return false;

            if (txt_CP.Text == "")
                return false;

            return true;
        }
    }
}
