using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace Ventanas_Finales_Siksi.Tablas_CQL
{
    class CQL_Puestos
    {
        public Guid ID_Puesto { get; set; }
        public string txt_Nom_Pue { get; set; }
        public float float_NS { get; set; }
        public float money_SD { get; set; }

        public Guid ID_Departamento { get; set; }
        public string txt_Nom_Depto { get; set; }
        public float money_SB { get; set; }

        public Guid ID_Empresa { get; set; }
        public string txt_RS { get; set; }
    }
}
