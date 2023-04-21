    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class Contrato
    {
       public int Id { get; set; }
       public string Clase { get; set; } = string.Empty;
       public string Name { get; set; } = string.Empty;
       public int MontoMax { get; set; }
       public Client Client { get; set; } = new Client();
       public string ClienteName { get; set; } = string.Empty;
    }
}
