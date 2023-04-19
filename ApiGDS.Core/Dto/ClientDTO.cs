using ApiGDS.Core.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class ClientDTO
    {
        public string Name { get; set; } = string.Empty;
        public Category ClienteCategory { get; set; }
    }
}
