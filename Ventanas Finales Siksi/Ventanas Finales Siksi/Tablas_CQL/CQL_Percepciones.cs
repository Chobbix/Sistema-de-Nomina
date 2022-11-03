using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventanas_Finales_Siksi.Tablas_CQL
{
    class CQL_Percepciones
    {
        public Guid Clave{ get; set; }
        public string txt_Nom_Per{ get; set; }
        public float float_Monto{ get; set; }
        public float valor { get; set; }
        public float porcentaje { get; set; }

        public Guid ID_Empresa{ get; set; }
        public Guid ID_Empleado{ get; set; }
    }
}
