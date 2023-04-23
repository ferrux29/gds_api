using ApiGDS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class AppendixDTO
    {
        public string ProjectName { get; set; } = string.Empty;
        public Assignment Assignment { get; set; }
        public string ConsultorName { get; set; } = string.Empty;
        public int HorasTrabajadas { get; set; }
        public string CostoEstimado { get; set; } = string.Empty;
        public string MontoFacturado { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public int ContractId { get; set; }
    }
}
