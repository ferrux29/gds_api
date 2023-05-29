    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class Contract
    {
       public int Id { get; set; }
       public float MontoMax { get; set; }
       public bool Fianza { get; set; }
       public Client Client { get; set; } = new Client();
       public string ClienteName { get; set; } = string.Empty;
    }
}
