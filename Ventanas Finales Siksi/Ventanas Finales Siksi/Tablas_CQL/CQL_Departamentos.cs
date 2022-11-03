using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace Ventanas_Finales_Siksi.Tablas_CQL
{
    class CQL_Departamentos
    {
        public string txt_Nombre { get; set; }
        public float money_SB { get; set; }
	
	    public Guid ID_Gerente { get; set; }
        public string txt_Nom_Empleado { get; set; }
        public string txt_ApePat { get; set; }
        public string txt_ApeMat { get; set; }
        public Guid ID_Departamento { get; set; }
    }
}
