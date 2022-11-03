using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventanas_Finales_Siksi.Ventanas;

namespace Ventanas_Finales_Siksi
{
    class AccionesForms
    {
        public static bool isClosing = true;
        public static bool isUpdate = false;
        public static bool enlace = false;
        public static int user = 0;

        public static Guid ID_Empresa;
        public static Guid ID_Depto;
        public static Guid ID_Puesto;
        public static Guid ID_Empleado;
        public static string txt_Empresa;

        public static int SQL_ID_Empresa;
        public static int SQL_ID_Depto;
        public static int SQL_ID_Puesto;
        public static int SQL_ID_Empleado;
        public static string SQL_txt_Empresa;

        Acciones objenum = new Acciones();

        public enum Acciones{
            DLG_EMPRESA,
            DLG_EMPLEADO,
            DLG_DEPARTAMENTO,
            DLG_PUESTO
        };

        public void AbrirEmpleados()
        {
            Form_Listado_Empleados form = new Form_Listado_Empleados();
            form.Show();
        }

        public void AbrirPuestos()
        {
            Form_Listado_Puestos form = new Form_Listado_Puestos();
            form.Show();
        }

        public void AbrirDepartamentos()
        {
            Form_Listado_Departamentos form = new Form_Listado_Departamentos();
            form.Show();
        }

        public void AbrirEmpresa() {
            Form_Listado_Empresas form = new Form_Listado_Empresas();
            form.Show();
        }

        public void AbrirNomina()
        {
            Form_Nomina_PerDed form = new Form_Nomina_PerDed();
            form.Show();
        }

        public void AbrirControlEmpleado()
        {
            Form_Control_Empleado form = new Form_Control_Empleado();
            form.Show();
        }

        public void AbrirDlgEmpleados()
        {
            Form_ABC_Empleados form = new Form_ABC_Empleados();
            form.ShowDialog();
        }

        public void AbrirDlgPuestos()
        {
            Form_ABC_Puestos form = new Form_ABC_Puestos();
            form.ShowDialog();
        }

        public void AbrirDlgDepartamentos()
        {
            Form_ABC_Departamentos form = new Form_ABC_Departamentos();
            form.ShowDialog();
        }

        public void AbrirDlgEmpresa()
        {
            Form_ABC_Empresa form = new Form_ABC_Empresa();
            form.ShowDialog();
        }

        public void AbrirDlgReportes()
        {
            Forms_Reportes form = new Forms_Reportes();
            form.ShowDialog();
        }

        public void AbrirDlgAdmin()
        {
            Forms_Admin form = new Forms_Admin();
            form.ShowDialog();
        }
    }
}
