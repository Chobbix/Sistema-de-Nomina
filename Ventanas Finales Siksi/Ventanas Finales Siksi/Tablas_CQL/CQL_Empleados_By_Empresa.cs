using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventanas_Finales_Siksi.Tablas_CQL
{
    class CQL_Empleados_By_Empresa
    {
        public Guid ID_Empleado { get; set; }
        public string txt_NombreCompleto { get; set; }
        public Guid ID_Empresa { get; set; }
        public string txt_NomEmpresa { get; set; }
        public Guid ID_Depto { get; set; }
        public Guid ID_Puesto { get; set; }
    }
}
