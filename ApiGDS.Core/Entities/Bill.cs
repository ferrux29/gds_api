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
        public string IssueDate { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public int Total { get; set; }
        public Client Client { get; set; } = new Client();
        public string ClientName { get; set; } = string.Empty;

    }
}
