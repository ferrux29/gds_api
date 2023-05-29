using ApiGDS.Core.Enums;
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
        public string ProjectName { get; set; } = string.Empty;
        public Service Service { get; set; } = new Service();
        public string ServiceName { get; set; } = string.Empty;
        public Assignment Assignment { get; set; }
        public Consultant consultant { get; set; } = new Consultant();
        public string ConsultorName { get; set; } = string.Empty;
        public int HorasTrabajadas { get; set; }
        public string CostoEstimado { get; set; } = string.Empty;
        public Contract Contract { get; set; } = new Contract();
        public int ContractId { get; set; }

    }
}
