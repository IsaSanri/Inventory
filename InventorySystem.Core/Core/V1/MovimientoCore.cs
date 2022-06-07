using AutoMapper;
using InventorySystem.Contracts.Repository;
using InventorySystem.Core.Core.ErrorsHandler;
using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.Entities;
using InventorySystem.Entities.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InventorySystem.Core.Core.V1
{
    public class MovimientoCore
    {
        private readonly IMovmientoRepository _context;
        private readonly ILogger _logger;
        private readonly ErrorHandler<Movimiento> _errorHandler;
        private readonly IMapper _mapper;

        public MovimientoCore(ILogger<Movimiento> logger, IMapper mapper, IMovmientoRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Movimiento>(logger);
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseService<List<Movimiento>>> GetMovimientosAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                return new ResponseService<List<Movimiento>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", System.Net.HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetMovimientoAsync", new List<Movimiento>());
                
            }
        }

        public async Task<ResponseService<Movimiento>> GetMovimientoByIdAsync(int id)
        {
            try
            {
                var response = await _context.GetByIdAsync(id);
                return new ResponseService<Movimiento>(false, response == null ? "No records found" : "Record found:", HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetMovementByIdAsync", new Movimiento());
            }
        }
        //public async Task<Movimiento> CreateMovimientoAsync(MovimientoCreateDto entity)
        //{
        //    Movimiento newMovimiento = new();

        //    newMovimiento.Name = entity.Name;
        //    newMovimiento.CV = entity.CV;
        //    newMovimiento.MovimientoType = entity.MovimientoType;
        //    newMovimiento.HardSkills = entity.HardSkills;    
        //    newMovimiento.SoftSkills = entity.SoftSkills;
        //    newMovimiento.Seniority = entity.Seniority;
        //    newMovimiento.YearsOfExperience = entity.YearsOfExperience;


        //    var newMovimientoCreated = _context.Movimiento.Add(newMovimiento);

        //    await _context.SaveChangesAsync();

        //    return newMovimientoCreated.Entity;
        //}

        //public async Task<bool> UpdateMovimientoAsync(Movimiento movimientoToUpdated)
        //{
        //    Movimiento movimiento = _context.Movimiento.Find(movimientoToUpdated.IdMovimiento);
        //    movimiento.Name = movimientoToUpdated.Name;
        //    movimiento.CV = movimientoToUpdated.CV;   
        //    movimiento.MovimientoType = movimientoToUpdated.MovimientoType;
        //    movimiento.HardSkills = movimientoToUpdated.HardSkills;   
        //    movimiento.SoftSkills = movimientoToUpdated.SoftSkills;
        //    movimiento.Seniority=movimientoToUpdated.Seniority;
        //    movimiento.YearsOfExperience= movimientoToUpdated.YearsOfExperience;


        //    _context.Movimiento.Update(movimiento);

        //    int recordsAffeted = await _context.SaveChangesAsync();

        //    return (recordsAffeted == 1);
        //}

        public async Task<bool> DeleteMovimientoAsync(int idMovimientoToDelete)
        {
            Movimiento movimiento = _context.Movimiento.Find(idMovimientoToDelete);


            _context.Movimiento.Remove(movimiento);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
