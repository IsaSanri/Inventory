using AutoMapper;
using InventorySystem.Core.Core.V1;
using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventorySystem.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly MovimientoCore _movimientoCore;

        public MovimientosController(ILogger<Movimiento> logger, IMapper mapper, SqlServerContext context)
        {
            _movimientoCore = new MovimientoCore(logger, mapper, context);
        }

        // GET: api/<MovimientosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> Get()
        {
            var response = await _movimientoCore.GetMovimientosAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<MovimientosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovimientosController>
        [HttpPost]
        //public async Task<Movimiento> Post([FromBody] MovimientoCreateDto movimiento)
        //{
        //    return await _movimientoCore.CreateMovimientoAsync(movimiento);
        //}

        // PUT api/<MovimientosController>/5
        [HttpPut]
        //public async Task<bool> Put([FromBody] Movimiento movimiento)
        //{
        //    return await _movimientoCore.UpdateMovimientoAsync(movimiento);
        //}

        // DELETE api/<MovimientosController>/5
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await _movimientoCore.DeleteMovimientoAsync(id);
        }
    }
}
