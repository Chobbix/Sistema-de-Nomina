using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace Ventanas_Finales_Siksi.Tablas_CQL
{
    class CQL_Empleados
    {
        public Guid ID_Empleado { get; set; }
        public Guid ID_Empresa { get; set; }
        public Guid ID_Depto { get; set; }
        public Guid ID_Puesto { get; set; }
        public string txt_Contra { get; set; }
        public string txt_Nom_Empleado { get; set; }
        public string txt_ApePat { get; set; }
        public string txt_ApeMat { get; set; }
        public string txt_CURP { get; set; }
        public string txt_NSS { get; set; }
        public string txt_RFC { get; set; }
        public string txt_Banco { get; set; }
        public string txt_NumCuenta { get; set; }
        public string txt_Email { get; set; }
        public string txt_Telefono { get; set; }
        public int int_Dias { get; set; }
        public int int_tipo { get; set; }
        public int int_GerDepto { get; set; }
        public int int_FP { get; set; }

        public float float_SueldoBase { get; set; }
        public LocalDate date_FchaNac { get; set; }
        public LocalDate date_FchaInicio { get; set; }
        public string txt_Calle { get; set; }
        public string txt_Num { get; set; }
        public string txt_Colonia { get; set; }
        public string txt_Municipio { get; set; }
        public string txt_Estado { get; set; }
        public string txt_CP { get; set; }
    }
}
