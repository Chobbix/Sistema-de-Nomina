using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using Ventanas_Finales_Siksi.Tablas_CQL;
using Ventanas_Finales_Siksi.Tablas_SQL;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using NumerosALetras;

namespace Ventanas_Finales_Siksi
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();

        public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
        }

        private static void conectar()
        {
            string cnn = ConfigurationManager.ConnectionStrings["BD_SQL"].ToString();
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }

        private static void desconectar()
        {
            _conexion.Close();
        }

        public bool Autentificar(string us, string ps)
        {
            bool isValid = false;
            try
            {
                conectar();
                string qry = "SP_ValidaUser";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                var parametro1 = _comandosql.Parameters.Add("@u", SqlDbType.Char, 20);
                parametro1.Value = us;
                var parametro2 = _comandosql.Parameters.Add("@p", SqlDbType.Char, 20);
                parametro2.Value = ps;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);

                if(_tabla.Rows.Count > 0)
                {
                    isValid = true;
                }

            }
            catch(SqlException e)
            {
                isValid = false;
            }
            finally
            {
                desconectar();
            }

            return isValid;
        }




        public void PDF_Reporte_Nomina_Empresa(DataTable tabla)
        {
            TextWriter txt = new StreamWriter("C://Users/2RJ25LA_RS5/Documents/Reportes_MAD/Reporte_Nomina_Empresa_CSV.txt");
            txt.WriteLine("NOMINA DE LA EMPRESA");
            txt.WriteLine("");
            txt.WriteLine("ID_EMPRESA, ID_EMPLEADO, NOMBRE_COMPLETO, BANCO, NUMERO_CUENTA, MONTO, FECHA_DE_INICIO");

            Document Doc = new Document();
            PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_MAD/Reporte_Nomina_Empresa.pdf", FileMode.Create));

            Doc.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 15f, BaseColor.BLACK);
            titulo.Add("NOMINA DE LA EMPRESA");
            Doc.Add(titulo);
            Doc.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(7);

            table.AddCell("ID_EMPRESA");
            table.AddCell("ID_EMPLEADO");
            table.AddCell("NOMBRE_COMPLETO");
            table.AddCell("BANCO");
            table.AddCell("NUMERO_CUENTA");
            table.AddCell("MONTO");
            table.AddCell("FECHA_DE_INICIO");

            foreach (DataRow item in tabla.Rows)
            {
                string id_empresa = item["id_empresa"].ToString();
                string id_empleado = item["id_empleado"].ToString();

                table.AddCell(id_empresa);
                table.AddCell(id_empleado);
                table.AddCell(item["NOMBRE_COMPLETO"].ToString());
                table.AddCell(item["BANCO"].ToString());
                table.AddCell(item["NUMERO_CUENTA"].ToString());
                table.AddCell(item["MONTO"].ToString());
                table.AddCell(item["FECHA_DE_INICIO"].ToString());

                txt.WriteLine(id_empresa + ", " + id_empleado + ", " + item["NOMBRE_COMPLETO"].ToString() + ", " + item["BANCO"].ToString() + ", " + item["NUMERO_CUENTA"].ToString() + ", " + item["MONTO"].ToString() + ", " + item["FECHA_DE_INICIO"].ToString());

                string qry = "sp_Nomina";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = "A";
                var parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                parametro2.Value = id_empresa;
                var parametro3 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                parametro3.Value = id_empleado;
                var parametro4 = _comandosql.Parameters.Add("@monto", SqlDbType.VarChar, 20);
                parametro4.Value = item["MONTO"].ToString();
                var parametro5 = _comandosql.Parameters.Add("@date", SqlDbType.Date);
                parametro5.Value = DateTime.Now.ToString();

                _adaptador.InsertCommand = _comandosql;
                _comandosql.ExecuteNonQuery();
            }

            txt.Close();

            Doc.Add(table);
            Doc.Close();
        }

        public void PDF_Recibo_Nomina(DataTable tabla_emp, DataTable tabla_inc, DataTable tabla_cam, DataTable tabla_cam2, DataTable tabla_per, DataTable tabla_ded)
        {
            foreach (DataRow row in tabla_emp.Rows)
            {
                Document Doc = new Document();
                PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_MAD/Recibo_Nomina_Empleado.pdf", FileMode.Create));

                Doc.Open();
                Paragraph titulo = new Paragraph();
                titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                titulo.Add("NOMBRE: " + row["NOMBRE_COMPLETO"].ToString() + "    NUMERO SEGURO SOCIAL: " + row["NSS"].ToString() + "    RFC: " + row["RFC"].ToString() + "    FECHA: " + row["EJECUCION"].ToString() + "       " + "    FRECUENCIA PAGO:" + row["FP"].ToString());
                titulo.Add("");
                Doc.Add(titulo);

                Paragraph emp = new Paragraph();
                emp.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                emp.Add("RAZON SOCIAL: " + row["NOMBRE_EMPRESA"].ToString() + "    REGISTRO PATRONAL: " + row["RP"].ToString() + "    REGISTRO FEDERAL: " + row["RF"].ToString() + "    EMAIL: " + row["EMAIL"].ToString());
                emp.Add("");
                Doc.Add(emp);
                Doc.Add(new Paragraph(" "));

                PdfPTable tableincidencias = new PdfPTable(2);

                tableincidencias.AddCell("INCIDENCIA");
                tableincidencias.AddCell("DIAS");

                foreach (DataRow item in tabla_inc.Rows)
                {
                    tableincidencias.AddCell(item["Nombre"].ToString());
                    tableincidencias.AddCell(item["Dias"].ToString());
                }

                Doc.Add(tableincidencias);

                Doc.Add(new Paragraph(" "));
                PdfPTable tableDatos = new PdfPTable(2);

                tableDatos.AddCell("SUELDO BASE");
                tableDatos.AddCell("NIVEL SALARIAL");

                tableDatos.AddCell(row["SB"].ToString());
                tableDatos.AddCell(row["NS"].ToString());

                Doc.Add(tableDatos);

                Doc.Add(new Paragraph(" "));
                Doc.Add(new Paragraph("PERCEPCIONES Y DEDUCCIONES: "));
                Doc.Add(new Paragraph(" "));

                PdfPTable tablePercep = new PdfPTable(3);

                tablePercep.AddCell("CLAVE");
                tablePercep.AddCell("RAZON PERCEPCION");
                tablePercep.AddCell("VALOR");

                foreach (DataRow item in tabla_cam.Rows)
                {
                    if ((int)item["Activo"] == 1)
                    {
                        if (item["Tipo"].ToString() == "Percepcion")
                        {
                            tablePercep.AddCell(item["Clave"].ToString());
                            tablePercep.AddCell(item["Nombre"].ToString());

                            if (float.Parse(item["Porcentaje"].ToString()) == 0)
                                tablePercep.AddCell(item["Valor"].ToString());

                            if (float.Parse(item["Valor"].ToString()) == 0)
                            {
                                float aux = float.Parse(row["SB"].ToString()) * float.Parse(item["Porcentaje"].ToString());
                                tablePercep.AddCell(aux.ToString());
                            }
                        }
                    }
                }

                foreach (DataRow item in tabla_per.Rows)
                {
                    tablePercep.AddCell(item["clave"].ToString());
                    tablePercep.AddCell(item["Motivo_Per"].ToString());

                    if (float.Parse(item["Porcentaje"].ToString()) == 0)
                        tablePercep.AddCell(item["Monto_Fijo"].ToString());

                    if (float.Parse(item["Monto_Fijo"].ToString()) == 0)
                    {
                        float sb = float.Parse(row["SB"].ToString()) * float.Parse(item["Porcentaje"].ToString());
                        tablePercep.AddCell(sb.ToString());
                    }
                }

                Doc.Add(tablePercep);
                Doc.Add(new Paragraph(" "));

                PdfPTable tableDedu = new PdfPTable(3);

                tableDedu.AddCell("CLAVE");
                tableDedu.AddCell("RAZON DEDUCCION");
                tableDedu.AddCell("VALOR");

                foreach (DataRow item in tabla_cam2.Rows)
                {
                    if ((int)item["Activo"] == 1)
                    {
                        if (item["Tipo"].ToString() == "Deduccion")
                        {
                            tableDedu.AddCell(item["Clave"].ToString());
                            tableDedu.AddCell(item["Nombre"].ToString());

                            if (float.Parse(item["Porcentaje"].ToString()) == 0)
                                tableDedu.AddCell(item["Valor"].ToString());

                            if (float.Parse(item["Valor"].ToString()) == 0)
                            {
                                float aux = float.Parse(row["SB"].ToString()) * float.Parse(item["Porcentaje"].ToString());
                                tableDedu.AddCell(aux.ToString());
                            }
                        }
                    }
                }

                foreach (DataRow item in tabla_ded.Rows)
                {
                    tableDedu.AddCell(item["clave"].ToString());
                    tableDedu.AddCell(item["Motivo_Ded"].ToString());

                    if (float.Parse(item["Porcentaje"].ToString()) == 0)
                        tableDedu.AddCell(item["Monto_Fijo"].ToString());

                    if (float.Parse(item["Monto_Fijo"].ToString()) == 0)
                    {
                        float sb = float.Parse(row["SB"].ToString()) * float.Parse(item["Porcentaje"].ToString());
                        tableDedu.AddCell(sb.ToString());
                    }
                }

                Doc.Add(tableDedu);

                Conversion conv = new Conversion();
                Doc.Add(new Paragraph(" "));
                Doc.Add(new Paragraph("PAGO NETO: " + row["MONTO"].ToString() + "    " + conv.enletras(row["MONTO"].ToString())));
                Doc.Close();

                break;
            }
        }

        public void PDF_Reporte_Nomina_General(DataTable tabla)
        {
            Document Doc = new Document();
            PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_MAD/Reporte_Nomina_General.pdf", FileMode.Create));

            Doc.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 15f, BaseColor.BLACK);
            titulo.Add("REPORTE NOMINA GENERAL");
            Doc.Add(titulo);
            Doc.Add(new Paragraph(" "));

            PdfPTable table = new PdfPTable(6);
            table.AddCell("DEPARTAMENTO");
            table.AddCell("PUESTO");
            table.AddCell("NOMBRE");
            table.AddCell("FECHA INGRESO");
            table.AddCell("FECHA NAC");
            table.AddCell("SALARIO DIARIO");

            foreach (DataRow row in tabla.Rows)
            {
                table.AddCell(row["DEPARTAMENTO"].ToString());
                table.AddCell(row["PUESTO"].ToString());
                table.AddCell(row["NOMBRE_COMPLETO"].ToString());
                table.AddCell(row["FECHA_INGRESO"].ToString());
                table.AddCell(row["FECHA_NAC"].ToString());
                table.AddCell(row["SALARIO_DIARIO"].ToString());
            }

            Doc.Add(table);
            Doc.Close();
            MessageBox.Show("Archivo Reporte Nomina General generado", "PDF", MessageBoxButtons.OK);
        }

        public void PDF_Reporte_HeadCounter(DataTable tabla_uno, DataTable tabla_dos)
        {
            Document Doc = new Document();
            PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_MAD/Reporte_Headcounter.pdf", FileMode.Create));

            Doc.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 15f, BaseColor.BLACK);
            titulo.Add("REPORTE HEADCOUNTER");
            Doc.Add(titulo);
            Doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(5);
            tabla.AddCell("EMPRESA");
            tabla.AddCell("DEPARTAMENTO");
            tabla.AddCell("GERENTE");
            tabla.AddCell("PUESTO");
            tabla.AddCell("NUM EMPLEADOS");

            foreach (DataRow row in tabla_uno.Rows)
            {
                tabla.AddCell(row["EMPRESA"].ToString());
                tabla.AddCell(row["DEPARTAMENTO"].ToString());
                tabla.AddCell(row["GERENTE"].ToString());
                tabla.AddCell(row["PUESTO"].ToString());
                tabla.AddCell(row["NUM_EMPLEADOS"].ToString());
            }

            Doc.Add(tabla);
            Doc.Add(new Paragraph(" "));

            PdfPTable tabla2 = new PdfPTable(5);
            tabla2.AddCell("EMPRESA");
            tabla2.AddCell("DEPARTAMENTO");
            tabla2.AddCell("GERENTE");
            tabla2.AddCell("NUM EMPLEADOS");
            tabla2.AddCell("ULTIMA EJECUCION DE NOMINA");
            
            foreach (DataRow row in tabla_dos.Rows)
            {
                tabla2.AddCell(row["EMPRESA"].ToString());
                tabla2.AddCell(row["DEPARTAMENTO"].ToString());
                tabla2.AddCell(row["GERENTE"].ToString());
                tabla2.AddCell(row["NUM_EMPLEADOS"].ToString());
                tabla2.AddCell(row["EJECUCION"].ToString());
            }

            Doc.Add(tabla2);
            Doc.Close();
            MessageBox.Show("Archivo Reporte Headcounter generado", "PDF", MessageBoxButtons.OK);
        }

        public void PDF_Reportes_Nomina(DataTable tabla_uno, DataTable tabla_dos)
        {
            Document Doc = new Document();
            PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_MAD/Reportes_Nomina.pdf", FileMode.Create));

            Doc.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 15f, BaseColor.BLACK);
            titulo.Add("REPORTES NOMINA");
            Doc.Add(titulo);
            Doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(6);
            tabla.AddCell("EMPRESA");
            tabla.AddCell("DEPARTAMENTO");
            tabla.AddCell("IMSS");
            tabla.AddCell("ISR");
            tabla.AddCell("SUELDO BRUTO");
            tabla.AddCell("SUELDO NETO");
            
            foreach (DataRow row in tabla_uno.Rows)
            {
                tabla.AddCell(row["EMPRESA"].ToString());
                tabla.AddCell(row["DEPARTAMENTO"].ToString());
                tabla.AddCell(row["IMSS"].ToString());
                tabla.AddCell(row["ISR"].ToString());
                tabla.AddCell(row["SUELDO_BRUTO"].ToString());
                tabla.AddCell(row["SUELDO_NETO"].ToString());
            }

            foreach (DataRow row in tabla_dos.Rows)
            {
                tabla.AddCell(row["EMPRESA"].ToString());
                tabla.AddCell(row["DEPARTAMENTO"].ToString());
                tabla.AddCell(row["IMSS"].ToString());
                tabla.AddCell(row["ISR"].ToString());
                tabla.AddCell(row["SUELDO_BRUTO"].ToString());
                tabla.AddCell(row["SUELDO_NETO"].ToString());
            }

            Doc.Add(tabla);
            Doc.Close();
            MessageBox.Show("Archivo Reportes Nomina generado", "PDF", MessageBoxButtons.OK);
        }




        public void Acciones_Domicilio(string opc, Domicilio dom)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Direccion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Calle", SqlDbType.VarChar, 40);
                parametro2.Value = dom.txt_Calle;
                var parametro3 = _comandosql.Parameters.Add("@Num", SqlDbType.VarChar, 30);
                parametro3.Value = dom.txt_NumCasa;
                var parametro4 = _comandosql.Parameters.Add("@Colonia", SqlDbType.VarChar, 30);
                parametro4.Value = dom.txt_Colonia;
                var parametro5 = _comandosql.Parameters.Add("@Municipio", SqlDbType.VarChar, 20);
                parametro5.Value = dom.txt_Municipio;
                var parametro6 = _comandosql.Parameters.Add("@Estado", SqlDbType.VarChar, 20);
                parametro6.Value = dom.txt_Estado;
                var parametro7 = _comandosql.Parameters.Add("@CP", SqlDbType.VarChar, 20);
                parametro7.Value = dom.txt_CP;

                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            
        }

        public void Acciones_Empresa(string opc, Empresa emp, Domicilio dom, int id_empresa)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Empresa";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A") {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@RS", SqlDbType.VarChar, 20);
                    parametro2.Value = emp.txt_RS;
                    var parametro3 = _comandosql.Parameters.Add("@Email", SqlDbType.VarChar, 30);
                    parametro3.Value = emp.txt_Email;
                    var parametro4 = _comandosql.Parameters.Add("@RP", SqlDbType.VarChar, 20);
                    parametro4.Value = emp.txt_RP;
                    var parametro5 = _comandosql.Parameters.Add("@RF", SqlDbType.VarChar, 20);
                    parametro5.Value = emp.txt_RF;
                    var parametro6 = _comandosql.Parameters.Add("@FInicio", SqlDbType.DateTime);
                    parametro6.Value = emp.date_FchaInicio;
                    var parametro7 = _comandosql.Parameters.Add("@FP", SqlDbType.Int);
                    parametro7.Value = emp.int_FPago;
                    var parametro8 = _comandosql.Parameters.Add("@FP2", SqlDbType.Int);
                    parametro8.Value = emp.int_FPago2;

                    _adaptador.SelectCommand = _comandosql;
                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B") {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Id", SqlDbType.VarChar, 30);
                    parametro2.Value = id_empresa;

                    _adaptador.DeleteCommand = _comandosql;
                }

                if (opc == "C")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@RS", SqlDbType.VarChar, 20);
                    parametro2.Value = emp.txt_RS;
                    var parametro3 = _comandosql.Parameters.Add("@Email", SqlDbType.VarChar, 30);
                    parametro3.Value = emp.txt_Email;
                    var parametro4 = _comandosql.Parameters.Add("@RP", SqlDbType.VarChar, 20);
                    parametro4.Value = emp.txt_RP;
                    var parametro5 = _comandosql.Parameters.Add("@RF", SqlDbType.VarChar, 20);
                    parametro5.Value = emp.txt_RF;
                    var parametro6 = _comandosql.Parameters.Add("@FInicio", SqlDbType.DateTime);
                    parametro6.Value = emp.date_FchaInicio;
                    var parametro7 = _comandosql.Parameters.Add("@FP", SqlDbType.Int);
                    parametro7.Value = emp.int_FPago;
                    var parametro8 = _comandosql.Parameters.Add("@FP2", SqlDbType.Int);
                    parametro8.Value = emp.int_FPago2;
                    
                    var parametro10 = _comandosql.Parameters.Add("@Calle", SqlDbType.VarChar, 40);
                    parametro10.Value = dom.txt_Calle;
                    var parametro11 = _comandosql.Parameters.Add("@Num", SqlDbType.VarChar, 30);
                    parametro11.Value = dom.txt_NumCasa;
                    var parametro12 = _comandosql.Parameters.Add("@Colonia", SqlDbType.VarChar, 30);
                    parametro12.Value = dom.txt_Colonia;
                    var parametro13 = _comandosql.Parameters.Add("@Municipio", SqlDbType.VarChar, 20);
                    parametro13.Value = dom.txt_Municipio;
                    var parametro14 = _comandosql.Parameters.Add("@Estado", SqlDbType.VarChar, 20);
                    parametro14.Value = dom.txt_Estado;
                    var parametro15 = _comandosql.Parameters.Add("@CP", SqlDbType.VarChar, 20);
                    parametro15.Value = dom.txt_CP;

                    var parametro16 = _comandosql.Parameters.Add("@Id", SqlDbType.Int);
                    parametro16.Value = id_empresa;

                    _adaptador.UpdateCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Empleado(string opc, Empleado_info emp, Domicilio dom)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Empleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 30);
                    parametro2.Value = emp.txt_Contrasenia;
                    var parametro3 = _comandosql.Parameters.Add("@Nombres", SqlDbType.VarChar, 50);
                    parametro3.Value = emp.txt_Nombre;
                    var parametro4 = _comandosql.Parameters.Add("@Ap_Paterno", SqlDbType.VarChar, 30);
                    parametro4.Value = emp.txt_Apellido_Pat;
                    var parametro5 = _comandosql.Parameters.Add("@Ap_Materno", SqlDbType.VarChar, 30);
                    parametro5.Value = emp.txt_Apellido_Mat;
                    var parametro6 = _comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 20);
                    parametro6.Value = emp.txt_CURP;
                    var parametro7 = _comandosql.Parameters.Add("@NSS", SqlDbType.VarChar, 20);
                    parametro7.Value = emp.txt_NSS;
                    var parametro8 = _comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 20);
                    parametro8.Value = emp.txt_RFC;
                    var parametro9 = _comandosql.Parameters.Add("@NumCuenta", SqlDbType.VarChar, 30);
                    parametro9.Value = emp.txt_NumCuenta;
                    var parametro10 = _comandosql.Parameters.Add("@Email", SqlDbType.VarChar, 30);
                    parametro10.Value = emp.txt_Email;
                    var parametro11 = _comandosql.Parameters.Add("@Tel", SqlDbType.VarChar, 30);
                    parametro11.Value = emp.txt_Telefono;
                    var parametro12 = _comandosql.Parameters.Add("@Dias", SqlDbType.Int);
                    parametro12.Value = emp.int_FPago;
                    var parametro13 = _comandosql.Parameters.Add("@FPagos", SqlDbType.Int);
                    parametro13.Value = emp.int_FPago;
                    var parametro14 = _comandosql.Parameters.Add("@Tipo", SqlDbType.Int);
                    parametro14.Value = emp.int_Tipo;
                    var parametro15 = _comandosql.Parameters.Add("@SueldoBase", SqlDbType.VarChar, 30);
                    parametro15.Value = emp.fSueldoBase;
                    var parametro16 = _comandosql.Parameters.Add("@FInicio", SqlDbType.Date);
                    parametro16.Value = emp.date_FInicio;
                    var parametro17 = _comandosql.Parameters.Add("@FNac", SqlDbType.Date);
                    parametro17.Value = emp.date_FchaNac;
                    var parametro18 = _comandosql.Parameters.Add("@Banco", SqlDbType.VarChar, 20);
                    parametro18.Value = emp.txt_Banco;

                    var parametro19 = _comandosql.Parameters.Add("@ID_Emp", SqlDbType.Int);
                    parametro19.Value = AccionesForms.SQL_ID_Empresa;
                    var parametro20 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                    parametro20.Value = AccionesForms.SQL_ID_Depto;
                    var parametro21 = _comandosql.Parameters.Add("@ID_Pue", SqlDbType.Int);
                    parametro21.Value = AccionesForms.SQL_ID_Puesto;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@ID", SqlDbType.Int);
                    parametro2.Value = AccionesForms.SQL_ID_Empleado;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "C")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 30);
                    parametro2.Value = emp.txt_Contrasenia;
                    var parametro3 = _comandosql.Parameters.Add("@Nombres", SqlDbType.VarChar, 50);
                    parametro3.Value = emp.txt_Nombre;
                    var parametro4 = _comandosql.Parameters.Add("@Ap_Paterno", SqlDbType.VarChar, 30);
                    parametro4.Value = emp.txt_Apellido_Pat;
                    var parametro5 = _comandosql.Parameters.Add("@Ap_Materno", SqlDbType.VarChar, 30);
                    parametro5.Value = emp.txt_Apellido_Mat;
                    var parametro6 = _comandosql.Parameters.Add("@CURP", SqlDbType.VarChar, 20);
                    parametro6.Value = emp.txt_CURP;
                    var parametro7 = _comandosql.Parameters.Add("@NSS", SqlDbType.VarChar, 20);
                    parametro7.Value = emp.txt_NSS;
                    var parametro8 = _comandosql.Parameters.Add("@RFC", SqlDbType.VarChar, 20);
                    parametro8.Value = emp.txt_RFC;
                    var parametro9 = _comandosql.Parameters.Add("@NumCuenta", SqlDbType.VarChar, 30);
                    parametro9.Value = emp.txt_NumCuenta;
                    var parametro10 = _comandosql.Parameters.Add("@Email", SqlDbType.VarChar, 30);
                    parametro10.Value = emp.txt_Email;
                    var parametro11 = _comandosql.Parameters.Add("@Tel", SqlDbType.VarChar, 30);
                    parametro11.Value = emp.txt_Telefono;
                    var parametro12 = _comandosql.Parameters.Add("@Dias", SqlDbType.Int);
                    parametro12.Value = emp.int_FPago;
                    var parametro13 = _comandosql.Parameters.Add("@FPagos", SqlDbType.Int);
                    parametro13.Value = emp.int_FPago;
                    var parametro14 = _comandosql.Parameters.Add("@Tipo", SqlDbType.Int);
                    parametro14.Value = emp.int_Tipo;
                    var parametro15 = _comandosql.Parameters.Add("@SueldoBase", SqlDbType.VarChar, 30);
                    parametro15.Value = emp.fSueldoBase;
                    var parametro16 = _comandosql.Parameters.Add("@FInicio", SqlDbType.Date);
                    parametro16.Value = emp.date_FInicio;
                    var parametro17 = _comandosql.Parameters.Add("@FNac", SqlDbType.Date);
                    parametro17.Value = emp.date_FchaNac;
                    var parametro18 = _comandosql.Parameters.Add("@Banco", SqlDbType.VarChar, 20);
                    parametro18.Value = emp.txt_Banco;

                    var parametro19 = _comandosql.Parameters.Add("@Calle", SqlDbType.VarChar, 40);
                    parametro19.Value = dom.txt_Calle;
                    var parametro20 = _comandosql.Parameters.Add("@Num", SqlDbType.VarChar, 30);
                    parametro20.Value = dom.txt_NumCasa;
                    var parametro21 = _comandosql.Parameters.Add("@Colonia", SqlDbType.VarChar, 30);
                    parametro21.Value = dom.txt_Colonia;
                    var parametro22 = _comandosql.Parameters.Add("@Municipio", SqlDbType.VarChar, 20);
                    parametro22.Value = dom.txt_Municipio;
                    var parametro23 = _comandosql.Parameters.Add("@Estado", SqlDbType.VarChar, 20);
                    parametro23.Value = dom.txt_Estado;
                    var parametro24 = _comandosql.Parameters.Add("@CP", SqlDbType.VarChar, 20);
                    parametro24.Value = dom.txt_CP;

                    var parametro25 = _comandosql.Parameters.Add("@ID", SqlDbType.Int);
                    parametro25.Value = AccionesForms.SQL_ID_Empleado;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "D")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@ID_Emp", SqlDbType.Int);
                    parametro2.Value = AccionesForms.SQL_ID_Empresa;
                }

                if (opc == "E") {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@ID", SqlDbType.Int);
                    parametro2.Value = emp.ID_Empleado;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Emp", SqlDbType.Int);
                    parametro3.Value = AccionesForms.SQL_ID_Empresa;

                    _adaptador.UpdateCommand = _comandosql;
                }

                if (opc == "J")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@ID", SqlDbType.Int);
                    parametro2.Value = emp.ID_Empleado;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                    parametro3.Value = AccionesForms.SQL_ID_Depto;

                    _adaptador.UpdateCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Banco(string opc, Banco ban)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Banco";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20);
                parametro2.Value = ban.txt_Nombre;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.InsertCommand = _comandosql;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Departamento(string opc, Departamento dep, int id_depto)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Departamento";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A")
                {
                    var parametro1 = _comandosql.Parameters.Add("@opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20);
                    parametro2.Value = dep.txt_Nombre;
                    var parametro3 = _comandosql.Parameters.Add("@SueldoBase", SqlDbType.VarChar, 20);
                    parametro3.Value = dep.money_SueldoBase;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B")
                {
                    var parametro1 = _comandosql.Parameters.Add("@opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                    parametro2.Value = id_depto;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "C")
                {
                    var parametro1 = _comandosql.Parameters.Add("@opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20);
                    parametro2.Value = dep.txt_Nombre;
                    var parametro3 = _comandosql.Parameters.Add("@SueldoBase", SqlDbType.VarChar, 20);
                    parametro3.Value = dep.money_SueldoBase;
                    var parametro4 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                    parametro4.Value = id_depto;

                    _adaptador.InsertCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Puesto(string opc, Puesto pue)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Puesto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20);
                    parametro2.Value = pue.txt_Nombre;
                    var parametro3 = _comandosql.Parameters.Add("@NivelSalarial", SqlDbType.VarChar, 20);
                    parametro3.Value = pue.fNivelSalarial;
                    var parametro4 = _comandosql.Parameters.Add("@id_Empresa", SqlDbType.Int);
                    parametro4.Value = AccionesForms.SQL_ID_Empresa;
                    var parametro5 = _comandosql.Parameters.Add("@id_Depto", SqlDbType.Int);
                    parametro5.Value = pue.ID_Departamento;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                    parametro2.Value = pue.ID_Puesto;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "C")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Nombre", SqlDbType.VarChar, 20);
                    parametro2.Value = pue.txt_Nombre;
                    var parametro3 = _comandosql.Parameters.Add("@NivelSalarial", SqlDbType.VarChar, 20);
                    parametro3.Value = pue.fNivelSalarial;
                    var parametro4 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                    parametro4.Value = AccionesForms.SQL_ID_Puesto;

                    _adaptador.UpdateCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Percepciones(string opc, string percepcion, int id_empleado, int id_empresa)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Percepciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@txt_Nom_Per", SqlDbType.VarChar, 20);
                    parametro2.Value = percepcion;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                    parametro3.Value = id_empleado;
                    var parametro4 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                    parametro4.Value = id_empresa;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Clave", SqlDbType.VarChar, 20);
                    parametro2.Value = id_empresa;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                    parametro3.Value = id_empleado;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "C")
                {

                    _adaptador.UpdateCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Deducciones(string opc, string deduccion, int id_empleado, int id_empresa)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Deducciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@txt_Nom_Ded", SqlDbType.VarChar, 20);
                    parametro2.Value = deduccion;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                    parametro3.Value = id_empleado;
                    var parametro4 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                    parametro4.Value = id_empresa;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Clave", SqlDbType.VarChar, 20);
                    parametro2.Value = id_empresa;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                    parametro3.Value = id_empleado;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "C")
                {

                    _adaptador.UpdateCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Cambios(string opc, int id_empresa, Cambios cam)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Cambios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@monto", SqlDbType.VarChar, 20);
                    parametro2.Value = cam.monto;
                    var parametro3 = _comandosql.Parameters.Add("@tipo", SqlDbType.VarChar, 20);
                    parametro3.Value = cam.tipo;
                    var parametro4 = _comandosql.Parameters.Add("@valor", SqlDbType.VarChar, 20);
                    parametro4.Value = cam.valor;
                    var parametro5 = _comandosql.Parameters.Add("@porcentaje", SqlDbType.VarChar, 20);
                    parametro5.Value = cam.porcentaje;
                    var parametro6 = _comandosql.Parameters.Add("@activo", SqlDbType.Int);
                    parametro6.Value = cam.activo;
                    var parametro7 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                    parametro7.Value = id_empresa;
                    var parametro8 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 20);
                    parametro8.Value = cam.nombre;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Clave", SqlDbType.Int);
                    parametro2.Value = cam.SQL_Clave;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "C")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Clave", SqlDbType.Int);
                    parametro2.Value = cam.SQL_Clave;

                    _adaptador.UpdateCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Acciones_Incidencias(string opc, int id_empresa, int id_empleado, string texto, int dias, DateTime date)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Incidencias";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "A")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Incidencia", SqlDbType.VarChar, 30);
                    parametro2.Value = texto;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                    parametro3.Value = id_empleado;
                    var parametro4 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                    parametro4.Value = id_empresa;
                    var parametro5 = _comandosql.Parameters.Add("@int_dias", SqlDbType.Int);
                    parametro5.Value = dias;
                    var parametro6 = _comandosql.Parameters.Add("@date_eje", SqlDbType.Date);
                    parametro6.Value = date;

                    _adaptador.InsertCommand = _comandosql;
                }

                if (opc == "B")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@Incidencia", SqlDbType.VarChar, 30);
                    parametro2.Value = texto;
                    var parametro3 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                    parametro3.Value = id_empleado;

                    _adaptador.InsertCommand = _comandosql;
                }

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

        public void Baja_Nomina(string opc, int id_empresa)
        {
            var msg = "";
            bool add = true;
            try
            {
                conectar();
                string qry = "sp_Nomina";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                
                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                parametro2.Value = id_empresa;

                _adaptador.DeleteCommand = _comandosql;

                _comandosql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                add = false;
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }



        public DataTable Obtener_Domicilio(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Direccion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Obtener_Empresa(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empresa";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Obtener_Deptos(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Departamento";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Empleados_By_Empresa(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Emp", SqlDbType.Int);
                parametro2.Value = AccionesForms.SQL_ID_Empresa;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Empleados_By_Depto(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                parametro2.Value = AccionesForms.SQL_ID_Depto;
                var parametro3 = _comandosql.Parameters.Add("@ID_Emp", SqlDbType.Int);
                parametro3.Value = AccionesForms.SQL_ID_Empresa;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Empleados_By_Deptos(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                parametro2.Value = AccionesForms.SQL_ID_Depto;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Empleados_By_Puesto(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Puesto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Id", SqlDbType.Int);
                parametro2.Value = id;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Empleados_By_Id(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Id", SqlDbType.Int);
                parametro2.Value = id;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable GetAllEmpleados(string opc, string user, string contrasenia)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Nombres", SqlDbType.Char, 50);
                parametro2.Value = user;
                var parametro3 = _comandosql.Parameters.Add("@Contrasenia", SqlDbType.Char, 30);
                parametro3.Value = contrasenia;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Empresa_By_ID(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empresa";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Id", SqlDbType.Int);
                parametro2.Value = id;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Depto_By_ID(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Departamento";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@Id", SqlDbType.Int);
                parametro2.Value = id;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Puestos_By_Depto(string opc, int id_empresa, int id_depto)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Puesto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@id_Empresa", SqlDbType.Int);
                parametro2.Value = id_empresa;
                var parametro3 = _comandosql.Parameters.Add("@id_Depto", SqlDbType.Int);
                parametro3.Value = id_depto;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Puestos_By_Deptos(string opc, int id_depto)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Puesto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro3 = _comandosql.Parameters.Add("@id_Depto", SqlDbType.Int);
                parametro3.Value = id_depto;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Puesto_By_Id(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Puesto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro2.Value = AccionesForms.SQL_ID_Puesto;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Puesto_By_Empresa(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Puesto";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@id_Empresa", SqlDbType.Int);
                parametro2.Value = id;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Obtener_EmpleadoInfo(string opc, int ID_empresa)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Empleado";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                if (opc == "D")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                }

                if (opc == "F")
                {
                    var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                    parametro1.Value = opc;
                    var parametro2 = _comandosql.Parameters.Add("@ID", SqlDbType.Int);
                    parametro2.Value = ID_empresa;
                }

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable GetAllCambios(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Cambios";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                parametro2.Value = AccionesForms.SQL_ID_Empresa;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Percepciones_By_Empleado(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Percepciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                parametro2.Value = id;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Deducciones_By_Empleado(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Deducciones";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                parametro2.Value = id;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Get_Incidencias_By_Empleado(string opc, int id)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Incidencias";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                parametro2.Value = id;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Reporte_Nomina_Empresa(string opc)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Reportes";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                parametro1.Value = opc;
                var parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                parametro2.Value = AccionesForms.SQL_ID_Empresa;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                PDF_Reporte_Nomina_Empresa(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public void Recibo_Nomina(string opcB, string opcD, int id_empleado, int id_empresa)
        {
            var msg = "";
            DataTable tabla_empleado = new DataTable();
            DataTable tabla_incidencias = new DataTable();
            DataTable tabla_cambios = new DataTable();
            DataTable tabla_cambios2 = new DataTable();
            DataTable tabla_per = new DataTable();
            DataTable tabla_ded = new DataTable();
            try
            {
                conectar();
                string qry_rep = "sp_Reportes";
                _comandosql = new SqlCommand(qry_rep, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var rep_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                rep_parametro1.Value = opcB;
                var rep_parametro2 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                rep_parametro2.Value = id_empleado;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_empleado);




                string qry_inc = "sp_Incidencias";
                _comandosql = new SqlCommand(qry_inc, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var inc_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                inc_parametro1.Value = opcD;
                var inc_parametro2 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                inc_parametro2.Value = id_empleado;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_incidencias);




                string qry_cam = "sp_Cambios";
                _comandosql = new SqlCommand(qry_cam, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var cam_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                cam_parametro1.Value = opcD;
                var cam_parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                cam_parametro2.Value = id_empresa;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_cambios);




                string qry_cam2 = "sp_Cambios";
                _comandosql = new SqlCommand(qry_cam2, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var cam2_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                cam2_parametro1.Value = opcD;
                var cam2_parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                cam2_parametro2.Value = id_empresa;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_cambios2);




                string qry_per = "sp_Percepciones";
                _comandosql = new SqlCommand(qry_per, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var per_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                per_parametro1.Value = opcD;
                var per_parametro2 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                per_parametro2.Value = id_empleado;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_per);




                string qry_ded = "sp_Deducciones";
                _comandosql = new SqlCommand(qry_ded, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var ded_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                ded_parametro1.Value = opcD;
                var ded_parametro2 = _comandosql.Parameters.Add("@ID_Empleado", SqlDbType.Int);
                ded_parametro2.Value = id_empleado;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_ded);


                PDF_Recibo_Nomina(tabla_empleado, tabla_incidencias, tabla_cambios, tabla_cambios2, tabla_per, tabla_ded);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        public void Reporte_Nomina_General(string opcC, int id_empresa, DateTime date)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry_rep = "sp_Reportes";
                _comandosql = new SqlCommand(qry_rep, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var rep_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                rep_parametro1.Value = opcC;
                var rep_parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                rep_parametro2.Value = id_empresa;
                var rep_parametro3 = _comandosql.Parameters.Add("@date_filtro", SqlDbType.Date);
                rep_parametro3.Value = date;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

                PDF_Reporte_Nomina_General(tabla);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        public void Reporte_HeadCounter(string opcD, string opcE, int id_empresa, int id_depto, DateTime date)
        {
            var msg = "";
            DataTable tabla_uno = new DataTable();
            DataTable tabla_dos = new DataTable();
            try
            {
                conectar();
                string qry_uno = "sp_Reportes";
                _comandosql = new SqlCommand(qry_uno, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var uno_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                uno_parametro1.Value = opcD;
                var uno_parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                uno_parametro2.Value = id_empresa;
                var uno_parametro3 = _comandosql.Parameters.Add("@date_filtro", SqlDbType.Date);
                uno_parametro3.Value = date;
                var uno_parametro4 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                uno_parametro4.Value = id_depto;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_uno);


                string qry_dos = "sp_Reportes";
                _comandosql = new SqlCommand(qry_dos, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var dos_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                dos_parametro1.Value = opcE;
                var dos_parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                dos_parametro2.Value = id_empresa;
                var dos_parametro3 = _comandosql.Parameters.Add("@date_filtro", SqlDbType.Date);
                dos_parametro3.Value = date;
                var dos_parametro4 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                dos_parametro4.Value = id_depto;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_dos);


                PDF_Reporte_HeadCounter(tabla_uno, tabla_dos);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        public void Reportes_Nomina(string opcF, string opcG, int id_empresa, int id_depto, DateTime date)
        {
            var msg = "";
            DataTable tabla_uno = new DataTable();
            DataTable tabla_dos = new DataTable();
            try
            {
                conectar();
                string qry_uno = "sp_Reportes";
                _comandosql = new SqlCommand(qry_uno, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var uno_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                uno_parametro1.Value = opcF;
                var uno_parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                uno_parametro2.Value = id_empresa;
                var uno_parametro3 = _comandosql.Parameters.Add("@date_filtro", SqlDbType.Date);
                uno_parametro3.Value = date;
                var uno_parametro4 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                uno_parametro4.Value = id_depto;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_uno);


                string qry_dos = "sp_Reportes";
                _comandosql = new SqlCommand(qry_dos, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var dos_parametro1 = _comandosql.Parameters.Add("@Opc", SqlDbType.Char, 1);
                dos_parametro1.Value = opcG;
                var dos_parametro2 = _comandosql.Parameters.Add("@ID_Empresa", SqlDbType.Int);
                dos_parametro2.Value = id_empresa;
                var dos_parametro3 = _comandosql.Parameters.Add("@date_filtro", SqlDbType.Date);
                dos_parametro3.Value = date;
                var dos_parametro4 = _comandosql.Parameters.Add("@ID_Depto", SqlDbType.Int);
                dos_parametro4.Value = id_depto;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla_dos);


                PDF_Reportes_Nomina(tabla_uno, tabla_dos);
            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
    }
}
