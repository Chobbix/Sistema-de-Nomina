using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventanas_Finales_Siksi
{
    public class Cambios
    {
        public Guid Clave { get; set; }
        public int SQL_Clave { get; set; }
        public string nombre { get; set; }
        public float monto { get; set; }
        public string tipo { get; set; }
        public float valor { get; set; }
        public float porcentaje { get; set; }
        public int activo { get; set; }

        public Guid ID_Empresa { get; set; }
        public int SQL_ID_Empresa { get; set; }
    }
}
