using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventanas_Finales_Siksi
{
    public partial class Form_ABC_Departamentos : Form
    {
        Validaciones val = new Validaciones();
        public static bool isClosing = true; 

        public Form_ABC_Departamentos()
        {
            InitializeComponent();
            ControlBox = false;
        }

        private void Form_ABC_Departamentos_Load(object sender, EventArgs e)
        {
            if (AccionesForms.isUpdate == true)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Get_Depto_By_ID("E", AccionesForms.SQL_ID_Depto);

                    foreach (DataRow row in lista.Rows)
                    {
                        txt_Nombre.Text = (string)row["Nombre_Depto"];
                        txt_SueldoBase.Text = row["Sueldo_Base"].ToString();
                    }
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Depto_By_Id(AccionesForms.ID_Depto);

                    foreach (var item in lista)
                    {
                        txt_SueldoBase.Text = item.money_SB.ToString();
                        txt_Nombre.Text = item.txt_Nombre.ToString();
                    }
                }
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (ObtenerInfo())
            {
                isClosing = true;
                this.Close();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            isClosing = false;
            this.Close();
        }

        bool ObtenerInfo()
        {
            bool isNotEmpty = Validacionesvacios();
            if (!isNotEmpty) {
                MessageBox.Show("Campos vacios", "ERROR", MessageBoxButtons.OK);
                return false;
            }

            Departamento Dep = new Departamento();

            Dep.txt_Nombre = txt_Nombre.Text;
            Dep.money_SueldoBase = float.Parse(txt_SueldoBase.Text);

            if (AccionesForms.enlace == false)
            {
                if (!AccionesForms.isUpdate)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    enlace.Acciones_Departamento("A", Dep, AccionesForms.SQL_ID_Depto);
                }

                if (AccionesForms.isUpdate)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    enlace.Acciones_Departamento("C", Dep, AccionesForms.SQL_ID_Depto);
                }
            }

            if (AccionesForms.enlace == true)
            {
                if (!AccionesForms.isUpdate)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Agregar_Departamento("A", Dep);
                }

                if (AccionesForms.isUpdate)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Update_Depto(Dep);
                }
            }
            MessageBox.Show("Informacion cargada con exito", "Registro", MessageBoxButtons.OK);
            return true;
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloLetras(e);
        }

        private void Cantidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.CantidadPorcentaje(e);
        }

        bool Validacionesvacios()
        {
            if (txt_Nombre.Text == "")
                return false;

            if (txt_SueldoBase.Text == "")
                return false;

            return true;
        }
    }
}
