using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class Appendix
    {
        public int Id { get; set; }
        public Consultant consultant { get; set; } = new Consultant();
        public string ConsultorName { get; set; } = string.Empty;
        public int HorasTrabajadas { get; set; }
        public string CostoEstimado { get; set; } = string.Empty;
        public string MontoFacturado { get; set; } = string.Empty;
    }
}
