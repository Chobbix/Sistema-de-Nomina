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
    public partial class Form_Listado_Puestos : Form
    {
        AccionesForms ObjAcciones = new AccionesForms();
        Guid id_puesto;

        public Form_Listado_Puestos()
        {
            InitializeComponent();
        }

        private void Form_Listado_Puestos_Load(object sender, EventArgs e)
        {
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;
            tabla_Puestos.Enabled = false;

            if (AccionesForms.user == 1)
            {
                btn_Regresar.Visible = false;
            }

            if (AccionesForms.user == 2)
            {
                btn_MdoEmpleado.Visible = false;
            }

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista = enlace.Obtener_Deptos("D");
                cmb_IDDeptos.DataSource = lista;

                cmb_IDDeptos.DisplayMember = "Nombre_Depto";
                cmb_IDDeptos.ValueMember = "ID";
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Deptos();
                cmb_IDDeptos.DataSource = lista;

                cmb_IDDeptos.DisplayMember = "txt_Nombre";
                cmb_IDDeptos.ValueMember = "ID_Departamento";
            }
        }

        private void Form_Listado_Puestos_Closing(object sender, FormClosingEventArgs e)
        {
            if (AccionesForms.isClosing == true)
            {
                DialogResult resultado = MessageBox.Show("¿Desea salir del sistema?", "Saliendo", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    if (AccionesForms.enlace == true)
                        EnlaceCassandra.desconectar();

                    Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            ObjAcciones.AbrirDlgPuestos();
            if (AccionesForms.enlace == false)
            {

            }

            if (AccionesForms.enlace == true)
            {
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            AccionesForms.isUpdate = true;
            ObjAcciones.AbrirDlgPuestos();
            AccionesForms.isUpdate = false;

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                int SQL_id_depto = (int)cmb_IDDeptos.SelectedValue;
                var lista = enlace.Get_Puestos_By_Depto("D", AccionesForms.SQL_ID_Empresa, SQL_id_depto);

                tabla_Puestos.DataSource = lista;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Puestos_By_Empresa_Depto(AccionesForms.ID_Empresa, AccionesForms.ID_Depto);

                tabla_Puestos.DataSource = lista;

                tabla_Puestos.Columns["ID_Departamento"].Visible = false;
                tabla_Puestos.Columns["ID_Empresa"].Visible = false;
                tabla_Puestos.Columns["txt_Nom_Depto"].Visible = false;
                tabla_Puestos.Columns["txt_RS"].Visible = false;

                tabla_Puestos.Columns["ID_Puesto"].HeaderText = "ID";
                tabla_Puestos.Columns["txt_Nom_Pue"].HeaderText = "NOMBRE DE PUESTO";
                tabla_Puestos.Columns["money_SD"].Visible = false;
                tabla_Puestos.Columns["float_NS"].HeaderText = "NIVEL SALARIAL";
                tabla_Puestos.Columns["money_SB"].Visible = false;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar el puesto seleccionado junto con los empleados registrados en el?", "Eliminar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var puesto = enlace.Get_Empleados_By_Puesto("F", AccionesForms.SQL_ID_Puesto);

                    foreach (DataRow row in puesto.Rows)
                    {
                        AccionesForms.SQL_ID_Empleado = (int)row["ID_Empleado"];
                        enlace.Acciones_Empleado("B", null, null);
                    }

                    Puesto pue = new Puesto();
                    pue.ID_Puesto = AccionesForms.SQL_ID_Puesto;
                    enlace.Acciones_Puesto("B", pue);

                    int SQL_id_depto = (int)cmb_IDDeptos.SelectedValue;
                    AccionesForms.SQL_ID_Depto = SQL_id_depto;
                    var lista = enlace.Get_Puestos_By_Depto("D", AccionesForms.SQL_ID_Empresa, SQL_id_depto);

                    tabla_Puestos.DataSource = lista;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Baja_Puesto_Y_Relacionados(AccionesForms.ID_Empresa, AccionesForms.ID_Depto, AccionesForms.ID_Puesto);
                    var lista = enlace.Get_Puestos_By_Empresa_Depto(AccionesForms.ID_Empresa, AccionesForms.ID_Depto);

                    tabla_Puestos.DataSource = lista;

                    tabla_Puestos.Columns["ID_Departamento"].Visible = false;
                    tabla_Puestos.Columns["ID_Empresa"].Visible = false;
                    tabla_Puestos.Columns["txt_Nom_Depto"].Visible = false;
                    tabla_Puestos.Columns["txt_RS"].Visible = false;

                    tabla_Puestos.Columns["ID_Puesto"].HeaderText = "ID";
                    tabla_Puestos.Columns["txt_Nom_Pue"].HeaderText = "NOMBRE DE PUESTO";
                    tabla_Puestos.Columns["money_SD"].HeaderText = "SALARIO DIARIO";
                    tabla_Puestos.Columns["float_NS"].Visible = false;
                    tabla_Puestos.Columns["money_SB"].Visible = false;
                }
            }
        }

        private void menu_Dep_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            AccionesForms.isClosing = true;
            ObjAcciones.AbrirDepartamentos();
        }

        private void menu_Emp_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            AccionesForms.isClosing = true;
            ObjAcciones.AbrirEmpleados();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirEmpresa();
            AccionesForms.isClosing = true;
        }

        private void btn_MdoEmpleado_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirControlEmpleado();
            AccionesForms.isClosing = true;
        }

        private void tabla_Puestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btn_Editar.Enabled = false;
                btn_Eliminar.Enabled = false;

                if (AccionesForms.enlace == false)
                {
                    btn_Eliminar.Enabled = true;
                    btn_Editar.Enabled = true;

                    tabla_Puestos.CurrentRow.Selected = true;
                    AccionesForms.SQL_ID_Puesto = int.Parse(tabla_Puestos.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                }

                if (AccionesForms.enlace == true)
                {
                    btn_Eliminar.Enabled = true;
                    btn_Editar.Enabled = true;

                    tabla_Puestos.CurrentRow.Selected = true;
                    AccionesForms.ID_Puesto = Guid.Parse(tabla_Puestos.Rows[e.RowIndex].Cells["ID_Puesto"].FormattedValue.ToString());
                }
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            if (cmb_IDDeptos.Text != "")
            {
                Guid id_depto;
                tabla_Puestos.Enabled = true;
                cmb_IDDeptos.Enabled = false;
                btn_Check.Enabled = false;
                btn_Agregar.Enabled = false;

                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    int SQL_id_depto = (int)cmb_IDDeptos.SelectedValue;
                    AccionesForms.SQL_ID_Depto = SQL_id_depto;
                    var lista = enlace.Get_Puestos_By_Depto("D", AccionesForms.SQL_ID_Empresa, SQL_id_depto);

                    tabla_Puestos.DataSource = lista;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    id_depto = (Guid)cmb_IDDeptos.SelectedValue;
                    AccionesForms.ID_Depto = id_depto;
                    var lista = enlace.Get_Puestos_By_Empresa_Depto(AccionesForms.ID_Empresa, id_depto);

                    tabla_Puestos.DataSource = lista;

                    tabla_Puestos.Columns["ID_Departamento"].Visible = false;
                    tabla_Puestos.Columns["ID_Empresa"].Visible = false;
                    tabla_Puestos.Columns["txt_Nom_Depto"].Visible = false;
                    tabla_Puestos.Columns["txt_RS"].Visible = false;

                    tabla_Puestos.Columns["ID_Puesto"].HeaderText = "ID";
                    tabla_Puestos.Columns["txt_Nom_Pue"].HeaderText = "NOMBRE DE PUESTO";
                    tabla_Puestos.Columns["money_SD"].Visible = false;
                    tabla_Puestos.Columns["float_NS"].HeaderText = "NIVEL SALARIAL";
                    tabla_Puestos.Columns["money_SB"].Visible = false;
                }
            }
        }

        private void menu_Nomina_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirNomina();
            AccionesForms.isClosing = true;
        }
    }
}
