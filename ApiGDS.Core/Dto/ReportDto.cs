using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class ReportDto
    {
        public int Horas { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string FirmaEmpleado { get; set; } = string.Empty;
        public string FirmaCliente { get; set; } = string.Empty;
    }
}
