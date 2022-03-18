using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipoCambioAPI.Models
{
    public class TipoCambio
    {
        public decimal monto{ get; set; }
        public decimal montoCambio{ get; set; }
        public string origen{ get; set; }
        public string destino{ get; set; }
        public decimal tipoDeCambio{ get; set; }
    }
}
