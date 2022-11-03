using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using System.Configuration;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class EnlaceCassandra
    {
        static private string _dbServer { set; get; }
        static private string _dbKeySpace { set; get; }
        static private Cluster _cluster;
        static private ISession _session;

        private static void conectar()
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

        private static void desconectar()
        {
            _cluster.Dispose();
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

        public IEnumerable<Usuarios> Get_One(int dato)
        {
            string query = "SELECT campo1, campo2 FROM ejemplo WHERE campo1 = ?;";
            conectar();
            IMapper mapper = new Mapper(_session);
            IEnumerable<Usuarios> users = mapper.Fetch<Usuarios>(query, dato);

            desconectar();
            return users.ToList();
        }

        public List<Usuarios> Get_All()
        {
            string query = "SELECT campo1, campo2 FROM ejemplo;";
            conectar();
            
            IMapper mapper = new Mapper(_session);
            IEnumerable<Usuarios> users = mapper.Fetch<Usuarios>(query);

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

                /*
                RowSet rsUsers = session.Execute(qry);

                ////////////////////////////////////////////////
                var users = new List<UserModel>();
                foreach (var userRow in rsUsers)
                {
                    //users.Add(ReflectionTools.GetSingleEntryDynamicFromReader<UserModel>(userRow));
                }

                foreach (UserModel user in users)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", user.Id, user.FirstName, user.LastName, user.Country, user.IsActive);
                }
                */

            }
        }

    }
}
