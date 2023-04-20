using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Client Client { get; set; } = new Client();
        public string ClientName { get; set; } = string.Empty;
        public Consultant Consultant { get; set; } = new Consultant();
        public string ConsultantName { get; set; } = string.Empty;
        public Appendix Appendix { get; set; } = new Appendix();
        public string AppendixMontoFacturado { get; set; } = string.Empty;
    }
}
