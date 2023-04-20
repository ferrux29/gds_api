using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class BillDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ConsultantName { get; set; } = string.Empty;
        public string AppendixMontoFacturado { get; set; } = string.Empty;
    }
}
