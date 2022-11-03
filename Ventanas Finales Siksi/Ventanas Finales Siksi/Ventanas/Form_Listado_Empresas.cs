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
    public partial class Form_Listado_Empresas : Form
    {
        AccionesForms ObjAcciones = new AccionesForms();
        int ID_Seleccionado = 0;
        Guid ID_Select;

        public Form_Listado_Empresas() 
        {
            InitializeComponent();
            //btn_Editar.Enabled = false;
            //btn_Eliminar.Enabled = false;
            //btn_Propiedades.Enabled = false;
        }

        private void Dlg_Principal_Load(object sender, EventArgs e) 
        {
            cmb_IDGerente.Enabled = false;
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;
            btn_Propiedades.Enabled = false;
            btn_Check.Enabled = false;

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                DataTable tabla = enlace.Obtener_Empresa("D");

                Empresa emp = new Empresa();

                foreach (DataRow fila in tabla.Rows)
                {
                    emp.ID_Domicilio = (int)fila["ID_Empresa"];
                }

                tabla_Empresas.DataSource = tabla;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Empresas();
                
                tabla_Empresas.DataSource = lista;

                tabla_Empresas.Columns["ID_Gerente"].Visible = false;
                tabla_Empresas.Columns["txt_ApePat"].Visible = false;
                tabla_Empresas.Columns["txt_ApeMat"].Visible = false;

                tabla_Empresas.Columns["ID_Empresa"].HeaderText = "ID";
                tabla_Empresas.Columns["txt_RS"].HeaderText = "RAZON SOCIAL";
                tabla_Empresas.Columns["txt_Email"].HeaderText = "EMAIL";
                tabla_Empresas.Columns["txt_RP"].HeaderText = "REGISTRO PATRONAL";
                tabla_Empresas.Columns["txt_RF"].HeaderText = "REGISTRO FISCAL";
                tabla_Empresas.Columns["date_FInicio"].HeaderText = "FECHA DE INICIO";
                tabla_Empresas.Columns["int_FP"].Visible = false;
                tabla_Empresas.Columns["txt_Calle"].HeaderText = "CALLE";
                tabla_Empresas.Columns["txt_Num"].HeaderText = "NUMERO";
                tabla_Empresas.Columns["txt_Colonia"].HeaderText = "COLONIA";
                tabla_Empresas.Columns["txt_Municipio"].HeaderText = "MUNICIPIO";
                tabla_Empresas.Columns["txt_Estado"].HeaderText = "ESTADO";
                tabla_Empresas.Columns["txt_CP"].HeaderText = "CODIGO POSTAL";
                tabla_Empresas.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
            }
        }

        private void Dlg_Principal_Closing(object sender, FormClosingEventArgs e)  
        {
            if (AccionesForms.isClosing)
            {
                DialogResult result = MessageBox.Show("¿Desea salir del sistema?", "Saliendo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
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

        private void btn_Propiedades_Click(object sender, EventArgs e) 
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirDepartamentos();
            AccionesForms.isClosing = true;
        }

        private void btn_Agregar_Click_1(object sender, EventArgs e)
        {
            ObjAcciones.AbrirDlgEmpresa();
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                DataTable tabla = enlace.Obtener_Empresa("D");
                tabla_Empresas.DataSource = tabla;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Empresas();

                tabla_Empresas.DataSource = lista;

                tabla_Empresas.Columns["ID_Gerente"].Visible = false;
                tabla_Empresas.Columns["txt_ApePat"].Visible = false;
                tabla_Empresas.Columns["txt_ApeMat"].Visible = false;

                tabla_Empresas.Columns["txt_RS"].HeaderText = "RAZON SOCIAL";
                tabla_Empresas.Columns["txt_Email"].HeaderText = "EMAIL";
                tabla_Empresas.Columns["txt_RP"].HeaderText = "REGISTRO PATRONAL";
                tabla_Empresas.Columns["txt_RF"].HeaderText = "REGISTRO FISCAL";
                tabla_Empresas.Columns["date_FInicio"].HeaderText = "FECHA DE INICIO";
                tabla_Empresas.Columns["int_FP"].Visible = false;
                tabla_Empresas.Columns["txt_Calle"].HeaderText = "CALLE";
                tabla_Empresas.Columns["txt_Num"].HeaderText = "NUMERO";
                tabla_Empresas.Columns["txt_Colonia"].HeaderText = "COLONIA";
                tabla_Empresas.Columns["txt_Municipio"].HeaderText = "MUNICIPIO";
                tabla_Empresas.Columns["txt_Estado"].HeaderText = "ESTADO";
                tabla_Empresas.Columns["txt_CP"].HeaderText = "CODIGO POSTAL";
                tabla_Empresas.Columns["ID_Empresa"].HeaderText = "ID";
                tabla_Empresas.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
            }
        }

        private void tabla_Empresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_Eliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar la empresa seleccionada junto con todos los puestos y empleados registrados en ella?", "Eliminar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes) {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    DataTable lista_emp = enlace.Obtener_EmpleadoInfo("F", AccionesForms.SQL_ID_Empresa);

                    foreach (DataRow row in lista_emp.Rows)
                    {
                        AccionesForms.SQL_ID_Empleado = (int)row["ID_Empleado"];
                        enlace.Acciones_Empleado("B", null, null);
                    }

                    Puesto pue = new Puesto();
                    var lista_pue = enlace.Get_Puesto_By_Empresa("H", AccionesForms.SQL_ID_Empresa);

                    foreach (DataRow row in lista_pue.Rows)
                    {
                        pue.ID_Puesto = (int)row["ID"];
                        enlace.Acciones_Puesto("B", pue);
                    }

                    enlace.Acciones_Empresa("B", null, null, AccionesForms.SQL_ID_Empresa);

                    var lista = enlace.Obtener_Empresa("D");
                    tabla_Empresas.DataSource = lista;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Baja_Empresa_Y_Relacionados(AccionesForms.ID_Empresa);

                    var lista = enlace.Get_Empresas();
                    tabla_Empresas.DataSource = lista;

                    tabla_Empresas.Columns["ID_Gerente"].Visible = false;
                    tabla_Empresas.Columns["txt_ApePat"].Visible = false;
                    tabla_Empresas.Columns["txt_ApeMat"].Visible = false;

                    tabla_Empresas.Columns["ID_Empresa"].HeaderText = "ID";
                    tabla_Empresas.Columns["txt_RS"].HeaderText = "RAZON SOCIAL";
                    tabla_Empresas.Columns["txt_Email"].HeaderText = "EMAIL";
                    tabla_Empresas.Columns["txt_RP"].HeaderText = "REGISTRO PATRONAL";
                    tabla_Empresas.Columns["txt_RF"].HeaderText = "REGISTRO FISCAL";
                    tabla_Empresas.Columns["date_FInicio"].HeaderText = "FECHA DE INICIO";
                    tabla_Empresas.Columns["int_FP"].Visible = false;
                    tabla_Empresas.Columns["txt_Calle"].HeaderText = "CALLE";
                    tabla_Empresas.Columns["txt_Num"].HeaderText = "NUMERO";
                    tabla_Empresas.Columns["txt_Colonia"].HeaderText = "COLONIA";
                    tabla_Empresas.Columns["txt_Municipio"].HeaderText = "MUNICIPIO";
                    tabla_Empresas.Columns["txt_Estado"].HeaderText = "ESTADO";
                    tabla_Empresas.Columns["txt_CP"].HeaderText = "CODIGO POSTAL";
                    tabla_Empresas.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
                }
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Form_ABC_Empresa formEmpresa = new Form_ABC_Empresa();
            AccionesForms.isUpdate = true;
            formEmpresa.ShowDialog();
            AccionesForms.isUpdate = false;

            if (AccionesForms.enlace == false)
            {

            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Empresas();

                tabla_Empresas.DataSource = lista;

                tabla_Empresas.Columns["ID_Gerente"].Visible = false;
                tabla_Empresas.Columns["txt_ApePat"].Visible = false;
                tabla_Empresas.Columns["txt_ApeMat"].Visible = false;

                tabla_Empresas.Columns["txt_RS"].HeaderText = "RAZON SOCIAL";
                tabla_Empresas.Columns["txt_Email"].HeaderText = "EMAIL";
                tabla_Empresas.Columns["txt_RP"].HeaderText = "REGISTRO PATRONAL";
                tabla_Empresas.Columns["txt_RF"].HeaderText = "REGISTRO FISCAL";
                tabla_Empresas.Columns["date_FInicio"].HeaderText = "FECHA DE INICIO";
                tabla_Empresas.Columns["int_FP"].Visible = false;
                tabla_Empresas.Columns["txt_Calle"].HeaderText = "CALLE";
                tabla_Empresas.Columns["txt_Num"].HeaderText = "NUMERO";
                tabla_Empresas.Columns["txt_Colonia"].HeaderText = "COLONIA";
                tabla_Empresas.Columns["txt_Municipio"].HeaderText = "MUNICIPIO";
                tabla_Empresas.Columns["txt_Estado"].HeaderText = "ESTADO";
                tabla_Empresas.Columns["txt_CP"].HeaderText = "CODIGO POSTAL";
                tabla_Empresas.Columns["ID_Empresa"].HeaderText = "ID";
                tabla_Empresas.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
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
                    enlace.Acciones_Empleado("E", emp, null);

                    DataTable tabla = enlace.Obtener_Empresa("D");
                    tabla_Empresas.DataSource = tabla;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    CQL_Empleados_By_Empresa emp = new CQL_Empleados_By_Empresa();
                    emp.ID_Empleado = (Guid)cmb_IDGerente.SelectedValue;
                    emp.txt_NombreCompleto = cmb_IDGerente.Text;
                    enlace.Update_Gerente_Empresa(emp);

                    var lista = enlace.Get_Empresas();

                    tabla_Empresas.DataSource = lista;

                    tabla_Empresas.Columns["ID_Gerente"].Visible = false;
                    tabla_Empresas.Columns["txt_ApePat"].Visible = false;
                    tabla_Empresas.Columns["txt_ApeMat"].Visible = false;

                    tabla_Empresas.Columns["ID_Empresa"].HeaderText = "ID";
                    tabla_Empresas.Columns["txt_RS"].HeaderText = "RAZON SOCIAL";
                    tabla_Empresas.Columns["txt_Email"].HeaderText = "EMAIL";
                    tabla_Empresas.Columns["txt_RP"].HeaderText = "REGISTRO PATRONAL";
                    tabla_Empresas.Columns["txt_RF"].HeaderText = "REGISTRO FISCAL";
                    tabla_Empresas.Columns["date_FInicio"].HeaderText = "FECHA DE INICIO";
                    tabla_Empresas.Columns["int_FP"].HeaderText = "FRECUENCIA DE PAGO";
                    tabla_Empresas.Columns["txt_Calle"].HeaderText = "CALLE";
                    tabla_Empresas.Columns["txt_Num"].HeaderText = "NUMERO";
                    tabla_Empresas.Columns["txt_Colonia"].HeaderText = "COLONIA";
                    tabla_Empresas.Columns["txt_Municipio"].HeaderText = "MUNICIPIO";
                    tabla_Empresas.Columns["txt_Estado"].HeaderText = "ESTADO";
                    tabla_Empresas.Columns["txt_CP"].HeaderText = "CODIGO POSTAL";
                    tabla_Empresas.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE GERENTE";
                }

                MessageBox.Show("El nuevo gerente de la empresa es: " + cmb_IDGerente.Text, "Nuevo Gerente", MessageBoxButtons.OK);
            }
        }

        private void tabla_Empresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tabla_Empresas.Rows[e.RowIndex];

                cmb_IDGerente.Enabled = true;
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;
                btn_Propiedades.Enabled = true;
                btn_Check.Enabled = true;

                if (AccionesForms.enlace == false)
                {
                    tabla_Empresas.CurrentRow.Selected = true;
                    ID_Seleccionado = int.Parse(tabla_Empresas.Rows[e.RowIndex].Cells["ID_Empresa"].FormattedValue.ToString());
                    AccionesForms.SQL_ID_Empresa = int.Parse(tabla_Empresas.Rows[e.RowIndex].Cells["ID_Empresa"].FormattedValue.ToString());

                    EnlaceDB enlace = new EnlaceDB();
                    DataTable tabla = enlace.Obtener_EmpleadoInfo("F", AccionesForms.SQL_ID_Empresa);
                    cmb_IDGerente.DataSource = tabla;

                    cmb_IDGerente.DisplayMember = "Nombre_Completo";
                    cmb_IDGerente.ValueMember = "ID_Empleado";
                }

                if (AccionesForms.enlace == true)
                {
                    tabla_Empresas.CurrentRow.Selected = true;
                    AccionesForms.ID_Empresa = Guid.Parse(tabla_Empresas.Rows[e.RowIndex].Cells["ID_Empresa"].FormattedValue.ToString());
                    AccionesForms.txt_Empresa = tabla_Empresas.Rows[e.RowIndex].Cells["txt_RS"].FormattedValue.ToString();

                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Empleados_By_Empresa(AccionesForms.ID_Empresa);
                    cmb_IDGerente.DataSource = lista;

                    cmb_IDGerente.DisplayMember = "txt_Nom_Empleado";
                    cmb_IDGerente.ValueMember = "ID_Empleado";
                }
            }
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            ObjAcciones.AbrirDlgReportes();
        }
    }
}
