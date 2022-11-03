using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using System.Configuration;
using System.Windows.Forms;
using Ventanas_Finales_Siksi.Tablas_CQL;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using NumerosALetras;

namespace Ventanas_Finales_Siksi
{
    class EnlaceCassandra
    {
        static private string _dbServer { set; get; }
        static private string _dbKeySpace { set; get; }
        static private Cluster _cluster;
        static private ISession _session;

        public static void conectar()
        {
            _dbServer = ConfigurationManager.AppSettings["Cluster"].ToString();
            _dbKeySpace = ConfigurationManager.AppSettings["KeySpace"].ToString();

            _cluster = Cluster.Builder()
                .AddContactPoint(_dbServer)
                .Build();

            _session = _cluster.Connect(_dbKeySpace);
        }
        
        private static void conectar2()
        {
            _cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1")
                .Build();

            _session = _cluster.Connect("keyspace3");
        }
         
        public static void desconectar()
        {
            _cluster.Dispose();
        }



        public void Agregar_Empresa(string opc, Empresa emp, Domicilio dom)
        {
            try
            {
                string query = "insert into Empresas (ID_Empresa, txt_RS, txt_Email, txt_RP, txt_RF, date_FInicio, int_FP, txt_Calle, txt_Num, txt_Colonia, txt_Municipio, txt_Estado, txt_CP) values(UUID(), '" + emp.txt_RS + "', '" + emp.txt_Email + "', '" + emp.txt_RP + "', '" + emp.txt_RF + "', '" + emp.date_FchaInicio.ToString("yyyy-MM-dd") + "', {" + emp.int_FPago + "," + emp.int_FPago2 + "}, '" + dom.txt_Calle + "', '" + dom.txt_NumCasa + "', '" + dom.txt_Colonia  + "', '" + dom.txt_Municipio + "', '" + dom.txt_Estado + "', '" + dom.txt_CP + "');";
                
                _session.Execute(query);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Agregar_Departamento(string opc, Departamento dep)
        {
            try
            {
                string qry = "";

                string query = "insert into Departamentos(ID_Departamento, txt_Nombre, money_SB) values(UUID(), '{0}', {1});";
                qry = string.Format(query, dep.txt_Nombre, dep.money_SueldoBase);

                _session.Execute(qry);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Agregar_Puesto(string opc, Puesto pue, Departamento dep)
        {
            try
            {
                Guid id_pue = Guid.NewGuid();
                string qry = "";

                string query = "INSERT INTO Puestos (ID_Puesto, txt_Nom_Pue, float_NS, money_SD, ID_Departamento, ID_Empresa) values({0}, '{1}', {2}, {3}, {4}, {5});";
                qry = string.Format(query, id_pue, pue.txt_Nombre, pue.fNivelSalarial, pue.money_SalarioDiario, dep.ID_Departamento, AccionesForms.ID_Empresa);
                _session.Execute(qry);

                //string query2 = "INSERT INTO Puestos_By_Empresa_Depto (ID_Puesto, txt_Nom_Pue, float_NS, money_SD, ID_Departamento, ID_Empresa) values({0}, '{1}', {2}, {3}, {4}, {5});";
                //qry2 = string.Format(query2, id_pue, pue.txt_Nombre, pue.fNivelSalarial, pue.money_SalarioDiario, dep.ID_Departamento, AccionesForms.ID_Empresa);
                //_session.Execute(qry2);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Agregar_Empleado(string opc, Empleado_info emp, Banco ban, Domicilio dom)
        {
            try
            {
                Guid id_emp = Guid.NewGuid();
                string qry = "";

                string query = "insert into Empleados_Info(ID_Empleado, txt_Contra, txt_Nom_Empleado, txt_ApePat, txt_ApeMat, txt_NSS, txt_RFC, txt_Banco, txt_NumCuenta, txt_Email, txt_Telefono, int_tipo, date_FchaNac, date_FchaInicio, txt_Calle, txt_Num, txt_Colonia, txt_Municipio, txt_Estado, txt_CP, ID_Empresa, ID_Depto, ID_Puesto, int_GerDepto, int_FP) values({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11}, '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', {20}, {21}, {22}, {23}, {24});";
                qry = string.Format(query, id_emp, emp.txt_Contrasenia, emp.txt_Nombre, emp.txt_Apellido_Pat, emp.txt_Apellido_Mat, emp.txt_NSS, emp.txt_RFC, ban.txt_Nombre, emp.txt_NumCuenta, emp.txt_Email, emp.txt_Telefono, emp.int_Tipo, emp.date_FchaNac.ToString("yyyy-MM-dd"), emp.date_FInicio.ToString("yyyy-MM-dd"), dom.txt_Calle, dom.txt_NumCasa, dom.txt_Colonia, dom.txt_Municipio, dom.txt_Estado, dom.txt_CP, AccionesForms.ID_Empresa, AccionesForms.ID_Depto, AccionesForms.ID_Puesto, emp.bool_GerDepto, emp.int_FPago);
                _session.Execute(qry);

                //string nom_completo = emp.txt_Nombre + ' ' + emp.txt_Apellido_Pat + ' ' + emp.txt_Apellido_Mat;
                //string query2 = "insert into Empleados_Info_By_Empr(ID_Empleado, txt_NombreCompleto, ID_Empresa, txt_NomEmpresa) values ({0}, '{1}', {2}, '{3}');";
                //qry2 = string.Format(query2, id_emp, nom_completo, AccionesForms.ID_Empresa, AccionesForms.txt_Empresa);
                //_session.Execute(qry2);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Agregar_Deduccion(Guid id_empresa, Guid id_empleado, Guid clave, string nombre, float monto, float valor, float porcentaje)
        {
            string query = "INSERT INTO Deducciones (Clave, txt_Nom_Ded, float_Monto, ID_Empresa, ID_Empleado, valor, porcentaje) VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6});";
            string qry = string.Format(query, clave, nombre, monto, id_empresa, id_empleado, valor, porcentaje);
            _session.Execute(qry);
        }

        public void Agregar_Percepcion(Guid id_empresa, Guid id_empleado, Guid clave, string nombre, float monto, float valor, float porcentaje)
        {
            string query = "INSERT INTO Percepciones (Clave, txt_Nom_Per, float_Monto, ID_Empresa, ID_Empleado, valor, porcentaje) VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6});";
            string qry = string.Format(query, clave, nombre, monto, id_empresa, id_empleado, valor, porcentaje);
            _session.Execute(qry);
        }

        public void Agregar_Incidencia(Guid id_empresa, Guid id_empleado, string nombre, int dias, LocalDate date_eje)
        {
            string query = "INSERT INTO Incidencias (Incidencia, ID_Empleado, ID_Empresa, int_dias, date_eje) VALUES ('{0}', {1}, {2}, {3}, '{4}')";
            string qry = string.Format(query, nombre, id_empleado, id_empresa, dias, date_eje);
            _session.Execute(qry);
        }

        public void Agregar_Cambio(Guid id_empresa, Cambios cam)
        {
            try
            {
                Guid clave = Guid.NewGuid();
                cam.Clave = clave;

                string query = "INSERT INTO Cambios (Clave, nombre, monto, tipo, valor, porcentaje, ID_Empresa, activo) VALUES ({0}, '{1}', {2}, '{3}', {4}, {5}, {6}, {7});";
                string qry = string.Format(query, cam.Clave, cam.nombre, cam.monto, cam.tipo, cam.valor, cam.porcentaje, cam.ID_Empresa, cam.activo);
                _session.Execute(qry);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Agregar_Percepcion_Empleado(string nombre, Guid id_empleado, Guid id_empresa)
        {
            try
            {
                Guid clave = id_empresa;
                float valor = 0;
                float porcentaje = 0;
                float monto = 0;

                string query = "SELECT Clave, valor, porcentaje, nombre FROM Cambios WHERE ID_Empresa=" + id_empresa + ";";
                var listado = _session.Execute(query);

                foreach (var row in listado)
                {
                    if (row.GetValue<string>("nombre") == nombre)
                    {
                        clave = row.GetValue<Guid>("clave");
                        valor = (float)row.GetValue<decimal>("valor");
                        porcentaje = (float)row.GetValue<decimal>("porcentaje");
                    }
                }

                Agregar_Percepcion(id_empresa, id_empleado, clave, nombre, monto, valor, porcentaje);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Agregar_Deduccion_Empleado(string nombre, Guid id_empleado, Guid id_empresa)
        {
            try
            {
                Guid clave = id_empresa;
                float valor = 0;
                float porcentaje = 0;
                float monto = 0;

                string query = "SELECT Clave, valor, porcentaje, nombre FROM Cambios WHERE ID_Empresa=" + id_empresa + ";";
                var listado = _session.Execute(query);

                foreach (var row in listado)
                {
                    if (row.GetValue<string>("nombre") == nombre)
                    {
                        clave = row.GetValue<Guid>("clave");
                        valor = (float)row.GetValue<decimal>("valor");
                        porcentaje = (float)row.GetValue<decimal>("porcentaje");
                    }
                }

                Agregar_Deduccion(id_empresa, id_empleado, clave, nombre, monto, valor, porcentaje);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }


        public void Baja_Empresa_Y_Relacionados(Guid id_empresa)
        {
            try
            {
                var deleteEmpresa = _session.Prepare("DELETE FROM Empresas WHERE ID_Empresa=?");
                var deletePuestos = _session.Prepare("DELETE FROM Puestos WHERE ID_Empresa=?");
                var deleteEmpleados = _session.Prepare("DELETE FROM Empleados_Info WHERE ID_Empresa=?");

                var batch = new BatchStatement().Add(deleteEmpresa.Bind(id_empresa))
                                                .Add(deletePuestos.Bind(id_empresa))
                                                .Add(deleteEmpleados.Bind(id_empresa));
                _session.Execute(batch);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Baja_Departamento_Y_Relacionados(Guid id_empresa, Guid id_depto)
        {
            try
            {
                var deleteDepto = _session.Prepare("DELETE FROM Departamentos WHERE ID_Departamento=?");
                var deletePuestos = _session.Prepare("DELETE FROM Puestos WHERE ID_Empresa=? AND ID_Departamento=?");
                var deleteEmpleados = _session.Prepare("DELETE FROM Empleados_Info WHERE ID_Empresa=? AND ID_Depto=?");

                var batch = new BatchStatement().Add(deleteDepto.Bind(id_depto))
                                                .Add(deletePuestos.Bind(id_empresa, id_depto))
                                                .Add(deleteEmpleados.Bind(id_empresa, id_depto));
                _session.Execute(batch);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Baja_Puesto_Y_Relacionados(Guid id_empresa, Guid id_depto, Guid id_puesto)
        {
            try
            {
                var deletePuestos = _session.Prepare("DELETE FROM Puestos WHERE ID_Empresa=? AND ID_Departamento=? AND ID_Puesto=?");
                var deleteEmpleados = _session.Prepare("DELETE FROM Empleados_Info WHERE ID_Empresa=? AND ID_Depto=? AND ID_Puesto=?");

                var batch = new BatchStatement().Add(deletePuestos.Bind(id_empresa, id_depto, id_puesto))
                                                .Add(deleteEmpleados.Bind(id_empresa, id_depto, id_puesto));
                _session.Execute(batch);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Baja_Empleado(Guid id_empresa, Guid id_depto, Guid id_puesto, Guid id_empleado)
        {
            try
            {
                string query = "DELETE FROM Empleados_Info WHERE ID_Empresa={0} AND ID_Depto={1} AND ID_Puesto={2} AND ID_Empleado={3}";
                string qry = string.Format(query, id_empresa, id_depto, id_puesto, id_empleado);
                _session.Execute(qry);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Baja_Deduccion(Guid id_empresa, Guid id_empleado, Guid clave)
        {
            string query = "DELETE FROM Deducciones WHERE ID_Empresa = {0} AND ID_Empleado = {1} AND Clave = {2};";
            string qry = string.Format(query, id_empresa, id_empleado, clave);
            _session.Execute(qry);
        }

        public void Baja_Percepcion(Guid id_empresa, Guid id_empleado, Guid clave)
        {
            string query = "DELETE FROM Percepciones WHERE ID_Empresa = {0} AND ID_Empleado = {1} AND Clave = {2};";
            string qry = string.Format(query, id_empresa, id_empleado, clave);
            _session.Execute(qry);
        }

        public void Baja_Incidencia(Guid id_empresa, Guid id_empleado, string nombre)
        {
            string query = "DELETE FROM Incidencias WHERE ID_Empresa=" + id_empresa + "AND ID_Empleado=" + id_empleado + "AND Incidencia='" + nombre + "';";
            _session.Execute(query);
        }

        public void Baja_Cambio(Guid id_empresa, Guid clave)
        {
            string query = "DELETE FROM Cambios WHERE ID_Empresa=" + id_empresa + " AND Clave=" + clave + ";";
            _session.Execute(query);
        }


        public void Update_Empresa(Empresa emp, Domicilio dom)
        {
            try
            {
                string updateEmpresa = "UPDATE Empresas SET txt_RS='{0}', txt_Email='{1}', txt_RP='{2}', txt_RF='{3}', date_FInicio='{4}', txt_Calle='{5}', txt_Num='{6}', txt_Colonia='{7}', txt_Municipio='{8}', txt_Estado='{9}', txt_CP='{10}' WHERE ID_Empresa={11};";
                LocalDate date = LocalDate.Parse(emp.date_FchaInicio.ToString("yyyy-MM-dd"));

                string qry = string.Format(updateEmpresa, emp.txt_RS, emp.txt_Email, emp.txt_RP, emp.txt_RF, date, dom.txt_Calle, dom.txt_NumCasa, dom.txt_Colonia, dom.txt_Municipio, dom.txt_Estado, dom.txt_CP, AccionesForms.ID_Empresa);
                _session.Execute(qry);

                int a = (int)emp.int_FPago;
                int b = (int)emp.int_FPago2;

                string query = "UPDATE Empresas SET int_FP={" + a + ", " + b + "} WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
                _session.Execute(query);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Update_Depto(Departamento dep)
        {
            try
            {
                var updateDepto = "UPDATE Departamentos SET txt_Nombre='{0}', money_SB={1} WHERE ID_Departamento={2};";
                var query = string.Format(updateDepto, dep.txt_Nombre, dep.money_SueldoBase, AccionesForms.ID_Depto); 
                _session.Execute(query);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Update_Puesto(Puesto pue)
        {
            try
            {
                var updatePue = "UPDATE Puestos SET txt_Nom_Pue='{0}', float_NS={1} WHERE ID_Empresa={2} AND ID_Departamento={3} AND ID_Puesto={4};";
                var query = string.Format(updatePue, pue.txt_Nombre, pue.fNivelSalarial, AccionesForms.ID_Empresa, AccionesForms.ID_Depto, AccionesForms.ID_Puesto);
                _session.Execute(query);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Update_Empleado(Empleado_info emp, Banco ban, Domicilio dom, Guid id_depto, Guid id_puesto)
        {
            try
            {
                //var updatePue = "UPDATE Empleados_Info SET txt_Contra='{0}', txt_Nom_Empleado='{1}', txt_ApePat='{2}', txt_ApeMat='{3}', txt_NSS='{4}', txt_RFC='{5}', txt_Banco='{6}', txt_NumCuenta='{7}', txt_Email='{8}', txt_Telefono='{9}', date_FchaNac='{10}', date_FchaInicio='{11}', txt_Calle='{12}', txt_Num='{13}', txt_Colonia='{14}', txt_Municipio='{15}', txt_Estado='{16}', txt_CP='{17}', ID_Depto={22}, ID_Puesto={23} WHERE ID_Empresa={18} AND ID_Depto={19} AND ID_Puesto={20} AND ID_Empleado={21};";
                //var query = string.Format(updatePue, emp.txt_Contrasenia, emp.txt_Nombre, emp.txt_Apellido_Pat, emp.txt_Apellido_Mat, emp.txt_NSS, emp.txt_RFC, ban.txt_Nombre, emp.txt_NumCuenta, emp.txt_Email, emp.txt_Telefono, emp.date_FchaNac.ToString("yyyy-MM-dd"), emp.date_FInicio.ToString("yyyy-MM-dd"), dom.txt_Calle, dom.txt_NumCasa, dom.txt_Colonia, dom.txt_Municipio, dom.txt_Estado, dom.txt_CP, AccionesForms.ID_Empresa, AccionesForms.ID_Depto, AccionesForms.ID_Puesto, AccionesForms.ID_Empleado, id_depto, id_puesto);

                var updatePue = "UPDATE Empleados_Info SET txt_Contra='{0}', txt_Nom_Empleado='{1}', txt_ApePat='{2}', txt_ApeMat='{3}', txt_NSS='{4}', txt_RFC='{5}', txt_Banco='{6}', txt_NumCuenta='{7}', txt_Email='{8}', txt_Telefono='{9}', date_FchaNac='{10}', date_FchaInicio='{11}', txt_Calle='{12}', txt_Num='{13}', txt_Colonia='{14}', txt_Municipio='{15}', txt_Estado='{16}', txt_CP='{17}', int_FP={22} WHERE ID_Empresa={18} AND ID_Depto={19} AND ID_Puesto={20} AND ID_Empleado={21};";
                var query = string.Format(updatePue, emp.txt_Contrasenia, emp.txt_Nombre, emp.txt_Apellido_Pat, emp.txt_Apellido_Mat, emp.txt_NSS, emp.txt_RFC, ban.txt_Nombre, emp.txt_NumCuenta, emp.txt_Email, emp.txt_Telefono, emp.date_FchaNac.ToString("yyyy-MM-dd"), emp.date_FInicio.ToString("yyyy-MM-dd"), dom.txt_Calle, dom.txt_NumCasa, dom.txt_Colonia, dom.txt_Municipio, dom.txt_Estado, dom.txt_CP, AccionesForms.ID_Empresa, AccionesForms.ID_Depto, AccionesForms.ID_Puesto, AccionesForms.ID_Empleado, emp.int_FPago);
                _session.Execute(query);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Update_Gerente_Empresa(CQL_Empleados_By_Empresa emp)
        {
            try
            {
                int tipo = 0;
                Guid id = emp.ID_Empleado;
                Guid id_depto = emp.ID_Empleado;
                Guid id_puesto = emp.ID_Empleado;
                Guid id_emp = AccionesForms.ID_Empresa;
                Guid id_emp_aux = emp.ID_Empresa;

                string query = "SELECT int_tipo, ID_Empleado, ID_Empresa, ID_Depto, ID_Puesto FROM Empleados_Info WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
                var rowSet = _session.Execute(query);
                
                foreach (var row in rowSet)
                {
                    if (emp.ID_Empleado == row.GetValue<Guid>("id_empleado")) {
                        emp.ID_Depto = row.GetValue<Guid>("id_depto");
                        emp.ID_Puesto = row.GetValue<Guid>("id_puesto");
                    }

                    
                    if (row.GetValue<int>("int_tipo") == 1)
                    {
                        id_depto = row.GetValue<Guid>("id_depto");
                        id_puesto = row.GetValue<Guid>("id_puesto");
                        id = row.GetValue<Guid>("id_empleado");
                        tipo = row.GetValue<int>("int_tipo");
                    }
                }

                if (tipo == 1)
                {
                    query = "UPDATE Empleados_Info SET int_tipo=0 WHERE ID_Empresa=" + AccionesForms.ID_Empresa + " AND ID_Depto=" + id_depto + " AND ID_Puesto=" + id_puesto + " AND ID_Empleado=" + id + ";";
                    _session.Execute(query);
                }

                var updateEmpresa = _session.Prepare("UPDATE Empresas SET ID_Gerente=?, txt_Nom_Empleado=? WHERE ID_Empresa=?");
                var updateEmpleado = _session.Prepare("UPDATE Empleados_Info SET int_tipo=1 WHERE ID_Empresa=? AND ID_Depto=? AND ID_Puesto=? AND ID_Empleado=?");

                var batch = new BatchStatement().Add(updateEmpresa.Bind(emp.ID_Empleado, emp.txt_NombreCompleto, AccionesForms.ID_Empresa))
                                                .Add(updateEmpleado.Bind(AccionesForms.ID_Empresa, emp.ID_Depto, emp.ID_Puesto, emp.ID_Empleado));
                _session.Execute(batch);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Update_Gerente_Depto(CQL_Empleados_By_Empresa emp, Guid id_depto)
        {
            try
            {
                bool gerente = false;
                Guid id_c = emp.ID_Empleado;
                Guid id_depto_c = emp.ID_Empleado;
                Guid id_puesto_c = emp.ID_Empleado;
                Guid id_emp = AccionesForms.ID_Empresa;
                Guid id_emp_aux = emp.ID_Empresa;

                string query = "SELECT int_tipo, ID_Empleado, ID_Empresa, ID_Depto, ID_Puesto, int_GerDepto FROM Empleados_Info WHERE ID_Empresa=" + AccionesForms.ID_Empresa + "AND ID_Depto=" + id_depto + ";";
                var rowSet = _session.Execute(query);

                foreach (var row in rowSet)
                {
                    if (emp.ID_Empleado == row.GetValue<Guid>("id_empleado"))
                    {
                        emp.ID_Depto = row.GetValue<Guid>("id_depto");
                        emp.ID_Puesto = row.GetValue<Guid>("id_puesto");
                        emp.ID_Empleado = row.GetValue<Guid>("id_empleado");
                    }
                    
                    if (row.GetValue<bool>("int_gerdepto") == true)
                    {
                        id_depto_c = row.GetValue<Guid>("id_depto");
                        id_puesto_c = row.GetValue<Guid>("id_puesto");
                        id_c = row.GetValue<Guid>("id_empleado");
                        gerente = row.GetValue<bool>("int_gerdepto");
                    }
                }

                if (gerente == true)
                {
                    query = "UPDATE Empleados_Info SET int_GerDepto=false WHERE ID_Empresa=" + AccionesForms.ID_Empresa + " AND ID_Depto=" + id_depto_c + " AND ID_Puesto=" + id_puesto_c + " AND ID_Empleado=" + id_c + ";";
                    _session.Execute(query);
                }

                var updateEmpresa = _session.Prepare("UPDATE Departamentos SET ID_Gerente=?, txt_Nom_Empleado=? WHERE ID_Departamento=?");
                var updateEmpleado = _session.Prepare("UPDATE Empleados_Info SET int_GerDepto=true WHERE ID_Empresa=? AND ID_Depto=? AND ID_Puesto=? AND ID_Empleado=?");

                var batch = new BatchStatement().Add(updateEmpresa.Bind(emp.ID_Empleado, emp.txt_NombreCompleto, id_depto))
                                                .Add(updateEmpleado.Bind(AccionesForms.ID_Empresa, emp.ID_Depto, emp.ID_Puesto, emp.ID_Empleado));
                _session.Execute(batch);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }

        public void Update_Activo_Cambio(Guid id_empresa, Guid clave)
        {
            try
            {
                int activo = 0;

                string query = "SELECT activo FROM Cambios WHERE ID_Empresa=" + AccionesForms.ID_Empresa + "AND clave=" + clave + ";";
                var listado = _session.Execute(query);

                foreach (var row in listado)
                {
                    activo = row.GetValue<int>("activo");
                    break;
                }

                if (activo == 1)
                {
                    activo = 0;
                }
                else
                {
                    activo = 1;
                }

                string qry = "UPDATE Cambios SET activo=" + activo + " WHERE ID_Empresa = " + AccionesForms.ID_Empresa + "AND clave = " + clave + ";";
                _session.Execute(qry);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }



        public List<CQL_Empresas> Get_Empresas()
        {
            string query = "SELECT ID_Empresa, txt_RS, txt_Email, txt_RP, txt_RF, date_FInicio, int_FP, ID_Gerente, txt_Nom_Empleado, txt_Calle, txt_Num, txt_Colonia, txt_Municipio, txt_Estado, txt_CP FROM Empresas;";

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Empresas> emp = mapper.Fetch<CQL_Empresas>(query);
            
            return emp.ToList();
        }

        public List<CQL_Empresas> Get_Empresas_By_ID(Guid id_empresa)
        {
            string query = "SELECT ID_Empresa, txt_RS, txt_Email, txt_RP, txt_RF, date_FInicio, int_FP, ID_Gerente, txt_Nom_Empleado, txt_Calle, txt_Num, txt_Colonia, txt_Municipio, txt_Estado, txt_CP FROM Empresas WHERE ID_Empresa = {0};";
            string qry = string.Format(query, id_empresa);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Empresas> emp = mapper.Fetch<CQL_Empresas>(qry);

            return emp.ToList();
        }

        public List<CQL_Departamentos> Get_Deptos()
        {
            string query = "SELECT ID_Departamento, txt_Nombre, money_SB, txt_Nom_Empleado FROM Departamentos;";

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Departamentos> depto = mapper.Fetch<CQL_Departamentos>(query);
            
            return depto.ToList();
        }

        public List<CQL_Departamentos> Get_Depto_By_Id(Guid id_depto)
        {
            string query = "SELECT ID_Departamento, txt_Nombre, money_SB, txt_Nom_Empleado FROM Departamentos WHERE ID_Departamento = {0};";
            string qry = string.Format(query, id_depto);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Departamentos> depto = mapper.Fetch<CQL_Departamentos>(qry);

            return depto.ToList();
        }

        public List<CQL_Empleados> Get_Empleados_By_Empresa(Guid id_empresa)
        {
            //string query = "SELECT ID_Empleado, txt_NombreCompleto, ID_Empresa, txt_NomEmpresa FROM Empleados_Info_By_Empr WHERE ID_Empresa = {0};";
            string query = "SELECT ID_Empleado, txt_Nom_Empleado, txt_ApePat, txt_ApeMat, ID_Empresa, txt_NSS, txt_RFC, txt_Email, txt_Telefono, date_FchaNac, date_FchaInicio, int_FP FROM Empleados_Info WHERE ID_Empresa = {0};";
            string qry = string.Format(query, id_empresa);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Empleados> emp = mapper.Fetch<CQL_Empleados>(qry);
            
            return emp.ToList();
        }

        public List<CQL_Empleados> Get_Empleados_By_Depto(Guid id_empresa, Guid id_depto)
        {
            //string query = "SELECT ID_Empleado, txt_NombreCompleto, ID_Empresa, txt_NomEmpresa FROM Empleados_Info_By_Empr WHERE ID_Empresa = {0};";
            string query = "SELECT ID_Empleado, txt_Nom_Empleado, txt_ApePat, txt_ApeMat, ID_Empresa, txt_NSS, txt_RFC, txt_Email, txt_Telefono, date_FchaNac, date_FchaInicio, int_GerDepto FROM Empleados_Info WHERE ID_Empresa = {0} AND ID_Depto = {1};";
            string qry = string.Format(query, id_empresa, id_depto);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Empleados> emp = mapper.Fetch<CQL_Empleados>(qry);

            return emp.ToList();
        }

        public List<CQL_Empleados> Get_Empleados_By_Id(Guid id_empresa, Guid id_depto, Guid id_Puesto, Guid id_empleado)
        {
            //string query = "SELECT ID_Empleado, txt_NombreCompleto, ID_Empresa, txt_NomEmpresa FROM Empleados_Info_By_Empr WHERE ID_Empresa = {0};";
            string query = "SELECT ID_Empleado, ID_Depto, ID_Puesto, ID_Empleado, txt_Contra, txt_Nom_Empleado, txt_ApePat, txt_ApeMat, txt_NSS, txt_RFC, txt_Banco, txt_NumCuenta, txt_Email, txt_Telefono, date_FchaNac, date_FchaInicio, txt_Calle, txt_Num, txt_Colonia, txt_Municipio, txt_Estado, txt_CP, int_FP FROM Empleados_Info WHERE ID_Empresa = {0} AND ID_Depto = {1} AND ID_Puesto = {2} AND ID_Empleado = {3};";
            string qry = string.Format(query, id_empresa, id_depto, id_Puesto, id_empleado);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Empleados> emp = mapper.Fetch<CQL_Empleados>(qry);

            return emp.ToList();
        }

        public List<CQL_Empleados> Get_Empleados_By_Id(Guid id_empresa, Guid id_empleado)
        {
            Guid id_depto = id_empresa;
            Guid id_puesto = id_empresa;

            string query = "SELECT ID_Empleado, ID_Depto, ID_Puesto, ID_Empleado FROM Empleados_Info WHERE ID_Empresa=" + id_empresa + ";";
            var rowSet = _session.Execute(query);

            foreach (var item in rowSet)
            {
                if (id_empleado == item.GetValue<Guid>("id_empleado"))
                {
                    id_depto = item.GetValue<Guid>("id_depto");
                    id_puesto = item.GetValue<Guid>("id_puesto");
                }
            }

            return Get_Empleados_By_Id(id_empresa, id_depto, id_puesto, id_empleado);
        }

        public List<CQL_Puestos> Get_Puestos_By_Empresa_Depto(Guid id_empresa, Guid id_Depto)
        {
            string query = "SELECT ID_Puesto, txt_Nom_Pue, float_NS, money_SD, ID_Departamento, ID_Empresa FROM Puestos WHERE ID_Empresa = {0} AND ID_Departamento = {1};";
            string qry = string.Format(query, id_empresa, id_Depto);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Puestos> emp = mapper.Fetch<CQL_Puestos>(qry);
            
            return emp.ToList();
        }

        public RowSet GetAll_Empleados()
        {
            string query = "SELECT ID_Empresa, ID_Depto, ID_Puesto, ID_Empleado, txt_ApePat, txt_ApeMat, txt_Contra, txt_Nom_Empleado, int_tipo, int_GerDepto, txt_NSS, txt_RFC, int_FP FROM Empleados_Info;";
            RowSet lista = _session.Execute(query);

            return lista;
        }

        public List<CQL_Deduccionescs> Get_Deducciones_By_Empleado(Guid id_empresa, Guid id_empleado)
        {
            string query = "SELECT Clave, txt_Nom_Ded, float_Monto, ID_Empresa, ID_Empleado, valor, porcentaje FROM Deducciones WHERE ID_Empresa = {0} AND ID_Empleado = {1};";
            string qry = string.Format(query, id_empresa, id_empleado);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Deduccionescs> emp = mapper.Fetch<CQL_Deduccionescs>(qry);

            return emp.ToList();
        }

        public List<CQL_Percepciones> Get_Percepciones_By_Empleado(Guid id_empresa, Guid id_empleado)
        {
            string query = "SELECT Clave, txt_Nom_Per, float_Monto, ID_Empresa, ID_Empleado, valor, porcentaje FROM Percepciones WHERE ID_Empresa = {0} AND ID_Empleado = {1};";
            string qry = string.Format(query, id_empresa, id_empleado);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Percepciones> emp = mapper.Fetch<CQL_Percepciones>(qry);

            return emp.ToList();
        }

        public List<CQL_Incidencias> Get_Incidencias_By_Empleado(Guid id_empresa, Guid id_empleado)
        {
            string query = "SELECT ID_Empresa, ID_Empleado, Incidencia, int_dias, date_eje FROM Incidencias WHERE ID_Empresa = {0} AND ID_Empleado = {1};";
            string qry = string.Format(query, id_empresa, id_empleado);

            IMapper mapper = new Mapper(_session);
            IEnumerable<CQL_Incidencias> emp = mapper.Fetch<CQL_Incidencias>(qry);

            return emp.ToList();
        }

        public List<Cambios> GetAll_Cambios()
        {
            string query = "SELECT Clave, nombre, tipo, valor, porcentaje, activo FROM Cambios WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";

            IMapper mapper = new Mapper(_session);
            IEnumerable<Cambios> emp = mapper.Fetch<Cambios>(query);

            return emp.ToList();
        }




        public bool Validacion_Fecha_Nomina(int fp, DateTime dateActual)
        {
            LocalDate date_empresa = LocalDate.Parse(dateActual.ToString("yyyy-MM-dd"));
            LocalDate date_actual = LocalDate.Parse(dateActual.ToString("yyyy-MM-dd"));
            LocalDate date_eje = LocalDate.Parse(dateActual.ToString("yyyy-MM-dd"));

            string query = "SELECT date_eje FROM Nomina_Empresa WHERE ID_Empresa=" + AccionesForms.ID_Empresa + "AND int_FP=" + fp.ToString() + ";";
            var listaNominas = _session.Execute(query);

            if (listaNominas.Count() == 0)
            {
                string query_Fcha_Empresa = "SELECT date_FInicio FROM Empresas WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
                var lista_empresa = _session.Execute(query_Fcha_Empresa);
                
                foreach (var row in lista_empresa)
                {
                    date_empresa = row.GetValue<LocalDate>("date_finicio");
                    break;
                }

                if (date_empresa.Day + fp >= date_actual.Day)
                    return true;
                else
                    return false;
            }
            else
            {
                foreach (var row in listaNominas)
                {
                    date_eje = row.GetValue<LocalDate>("date_finicio");
                    break;
                }

                if (date_eje.Day + fp >= date_actual.Day)
                    return true;
                else
                    return false;
            }
        }

        public void PDF_Nomina_Empresa()
        {
            string query_Nomina = "SELECT ID_Empresa, ID_Empleado, txt_NomCom, txt_Banco, txt_NumCuenta, monto, date FROM Nomina_Empresa WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
            RowSet lista_Nomina = _session.Execute(query_Nomina);

            TextWriter txt = new StreamWriter("C://Users/2RJ25LA_RS5/Documents/Reportes_AAVD/Reporte_Nomina_Empresa_CSV.txt");
            txt.WriteLine("NOMINA DE LA EMPRESA");
            txt.WriteLine("");
            txt.WriteLine("ID_EMPRESA, ID_EMPLEADO, NOMBRE_COMPLETO, BANCO, NUMERO_CUENTA, MONTO, FECHA_DE_INICIO");

            Document Doc = new Document();
            PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_AAVD/Reporte_Nomina_Empresa.pdf", FileMode.Create));

            Doc.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 15f, BaseColor.CYAN);
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

            foreach (var item in lista_Nomina)
            {
                string id_empresa = item.GetValue<Guid>("id_empresa").ToString();
                string id_empleado = item.GetValue<Guid>("id_empleado").ToString();

                table.AddCell(id_empresa);
                table.AddCell(id_empleado);
                table.AddCell(item.GetValue<string>("txt_nomcom"));
                table.AddCell(item.GetValue<string>("txt_banco"));
                table.AddCell(item.GetValue<string>("txt_numcuenta"));
                table.AddCell(item.GetValue<decimal>("monto").ToString());
                table.AddCell(item.GetValue<LocalDate>("date").ToString());

                txt.WriteLine(id_empresa + ", " + id_empleado + ", " + item.GetValue<string>("txt_nomcom") + ", " + item.GetValue<string>("txt_banco") + ", " + item.GetValue<string>("txt_numcuenta") + ", " + item.GetValue<decimal>("monto").ToString() + ", " + item.GetValue<LocalDate>("date").ToString());
            }

            txt.Close();

            Doc.Add(table);
            Doc.Close();
        }

        public void Calculo_Nomina()
        {
            string delete_Nomina = "TRUNCATE Nomina_Empresa";
            _session.Execute(delete_Nomina);

            DateTime date_eje = DateTime.Now;

            string query_Empleados = "SELECT ID_Depto, ID_Puesto, ID_Empleado, txt_ApePat, txt_ApeMat, txt_Nom_Empleado, txt_Banco, txt_NumCuenta, date_FchaInicio, int_FP FROM Empleados_Info WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
            RowSet lista_Empleados = _session.Execute(query_Empleados);

            foreach (var item in lista_Empleados)
            {
                float sueldoBase = 0;
                float ns = 0;
                float salarioDiario = 0;
                float monto = 0;
                int FrePago = 0;

                string Nombre_Completo = "";

                string query_FrePago = "SELECT int_FP FROM Empresas WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
                string query_SueldoBase = "SELECT money_SB FROM Departamentos WHERE ID_Departamento=" + item.GetValue<Guid>("id_depto") + ";";
                string query_NS = "SELECT float_NS FROM Puestos WHERE ID_Empresa=" + AccionesForms.ID_Empresa + "AND ID_Departamento=" + item.GetValue<Guid>("id_depto") + "AND ID_Puesto=" + item.GetValue<Guid>("id_puesto") + ";";
                string query_Dedu = "SELECT float_Monto, valor, porcentaje FROM Deducciones WHERE ID_Empresa=" + AccionesForms.ID_Empresa + " AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
                string query_Percep = "SELECT float_Monto, valor, porcentaje FROM Percepciones WHERE ID_Empresa=" + AccionesForms.ID_Empresa + " AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
                string query_Inside = "SELECT int_dias, Incidencia FROM Incidencias WHERE ID_Empresa=" + AccionesForms.ID_Empresa + "AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
                string query_Cambios = "SELECT nombre, tipo, valor, porcentaje, activo FROM Cambios WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";

                RowSet lista_Empresas = _session.Execute(query_FrePago);
                RowSet lista_Deptos = _session.Execute(query_SueldoBase);
                RowSet lista_Puestos = _session.Execute(query_NS);
                RowSet lista_Deducciones = _session.Execute(query_Dedu);
                RowSet lista_Percepciones = _session.Execute(query_Percep);
                RowSet lista_Insidencias = _session.Execute(query_Inside);
                RowSet lista_Cambios = _session.Execute(query_Cambios);

                FrePago = item.GetValue<int>("int_fp");

                foreach (var row in lista_Deptos)
                {
                    sueldoBase = (float)row.GetValue<decimal>("money_sb");
                    break;
                }

                foreach (var row in lista_Puestos)
                {
                    ns = (float)row.GetValue<decimal>("float_ns");
                    break;
                }

                salarioDiario = ns * sueldoBase;

                foreach (var row in lista_Insidencias)
                {
                    if (row.GetValue<string>("incidencia") != "Prima Vacacional")
                    {
                        FrePago = FrePago - row.GetValue<int>("int_dias");
                        if (FrePago <= 0)
                        {
                            FrePago = 0;
                            break;
                        }
                    }
                }

                monto = salarioDiario * FrePago;

                foreach (var row in lista_Cambios)
                {
                    if (row.GetValue<int>("activo") == 1)
                    {
                        if (row.GetValue<string>("tipo") == "Percepcion")
                        {
                            if (row.GetValue<decimal>("porcentaje") == 0)
                                monto = monto + (float)row.GetValue<decimal>("valor");

                            if (row.GetValue<decimal>("valor") == 0)
                                monto = monto + (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                        }

                        if (row.GetValue<string>("tipo") == "Deduccion")
                        {
                            if (row.GetValue<decimal>("porcentaje") == 0)
                                monto = monto - (float)row.GetValue<decimal>("valor");

                            if (row.GetValue<decimal>("valor") == 0)
                                monto = monto - (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                        }
                    }
                }

                foreach (var row in lista_Deducciones)
                {
                    if(row.GetValue<decimal>("porcentaje") == 0)
                        monto = monto - (float)row.GetValue<decimal>("valor");

                    if(row.GetValue<decimal>("valor") == 0)
                        monto = monto - (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                }

                foreach (var row in lista_Percepciones)
                {
                    if (row.GetValue<decimal>("porcentaje") == 0)
                        monto = monto + (float)row.GetValue<decimal>("valor");

                    if (row.GetValue<decimal>("valor") == 0)
                        monto = monto + (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                }

                Nombre_Completo = item.GetValue<string>("txt_nom_empleado") + " " + item.GetValue<string>("txt_apepat") + " " + item.GetValue<string>("txt_apemat");

                string query_NomEmpresa = "INSERT INTO Nomina_Empresa (ID_Empresa, ID_Empleado, txt_NomCom, txt_Banco, txt_NumCuenta, monto, date, date_eje) VALUES ({0}, {1}, '{2}', '{3}', '{4}', {5}, '{6}', '{7}');";
                string qry = string.Format(query_NomEmpresa, AccionesForms.ID_Empresa, item.GetValue<Guid>("id_empleado"), Nombre_Completo, item.GetValue<string>("txt_banco"), item.GetValue<string>("txt_numcuenta"), monto, item.GetValue<LocalDate>("date_fchainicio"), date_eje.ToString("yyyy-MM-dd"));
                _session.Execute(qry);

                PDF_Nomina_Empresa();
            }
        }

        public void Recibo_Nomina()
        {
            float monto = 0;
            float frepago = 0;
            string nombreCompleto = "";
            DateTime date = DateTime.Today;
            float sueldobase = 0;
            string nombreDepto = "";
            string nombrePuesto = "";
            float ns = 0;
            float aux = 0;

            string query_Empresa = "SELECT txt_RS, txt_RP, txt_RF, int_FP, txt_Email FROM Empresas WHERE ID_Empresa=" + User.static_ID_Empresa + ";";
            string query_Nomina = "SELECT monto, txt_NomCom FROM Nomina_Empresa WHERE ID_Empresa=" + User.static_ID_Empresa + "AND ID_Empleado=" + User.static_ID_Empleado + ";";
            string query_Percep = "SELECT Clave, txt_Nom_Per, float_Monto, porcentaje, valor FROM Percepciones WHERE ID_Empresa=" + User.static_ID_Empresa + " AND ID_Empleado=" + User.static_ID_Empleado + ";";
            string query_Dedu = "SELECT Clave, txt_Nom_Ded, float_Monto, porcentaje, valor FROM Deducciones WHERE ID_Empresa=" + User.static_ID_Empresa + "AND ID_Empleado=" + User.static_ID_Empleado + ";";
            string query_Empleado = "SELECT money_SB, txt_nombre FROM Departamentos WHERE ID_Departamento=" + User.static_ID_Depto +";";
            string query_Cambios = "SELECT Clave, nombre, tipo, valor, porcentaje, activo FROM Cambios WHERE ID_Empresa=" + User.static_ID_Empresa + ";";
            string query_Puesto = "SELECT txt_Nom_Pue, float_NS FROM Puestos WHERE ID_Empresa=" + User.static_ID_Empresa + " AND ID_Departamento=" + User.static_ID_Depto + " AND ID_Puesto=" + User.static_ID_Puesto + ";";
            string query_Inside = "SELECT int_dias, Incidencia FROM Incidencias WHERE ID_Empresa=" + User.static_ID_Empresa + "AND ID_Empleado=" + User.static_ID_Empleado + ";";

            RowSet lista_Nomina = _session.Execute(query_Nomina);
            RowSet lista_Empresa = _session.Execute(query_Empresa);
            RowSet lista_Percepciones = _session.Execute(query_Percep);
            RowSet lista_Deducciones = _session.Execute(query_Dedu);
            RowSet lista_Depto = _session.Execute(query_Empleado);
            RowSet lista_Cambios = _session.Execute(query_Cambios);
            RowSet lista_Cambios2 = _session.Execute(query_Cambios);
            RowSet lista_Puesto = _session.Execute(query_Puesto);
            RowSet lista_Insidencia = _session.Execute(query_Inside);

            foreach (var row in lista_Depto)
            {
                sueldobase = (float)row.GetValue<decimal>("money_sb");
                nombreDepto = row.GetValue<string>("txt_nombre");
                break;
            }

            foreach (var row in lista_Puesto)
            {
                nombrePuesto = row.GetValue<string>("txt_nom_pue");
                ns = (float)row.GetValue<decimal>("float_ns");
                break;
            }

            foreach (var row in lista_Nomina)
            {
                monto = (float)row.GetValue<decimal>("monto");
                nombreCompleto = row.GetValue<string>("txt_nomcom");
                break;
            }

            foreach (var item in lista_Empresa)
            {
                Document Doc = new Document();
                PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_AAVD/Recibo_Nomina_Empleado.pdf", FileMode.Create));

                Doc.Open();
                Paragraph titulo = new Paragraph();
                titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                titulo.Add("NOMBRE: " + nombreCompleto + "    NUMERO SEGURO SOCIAL: " + User.static_txt_NSS + "    RFC: " + User.static_txt_RFC + "    FECHA: " + date.ToString() + "       " + "    FRECUENCIA PAGO:" + User.static_int_FP);
                titulo.Add("");
                Doc.Add(titulo);

                Paragraph emp = new Paragraph();
                emp.Font = FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
                emp.Add("RAZON SOCIAL: " + item.GetValue<string>("txt_rs") + "    REGISTRO PATRONAL: " + item.GetValue<string>("txt_rp") + "    REGISTRO FEDERAL: " + item.GetValue<string>("txt_rf") + "    EMAIL: " + item.GetValue<string>("txt_email"));
                emp.Add("");
                Doc.Add(emp);
                Doc.Add(new Paragraph(" "));

                PdfPTable tableincidencias = new PdfPTable(2);

                tableincidencias.AddCell("INCIDENCIA");
                tableincidencias.AddCell("DIAS");

                foreach (var row in lista_Insidencia)
                {
                    tableincidencias.AddCell(row.GetValue<string>("incidencia"));
                    tableincidencias.AddCell(row.GetValue<int>("int_dias").ToString());
                }

                Doc.Add(tableincidencias);

                Doc.Add(new Paragraph(" "));
                PdfPTable tableDatos = new PdfPTable(3);

                tableDatos.AddCell("SUELDO BASE");
                tableDatos.AddCell("NIVEL SALARIAL");
                tableDatos.AddCell("FRECUENCIA DE PAGO");
                
                tableDatos.AddCell(sueldobase.ToString());
                tableDatos.AddCell(ns.ToString());
                tableDatos.AddCell(User.static_int_FP.ToString());

                Doc.Add(tableDatos);

                Doc.Add(new Paragraph(" "));
                Doc.Add(new Paragraph("PERCEPCIONES Y DEDUCCIONES: "));
                Doc.Add(new Paragraph(" "));

                PdfPTable tablePercep = new PdfPTable(3);

                tablePercep.AddCell("CLAVE");
                tablePercep.AddCell("RAZON PERCEPCION");
                tablePercep.AddCell("VALOR");

                foreach (var row in lista_Cambios)
                {
                    if (row.GetValue<int>("activo") == 1)
                    {
                        if (row.GetValue<string>("tipo") == "Percepcion")
                        {
                            tablePercep.AddCell(row.GetValue<Guid>("clave").ToString());
                            tablePercep.AddCell(row.GetValue<string>("nombre"));

                            if (row.GetValue<decimal>("porcentaje") == 0)
                                tablePercep.AddCell(row.GetValue<decimal>("valor").ToString());

                            if (row.GetValue<decimal>("valor") == 0)
                            {
                                aux = sueldobase * (float)row.GetValue<decimal>("porcentaje");
                                tablePercep.AddCell(aux.ToString());
                            }
                        }
                    }
                }

                foreach (var row in lista_Percepciones)
                {
                    tablePercep.AddCell(row.GetValue<Guid>("clave").ToString());
                    tablePercep.AddCell(row.GetValue<string>("txt_nom_per"));

                    if (row.GetValue<decimal>("porcentaje") == 0)
                        tablePercep.AddCell(row.GetValue<decimal>("valor").ToString());

                    if (row.GetValue<decimal>("valor") == 0)
                    {
                        sueldobase = sueldobase * (float)row.GetValue<decimal>("porcentaje");
                        tablePercep.AddCell(sueldobase.ToString());
                    }
                }

                Doc.Add(tablePercep);
                Doc.Add(new Paragraph(" "));

                PdfPTable tableDedu = new PdfPTable(3);

                tableDedu.AddCell("CLAVE");
                tableDedu.AddCell("RAZON DEDUCCION");
                tableDedu.AddCell("VALOR");

                foreach (var row in lista_Cambios2)
                {
                    if (row.GetValue<int>("activo") == 1)
                    {
                        if (row.GetValue<string>("tipo") == "Deduccion")
                        {
                            tableDedu.AddCell(row.GetValue<Guid>("clave").ToString());
                            tableDedu.AddCell(row.GetValue<string>("nombre"));

                            if (row.GetValue<decimal>("porcentaje") == 0)
                                tableDedu.AddCell(row.GetValue<decimal>("valor").ToString());

                            if (row.GetValue<decimal>("valor") == 0)
                            {
                                aux = sueldobase * (float)row.GetValue<decimal>("porcentaje");
                                tableDedu.AddCell(aux.ToString());
                            }
                        }
                    }
                }

                foreach (var row in lista_Deducciones)
                {
                    tableDedu.AddCell(row.GetValue<Guid>("clave").ToString());
                    tableDedu.AddCell(row.GetValue<string>("txt_nom_ded"));

                    if (row.GetValue<decimal>("porcentaje") == 0)
                        tableDedu.AddCell(row.GetValue<decimal>("valor").ToString());

                    if (row.GetValue<decimal>("valor") == 0)
                    {
                        sueldobase = sueldobase * (float)row.GetValue<decimal>("porcentaje");
                        tableDedu.AddCell(sueldobase.ToString());
                    }
                }

                Doc.Add(tableDedu);

                Conversion conv = new Conversion();
                Doc.Add(new Paragraph(" "));
                Doc.Add(new Paragraph("PAGO NETO: " + monto.ToString() + "    " + conv.enletras(monto.ToString())));
                Doc.Close();

                break;
            }
        }

        public void Reporte_Nomina_General(Guid id_empresa, LocalDate date)
        {
            string nombre_depto = "";
            string nombre_puesto = "";
            float ns = 0;
            float sb = 0;
            Guid id_depto = id_empresa;
            Guid id_puesto = id_empresa;
            bool isBaddate = false;

            string query_Empleados = "SELECT ID_Depto, ID_Puesto, txt_Nom_Empleado, txt_ApePat, txt_ApeMat, date_FchaInicio, date_FchaNac FROM Empleados_Info WHERE ID_Empresa=" + id_empresa + " ORDER BY ID_Depto;";
            var listado_Empleados = _session.Execute(query_Empleados);

            Document Doc = new Document();
            PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_AAVD/Reporte_Nomina_General.pdf", FileMode.Create));

            Doc.Open();
            Paragraph titulo = new Paragraph();
            titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 15f, BaseColor.BLACK);
            titulo.Add("REPORTE NOMINA GENERAL");
            Doc.Add(titulo);
            Doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(6);
            tabla.AddCell("DEPARTAMENTO");
            tabla.AddCell("PUESTO");
            tabla.AddCell("NOMBRE");
            tabla.AddCell("FECHA INGRESO");
            tabla.AddCell("FECHA NAC");
            tabla.AddCell("SALARIO DIARIO");

            foreach (var item in listado_Empleados)
            {
                LocalDate dateEmp = item.GetValue<LocalDate>("date_fchainicio");
                if (dateEmp.Year == date.Year && dateEmp.Month == date.Month)
                {

                    if (item.GetValue<Guid>("id_depto") != id_depto)
                    {
                        string query_Depto = "SELECT txt_Nombre, money_SB FROM Departamentos WHERE ID_Departamento=" + item.GetValue<Guid>("id_depto") + ";";
                        var listado_deptos = _session.Execute(query_Depto);

                        foreach (var row in listado_deptos)
                        {
                            id_depto = item.GetValue<Guid>("id_depto");
                            nombre_depto = row.GetValue<string>("txt_nombre");
                            sb = (float)row.GetValue<decimal>("money_sb");
                            break;
                        }
                    }

                    if (item.GetValue<Guid>("id_puesto") != id_puesto)
                    {
                        string query_Depto = "SELECT txt_Nom_Pue, float_NS FROM Puestos WHERE ID_Empresa=" + id_empresa + " AND ID_Departamento=" + id_depto + " AND ID_Puesto=" + item.GetValue<Guid>("id_puesto") + ";";
                        var listado_deptos = _session.Execute(query_Depto);

                        foreach (var row in listado_deptos)
                        {
                            id_puesto = item.GetValue<Guid>("id_puesto");
                            nombre_puesto = row.GetValue<string>("txt_nom_pue");
                            ns = (float)row.GetValue<decimal>("float_ns");
                            break;
                        }
                    }

                    float sd = ns * sb;
                    string nombreCompleto = item.GetValue<string>("txt_nom_empleado") + " " + item.GetValue<string>("txt_apepat") + " " + item.GetValue<string>("txt_apemat");

                    tabla.AddCell(nombre_depto);
                    tabla.AddCell(nombre_puesto);
                    tabla.AddCell(nombreCompleto);
                    tabla.AddCell(item.GetValue<LocalDate>("date_fchainicio").ToString());
                    tabla.AddCell(item.GetValue<LocalDate>("date_fchanac").ToString());
                    tabla.AddCell(sd.ToString());
                }
                else
                    isBaddate = true;
            }

            if(isBaddate)
                MessageBox.Show("El filtro de la fecha no aplica", "ERROR", MessageBoxButtons.OK);
            else
                MessageBox.Show("Se ha generado el archivo PDF", "ARCHIVO", MessageBoxButtons.OK);

            Doc.Add(tabla);
            Doc.Close();
        }

        public void Reporte_Headcounter(Guid id_empresa, Guid id_depto, LocalDate date, string txt_depto, string txt_empresa)
        {
            bool isOnTime = false;
            string query_Empresa = "SELECT date_FInicio FROM Empresas WHERE ID_Empresa=" + id_empresa + ";";
            var lista_Empresa = _session.Execute(query_Empresa);

            foreach (var row in lista_Empresa)
            {
                LocalDate date_emp = row.GetValue<LocalDate>("date_finicio");
                if (date_emp.Year == date.Year && date_emp.Month == date.Month)
                {
                    isOnTime = true;
                    break;
                }
            }

            if (isOnTime == true)
            {
                string nombreCompleto = "";

                string query_Puestos = "SELECT ID_Puesto, txt_Nom_Pue FROM Puestos WHERE ID_Empresa=" + id_empresa + " AND ID_Departamento=" + id_depto + ";";
                var listado_Puestos = _session.Execute(query_Puestos);

                Document Doc = new Document();
                PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_AAVD/Reporte_Headcounter.pdf", FileMode.Create));

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

                foreach (var Item in listado_Puestos)
                {
                    string query_Empleados = "SELECT ID_Puesto, txt_Nom_Empleado, txt_ApePat, txt_ApeMat, int_GerDepto FROM Empleados_Info WHERE ID_Empresa=" + id_empresa + " AND ID_Depto=" + id_depto + " AND ID_Puesto=" + Item.GetValue<Guid>("id_puesto") + ";";
                    var listado_Empleados = _session.Execute(query_Empleados);
                    int i = 0;

                    foreach (var row in listado_Empleados)
                    {
                        if (row.GetValue<bool>("int_gerdepto") == true)
                        {
                            nombreCompleto = row.GetValue<string>("txt_nom_empleado") + " " + row.GetValue<string>("txt_apepat") + " " + row.GetValue<string>("txt_apemat");
                        }
                        i++;
                    }

                    tabla.AddCell(txt_empresa);
                    tabla.AddCell(txt_depto);
                    tabla.AddCell(nombreCompleto);
                    tabla.AddCell(Item.GetValue<string>("txt_nom_pue"));
                    tabla.AddCell(i.ToString());
                }

                Doc.Add(tabla);
                Doc.Add(new Paragraph(" "));

                PdfPTable tabla2 = new PdfPTable(5);
                tabla2.AddCell("EMPRESA");
                tabla2.AddCell("DEPARTAMENTO");
                tabla2.AddCell("GERENTE");
                tabla2.AddCell("NUM EMPLEADOS");
                tabla2.AddCell("ULTIMA EJECUCION DE NOMINA");

                string query_Deptos = "SELECT ID_Gerente FROM Departamentos WHERE ID_Departamento=" + id_depto + ";";
                var listado_Deptos = _session.Execute(query_Deptos);

                DateTime b = DateTime.Now;
                LocalDate fecha = LocalDate.Parse(b.ToString("yyyy-MM-dd"));

                foreach (var row in listado_Deptos)
                {
                    string query_listado = "SELECT txt_Nom_Empleado, txt_ApePat, txt_ApeMat FROM Empleados_Info WHERE ID_Empresa=" + id_empresa + " AND ID_Depto=" + id_depto + ";";
                    string query_Fecha = "SELECT date_eje FROM Nomina_Empresa;";

                    var listado = _session.Execute(query_listado);
                    var listado_fechas = _session.Execute(query_Fecha);

                    foreach (var info in listado_fechas)
                    {
                        fecha = info.GetValue<LocalDate>("date_eje");
                        break;
                    }

                    int i = listado.Count();

                    tabla2.AddCell(txt_empresa);
                    tabla2.AddCell(txt_depto);
                    tabla2.AddCell(nombreCompleto);
                    tabla2.AddCell(i.ToString());
                    tabla2.AddCell(fecha.ToString());
                }
                Doc.Add(tabla2);

                Doc.Close();
                MessageBox.Show("Archivo Reporte Headcounter generado", "PDF", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("No hay ningun dato registrado con la fecha ingresada", "ERROR", MessageBoxButtons.OK);
        }
        
        public void Reportes_Nomina(Guid id_empresa, Guid id_depto, LocalDate date, string txt_depto, string txt_empresa)
        {
            bool isOnTime = false;
            string query_Empresa = "SELECT date_FInicio FROM Empresas WHERE ID_Empresa=" + id_empresa + ";";
            var lista_Empresa = _session.Execute(query_Empresa);

            foreach (var row in lista_Empresa)
            {
                LocalDate date_emp = row.GetValue<LocalDate>("date_finicio");
                if (date_emp.Year == date.Year && date_emp.Month == date.Month)
                {
                    isOnTime = true;
                    break;
                }
            }

            if (isOnTime == true)
            {
                string nombreCompleto = "";
                float Simss = 0;
                float Sisr = 0;
                float SsueldoBruto = 0;
                float SsueldoNeto = 0;

                string query_Puestos = "SELECT ID_Puesto, txt_Nom_Pue FROM Puestos WHERE ID_Empresa=" + id_empresa + " AND ID_Departamento=" + id_depto + ";";
                var listado_Puestos = _session.Execute(query_Puestos);

                Document Doc = new Document();
                PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_AAVD/Reportes_Nomina.pdf", FileMode.Create));

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

                string query_Empleados = "SELECT ID_Depto, ID_Puesto, ID_Empleado, txt_ApePat, txt_ApeMat, txt_Nom_Empleado, txt_Banco, txt_NumCuenta, date_FchaInicio, int_FP FROM Empleados_Info WHERE ID_Empresa=" + id_empresa + " AND ID_Depto=" + id_depto + ";";
                RowSet lista_Empleados = _session.Execute(query_Empleados);

                foreach (var item in lista_Empleados)
                {
                    float sueldoBase = 0;
                    float ns = 0;
                    float salarioDiario = 0;
                    float sueldoBruto = 0;
                    float sueldoNeto = 0;
                    float imss = 0;
                    float isr = 0;
                    int FrePago = 0;

                    string Nombre_Completo = "";

                    string query_FrePago = "SELECT int_FP FROM Empresas WHERE ID_Empresa=" + id_empresa + ";";
                    string query_SueldoBase = "SELECT money_SB FROM Departamentos WHERE ID_Departamento=" + id_depto + ";";
                    string query_NS = "SELECT float_NS FROM Puestos WHERE ID_Empresa=" + id_empresa + "AND ID_Departamento=" + id_depto + "AND ID_Puesto=" + item.GetValue<Guid>("id_puesto") + ";";
                    string query_Dedu = "SELECT float_Monto, valor, porcentaje FROM Deducciones WHERE ID_Empresa=" + id_empresa + " AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
                    string query_Percep = "SELECT float_Monto, valor, porcentaje FROM Percepciones WHERE ID_Empresa=" + id_empresa + " AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
                    string query_Inside = "SELECT int_dias, Incidencia FROM Incidencias WHERE ID_Empresa=" + id_empresa + "AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
                    string query_Cambios = "SELECT nombre, tipo, valor, porcentaje, activo FROM Cambios WHERE ID_Empresa=" + id_empresa + ";";

                    RowSet lista_Empresas = _session.Execute(query_FrePago);
                    RowSet lista_Deptos = _session.Execute(query_SueldoBase);
                    RowSet lista_Puestos = _session.Execute(query_NS);
                    RowSet lista_Deducciones = _session.Execute(query_Dedu);
                    RowSet lista_Percepciones = _session.Execute(query_Percep);
                    RowSet lista_Insidencias = _session.Execute(query_Inside);
                    RowSet lista_Cambios = _session.Execute(query_Cambios);
                    RowSet lista_Cambios2 = _session.Execute(query_Cambios);

                    FrePago = item.GetValue<int>("int_fp");

                    foreach (var row in lista_Deptos)
                    {
                        sueldoBase = (float)row.GetValue<decimal>("money_sb");
                        break;
                    }

                    foreach (var row in lista_Puestos)
                    {
                        ns = (float)row.GetValue<decimal>("float_ns");
                        break;
                    }

                    salarioDiario = ns * sueldoBase;

                    foreach (var row in lista_Insidencias)
                    {
                        if (row.GetValue<string>("incidencia") != "Prima Vacacional")
                        {
                            FrePago = FrePago - row.GetValue<int>("int_dias");
                            if (FrePago <= 0)
                            {
                                FrePago = 0;
                                break;
                            }
                        }
                    }

                    sueldoBruto = salarioDiario * FrePago;
                    sueldoNeto = sueldoBruto;

                    foreach (var row in lista_Cambios)
                    {
                        if (row.GetValue<int>("activo") == 1)
                        {
                            if (row.GetValue<string>("tipo") == "Percepcion")
                            {
                                if (row.GetValue<decimal>("porcentaje") == 0)
                                    sueldoNeto = sueldoNeto + (float)row.GetValue<decimal>("valor");

                                if (row.GetValue<decimal>("valor") == 0)
                                    sueldoNeto = sueldoNeto + (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                            }

                            if (row.GetValue<string>("tipo") == "Deduccion")
                            {
                                if (row.GetValue<decimal>("porcentaje") == 0)
                                    sueldoNeto = sueldoNeto - (float)row.GetValue<decimal>("valor");

                                if (row.GetValue<decimal>("valor") == 0)
                                    sueldoNeto = sueldoNeto - (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                            }
                        }
                    }

                    foreach (var row in lista_Cambios2)
                    {
                        if (row.GetValue<int>("activo") == 1)
                        {
                            if (row.GetValue<string>("tipo") == "Deduccion")
                            {
                                if (row.GetValue<string>("nombre") == "IMSS")
                                {
                                    if (row.GetValue<decimal>("porcentaje") == 0)
                                        imss = (float)row.GetValue<decimal>("valor");

                                    if (row.GetValue<decimal>("valor") == 0)
                                        imss = (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                                }

                                if (row.GetValue<string>("nombre") == "ISR")
                                {
                                    if (row.GetValue<decimal>("porcentaje") == 0)
                                        isr = (float)row.GetValue<decimal>("valor");

                                    if (row.GetValue<decimal>("valor") == 0)
                                        isr = (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                                }
                            }
                        }
                    }

                    foreach (var row in lista_Deducciones)
                    {
                        if (row.GetValue<decimal>("porcentaje") == 0)
                            sueldoNeto = sueldoNeto - (float)row.GetValue<decimal>("valor");

                        if (row.GetValue<decimal>("valor") == 0)
                            sueldoNeto = sueldoNeto - (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                    }

                    foreach (var row in lista_Percepciones)
                    {
                        if (row.GetValue<decimal>("porcentaje") == 0)
                            sueldoNeto = sueldoNeto + (float)row.GetValue<decimal>("valor");

                        if (row.GetValue<decimal>("valor") == 0)
                            sueldoNeto = sueldoNeto + (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
                    }

                    Nombre_Completo = item.GetValue<string>("txt_nom_empleado") + " " + item.GetValue<string>("txt_apepat") + " " + item.GetValue<string>("txt_apemat");

                    tabla.AddCell(txt_empresa);
                    tabla.AddCell(txt_depto);
                    tabla.AddCell(imss.ToString());
                    tabla.AddCell(isr.ToString());
                    tabla.AddCell(sueldoBruto.ToString());
                    tabla.AddCell(sueldoNeto.ToString());

                    Simss = Simss + imss;
                    Sisr = Sisr + isr;
                    SsueldoBruto = SsueldoBruto + sueldoBruto;
                    SsueldoNeto = SsueldoNeto + sueldoNeto;
                }

                tabla.AddCell(txt_empresa);
                tabla.AddCell(txt_depto);
                tabla.AddCell(Simss.ToString());
                tabla.AddCell(Sisr.ToString());
                tabla.AddCell(SsueldoBruto.ToString());
                tabla.AddCell(SsueldoNeto.ToString());

                Doc.Add(tabla);
                Doc.Close();
                MessageBox.Show("Archivo Reporte Headcounter generado", "PDF", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("No hay ningun dato registrado con la fecha ingresada", "ERROR", MessageBoxButtons.OK);
        }











        // Ejemplo de leer row x row
        public string ValidaUsuario(string us, string ps)
        {
            string nombre = "";
            var Pass = "";
            var Nombre = "";
            conectar();

            string query = "SELECT Pass, Nombre FROM Usuarios WHERE Email = '" + us + "';";

            // Execute a query on a connection synchronously 
            var rs = _session.Execute(query);

            // Iterate through the RowSet 
            foreach (var row in rs)
            {
                Pass = row.GetValue<string>("pass");
                Nombre = row.GetValue<string>("nombre");
                if (Pass == ps)
                    nombre = Nombre;
            }

            return nombre;
        }
        
        public void InsertaDatos(int id, string dato)
        {
            try
            {
                conectar();
                
                string qry = "insert into ejemplo(campo1, campo2) values(";
                qry = qry + id.ToString();
                qry = qry + ",'";
                qry = qry + dato;
                qry = qry + "');";


                string query = "insert into ejemplo(campo1, campo2) values({0}, '{1}');";
                qry = string.Format(query, id, dato);

                _session.Execute(qry);
            }
            catch(Exception e)
            {
                throw e;   
            }
            finally
            {
                // desconectar o cerrar la conexión
                desconectar();
            }
        }

        public IEnumerable<Empresa> Get_One(int dato)
        {
            string query = "SELECT campo1, campo2 FROM ejemplo WHERE campo1 = ?;";
            conectar();
            IMapper mapper = new Mapper(_session);
            IEnumerable<Empresa> users = mapper.Fetch<Empresa>(query, dato);

            desconectar();
            return users.ToList();
        }
        
        // Ejemplo de leer row x row
        public void GetOne()
        {
            conectar();

            string query ="SELECT campo1, campo2 FROM ejemplo;";

            // Execute a query on a connection synchronously 
            var rs = _session.Execute(query);
            
            // Iterate through the RowSet 
            foreach (var row in rs)
            {
                var value = row.GetValue<int>("campo1");
                // Do something with the value 
                var texto = row.GetValue<string>("campo2");
                // Do something with the value 

                MessageBox.Show(texto, value.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //public void Calculo_Nomina()
        //{
        //    string delete_Nomina = "TRUNCATE Nomina_Empresa";
        //    _session.Execute(delete_Nomina);

        //    DateTime date_eje = DateTime.Now;

        //    string query_Empleados = "SELECT ID_Depto, ID_Puesto, ID_Empleado, txt_ApePat, txt_ApeMat, txt_Nom_Empleado, txt_Banco, txt_NumCuenta, date_FchaInicio, int_FP FROM Empleados_Info WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
        //    RowSet lista_Empleados = _session.Execute(query_Empleados);

        //    foreach (var item in lista_Empleados)
        //    {
        //        float sueldoBase = 0;
        //        float ns = 0;
        //        float salarioDiario = 0;
        //        float monto = 0;
        //        int FrePago = 0;

        //        string Nombre_Completo = "";

        //        string query_FrePago = "SELECT int_FP FROM Empresas WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";
        //        string query_SueldoBase = "SELECT money_SB FROM Departamentos WHERE ID_Departamento=" + item.GetValue<Guid>("id_depto") + ";";
        //        string query_NS = "SELECT float_NS FROM Puestos WHERE ID_Empresa=" + AccionesForms.ID_Empresa + "AND ID_Departamento=" + item.GetValue<Guid>("id_depto") + "AND ID_Puesto=" + item.GetValue<Guid>("id_puesto") + ";";
        //        string query_Dedu = "SELECT float_Monto, valor, porcentaje FROM Deducciones WHERE ID_Empresa=" + AccionesForms.ID_Empresa + " AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
        //        string query_Percep = "SELECT float_Monto, valor, porcentaje FROM Percepciones WHERE ID_Empresa=" + AccionesForms.ID_Empresa + " AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
        //        string query_Inside = "SELECT int_dias, Incidencia FROM Incidencias WHERE ID_Empresa=" + AccionesForms.ID_Empresa + "AND ID_Empleado=" + item.GetValue<Guid>("id_empleado") + ";";
        //        string query_Cambios = "SELECT nombre, tipo, valor, porcentaje, activo FROM Cambios WHERE ID_Empresa=" + AccionesForms.ID_Empresa + ";";

        //        RowSet lista_Empresas = _session.Execute(query_FrePago);
        //        RowSet lista_Deptos = _session.Execute(query_SueldoBase);
        //        RowSet lista_Puestos = _session.Execute(query_NS);
        //        RowSet lista_Deducciones = _session.Execute(query_Dedu);
        //        RowSet lista_Percepciones = _session.Execute(query_Percep);
        //        RowSet lista_Insidencias = _session.Execute(query_Inside);
        //        RowSet lista_Cambios = _session.Execute(query_Cambios);

        //        FrePago = item.GetValue<int>("int_fp");

        //        foreach (var row in lista_Deptos)
        //        {
        //            sueldoBase = (float)row.GetValue<decimal>("money_sb");
        //            break;
        //        }

        //        foreach (var row in lista_Puestos)
        //        {
        //            ns = (float)row.GetValue<decimal>("float_ns");
        //            break;
        //        }

        //        foreach (var row in lista_Cambios)
        //        {
        //            if (row.GetValue<int>("activo") == 1)
        //            {
        //                if (row.GetValue<string>("tipo") == "Percepcion")
        //                {
        //                    if (row.GetValue<decimal>("porcentaje") == 0)
        //                        sueldoBase = sueldoBase + (float)row.GetValue<decimal>("valor");

        //                    if (row.GetValue<decimal>("valor") == 0)
        //                        sueldoBase = sueldoBase + (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
        //                }

        //                if (row.GetValue<string>("tipo") == "Deduccion")
        //                {
        //                    if (row.GetValue<decimal>("porcentaje") == 0)
        //                        sueldoBase = sueldoBase - (float)row.GetValue<decimal>("valor");

        //                    if (row.GetValue<decimal>("valor") == 0)
        //                        sueldoBase = sueldoBase - (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
        //                }
        //            }
        //        }

        //        foreach (var row in lista_Deducciones)
        //        {
        //            if (row.GetValue<decimal>("porcentaje") == 0)
        //                sueldoBase = sueldoBase - (float)row.GetValue<decimal>("valor");

        //            if (row.GetValue<decimal>("valor") == 0)
        //                sueldoBase = sueldoBase - (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
        //        }

        //        foreach (var row in lista_Percepciones)
        //        {
        //            if (row.GetValue<decimal>("porcentaje") == 0)
        //                sueldoBase = sueldoBase + (float)row.GetValue<decimal>("valor");

        //            if (row.GetValue<decimal>("valor") == 0)
        //                sueldoBase = sueldoBase + (float)row.GetValue<decimal>("porcentaje") * sueldoBase;
        //        }

        //        foreach (var row in lista_Insidencias)
        //        {
        //            if (row.GetValue<string>("incidencia") != "Prima Vacacional")
        //            {
        //                FrePago = FrePago - row.GetValue<int>("int_dias");
        //                if (FrePago <= 0)
        //                {
        //                    FrePago = 0;
        //                    break;
        //                }
        //            }
        //        }

        //        salarioDiario = ns * sueldoBase;
        //        monto = salarioDiario * FrePago;

        //        Nombre_Completo = item.GetValue<string>("txt_nom_empleado") + " " + item.GetValue<string>("txt_apepat") + " " + item.GetValue<string>("txt_apemat");

        //        string query_NomEmpresa = "INSERT INTO Nomina_Empresa (ID_Empresa, ID_Empleado, txt_NomCom, txt_Banco, txt_NumCuenta, monto, date, date_eje) VALUES ({0}, {1}, '{2}', '{3}', '{4}', {5}, '{6}', '{7}');";
        //        string qry = string.Format(query_NomEmpresa, AccionesForms.ID_Empresa, item.GetValue<Guid>("id_empleado"), Nombre_Completo, item.GetValue<string>("txt_banco"), item.GetValue<string>("txt_numcuenta"), monto, item.GetValue<LocalDate>("date_fchainicio"), date_eje.ToString("yyyy-MM-dd"));
        //        _session.Execute(qry);

        //        PDF_Nomina_Empresa();
        //    }
        //}

        //public void Reporte_Headcounter(Guid id_empresa, Guid id_depto, LocalDate date, string txt_depto, string txt_empresa)
        //{
        //    bool isOnTime = false;
        //    string query_Empresa = "SELECT date_FInicio FROM Empresas WHERE ID_Empresa=" + id_empresa + ";";
        //    var lista_Empresa = _session.Execute(query_Empresa);

        //    foreach (var row in lista_Empresa)
        //    {
        //        LocalDate date_emp = row.GetValue<LocalDate>("date_finicio");
        //        if (date_emp.Year == date.Year && date_emp.Month == date.Month)
        //        {
        //            isOnTime = true;
        //            break;
        //        }
        //    }

        //    if (isOnTime == true)
        //    {
        //        string nombreCompleto = "";

        //        string query_Puestos = "SELECT ID_Puesto, txt_Nom_Pue FROM Puestos WHERE ID_Empresa=" + id_empresa + " AND ID_Departamento=" + id_depto + ";";
        //        var listado_Puestos = _session.Execute(query_Puestos);

        //        Document Doc = new Document();
        //        PdfWriter.GetInstance(Doc, new FileStream("C://Users/2RJ25LA_RS5/Documents/Reportes_AAVD/Reporte_Headcounter.pdf", FileMode.Create));

        //        Doc.Open();
        //        Paragraph titulo = new Paragraph();
        //        titulo.Font = FontFactory.GetFont(FontFactory.HELVETICA, 15f, BaseColor.BLACK);
        //        titulo.Add("REPORTE HEADCOUNTER");
        //        Doc.Add(titulo);
        //        Doc.Add(new Paragraph(" "));

        //        PdfPTable tabla = new PdfPTable(5);
        //        tabla.AddCell("EMPRESA");
        //        tabla.AddCell("DEPARTAMENTO");
        //        tabla.AddCell("GERENTE");
        //        tabla.AddCell("PUESTO");
        //        tabla.AddCell("NUM EMPLEADOS");

        //        foreach (var Item in listado_Puestos)
        //        {
        //            string query_Empleados = "SELECT ID_Puesto, txt_Nom_Empleado, txt_ApePat, txt_ApeMat, int_GerDepto FROM Empleados_Info WHERE ID_Empresa=" + id_empresa + " AND ID_Depto=" + id_depto + " AND ID_Puesto=" + Item.GetValue<Guid>("id_puesto") + ";";
        //            var listado_Empleados = _session.Execute(query_Empleados);
        //            int i = 0;

        //            foreach (var row in listado_Empleados)
        //            {
        //                if (row.GetValue<bool>("int_gerdepto") == true)
        //                {
        //                    nombreCompleto = row.GetValue<string>("txt_nom_empleado") + " " + row.GetValue<string>("txt_apepat") + " " + row.GetValue<string>("txt_apemat");
        //                }
        //                i++;
        //            }

        //            tabla.AddCell(txt_empresa);
        //            tabla.AddCell(txt_depto);
        //            tabla.AddCell(nombreCompleto);
        //            tabla.AddCell(Item.GetValue<string>("txt_nom_pue"));
        //            tabla.AddCell(i.ToString());
        //        }

        //        Doc.Add(tabla);
        //        Doc.Close();
        //    }
        //}
    }
}
