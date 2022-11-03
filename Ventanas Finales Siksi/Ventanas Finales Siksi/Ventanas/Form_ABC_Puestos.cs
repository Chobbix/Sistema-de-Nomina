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
    public partial class Form_ABC_Puestos : Form
    {
        Validaciones val = new Validaciones();
        Guid id_depto;
        int sql_id_depto;
        float Sueldo_Base;
        float Salario_Diario;

        public Form_ABC_Puestos()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Form_ABC_Puestos_Load(object sender, EventArgs e)
        {
            if (!AccionesForms.isUpdate)
            {
                txt_Nombre.Enabled = false;
                txt_NS.Enabled = false;
                lbl_Sueldo.Enabled = false;

                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Obtener_Deptos("D");
                    cmb_Depto.DataSource = lista;

                    cmb_Depto.DisplayMember = "Nombre_Depto";
                    cmb_Depto.ValueMember = "ID";
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Deptos();
                    cmb_Depto.DataSource = lista;

                    cmb_Depto.DisplayMember = "txt_Nombre";
                    cmb_Depto.ValueMember = "ID_Departamento";
                }
            }

            if (AccionesForms.isUpdate)
            {
                txt_Nombre.Enabled = true;
                txt_NS.Enabled = true;
                lbl_Sueldo.Enabled = true;
                btn_Check.Enabled = false;
                cmb_Depto.Enabled = false;

                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Get_Depto_By_ID("E", AccionesForms.SQL_ID_Depto);
                    cmb_Depto.DataSource = lista;

                    cmb_Depto.DisplayMember = "Nombre_Depto";
                    cmb_Depto.ValueMember = "ID";

                    var puesto = enlace.Get_Puesto_By_Id("E");

                    foreach (DataRow row in puesto.Rows)
                    {
                        txt_Nombre.Text = (string)row["Nombre_Puesto"];
                        txt_NS.Text = row["Nivel_Salarial"].ToString();
                    }
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Depto_By_Id(AccionesForms.ID_Depto);
                    cmb_Depto.DataSource = lista;

                    cmb_Depto.DisplayMember = "txt_Nombre";
                    cmb_Depto.ValueMember = "ID_Departamento";
                }
            }
        }

        private void Form_ABC_Puestos_Closing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if(ObtenerInfo())
                this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool ObtenerInfo()
        {
            bool isNotEmpty = ValidacionesVacios();
            if (!isNotEmpty)
            {
                MessageBox.Show("Campos vacios", "ERROR", MessageBoxButtons.OK);
                return false;
            }
            
            Puesto Pue = new Puesto();
            Departamento Dep = new Departamento();
            
            
            Dep.txt_Nombre = cmb_Depto.Text;

            if (AccionesForms.enlace == true)
            {
                Dep.ID_Departamento = (Guid)cmb_Depto.SelectedValue;
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Depto_By_Id(Dep.ID_Departamento);
                foreach (var row in lista)
                {
                    Sueldo_Base = row.money_SB;
                    break;
                }

                Salario_Diario = float.Parse(txt_NS.Text);
                Salario_Diario = Salario_Diario * Sueldo_Base;
                Pue.money_SalarioDiario = Salario_Diario;
            }

            Pue.txt_Nombre = txt_Nombre.Text;
            Pue.fNivelSalarial = float.Parse(txt_NS.Text);

            if (!AccionesForms.isUpdate)
            {
                if (AccionesForms.enlace == false)
                {
                    Pue.ID_Departamento = (int)cmb_Depto.SelectedValue;
                    EnlaceDB enlaceDB = new EnlaceDB();
                    enlaceDB.Acciones_Puesto("A", Pue);
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Agregar_Puesto("A", Pue, Dep);
                }
            }

            if (AccionesForms.isUpdate)
            {
                if (AccionesForms.enlace == false)
                {
                    Pue.ID_Departamento = (int)cmb_Depto.SelectedValue;
                    EnlaceDB enlaceDB = new EnlaceDB();
                    enlaceDB.Acciones_Puesto("C", Pue);
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Update_Puesto(Pue);
                }
            }
            MessageBox.Show("Informacion cargada con exito", "Registro", MessageBoxButtons.OK);
            return true;
        }

        private void lbl_Sueldo_Click(object sender, EventArgs e)
        {
            if (txt_NS.Text != "")
            {
                if (AccionesForms.enlace == false)
                {
                    sql_id_depto = (int)cmb_Depto.SelectedValue;
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Get_Depto_By_ID("E", sql_id_depto);
                    foreach (DataRow row in lista.Rows)
                    {
                        Sueldo_Base = float.Parse(row["Sueldo_Base"].ToString());
                        break;
                    }

                    Salario_Diario = float.Parse(txt_NS.Text);
                    Salario_Diario = Salario_Diario * Sueldo_Base;
                    lbl_Sueldo.Text = Salario_Diario.ToString();
                }

                if (AccionesForms.enlace == true)
                {
                    id_depto = (Guid)cmb_Depto.SelectedValue;
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Depto_By_Id(id_depto);
                    foreach (var row in lista)
                    {
                        Sueldo_Base = row.money_SB;
                        break;
                    }

                    Salario_Diario = float.Parse(txt_NS.Text);
                    Salario_Diario = Salario_Diario * Sueldo_Base;
                    lbl_Sueldo.Text = Salario_Diario.ToString();
                }
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            txt_Nombre.Enabled = true;
            txt_NS.Enabled = true;
            lbl_Sueldo.Enabled = true;
            btn_Check.Enabled = false;
            cmb_Depto.Enabled = false;
        }

        bool ValidacionesVacios()
        {
            if (cmb_Depto.Text == "")
                return false;

            if (txt_Nombre.Text == "")
                return false;

            if (txt_NS.Text == "")
                return false;

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
    }
}
