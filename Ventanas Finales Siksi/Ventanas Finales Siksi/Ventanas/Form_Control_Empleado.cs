using Cassandra;
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
using Ventanas_Finales_Siksi.Tablas_SQL;

namespace Ventanas_Finales_Siksi
{
    public partial class Form_Control_Empleado : Form
    {
        string nombre;
        AccionesForms ObjAcciones = new AccionesForms();

        public Form_Control_Empleado()
        {
            InitializeComponent();
        }

        private void Form_Control_Empleado_Load(object sender, EventArgs e)
        {
            btn_Agregar.Enabled = false;
            btn_Eliminar.Enabled = false;
            
            cmb_Incidencia.Items.Add("Permiso");
            cmb_Incidencia.Items.Add("Enfermedad");

            if (AccionesForms.user == 0) {
                btn_Regresar.Visible = false;
            }

            if (AccionesForms.enlace == false)
            {
                lbl_Nombre.Text = User_SQL.static_txt_Nom_Empleado + " " + User_SQL.static_txt_ApePat + " " + User_SQL.static_txt_ApeMat;

                EnlaceDB enlace = new EnlaceDB();
                Llenar_incidencias();

                var lista_Dedu = enlace.Get_Deducciones_By_Empleado("D", User_SQL.static_ID_Empleado);
                var lista_Percep = enlace.Get_Percepciones_By_Empleado("D", User_SQL.static_ID_Empleado);

                tabla_Deducciones.DataSource = lista_Dedu;
                tabla_Percepciones.DataSource = lista_Percep;
            }

            if (AccionesForms.enlace == true)
            {
                lbl_Nombre.Text = User.static_txt_Nom_Empleado + " " + User.static_txt_ApePat + " " + User.static_txt_ApeMat;

                EnlaceCassandra enlace = new EnlaceCassandra();
                Llenar_incidencias();

                var lista_Dedu = enlace.Get_Deducciones_By_Empleado(User.static_ID_Empresa, User.static_ID_Empleado);
                var lista_Percep = enlace.Get_Percepciones_By_Empleado(User.static_ID_Empresa, User.static_ID_Empleado);

                tabla_Deducciones.DataSource = lista_Dedu;
                tabla_Percepciones.DataSource = lista_Percep;

                Llenar_Dedu_Percep();
            }
        }

        private void Form_Control_Empleado_Closing(object sender, FormClosingEventArgs e)
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

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            AccionesForms.isClosing = false;
            this.Close();
            ObjAcciones.AbrirDepartamentos();
            AccionesForms.isClosing = true;
        }

