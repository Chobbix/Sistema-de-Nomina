using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1
{
    public class Funciones: EnlaceDB
    {
        public static DataTable ObtenUsuarios()
        {
            EnlaceDB conexion = new EnlaceDB();
            DataTable data = new DataTable();

            data = conexion.get_Users();

            return  data;
        }
    }
}
