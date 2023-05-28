using ApiGDS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class ActivityDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public ActivityCategory Category { get; set; }
    }
}