        private void cmb_Incidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Incidencia.Text == "Prima Vacacional")
            {
                cmb_Dias.Items.Clear();
                cmb_Dias.Items.Add("1 Semanas");
                cmb_Dias.Items.Add("2 Semanas");
                cmb_Dias.Items.Add("3 Semanas");
            }

            if (cmb_Incidencia.Text == "Permiso")
            {
                cmb_Dias.Items.Clear();
                cmb_Dias.Items.Add("1 Dias");
                cmb_Dias.Items.Add("2 Dias");
                cmb_Dias.Items.Add("3 Dias");
                cmb_Dias.Items.Add("4 Dias");
                cmb_Dias.Items.Add("5 Dias");
                cmb_Dias.Items.Add("6 Dias");
                cmb_Dias.Items.Add("7 Dias");
            }

            if (cmb_Incidencia.Text == "Enfermedad")
            {
                cmb_Dias.Items.Clear();
                cmb_Dias.Items.Add("1 Dias");
                cmb_Dias.Items.Add("2 Dias");
                cmb_Dias.Items.Add("3 Dias");
                cmb_Dias.Items.Add("7 Dias");
                cmb_Dias.Items.Add("14 Dias");
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if (cmb_Dias.Text != "")
            {
                int dias = 0;
                dias = Obtener_Dias();

                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    DateTime dateAux = DateTime.Now;

                    enlace.Acciones_Incidencias("A", User_SQL.static_ID_Empresa, User_SQL.static_ID_Empleado, cmb_Incidencia.Text, dias, dateAux);

                    MessageBox.Show("Informacion cargada con exito", "Registro", MessageBoxButtons.OK);
                    Llenar_incidencias();
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    DateTime dateAux = DateTime.Now;
                    LocalDate dateNow = LocalDate.Parse(dateAux.ToString("yyyy-MM-dd"));

                    enlace.Agregar_Incidencia(User.static_ID_Empresa, User.static_ID_Empleado, cmb_Incidencia.Text, dias, dateNow);

                    MessageBox.Show("Informacion cargada con exito", "Registro", MessageBoxButtons.OK);
                    Llenar_incidencias();
                }
            }
        }

        private int Obtener_Dias()
        {
            int dias = 0;

            if (cmb_Incidencia.Text == "Prima Vacacional")
            {
                if (cmb_Dias.Text == "1 Semanas")
                    dias = 7;

                if (cmb_Dias.Text == "2 Semanas")
                    dias = 14;

                if (cmb_Dias.Text == "3 Semanas")
                    dias = 21;
            }

            if (cmb_Incidencia.Text == "Permiso")
            {
                if (cmb_Dias.Text == "1 Dias")
                    dias = 1;

                if (cmb_Dias.Text == "2 Dias")
                    dias = 2;

                if (cmb_Dias.Text == "3 Dias")
                    dias = 3;

                if (cmb_Dias.Text == "4 Dias")
                    dias = 4;

                if (cmb_Dias.Text == "5 Dias")
                    dias = 5;

                if (cmb_Dias.Text == "6 Dias")
                    dias = 6;

                if (cmb_Dias.Text == "7 Dias")
                    dias = 7;
            }

            if (cmb_Incidencia.Text == "Enfermedad")
            {
                if (cmb_Dias.Text == "1 Dias")
                    dias = 1;

                if (cmb_Dias.Text == "2 Dias")
                    dias = 2;

                if (cmb_Dias.Text == "3 Dias")
                    dias = 3;

                if (cmb_Dias.Text == "7 Dias")
                    dias = 7;

                if (cmb_Dias.Text == "14 Dias")
                    dias = 14;
            }

            return dias;
        }

        private void tabla_Incidencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (AccionesForms.enlace == false)
                {
                    btn_Eliminar.Enabled = true;
                    tabla_Incidencias.CurrentRow.Selected = true;
                    nombre = tabla_Incidencias.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString();
                }

                if (AccionesForms.enlace == true)
                {
                    btn_Eliminar.Enabled = true;
                    tabla_Incidencias.CurrentRow.Selected = true;
                    nombre = tabla_Incidencias.Rows[e.RowIndex].Cells["Incidencia"].FormattedValue.ToString();
                }
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                enlace.Acciones_Incidencias("B", User_SQL.static_ID_Empresa, User_SQL.static_ID_Empleado, nombre, 0, DateTime.Now);

                Llenar_incidencias();
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Baja_Incidencia(User.static_ID_Empresa, User.static_ID_Empleado, nombre);

                Llenar_incidencias();
            }
        }

        private void Llenar_incidencias()
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista = enlace.Get_Incidencias_By_Empleado("D", User_SQL.static_ID_Empleado);

                tabla_Incidencias.DataSource = lista;

                bool isVacaciones = false;
                DateTime dateAux = DateTime.Now;

                foreach (DataRow row in lista.Rows)
                {
                    if (row["Nombre"].ToString() == "Prima Vacacional")
                    {
                        if (DateTime.Parse(row["Fecha_Ejecucion"].ToString()).Day + 365 == dateAux.Day && DateTime.Parse(row["Fecha_Ejecucion"].ToString()).Month + 12 == dateAux.Month && DateTime.Parse(row["Fecha_Ejecucion"].ToString()).Year + 1 == dateAux.Year)
                        {
                            enlace.Acciones_Incidencias("B", User_SQL.static_ID_Empresa, User_SQL.static_ID_Empleado, "Prima Vacacional", 0, dateAux);
                        }
                        else
                            isVacaciones = true;
                    }
                }

                if (isVacaciones == false)
                    cmb_Incidencia.Items.Add("Prima Vacacional");
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.Get_Incidencias_By_Empleado(User.static_ID_Empresa, User.static_ID_Empleado);

                tabla_Incidencias.DataSource = lista;

                tabla_Incidencias.Columns["ID_Empresa"].Visible = false;
                tabla_Incidencias.Columns["ID_Empleado"].Visible = false;

                tabla_Incidencias.Columns["date_eje"].HeaderText = "FECHA DE EJECUCION";
                tabla_Incidencias.Columns["Incidencia"].HeaderText = "NOMBRE";
                tabla_Incidencias.Columns["int_dias"].HeaderText = "DIAS";

                bool isVacaciones = false;
                DateTime dateAux = DateTime.Now;
                LocalDate dateNow = LocalDate.Parse(dateAux.ToString("yyyy-MM-dd"));

                foreach (var row in lista)
                {
                    if (row.Incidencia == "Prima Vacacional")
                    {
                        if (row.date_eje.Day + 365 == dateNow.Day && row.date_eje.Month + 12 == dateNow.Month && row.date_eje.Year + 1 == dateNow.Year)
                        {
                            enlace.Baja_Incidencia(User.static_ID_Empresa, User.static_ID_Empleado, "Prima Vacacional");
                        }
                        else
                            isVacaciones = true;
                    }
                }

                if (isVacaciones == false)
                    cmb_Incidencia.Items.Add("Prima Vacacional");
            }
        }

        private void Llenar_Dedu_Percep()
        {
            tabla_Deducciones.Columns["Clave"].HeaderText = "Clave";
            tabla_Deducciones.Columns["txt_Nom_Ded"].HeaderText = "NOMBRE DEDUCCION";
            tabla_Deducciones.Columns["valor"].HeaderText = "VALOR";
            tabla_Deducciones.Columns["porcentaje"].HeaderText = "PORCENTAJE";
            tabla_Deducciones.Columns["float_Monto"].Visible = false;
            tabla_Deducciones.Columns["ID_Empresa"].Visible = false;
            tabla_Deducciones.Columns["ID_Empleado"].Visible = false;

            tabla_Percepciones.Columns["Clave"].HeaderText = "Clave";
            tabla_Percepciones.Columns["txt_Nom_Per"].HeaderText = "NOMBRE DEDUCCION";
            tabla_Percepciones.Columns["valor"].HeaderText = "VALOR";
            tabla_Percepciones.Columns["porcentaje"].HeaderText = "PORCENTAJE";
            tabla_Percepciones.Columns["float_Monto"].Visible = false;
            tabla_Percepciones.Columns["ID_Empresa"].Visible = false;
            tabla_Percepciones.Columns["ID_Empleado"].Visible = false;
        }

        private void cmb_Dias_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Agregar.Enabled = true;
        }

        private void btn_Nomina_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                enlace.Recibo_Nomina("B", "D", User_SQL.static_ID_Empleado, User_SQL.static_ID_Empresa);
                MessageBox.Show("Archivo pdf generado con el recibo de la nomina");
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Recibo_Nomina();
                MessageBox.Show("Archivo pdf generado con el recibo de la nomina");
            }
        }
    }
}
