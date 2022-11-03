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
    public partial class Form_Listado_Empleados : Form
    {
        AccionesForms ObjAcciones = new AccionesForms();
        Guid id_empleado;

        public Form_Listado_Empleados()
        {
            InitializeComponent();
        }

        private void Form_Listado_Empleados_Load(object sender, EventArgs e)
        {
            btn_Editar.Enabled = false;
            btn_Eliminar.Enabled = false;

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
                var lista = enlace.Get_Empleados_By_Empresa("D");
                tabla_Empleados.DataSource = lista;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Empleados_By_Empresa(AccionesForms.ID_Empresa);

                tabla_Empleados.DataSource = lista;

                tabla_Empleados.Columns["ID_Empleado"].HeaderText = "ID";
                tabla_Empleados.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE/S";
                tabla_Empleados.Columns["txt_ApePat"].HeaderText = "APELLIDO PATERNO";
                tabla_Empleados.Columns["txt_ApeMat"].HeaderText = "APELLIDO MATERNO";
                tabla_Empleados.Columns["txt_NSS"].HeaderText = "NSS";
                tabla_Empleados.Columns["txt_RFC"].HeaderText = "RFC";
                tabla_Empleados.Columns["txt_Email"].HeaderText = "EMAIL";
                tabla_Empleados.Columns["txt_Telefono"].HeaderText = "TELEFONO";
                tabla_Empleados.Columns["date_FchaNac"].HeaderText = "FECHA DE NACIMIENTO";
                tabla_Empleados.Columns["date_FchaInicio"].HeaderText = "FECHA DE INICIO";
                tabla_Empleados.Columns["int_FP"].HeaderText = "FRECUENCIA DE PAGO";

                tabla_Empleados.Columns["ID_Empresa"].Visible = false;
                tabla_Empleados.Columns["txt_Contra"].Visible = false;
                tabla_Empleados.Columns["txt_CURP"].Visible = false;
                tabla_Empleados.Columns["txt_Banco"].Visible = false;
                tabla_Empleados.Columns["int_Dias"].Visible = false;
                tabla_Empleados.Columns["int_tipo"].Visible = false;
                tabla_Empleados.Columns["float_SueldoBase"].Visible = false;
                tabla_Empleados.Columns["txt_Calle"].Visible = false;
                tabla_Empleados.Columns["txt_Num"].Visible = false;
                tabla_Empleados.Columns["txt_Colonia"].Visible = false;
                tabla_Empleados.Columns["txt_Municipio"].Visible = false;
                tabla_Empleados.Columns["txt_Estado"].Visible = false;
                tabla_Empleados.Columns["txt_CP"].Visible = false;
                tabla_Empleados.Columns["int_GerDepto"].Visible = false;
                tabla_Empleados.Columns["txt_NumCuenta"].Visible = false;
                tabla_Empleados.Columns["ID_Depto"].Visible = false;
                tabla_Empleados.Columns["ID_Puesto"].Visible = false;
            }
        }

        private void Form_Listado_Empleados_Closing(object sender, FormClosingEventArgs e)
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
            ObjAcciones.AbrirDlgEmpleados();

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista = enlace.Get_Empleados_By_Empresa("D");
                tabla_Empleados.DataSource = lista;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Empleados_By_Empresa(AccionesForms.ID_Empresa);

                tabla_Empleados.DataSource = lista;

                tabla_Empleados.Columns["ID_Empleado"].HeaderText = "ID";
                tabla_Empleados.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE/S";
                tabla_Empleados.Columns["txt_ApePat"].HeaderText = "APELLIDO PATERNO";
                tabla_Empleados.Columns["txt_ApeMat"].HeaderText = "APELLIDO MATERNO";
                tabla_Empleados.Columns["txt_NSS"].HeaderText = "NSS";
                tabla_Empleados.Columns["txt_RFC"].HeaderText = "RFC";
                tabla_Empleados.Columns["txt_Email"].HeaderText = "EMAIL";
                tabla_Empleados.Columns["txt_Telefono"].HeaderText = "TELEFONO";
                tabla_Empleados.Columns["date_FchaNac"].HeaderText = "FECHA DE NACIMIENTO";
                tabla_Empleados.Columns["date_FchaInicio"].HeaderText = "FECHA DE INICIO";
                tabla_Empleados.Columns["int_FP"].HeaderText = "FRECUENCIA DE PAGO";

                tabla_Empleados.Columns["ID_Empresa"].Visible = false;
                tabla_Empleados.Columns["txt_Contra"].Visible = false;
                tabla_Empleados.Columns["txt_CURP"].Visible = false;
                tabla_Empleados.Columns["txt_Banco"].Visible = false;
                tabla_Empleados.Columns["int_Dias"].Visible = false;
                tabla_Empleados.Columns["int_tipo"].Visible = false;
                tabla_Empleados.Columns["float_SueldoBase"].Visible = false;
                tabla_Empleados.Columns["txt_Calle"].Visible = false;
                tabla_Empleados.Columns["txt_Num"].Visible = false;
                tabla_Empleados.Columns["txt_Colonia"].Visible = false;
                tabla_Empleados.Columns["txt_Municipio"].Visible = false;
                tabla_Empleados.Columns["txt_Estado"].Visible = false;
                tabla_Empleados.Columns["txt_CP"].Visible = false;
                tabla_Empleados.Columns["int_GerDepto"].Visible = false;
                tabla_Empleados.Columns["txt_NumCuenta"].Visible = false;
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            AccionesForms.isUpdate = true;
            ObjAcciones.AbrirDlgEmpleados();
            AccionesForms.isUpdate = false;

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista = enlace.Get_Empleados_By_Empresa("D");
                tabla_Empleados.DataSource = lista;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Empleados_By_Empresa(AccionesForms.ID_Empresa);

                tabla_Empleados.DataSource = lista;

                tabla_Empleados.Columns["ID_Empleado"].HeaderText = "ID";
                tabla_Empleados.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE/S";
                tabla_Empleados.Columns["txt_ApePat"].HeaderText = "APELLIDO PATERNO";
                tabla_Empleados.Columns["txt_ApeMat"].HeaderText = "APELLIDO MATERNO";
                tabla_Empleados.Columns["txt_NSS"].HeaderText = "NSS";
                tabla_Empleados.Columns["txt_RFC"].HeaderText = "RFC";
                tabla_Empleados.Columns["txt_Email"].HeaderText = "EMAIL";
                tabla_Empleados.Columns["txt_Telefono"].HeaderText = "TELEFONO";
                tabla_Empleados.Columns["date_FchaNac"].HeaderText = "FECHA DE NACIMIENTO";
                tabla_Empleados.Columns["date_FchaInicio"].HeaderText = "FECHA DE INICIO";
                tabla_Empleados.Columns["int_FP"].HeaderText = "FRECUENCIA DE PAGO";

                tabla_Empleados.Columns["ID_Empresa"].Visible = false;
                tabla_Empleados.Columns["txt_Contra"].Visible = false;
                tabla_Empleados.Columns["txt_CURP"].Visible = false;
                tabla_Empleados.Columns["txt_Banco"].Visible = false;
                tabla_Empleados.Columns["int_Dias"].Visible = false;
                tabla_Empleados.Columns["int_tipo"].Visible = false;
                tabla_Empleados.Columns["float_SueldoBase"].Visible = false;
                tabla_Empleados.Columns["txt_Calle"].Visible = false;
                tabla_Empleados.Columns["txt_Num"].Visible = false;
                tabla_Empleados.Columns["txt_Colonia"].Visible = false;
                tabla_Empleados.Columns["txt_Municipio"].Visible = false;
                tabla_Empleados.Columns["txt_Estado"].Visible = false;
                tabla_Empleados.Columns["txt_CP"].Visible = false;
                tabla_Empleados.Columns["int_GerDepto"].Visible = false;
                tabla_Empleados.Columns["txt_NumCuenta"].Visible = false;
                tabla_Empleados.Columns["ID_Depto"].Visible = false;
                tabla_Empleados.Columns["ID_Puesto"].Visible = false;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea eliminar el empleado seleccionado?", "Eliminar", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    enlace.Acciones_Empleado("B", null, null);
                    
                    var lista = enlace.Get_Empleados_By_Empresa("D");
                    tabla_Empleados.DataSource = lista;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista2 = enlace.Get_Empleados_By_Id(AccionesForms.ID_Empresa, AccionesForms.ID_Empleado);
                    foreach (var item in lista2)
                    {
                        AccionesForms.ID_Depto = item.ID_Depto;
                        AccionesForms.ID_Puesto = item.ID_Puesto;
                    }
                    enlace.Baja_Empleado(AccionesForms.ID_Empresa, AccionesForms.ID_Depto, AccionesForms.ID_Puesto, AccionesForms.ID_Empleado);

                    var lista = enlace.Get_Empleados_By_Empresa(AccionesForms.ID_Empresa);

                    tabla_Empleados.DataSource = lista;

                    tabla_Empleados.Columns["ID_Empleado"].HeaderText = "ID";
                    tabla_Empleados.Columns["txt_Nom_Empleado"].HeaderText = "NOMBRE/S";
                    tabla_Empleados.Columns["txt_ApePat"].HeaderText = "APELLIDO PATERNO";
                    tabla_Empleados.Columns["txt_ApeMat"].HeaderText = "APELLIDO MATERNO";
                    tabla_Empleados.Columns["txt_NSS"].HeaderText = "NSS";
                    tabla_Empleados.Columns["txt_RFC"].HeaderText = "RFC";
                    tabla_Empleados.Columns["txt_Email"].HeaderText = "EMAIL";
                    tabla_Empleados.Columns["txt_Telefono"].HeaderText = "TELEFONO";
                    tabla_Empleados.Columns["date_FchaNac"].HeaderText = "FECHA DE NACIMIENTO";
                    tabla_Empleados.Columns["date_FchaInicio"].HeaderText = "FECHA DE INICIO";
                    tabla_Empleados.Columns["int_FP"].HeaderText = "FRECUENCIA DE PAGO";

                    tabla_Empleados.Columns["ID_Empresa"].Visible = false;
                    tabla_Empleados.Columns["txt_Contra"].Visible = false;
                    tabla_Empleados.Columns["txt_CURP"].Visible = false;
                    tabla_Empleados.Columns["txt_Banco"].Visible = false;
                    tabla_Empleados.Columns["int_Dias"].Visible = false;
                    tabla_Empleados.Columns["int_tipo"].Visible = false;
                    tabla_Empleados.Columns["float_SueldoBase"].Visible = false;
                    tabla_Empleados.Columns["txt_Calle"].Visible = false;
                    tabla_Empleados.Columns["txt_Num"].Visible = false;
                    tabla_Empleados.Columns["txt_Colonia"].Visible = false;
                    tabla_Empleados.Columns["txt_Municipio"].Visible = false;
                    tabla_Empleados.Columns["txt_Estado"].Visible = false;
                    tabla_Empleados.Columns["txt_CP"].Visible = false;
                    tabla_Empleados.Columns["int_GerDepto"].Visible = false;
                    tabla_Empleados.Columns["txt_NumCuenta"].Visible = false;
                }
            }
        }

        private void menu_Pue_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            AccionesForms.isClosing = true;
            ObjAcciones.AbrirPuestos();
        }

        private void menu_Dep_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            AccionesForms.isClosing = true;
            ObjAcciones.AbrirDepartamentos();
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

        private void tabla_Empleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btn_Editar.Enabled = true;
                btn_Eliminar.Enabled = true;

                if (AccionesForms.enlace == false)
                {
                    tabla_Empleados.CurrentRow.Selected = true;
                    AccionesForms.SQL_ID_Empleado = int.Parse(tabla_Empleados.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
                }

                if (AccionesForms.enlace == true)
                {
                    tabla_Empleados.CurrentRow.Selected = true;
                    id_empleado = Guid.Parse(tabla_Empleados.Rows[e.RowIndex].Cells["ID_Empleado"].FormattedValue.ToString());
                    AccionesForms.ID_Empleado = id_empleado;
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
