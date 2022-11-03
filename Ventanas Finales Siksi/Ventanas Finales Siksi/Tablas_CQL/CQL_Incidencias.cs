using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace Ventanas_Finales_Siksi.Tablas_CQL
{
    class CQL_Incidencias
    {
        public Guid ID_Empresa { get; set; }
        public Guid ID_Empleado { get; set; }
        public string Incidencia { get; set; }
        public int int_dias { get; set; }
        public LocalDate date_eje { get; set; }
    }
}
