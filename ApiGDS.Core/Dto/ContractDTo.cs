using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class ContractDTo
    {
        public string Clase { get; set; } = string.Empty;
        public string ClienteName { get; set; } = string.Empty;
        public int MontoMax { get; set; }
        public bool Fianza { get; set; }
    }
}
