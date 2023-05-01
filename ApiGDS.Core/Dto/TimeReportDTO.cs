using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class TimeReportDTO
    {
        public string ClientName { get; set; } = string.Empty;
        public string ConsultantName { get; set; } = string.Empty;
        public string AppendixName { get; set; } = string.Empty;
        public int Week { get; set; }
        public int HorasNormalesFacturables { get; set; }
        public int HorasNormalesNoFacturables { get; set; }
        public int HorasNormalesOficina { get; set; }
        public int HorasEntrenamiento { get; set; }
        public int HorasPermisoEnfermedad { get; set; }
        public int HorasVacaciones { get; set; }
        public int HorasFeriadoFacturable { get; set; }
        public int HorasFeriadoNoFacturable { get; set; }
        public int HorasFeriadoOficina { get; set; }
        public int HorasViajeFacturable { get; set; }
        public int HorasViajeNoFacturable { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
