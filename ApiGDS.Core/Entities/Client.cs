using ApiGDS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Category ClienteCategory{ get; set; }
    }
}
