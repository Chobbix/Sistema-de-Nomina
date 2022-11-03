using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace Ventanas_Finales_Siksi.Tablas_CQL
{
    class CQL_Empresas
    {
        public string txt_RS { get; set; }
        public string txt_Email { get; set; }
        public string txt_RP { get; set; }
        public string txt_RF { get; set; }
        public LocalDate date_FInicio { get; set; }
        public IEnumerable<int> int_FP { get; set; }

        public Guid ID_Gerente { get; set; }
        public string txt_Nom_Empleado { get; set; }
        public string txt_ApePat { get; set; }
        public string txt_ApeMat { get; set; }

        public string txt_Calle { get; set; }
        public string txt_Num { get; set; }
        public string txt_Colonia { get; set; }
        public string txt_Municipio { get; set; }
        public string txt_Estado { get; set; }
        public string txt_CP { get; set; }
        public Guid ID_Empresa { get; set; }
    }
}
