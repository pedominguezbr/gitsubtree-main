using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoCambioAPI.Models;

namespace TipoCambioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tipoCambioController : ControllerBase
    {
        private readonly MonedaDbContext _context;

        public tipoCambioController(MonedaDbContext context) {
            _context = context;
        
        }
        [HttpGet("ListarMonedas")]
        public List<Moneda> GetMonedas() {
            return _context.Monedas.ToList();
        
        }

        [HttpGet("ListarMonedasById{id}")]
        public Moneda getMonedaById(string id) {
            return _context.Monedas.SingleOrDefault(e=>e.id==id);
        }
        [HttpPost]
        public IActionResult AddMoneda(Moneda monedas) {
            _context.Monedas.Add(monedas);
            _context.SaveChanges();
            return Created("api/tipoCambio/" + monedas.id, monedas.nombre);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMoneda(string id, Moneda monedas)
        {
            var mon = _context.Monedas.SingleOrDefault(e => e.id == id);
            if (mon == null) {
                return NotFound("No existe la moneda con el id " + id);
            }

            if (monedas.nombre != null)
                mon.nombre = monedas.nombre;
            //if (monedas.valor != null)
            //    mon.valor = monedas.valor;


            _context.Update(mon);
            _context.SaveChanges();
            return Ok("La moneda con el ID: " + id +", se actualizó correctamente ");
        }
        [HttpGet("RealizarCambio")]
        public TipoCambio tryTipoCambio(decimal Monto, string Origen, string Destino)
        {
            var cambio = _context.Monedas.SingleOrDefault(e => e.nombre == Destino).valor;
            var tipo = new TipoCambio() {
                monto = Monto,
                origen = Origen,
                destino = Destino,
                tipoDeCambio = cambio,
                montoCambio = Origen=="PEN"? Monto * cambio:Monto/cambio

            };
            return tipo;
        }
    }
}
