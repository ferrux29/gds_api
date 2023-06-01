using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class TimeReportDTO
    {
        public int Serial { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string ConsultantName { get; set; } = string.Empty;
        public string AppendixName { get; set; } = string.Empty;
        public int Horas { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string FirmaEmpleado { get; set; } = string.Empty;
        public string FirmaCliente { get; set; } = string.Empty;
        //public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}
