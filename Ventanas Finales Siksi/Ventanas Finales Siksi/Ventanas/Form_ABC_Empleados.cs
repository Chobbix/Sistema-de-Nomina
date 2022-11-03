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
    public partial class Form_ABC_Empleados : Form
    {
        Validaciones val = new Validaciones();
        Guid id_depto;
        Guid Id_puesto;
        int SQL_id_depto;
        int SQL_id_puesto;

        public Form_ABC_Empleados()
        {
            InitializeComponent();
            ControlBox = false;
        }

        private void Form_ABC_Empleados_Load(object sender, EventArgs e)
        {
            date_FInicio.Enabled = false;
            cmb_Puesto.Enabled = false;

            if (AccionesForms.isUpdate)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Obtener_Deptos("D");
                    cmb_Deptos.DataSource = lista;
                    cmb_Deptos.DisplayMember = "Nombre_Depto";
                    cmb_Deptos.ValueMember = "ID";

                    var listaFrecuencias = enlace.Get_Empresa_By_ID("E", AccionesForms.SQL_ID_Empresa);
                    foreach (DataRow row in listaFrecuencias.Rows)
                    {
                        if ((int)row["int_FP"] == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if ((int)row["int_FP"] == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if ((int)row["int_FP"] == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if ((int)row["int_FP"] == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }

                        if ((int)row["int_FP2"] == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if ((int)row["int_FP2"] == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if ((int)row["int_FP2"] == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if ((int)row["int_FP2"] == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }
                    }

                    var lista2 = enlace.Get_Empleados_By_Id("G", AccionesForms.SQL_ID_Empleado);
                    foreach (DataRow item in lista2.Rows)
                    {
                        txt_Nombres.Text = item["txt_Nom"].ToString();
                        txt_Contrasenia.Text = item["txt_Contra"].ToString();
                        txt_ApMaterno.Text = item["txt_ApeMat"].ToString();
                        txt_ApPaterno.Text = item["txt_ApePat"].ToString();
                        txt_NumSegSocial.Text = item["txt_NSS"].ToString();
                        txt_RFC.Text = item["txt_RFC"].ToString();
                        txt_NumCuenta.Text = item["txt_NumCuenta"].ToString();
                        txt_Email.Text = item["txt_Email"].ToString();
                        txt_Tel.Text = item["txt_Teléfono"].ToString();
                        date_FNacimiento.Value = DateTime.Parse(item["date_FchaNac"].ToString());
                        date_FInicio.Value = DateTime.Parse(item["date_FchaInicio"].ToString());

                        txt_Calle.Text = item["txt_Calle"].ToString();
                        txt_Colonia.Text = item["txt_Colonia"].ToString();
                        txt_NumCasa.Text = item["txt_Num"].ToString();
                        txt_Municipio.Text = item["txt_Municipio"].ToString();
                        txt_Estado.Text = item["txt_Estado"].ToString();
                        txt_CP.Text = item["txt_CP"].ToString();

                        txt_Banco.Text = item["txt_Banco"].ToString();

                        if ((int)item["int_tipo"] == 7)
                        {
                            cmb_FrePago.Text = "Semanal";
                        }
                        if ((int)item["int_tipo"] == 14)
                        {
                            cmb_FrePago.Text = "Catorcenal";
                        }
                        if ((int)item["int_tipo"] == 15)
                        {
                            cmb_FrePago.Text = "Quincenal";
                        }
                        if ((int)item["int_tipo"] == 30)
                        {
                            cmb_FrePago.Text = "Mensual";
                        }
                    }

                    var lista3 = enlace.Get_Empleados_By_Id("H", AccionesForms.SQL_ID_Empleado);
                    foreach (DataRow item in lista3.Rows)
                    {
                        AccionesForms.SQL_ID_Depto = (int)item["ID_Departamento"];
                        AccionesForms.SQL_ID_Puesto = (int)item["ID_Puesto"];
                    }
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Deptos();
                    cmb_Deptos.DataSource = lista;
                    cmb_Deptos.DisplayMember = "txt_Nombre";
                    cmb_Deptos.ValueMember = "ID_Departamento";

                    var listaFrecuencias = enlace.Get_Empresas_By_ID(AccionesForms.ID_Empresa);
                    foreach (var row in listaFrecuencias)
                    {
                        if (row.int_FP.First() == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if (row.int_FP.First() == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if (row.int_FP.First() == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if (row.int_FP.First() == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }

                        if (row.int_FP.Last() == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if (row.int_FP.Last() == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if (row.int_FP.Last() == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if (row.int_FP.Last() == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }
                    }

                    var lista2 = enlace.Get_Empleados_By_Id(AccionesForms.ID_Empresa, AccionesForms.ID_Empleado);
                    foreach (var item in lista2)
                    {
                        AccionesForms.ID_Depto = item.ID_Depto;
                        AccionesForms.ID_Puesto = item.ID_Puesto;

                        txt_Nombres.Text = item.txt_Nom_Empleado;
                        txt_Contrasenia.Text = item.txt_Contra;
                        txt_ApMaterno.Text = item.txt_ApeMat;
                        txt_ApPaterno.Text = item.txt_ApePat;
                        txt_CURP.Text = item.txt_CURP;
                        txt_NumSegSocial.Text = item.txt_NSS;
                        txt_RFC.Text = item.txt_RFC;
                        txt_NumCuenta.Text = item.txt_NumCuenta;
                        txt_Email.Text = item.txt_Email;
                        txt_Tel.Text = item.txt_Telefono;
                        date_FNacimiento.Value = DateTime.Parse(item.date_FchaNac.ToString());
                        date_FInicio.Value = DateTime.Parse(item.date_FchaInicio.ToString());

                        txt_Calle.Text = item.txt_Calle;
                        txt_Colonia.Text = item.txt_Colonia;
                        txt_NumCasa.Text = item.txt_Num;
                        txt_Municipio.Text = item.txt_Municipio;
                        txt_Estado.Text = item.txt_Estado;
                        txt_CP.Text = item.txt_CP;

                        txt_Banco.Text = item.txt_Banco;

                        if (item.int_tipo == 7)
                        {
                            cmb_FrePago.Text = "Semanal";
                        }
                        if (item.int_tipo == 14)
                        {
                            cmb_FrePago.Text = "Catorcenal";
                        }
                        if (item.int_tipo == 15)
                        {
                            cmb_FrePago.Text = "Quincenal";
                        }
                        if (item.int_tipo == 30)
                        {
                            cmb_FrePago.Text = "Mensual";
                        }
                    }
                }
            }

            if (!AccionesForms.isUpdate)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Obtener_Deptos("D");
                    cmb_Deptos.DataSource = lista;
                    cmb_Deptos.DisplayMember = "Nombre_Depto";
                    cmb_Deptos.ValueMember = "ID";

                    var listaFrecuencias = enlace.Get_Empresa_By_ID("E", AccionesForms.SQL_ID_Empresa);
                    foreach (DataRow row in listaFrecuencias.Rows)
                    {
                        if ((int)row["int_FP"] == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if ((int)row["int_FP"] == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if ((int)row["int_FP"] == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if ((int)row["int_FP"] == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }

                        if ((int)row["int_FP2"] == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if ((int)row["int_FP2"] == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if ((int)row["int_FP2"] == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if ((int)row["int_FP2"] == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }
                    }
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Deptos();
                    cmb_Deptos.DataSource = lista;
                    cmb_Deptos.DisplayMember = "txt_Nombre";
                    cmb_Deptos.ValueMember = "ID_Departamento";

                    var listaFrecuencias = enlace.Get_Empresas_By_ID(AccionesForms.ID_Empresa);
                    foreach (var row in listaFrecuencias)
                    {
                        if (row.int_FP.First() == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if (row.int_FP.First() == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if (row.int_FP.First() == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if (row.int_FP.First() == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }

                        if (row.int_FP.Last() == 7)
                        {
                            cmb_FrePago.Items.Add("Semanal");
                        }
                        if (row.int_FP.Last() == 14)
                        {
                            cmb_FrePago.Items.Add("Catorcenal");
                        }
                        if (row.int_FP.Last() == 15)
                        {
                            cmb_FrePago.Items.Add("Quincenal");
                        }
                        if (row.int_FP.Last() == 30)
                        {
                            cmb_FrePago.Items.Add("Mensual");
                        }
                    }
                }
            }
        }

        private void Form_ABC_Empleados_Closing(object sender, FormClosingEventArgs e)
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
            if (isNotEmpty == false)
            {
                MessageBox.Show("Campos sin llenar", "ERROR", MessageBoxButtons.OK);
                return false;
            }

            Empleado_info Emp_info = new Empleado_info();
            Domicilio Dom = new Domicilio();
            Banco Ban = new Banco();

            Emp_info.txt_Nombre = txt_Nombres.Text;
            Emp_info.txt_Contrasenia = txt_Contrasenia.Text;
            Emp_info.txt_Apellido_Mat = txt_ApMaterno.Text;
            Emp_info.txt_Apellido_Pat = txt_ApPaterno.Text;
            Emp_info.txt_CURP = txt_CURP.Text;
            Emp_info.txt_NSS = txt_NumSegSocial.Text;
            Emp_info.txt_RFC = txt_RFC.Text;
            Emp_info.txt_NumCuenta = txt_NumCuenta.Text;
            Emp_info.txt_Email = txt_Email.Text;
            Emp_info.txt_Telefono = txt_Tel.Text;
            Emp_info.date_FchaNac = date_FNacimiento.Value;
            Emp_info.date_FInicio = date_FInicio.Value;

            if (cmb_FrePago.Text == "Semanal")
            {
                Emp_info.int_FPago = 7;
            }
            if (cmb_FrePago.Text == "Catorcenal")
            {
                Emp_info.int_FPago = 14;
            }
            if (cmb_FrePago.Text == "Quincenal")
            {
                Emp_info.int_FPago = 15;
            }
            if (cmb_FrePago.Text == "Mensual")
            {
                Emp_info.int_FPago = 30;
            }

            Dom.txt_Calle = txt_Calle.Text;
            Dom.txt_Colonia = txt_Colonia.Text;
            Dom.txt_NumCasa = txt_NumCasa.Text;
            Dom.txt_Municipio = txt_Municipio.Text;
            Dom.txt_Estado = txt_Estado.Text;
            Dom.txt_CP = txt_CP.Text;
            
            Ban.txt_Nombre = txt_Banco.Text;
            Emp_info.txt_Banco = txt_Banco.Text;

            if (cmb_Puesto.Text != "")
            {
                if (AccionesForms.enlace == false)
                { 
                    SQL_id_depto = (int)cmb_Deptos.SelectedValue;
                    SQL_id_puesto = (int)cmb_Puesto.SelectedValue;
                }

                if (AccionesForms.enlace == true)
                {
                    id_depto = (Guid)cmb_Deptos.SelectedValue;
                    Id_puesto = (Guid)cmb_Puesto.SelectedValue;
                }
            }

            if (!AccionesForms.isUpdate)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    AccionesForms.SQL_ID_Depto = SQL_id_depto;
                    AccionesForms.SQL_ID_Puesto = SQL_id_puesto;
                    enlace.Acciones_Domicilio("A", Dom);
                    enlace.Acciones_Empleado("A", Emp_info, Dom);
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    AccionesForms.ID_Depto = id_depto;
                    AccionesForms.ID_Puesto = Id_puesto;
                    enlace.Agregar_Empleado("A", Emp_info, Ban, Dom);
                }
            }

            if (AccionesForms.isUpdate)
            {
                if (AccionesForms.enlace == false)
                {
                    EnlaceDB enlace = new EnlaceDB();
                    enlace.Acciones_Empleado("C", Emp_info, Dom);
                }

                if (AccionesForms.enlace == true)
                {
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    enlace.Update_Empleado(Emp_info, Ban, Dom, id_depto, Id_puesto);
                }
            }
            MessageBox.Show("Informacion cargada con exito", "Registro", MessageBoxButtons.OK);
            return true;
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            if (cmb_Deptos.Text != "") {
                cmb_Puesto.Enabled = true;
                cmb_Deptos.Enabled = false;
                btn_Check.Enabled = false;

                if (AccionesForms.enlace == false)
                {
                    int SQL_id_depto = (int)cmb_Deptos.SelectedValue;
                    EnlaceDB enlace = new EnlaceDB();
                    var lista = enlace.Get_Puestos_By_Depto("D", AccionesForms.SQL_ID_Empresa, SQL_id_depto);

                    cmb_Puesto.DataSource = lista;
                    cmb_Puesto.DisplayMember = "Nombre_Puesto";
                    cmb_Puesto.ValueMember = "ID";
                }

                if (AccionesForms.enlace == true)
                {
                    id_depto = (Guid)cmb_Deptos.SelectedValue;
                    EnlaceCassandra enlace = new EnlaceCassandra();
                    var lista = enlace.Get_Puestos_By_Empresa_Depto(AccionesForms.ID_Empresa, id_depto);

                    cmb_Puesto.DataSource = lista;
                    cmb_Puesto.DisplayMember = "txt_Nom_Pue";
                    cmb_Puesto.ValueMember = "ID_Puesto";
                }
            }
        }

        private void LetrasNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.LetrasNumeros(e);
        }

        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.soloLetras(e);
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private bool ValidacionesVacios()
        {
            if (txt_Contrasenia.Text == "")
                return false;

            if (txt_Nombres.Text == "")
                return false;

            if (txt_ApMaterno.Text == "")
                return false;

            if (txt_ApPaterno.Text == "")
                return false;

            if (cmb_Deptos.Text == "")
                return false;

            if (cmb_Puesto.Text == "")
                return false;

            if (txt_NumSegSocial.Text == "")
                return false;

            if (cmb_FrePago.Text == "")
                return false;

            if (txt_RFC.Text == "")
                return false;

            if (txt_Calle.Text == "")
                return false;

            if (txt_Colonia.Text == "")
                return false;

            if (txt_NumCasa.Text == "")
                return false;

            if (txt_Municipio.Text == "")
                return false;

            if (txt_Estado.Text == "")
                return false;

            if (txt_CP.Text == "")
                return false;

            if (txt_Banco.Text == "")
                return false;

            if (txt_NumCuenta.Text == "")
                return false;

            if (txt_Email.Text == "")
                return false;

            if (txt_Tel.Text == "")
                return false;

            return true;
        }
    }
}
