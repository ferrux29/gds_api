using ApiGDS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Code { get; set; }
        public ActivityCategory Category { get; set; }

        public TimeReport timeReport { get; set; } = new TimeReport();
        public int TimeReportId { get; set; }

    }
}
