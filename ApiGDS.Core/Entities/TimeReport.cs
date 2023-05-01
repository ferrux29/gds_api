﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGDS.Core.Entities
{
    public class TimeReport
    {
        public int Id { get; set; } //serial
        public Client Client { get; set; } = new Client();
        public string ClientName { get; set; } = string.Empty;
        public Consultant Consultant { get; set; } = new Consultant();
        public string ConsultantName { get; set; } = string.Empty;
        public Appendix Appendix { get; set; } = new Appendix();
        public string AppendixName { get; set; } = string.Empty;
        public int Week {get; set; }
        public int HorasNormalesFacturables { get; set; }
        public int HorasNormalesNoFacturables { get; set; }
        public int HorasNormalesOficina { get; set; }
        public int HorasEntrenamiento { get; set; }
        public int HorasPermisoEnfermedad { get; set; }
        public int HorasVacaciones { get; set; }
        public int HorasFeriadoFacturable { get; set; }
        public int HorasFeriadoNoFacturable { get; set; }
        public int HorasFeriadoOficina { get; set; }
        public int HorasViajeFacturable { get; set; }
        public int HorasViajeNoFacturable { get; set; }
        public int Total { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
