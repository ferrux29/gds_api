using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class Folder
    {
        public int Id { get; set; }
        public Client Client { get; set; } = new Client();
        public string ClientName { get; set; } = string.Empty;
        public Contrato Contrato { get; set; } = new Contrato();
        public string ContratoName { get; set; } = string.Empty;
        public Appendix Appendix { get; set; } = new Appendix();
        public string AppendixName { get; set; } = string.Empty;
    }
}
