using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TipoCambioAPI.Models
{
    public class Moneda
    {
        [Key]
        public string id { get; set; }
        public string nombre { get; set; }
        public decimal valor { get; set; }
    }
}
