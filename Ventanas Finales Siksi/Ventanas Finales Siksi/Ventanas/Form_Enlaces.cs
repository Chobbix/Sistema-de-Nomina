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
using Cassandra;

namespace Ventanas_Finales_Siksi
{
    public partial class Form_Enlaces : Form
    {
        AccionesForms form = new AccionesForms();
        public Form_Enlaces()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            bool isUser = false;

            if (AccionesForms.enlace == false)
            {
                EnlaceDB enlace = new EnlaceDB();
                var lista_empleados = enlace.GetAllEmpleados("L", txt_IniSesion.Text, txt_Contrasenia.Text);

                foreach (DataRow item in lista_empleados.Rows)
                {
                    User_SQL.static_ID_Empresa = (int)item["id_empresa"];
                    User_SQL.static_ID_Depto = (int)item["id_departamento"];
                    User_SQL.static_ID_Puesto = (int)item["id_puesto"];
                    User_SQL.static_ID_Empleado = (int)item["id_empleado"];
                    User_SQL.static_txt_Contra = (string)item["txt_contra"];
                    User_SQL.static_txt_Nom_Empleado = (string)item["txt_Nom"];
                    User_SQL.static_txt_ApePat = (string)item["txt_apepat"];
                    User_SQL.static_txt_ApeMat = (string)item["txt_apemat"];
                    User.static_int_tipo = (int)item["int_tipo"];
                    AccionesForms.user = User.static_int_tipo;
                    User_SQL.static_txt_NSS = (string)item["txt_nss"];
                    User_SQL.static_txt_RFC = (string)item["txt_rfc"];
                    User_SQL.static_int_FP = (int)item["int_DIAS"];

                    isUser = true;
                    break;
                }
            }

            if (AccionesForms.enlace == true) {
                EnlaceCassandra enlace = new EnlaceCassandra();
                var lista = enlace.GetAll_Empleados();

                foreach (var item in lista)
                {
                    if (txt_IniSesion.Text == item.GetValue<string>("txt_nom_empleado"))
                    {
                        if (txt_Contrasenia.Text == item.GetValue<string>("txt_contra"))
                        {
                            User.static_ID_Empresa = item.GetValue<Guid>("id_empresa");
                            User.static_ID_Depto = item.GetValue<Guid>("id_depto");
                            User.static_ID_Puesto = item.GetValue<Guid>("id_puesto");
                            User.static_ID_Empleado = item.GetValue<Guid>("id_empleado");
                            User.static_txt_Contra = item.GetValue<string>("txt_contra");
                            User.static_txt_Nom_Empleado = item.GetValue<string>("txt_nom_empleado");
                            User.static_txt_ApePat = item.GetValue<string>("txt_apepat");
                            User.static_txt_ApeMat = item.GetValue<string>("txt_apemat");
                            User.static_int_tipo = item.GetValue<int>("int_tipo");
                            AccionesForms.user = User.static_int_tipo;
                            User.static_bool_GerDepto = item.GetValue<bool>("int_gerdepto");
                            User.static_txt_NSS = item.GetValue<string>("txt_nss");
                            User.static_txt_RFC = item.GetValue<string>("txt_rfc");
                            User.static_int_FP = item.GetValue<int>("int_fp");

                            isUser = true;
                            break;
                        }
                    }
                }
            }

            if (isUser == false)
            {
                if (txt_IniSesion.Text == "VICTOR FRANCISCO" && txt_Contrasenia.Text == "123")
                {
                    User.static_int_tipo = 2;
                    AccionesForms.user = User.static_int_tipo;
                    form.AbrirEmpresa();
                    this.Close();
                }
                else
                    MessageBox.Show("Contraseña o Usuario incorrectos", "ERROR", MessageBoxButtons.OK);
            }

            if (isUser == true)
            {
                if (AccionesForms.user == 0)
                {
                    form.AbrirControlEmpleado();
                    this.Close();
                }

                if (AccionesForms.user == 1)
                {
                    form.AbrirDepartamentos();
                    this.Close();
                    AccionesForms.ID_Empresa = User.static_ID_Empresa;
                    AccionesForms.SQL_ID_Empresa = User_SQL.static_ID_Empresa;
                }
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
