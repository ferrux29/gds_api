using ApiGDS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Dto
{
    public class BillDTO
    {
        public string IssueDate { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public int Total { get; set; }
        public string ClientName { get; set; } = string.Empty;
    }
}
