using ApiGDS.Core.Dto;
using ApiGDS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class TimeReport
    {
        public int Id { get; set; } 
        public int Serial { get; set; }
        public Client Client { get; set; } = new Client();
        public string ClientName { get; set; } = string.Empty;
        public Consultant Consultant { get; set; } = new Consultant();
        public string ConsultantName { get; set; } = string.Empty;
        public Appendix Appendix { get; set; } = new Appendix();
        public string AppendixName { get; set; } = string.Empty;
        public int Horas { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string FirmaEmpleado { get; set; } = string.Empty;
        public string FirmaCliente { get; set; } = string.Empty;
        //public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}
