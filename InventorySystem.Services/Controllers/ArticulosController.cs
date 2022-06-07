using AutoMapper;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.V1;
using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.DTOs;
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
    public class ArticulosController : ControllerBase
    {
        private readonly ArticuloCore _articuloCore;

        public ArticulosController(ILogger<Articulo> logger, IMapper mapper, IArticuloRepository context)
        {
            _articuloCore = new ArticuloCore(logger, mapper, context);
        }
        // GET: api/<ArticulosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> Get()
        {
            var response = await _articuloCore.GetArticulosAsync();
            return StatusCode((int)response.StatusHttp, response);
        }
        // GET: api/<ArticulosController>
        [HttpGet("Stock")]
        public async Task<ActionResult<IEnumerable<ArticuloSaldoExistenciaDto>>> GetSaldos()
        {
            var response = await _articuloCore.GetSaldosAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<ArticulosController>/
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> Get(int id)
        {
            var response = await _articuloCore.GetArticuloByIdAsync(id);
            return StatusCode((int)response.StatusHttp,response);
        }

        // GET: api/<ArticulosController>
        [HttpGet("Stock{id}")]
        public async Task<ActionResult<ArticuloSaldoExistenciaDto>> GetArticuloByIdAsync(int id)
        {
            var response = await _articuloCore.GetArticuloByIdSaldoExistenciaAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        //// POST api/<ArticuloController>
        //[HttpPost]
        ////public async Task<Articulo> Post([FromBody] ArticuloCreateDto articulo)
        ////{
        ////    return await _articuloCore.CreateArticuloAsync(articulo);
        ////}

        //// PUT api/<ArticuloController>/5
        //[HttpPut]
        ////public async Task<bool> Put([FromBody] Articulo articulo)
        ////{
        ////    return await _articuloCore.UpdateArticuloAsync(articulo);
        ////}

        //// DELETE api/<ArticuloController>/5
        //[HttpDelete]
        //public async Task<bool> Delete(Articulo articulo)
        //{
        //    return await _articuloCore.DeleteArticuloAsync(articulo);
        //}
    }
}
