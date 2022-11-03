using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ventanas_Finales_Siksi.Tablas_CQL;

namespace Ventanas_Finales_Siksi
{
    public partial class Form_Listado_Departamentos : Form
    {
        AccionesForms ObjAcciones = new AccionesForms();
        Guid id_depto;

        public Form_Listado_Departamentos()
        {
            InitializeComponent();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            AccionesForms.isUpdate = true;
            ObjAcciones.AbrirDlgDepartamentos();
            AccionesForms.isUpdate = false;

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista = enlace.Obtener_Deptos("D");

                tabla_Departamentos.DataSource = lista;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Deptos();

                tabla_Departamentos.DataSource = lista;

                tabla_Departamentos.Columns["ID_Gerente"].Visible = false;
                tabla_Departamentos.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
                tabla_Departamentos.Columns["txt_ApePat"].Visible = false;
                tabla_Departamentos.Columns["txt_ApeMat"].Visible = false;

                tabla_Departamentos.Columns["ID_Departamento"].HeaderText = "ID";
                tabla_Departamentos.Columns["txt_Nombre"].HeaderText = "NOMBRE DEPARTAMENTO";
                tabla_Departamentos.Columns["money_SB"].HeaderText = "SUELDO BASE";
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            ObjAcciones.AbrirDlgDepartamentos();

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista = enlace.Obtener_Deptos("D");

                tabla_Departamentos.DataSource = lista;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Deptos();

                tabla_Departamentos.DataSource = lista;

                tabla_Departamentos.Columns["ID_Gerente"].Visible = false;
                tabla_Departamentos.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
                tabla_Departamentos.Columns["txt_ApePat"].Visible = false;
                tabla_Departamentos.Columns["txt_ApeMat"].Visible = false;

                tabla_Departamentos.Columns["ID_Departamento"].HeaderText = "ID";
                tabla_Departamentos.Columns["txt_Nombre"].HeaderText = "NOMBRE DEPARTAMENTO";
                tabla_Departamentos.Columns["money_SB"].HeaderText = "SUELDO BASE";
            }

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar el departamento seleccionado junto con los puestos y empleados relacionados?", "Eliminar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var lista_emp = enlace.Get_Empleados_By_Deptos("K");

                    foreach (DataRow row in lista_emp.Rows)
                    {
                        AccionesForms.SQL_ID_Empleado = (int)row["ID_Empleado"];
                        enlace.Acciones_Empleado("B", null, null);
                    }

                    Puesto pue = new Puesto();
                    var lista_pue = enlace.Get_Puestos_By_Deptos("G", AccionesForms.SQL_ID_Depto);

                    foreach (DataRow row in lista_pue.Rows)
                    {
                        pue.ID_Puesto = (int)row["ID"];
                        enlace.Acciones_Puesto("B", pue);
                    }

                    enlace.Acciones_Departamento("B", null, AccionesForms.SQL_ID_Depto);

                    var lista = enlace.Obtener_Deptos("D");

                    tabla_Departamentos.DataSource = lista;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Baja_Departamento_Y_Relacionados(AccionesForms.ID_Empresa, AccionesForms.ID_Depto);

                    var lista = enlace.Get_Deptos();
                    tabla_Departamentos.DataSource = lista;

                    tabla_Departamentos.Columns["ID_Gerente"].Visible = false;
                    tabla_Departamentos.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
                    tabla_Departamentos.Columns["txt_ApePat"].Visible = false;
                    tabla_Departamentos.Columns["txt_ApeMat"].Visible = false;

