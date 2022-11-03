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
using iTextSharp;

namespace Ventanas_Finales_Siksi.Ventanas
{
    public partial class Form_Nomina_PerDed : Form
    {
        AccionesForms ObjAcciones = new AccionesForms();
        Guid id_persep;
        Guid id_dedu;
        int SQL_id_persep;
        int SQL_id_dedu;

        public Form_Nomina_PerDed()
        {
            InitializeComponent();
        }

        private void Form_Nomina_PerDed_Load(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                DataTable tabla = enlace.Obtener_EmpleadoInfo("F", AccionesForms.SQL_ID_Empresa);
                cmb_Empleados.DataSource = tabla;

                cmb_Empleados.DisplayMember = "Nombre_Completo";
                cmb_Empleados.ValueMember = "ID_Empleado";

                var listadoCambios = enlace.GetAllCambios("D");

                foreach (DataRow row in listadoCambios.Rows)
                {
                    if ((string)row["Tipo"] == "Percepcion")
                    {
                        if ((int)row["Activo"] == 0)
                        {
                            cmb_Percepciones.Items.Add((string)row["Nombre"]);
                        }
                    }
                    if ((string)row["Tipo"] == "Deduccion")
                    {
                        if ((int)row["Activo"] == 0)
                        {
                            cmb_Deducciones.Items.Add((string)row["Nombre"]);
                        }
                    }
                }
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Empleados_By_Empresa(AccionesForms.ID_Empresa);
                cmb_Empleados.DataSource = lista;
                cmb_Empleados.DisplayMember = "txt_Nom_Empleado";
                cmb_Empleados.ValueMember = "ID_Empleado";

                var listadoCambios = enlace.GetAll_Cambios();
                foreach (var row in listadoCambios)
                {
                    if (row.tipo == "Percepcion")
                    {
                        if (row.activo == 0)
                        {
                            cmb_Percepciones.Items.Add(row.nombre);
                        }
                    }
                    if (row.tipo == "Deduccion")
                    {
                        if (row.activo == 0)
                        {
                            cmb_Deducciones.Items.Add(row.nombre);
                        }
                    }
                }
            }
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirDepartamentos();
            AccionesForms.isClosing = true;
        }

        private void Form_Nomina_PerDed_Closing(object sender, FormClosingEventArgs e)
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

