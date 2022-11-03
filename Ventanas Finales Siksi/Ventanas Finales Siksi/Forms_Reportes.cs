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
    public partial class Forms_Reportes : Form
    {
        public Forms_Reportes()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Forms_Reportes_Load(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();

                var lista_Empresas = enlace.Obtener_Empresa("D");
                cmb_Empresa1.DataSource = lista_Empresas;
                cmb_Empresa2.DataSource = lista_Empresas;
                cmb_Empresa3.DataSource = lista_Empresas;

                cmb_Empresa1.DisplayMember = "Razon_Social";
                cmb_Empresa1.ValueMember = "ID_Empresa";

                cmb_Empresa2.DisplayMember = "Razon_Social";
                cmb_Empresa2.ValueMember = "ID_Empresa";

                cmb_Empresa3.DisplayMember = "Razon_Social";
                cmb_Empresa3.ValueMember = "ID_Empresa";

                var lista_deptos = enlace.Obtener_Deptos("D");
                cmb_Deptos1.DataSource = lista_deptos;
                cmb_Deptos2.DataSource = lista_deptos;

                cmb_Deptos1.DisplayMember = "Nombre_Depto";
                cmb_Deptos1.ValueMember = "ID";

                cmb_Deptos2.DisplayMember = "Nombre_Depto";
                cmb_Deptos2.ValueMember = "ID";
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();

                var lista_Empresas = enlace.Get_Empresas();
                cmb_Empresa1.DataSource = lista_Empresas;
                cmb_Empresa2.DataSource = lista_Empresas;
                cmb_Empresa3.DataSource = lista_Empresas;

                cmb_Empresa1.DisplayMember = "txt_RS";
                cmb_Empresa1.ValueMember = "ID_Empresa";
                
                cmb_Empresa2.DisplayMember = "txt_RS";
                cmb_Empresa2.ValueMember = "ID_Empresa";

                cmb_Empresa3.DisplayMember = "txt_RS";
                cmb_Empresa3.ValueMember = "ID_Empresa";

                var lista_deptos = enlace.Get_Deptos();
                cmb_Deptos1.DataSource = lista_deptos;
                cmb_Deptos2.DataSource = lista_deptos;

                cmb_Deptos1.DisplayMember = "txt_Nombre";
                cmb_Deptos1.ValueMember = "ID_Departamento";

                cmb_Deptos2.DisplayMember = "txt_Nombre";
                cmb_Deptos2.ValueMember = "ID_Departamento";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
        }

        private void btn_Check2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Reporte1_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                DateTime dateTime = date_Filtro1.Value;

                int id_empresa = (int)cmb_Empresa1.SelectedValue;

                EnlaceDB enlace = new EnlaceDB();
                enlace.Reporte_Nomina_General("C", id_empresa, dateTime);
            }

            if (AccionesForms.enlace == true)
            {
                DateTime dateTime = date_Filtro1.Value;
                LocalDate date = LocalDate.Parse(dateTime.ToString("yyyy-MM-dd"));

                Guid id_empresa = (Guid)cmb_Empresa1.SelectedValue;

                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Reporte_Nomina_General(id_empresa, date);
            }
        }

        private void btn_Reporte2_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                DateTime dateTime = date_Filtro2.Value;

                int id_empresa = (int)cmb_Empresa2.SelectedValue;
                int id_depto = (int)cmb_Deptos1.SelectedValue;

                string txt_depto = cmb_Deptos1.Text;
                string txt_empresa = cmb_Empresa2.Text;

                EnlaceDB enlace = new EnlaceDB();
                enlace.Reporte_HeadCounter("D", "E", id_empresa, id_depto, dateTime);
            }

            if (AccionesForms.enlace == true)
            {
                DateTime dateTime = date_Filtro2.Value;
                LocalDate date = LocalDate.Parse(dateTime.ToString("yyyy-MM-dd"));

                Guid id_empresa = (Guid)cmb_Empresa2.SelectedValue;
                Guid id_depto = (Guid)cmb_Deptos1.SelectedValue;

                string txt_depto = cmb_Deptos1.Text;
                string txt_empresa = cmb_Empresa2.Text;

                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Reporte_Headcounter(id_empresa, id_depto, date, txt_depto, txt_empresa);
            }
        }

        private void btn_Reporte3_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                DateTime dateTime = date_Filtro3.Value;

                int id_empresa = (int)cmb_Empresa3.SelectedValue;
                int id_depto = (int)cmb_Deptos2.SelectedValue;

                string txt_depto = cmb_Deptos2.Text;
                string txt_empresa = cmb_Empresa3.Text;

                EnlaceDB enlace = new EnlaceDB();
                enlace.Reportes_Nomina("F", "G", id_empresa, id_depto, dateTime);
            }

            if (AccionesForms.enlace == true)
            {
                DateTime dateTime = date_Filtro3.Value;
                LocalDate date = LocalDate.Parse(dateTime.ToString("yyyy-MM-dd"));

                Guid id_empresa = (Guid)cmb_Empresa3.SelectedValue;
                Guid id_depto = (Guid)cmb_Deptos2.SelectedValue;

                string txt_depto = cmb_Deptos2.Text;
                string txt_empresa = cmb_Empresa3.Text;

                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Reportes_Nomina(id_empresa, id_depto, date, txt_depto, txt_empresa);
            }
        }
    }
}