                    tabla_Departamentos.Columns["ID_Departamento"].HeaderText = "ID";
                    tabla_Departamentos.Columns["txt_Nombre"].HeaderText = "NOMBRE DEPARTAMENTO";
                    tabla_Departamentos.Columns["money_SB"].HeaderText = "SUELDO BASE";
                }
            }
        }

        private void Form_Listado_Departamentos_Load(object sender, EventArgs e)
        {
            if (AccionesForms.user == 1)
            {
                btn_Regresar.Visible = false;
            }

            if (AccionesForms.user == 2)
            {
                btn_MdoEmlpeado.Visible = false;
            }

            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;
            cmb_IDGerente.Enabled = false;
            btn_Check.Enabled = false;

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista = enlace.Obtener_Deptos("D");

                tabla_Departamentos.DataSource = lista;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Deptos();

                tabla_Departamentos.DataSource = lista;

                tabla_Departamentos.Columns["ID_Gerente"].Visible = false;
                tabla_Departamentos.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
                tabla_Departamentos.Columns["txt_ApePat"].Visible = false;
                tabla_Departamentos.Columns["txt_ApeMat"].Visible = false;

                tabla_Departamentos.Columns["ID_Departamento"].HeaderText = "ID";
                tabla_Departamentos.Columns["txt_Nombre"].HeaderText = "NOMBRE";
                tabla_Departamentos.Columns["money_SB"].HeaderText = "SUELDO BASE";
            }
        }

        private void Form_Listado_Departamentos_Closing(object sender, FormClosingEventArgs e)
        {
            if (AccionesForms.isClosing == true) {
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

        private void menu_Pue_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirPuestos();
            AccionesForms.isClosing = true;
        }

        private void menu_Emp_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirEmpleados();
            AccionesForms.isClosing = true;
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirEmpresa();
            AccionesForms.isClosing = true;
        }

        private void btn_MdoEmlpeado_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirControlEmpleado();
            AccionesForms.isClosing = true;
        }

        private void tabla_Departamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tabla_Departamentos.Rows[e.RowIndex];

                cmb_IDGerente.Enabled = true;
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;
                btn_Check.Enabled = true;

                if (AccionesForms.enlace == false)
                {
                    tabla_Departamentos.CurrentRow.Selected = true;
                    AccionesForms.SQL_ID_Depto = int.Parse(tabla_Departamentos.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());

                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Get_Empleados_By_Depto("I");
                    cmb_IDGerente.DataSource = lista;

                    cmb_IDGerente.DisplayMember = "Nombre_Completo";
                    cmb_IDGerente.ValueMember = "ID_Empleado";
                }

                if (AccionesForms.enlace == true)
                {
                    tabla_Departamentos.CurrentRow.Selected = true;
                    id_depto = Guid.Parse(tabla_Departamentos.Rows[e.RowIndex].Cells["ID_Departamento"].FormattedValue.ToString());
                    AccionesForms.ID_Depto = id_depto;

                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Empleados_By_Depto(AccionesForms.ID_Empresa, id_depto);
                    cmb_IDGerente.DataSource = lista;

                    cmb_IDGerente.DisplayMember = "txt_Nom_Empleado";
                    cmb_IDGerente.ValueMember = "ID_Empleado";
                }
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            if (cmb_IDGerente.Text != "")
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    Empleado_info emp = new Empleado_info();
                    emp.ID_Empleado = (int)cmb_IDGerente.SelectedValue;
                    enlace.Acciones_Empleado("J", emp, null);

                    var lista = enlace.Obtener_Deptos("D");
                    tabla_Departamentos.DataSource = lista;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    CQL_Empleados_By_Empresa emp = new CQL_Empleados_By_Empresa();
                    emp.ID_Empleado = (Guid)cmb_IDGerente.SelectedValue;
                    emp.txt_NombreCompleto = cmb_IDGerente.Text;
                    enlace.Update_Gerente_Depto(emp, id_depto);
                    
                    var lista = enlace.Get_Deptos();
                    tabla_Departamentos.DataSource = lista;

                    tabla_Departamentos.Columns["ID_Gerente"].Visible = false;
                    tabla_Departamentos.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
                    tabla_Departamentos.Columns["txt_ApePat"].Visible = false;
                    tabla_Departamentos.Columns["txt_ApeMat"].Visible = false;

                    tabla_Departamentos.Columns["ID_Departamento"].HeaderText = "ID";
                    tabla_Departamentos.Columns["txt_Nombre"].HeaderText = "NOMBRE DEPARTAMENTO";
                    tabla_Departamentos.Columns["money_SB"].HeaderText = "SUELDO BASE";
                }

                MessageBox.Show("El nuevo gerente de la empresa es: " + cmb_IDGerente.Text, "Nuevo Gerente", MessageBoxButtons.OK);
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
