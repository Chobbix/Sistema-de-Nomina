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
    public partial class Forms_Admin : Form
    {
        Validaciones val = new Validaciones();
        Guid id_cambio;
        int SQL_id_cambio;

        public Forms_Admin()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Forms_Admin_Load(object sender, EventArgs e)
        {
            CargarInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isNotEmpty = ValidacionesVacios();
            if (!isNotEmpty) {
                MessageBox.Show("Campos vacios", "ERROR", MessageBoxButtons.OK);
                return;
            }

            Cambios cam = new Cambios();

            if(radio_Valor.Checked == true)
            {
                cam.valor = float.Parse(txt_Monto.Text);
                cam.porcentaje = 0;
            }

            if (radio_Por.Checked == true)
            {
                cam.valor = 0;
                cam.porcentaje = float.Parse(txt_Monto.Text);
            }

            cam.monto = 0;
            cam.nombre = txt_Nombre.Text;
            cam.tipo = cmb_PerDed.Text;
            cam.ID_Empresa = AccionesForms.ID_Empresa;
            cam.activo = 1;

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Agregar_Cambio(AccionesForms.ID_Empresa, cam);
                CargarInfo();
                MessageBox.Show("Se ingreso el dato con exito", "AGREGAR", MessageBoxButtons.OK);
            }

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                enlace.Acciones_Cambios("A", AccionesForms.SQL_ID_Empresa, cam);
                CargarInfo();
                MessageBox.Show("Se ingreso el dato con exito", "AGREGAR", MessageBoxButtons.OK);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                Cambios cam = new Cambios();
                cam.SQL_Clave = SQL_id_cambio;
                enlace.Acciones_Cambios("B", AccionesForms.SQL_ID_Empresa, cam);
                CargarInfo();
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Baja_Cambio(AccionesForms.ID_Empresa, id_cambio);
                CargarInfo();
            }
        }

        private void tabla_Cambios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btn_Eliminar.Enabled = true;
                btn_Activar.Enabled = true;
                tabla_Cambios.CurrentRow.Selected = true;

                if (!AccionesForms.enlace)
                    SQL_id_cambio = int.Parse(tabla_Cambios.Rows[e.RowIndex].Cells["Clave"].FormattedValue.ToString());

                if (AccionesForms.enlace)
                    id_cambio = Guid.Parse(tabla_Cambios.Rows[e.RowIndex].Cells["Clave"].FormattedValue.ToString());
            }
        }

        private void btn_Activar_Click(object sender, EventArgs e)
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                Cambios cam = new Cambios();
                cam.SQL_Clave = SQL_id_cambio;
                enlace.Acciones_Cambios("C", AccionesForms.SQL_ID_Empresa, cam);
                CargarInfo();
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                enlace.Update_Activo_Cambio(AccionesForms.ID_Empresa, id_cambio);
                CargarInfo();
            }
        }

        private void CargarInfo()
        {
            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var listado = enlace.GetAllCambios("D");
                tabla_Cambios.DataSource = listado;
            }

            if (AccionesForms.enlace == true)
            {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var listado = enlace.GetAll_Cambios();
                tabla_Cambios.DataSource = listado;

                tabla_Cambios.Columns["Clave"].HeaderText = "Clave";
                tabla_Cambios.Columns["nombre"].HeaderText = "Nombre";
                tabla_Cambios.Columns["monto"].Visible = false;
                tabla_Cambios.Columns["tipo"].HeaderText = "Tipo";
                tabla_Cambios.Columns["valor"].HeaderText = "Valor";
                tabla_Cambios.Columns["porcentaje"].HeaderText = "Porcentaje";
                tabla_Cambios.Columns["activo"].HeaderText = "Activo";
                tabla_Cambios.Columns["ID_Empresa"].Visible = false;
            }

        }
        
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloLetras(e);
        }

        private void Cantidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.CantidadPorcentaje(e);
        }

        bool ValidacionesVacios()
        {
            if (cmb_PerDed.Text == "")
                return false;

            if (txt_Monto.Text == "")
                return false;

            if (txt_Nombre.Text == "")
                return false;

            if (radio_Por.Checked == false && radio_Valor.Checked == false)
                return false;

            return true;
        }
    }
}