        private void cmb_Empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmb_Percepciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Percepciones.Text != "")
            {
                btn_Agregar_Percep.Enabled = true;
            }
        }

        private void cmb_Deducciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Deducciones.Text != "")
            {
                btn_Agregar_Dedu.Enabled = true;
            }
        }

        private void tabla_Percepciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btn_Eliminar_Percep.Enabled = true;

                tabla_Percepciones.CurrentRow.Selected = true;

                if(AccionesForms.enlace == true)
                    id_persep = Guid.Parse(tabla_Percepciones.Rows[e.RowIndex].Cells["Clave"].FormattedValue.ToString());

                if (AccionesForms.enlace == false)
                    SQL_id_persep = int.Parse(tabla_Percepciones.Rows[e.RowIndex].Cells["Clave"].FormattedValue.ToString());
            }
        }

        private void tabla_Deducciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btn_Eliminar_Dedu.Enabled = true;

                tabla_Deducciones.CurrentRow.Selected = true;

                if (AccionesForms.enlace == true)
                    id_dedu = Guid.Parse(tabla_Deducciones.Rows[e.RowIndex].Cells["Clave"].FormattedValue.ToString());

                if (AccionesForms.enlace == false)
                    SQL_id_dedu = int.Parse(tabla_Deducciones.Rows[e.RowIndex].Cells["Clave"].FormattedValue.ToString());
            }
        }

        private void btn_Eliminar_Percep_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var id_empleado = (int)cmb_Empleados.SelectedValue;

                enlace.Acciones_Percepciones("B", cmb_Percepciones.Text, id_empleado, SQL_id_persep);
                var listaPersep = enlace.Get_Percepciones_By_Empleado("D", id_empleado);
                tabla_Percepciones.DataSource = listaPersep;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var id_empleado = (Guid)cmb_Empleados.SelectedValue;
                enlace.Baja_Percepcion(AccionesForms.ID_Empresa, id_empleado, id_persep);
                
                var listaPercep = enlace.Get_Percepciones_By_Empleado(AccionesForms.ID_Empresa, id_empleado);
                tabla_Percepciones.DataSource = listaPercep;
                Cargar_Tabla();
            }
        }

        private void btn_Eliminar_Dedu_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var id_empleado = (int)cmb_Empleados.SelectedValue;

                enlace.Acciones_Deducciones("B", cmb_Deducciones.Text, id_empleado, SQL_id_dedu);
                var listaDedu = enlace.Get_Deducciones_By_Empleado("D", id_empleado);
                tabla_Deducciones.DataSource = listaDedu;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var id_empleado = (Guid)cmb_Empleados.SelectedValue;
                enlace.Baja_Deduccion(AccionesForms.ID_Empresa, id_empleado, id_dedu);
                
                var listaDedu = enlace.Get_Deducciones_By_Empleado(AccionesForms.ID_Empresa, id_empleado);
                tabla_Deducciones.DataSource = listaDedu;

                Cargar_Tabla();
            }
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            if (cmb_Empleados.Text != "")
            {
                cmb_Deducciones.Enabled = true;
                cmb_Percepciones.Enabled = true;

                btn_Agregar_Dedu.Enabled = true;
                btn_Eliminar_Dedu.Enabled = true;

                btn_Agregar_Percep.Enabled = true;
                btn_Eliminar_Percep.Enabled = true;

                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var id_empleado = (int)cmb_Empleados.SelectedValue;

                    var listaDedu = enlace.Get_Deducciones_By_Empleado("D", id_empleado);
                    tabla_Deducciones.DataSource = listaDedu;

                    var listaPercep = enlace.Get_Percepciones_By_Empleado("D", id_empleado);
                    tabla_Percepciones.DataSource = listaPercep;

                    tabla_Percepciones.Columns["ID_Empresa"].Visible = false;
                    tabla_Percepciones.Columns["ID_Empleado"].Visible = false;
                    tabla_Deducciones.Columns["ID_Empresa"].Visible = false;
                    tabla_Deducciones.Columns["ID_Empleado"].Visible = false;
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var id_empleado = (Guid)cmb_Empleados.SelectedValue;

                    var listaDedu = enlace.Get_Deducciones_By_Empleado(AccionesForms.ID_Empresa, id_empleado);
                    tabla_Deducciones.DataSource = listaDedu;

                    var listaPercep = enlace.Get_Percepciones_By_Empleado(AccionesForms.ID_Empresa, id_empleado);
                    tabla_Percepciones.DataSource = listaPercep;

                    Cargar_Tabla();
                }
            }
        }

        private void btn_Agregar_Percep_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var id_empleado = (int)cmb_Empleados.SelectedValue;
                
                enlace.Acciones_Percepciones("A", cmb_Percepciones.Text, id_empleado, AccionesForms.SQL_ID_Empresa);
                var listaPersep = enlace.Get_Percepciones_By_Empleado("D", id_empleado);
                tabla_Percepciones.DataSource = listaPersep;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var id_empleado = (Guid)cmb_Empleados.SelectedValue;

                enlace.Agregar_Percepcion_Empleado(cmb_Percepciones.Text, id_empleado, AccionesForms.ID_Empresa);
                var listaPersep = enlace.Get_Percepciones_By_Empleado(AccionesForms.ID_Empresa, id_empleado);
                tabla_Percepciones.DataSource = listaPersep;
                Cargar_Tabla();
            }
        }

        private void btn_Agregar_Dedu_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var id_empleado = (int)cmb_Empleados.SelectedValue;

                enlace.Acciones_Deducciones("A", cmb_Deducciones.Text, id_empleado, AccionesForms.SQL_ID_Empresa);
                var listaDedu = enlace.Get_Deducciones_By_Empleado("D", id_empleado);
                tabla_Deducciones.DataSource = listaDedu;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var id_empleado = (Guid)cmb_Empleados.SelectedValue;

                enlace.Agregar_Deduccion_Empleado(cmb_Deducciones.Text, id_empleado, AccionesForms.ID_Empresa);
                var listaDedu = enlace.Get_Deducciones_By_Empleado(AccionesForms.ID_Empresa, id_empleado);
                tabla_Deducciones.DataSource = listaDedu;
                Cargar_Tabla();
            }
        }

        private void Cargar_Tabla()
        {
            tabla_Deducciones.Columns["Clave"].HeaderText = "Clave";
            tabla_Deducciones.Columns["txt_Nom_Ded"].HeaderText = "NOMBRE DEDUCCION";
            tabla_Deducciones.Columns["float_Monto"].Visible = false;
            tabla_Deducciones.Columns["valor"].HeaderText = " VALOR";
            tabla_Deducciones.Columns["porcentaje"].HeaderText = "PORCENTAJE";
            tabla_Deducciones.Columns["ID_Empresa"].Visible = false;
            tabla_Deducciones.Columns["ID_Empleado"].Visible = false;

            tabla_Percepciones.Columns["Clave"].HeaderText = "Clave";
            tabla_Percepciones.Columns["txt_Nom_Per"].HeaderText = "NOMBRE DEDUCCION";
            tabla_Percepciones.Columns["float_Monto"].Visible = false;
            tabla_Percepciones.Columns["valor"].HeaderText = " VALOR";
            tabla_Percepciones.Columns["porcentaje"].HeaderText = "PORCENTAJE";
            tabla_Percepciones.Columns["ID_Empresa"].Visible = false;
            tabla_Percepciones.Columns["ID_Empleado"].Visible = false;
        }



        private void btn_Calcu_Nomina_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Calculo_Nomina();
                DialogResult result = MessageBox.Show("Generando archivos PDF y CSV respectivamente", "ARCHIVOS", MessageBoxButtons.OK);
            }

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                enlace.Baja_Nomina("B", AccionesForms.SQL_ID_Empresa);
                enlace.Reporte_Nomina_Empresa("A");
                DialogResult result = MessageBox.Show("Generando archivos PDF y CSV respectivamente", "ARCHIVOS", MessageBoxButtons.OK);
            }
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            ObjAcciones.AbrirDlgAdmin();

            cmb_Deducciones.Items.Clear();
            cmb_Percepciones.Items.Clear();

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var listadoCambios = enlace.GetAllCambios("D");

                foreach (DataRow row in listadoCambios.Rows)
                {
                    if ((string)row["Tipo"] == "Percepcion")
                    {
                        if ((int)row["Activo"] == 0)
                        {
                            cmb_Percepciones.Items.Add((string)row["Nombre"]);
                        }
                    }
                    if ((string)row["Tipo"] == "Deduccion")
                    {
                        if ((int)row["Activo"] == 0)
                        {
                            cmb_Deducciones.Items.Add((string)row["Nombre"]);
                        }
                    }
                }
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var listadoCambios = enlace.GetAll_Cambios();
                foreach (var row in listadoCambios)
                {
                    if (row.tipo == "Percepcion")
                    {
                        if (row.activo == 0)
                        {
                            cmb_Percepciones.Items.Add(row.nombre);
                        }
                    }
                    if (row.tipo == "Deduccion")
                    {
                        if (row.activo == 0)
                        {
                            cmb_Deducciones.Items.Add(row.nombre);
                        }
                    }
                }
            }
        }
    }
}
