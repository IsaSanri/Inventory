using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.Entities;
using InventorySystem.Entities.Utils;
using InventorySystem.Core.Core.ErrorsHandler;
using InventorySystem.Contracts.Repository;
using InventorySystem.Entities.DTOs;
using System.Net;

namespace InventorySystem.Core.Core.V1
{
    public class ArticuloCore
    {
        private readonly IArticuloRepository _context;
        private readonly ILogger _logger;
        private readonly ErrorHandler<Articulo> _errorHandler;
        private readonly IMapper _mapper;

        public ArticuloCore(ILogger<Articulo> logger, IMapper mapper, IArticuloRepository context)
        {
            _logger = logger;
            _errorHandler = new ErrorHandler<Articulo>(logger);
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseService<List<Articulo>>> GetArticulosAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                return new ResponseService<List<Articulo>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", System.Net.HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetArticuloAsync", new List<Articulo>());
                
            }
        }

        public async Task<ResponseService<List<ArticuloSaldoExistenciaDto>>> GetSaldosAsync()
        {
            try
            {
                var response = await _context.GetAllAsync();
                List<ArticuloSaldoExistenciaDto> newItem = new();
                newItem = _mapper.Map<List<ArticuloSaldoExistenciaDto>>(response);
                return new ResponseService<List<ArticuloSaldoExistenciaDto>>(false, newItem.Count == 0 ? "No records found" : $"{newItem.Count} records found", HttpStatusCode.OK, newItem);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetArticuloSaldoExistenciaAsync", new List<ArticuloSaldoExistenciaDto>());
            }
        }

        public async Task<ResponseService<Articulo>> GetArticuloByIdAsync(int id)
        {
            try
            {
                var response = await _context.GetByIdAsync(id);
                return new ResponseService<Articulo>(false, response == null ? "No records found" : "Record found:", HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetItemByIdAsync", new Articulo());
            }
        }

        public async Task<ResponseService<ArticuloSaldoExistenciaDto>> GetArticuloByIdSaldoExistenciaAsync(int id)
        {
            try
            {
                var response = await _context.GetByIdAsync(id);
                ArticuloSaldoExistenciaDto newItem = new();
                newItem = _mapper.Map<ArticuloSaldoExistenciaDto>(response);
                return new ResponseService<ArticuloSaldoExistenciaDto>(false, newItem == null ? "No records found" : "Record found:", HttpStatusCode.OK, newItem);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetItemByIdStockBalanceAsync", new ArticuloSaldoExistenciaDto());
            }
        }
        //public async Task<Articulo> CreateArticuloAsync(ArticuloCreateDto entity)
        //{
        //    Articulo newArticulo = new();

        //    newArticulo.Name = entity.Name;
        //    newArticulo.Address = entity.Address;
        //    newArticulo.PhoneNumber = entity.PhoneNumber;

        //    var newArticuloCreated = _context.Articulo.Add(newArticulo);

        //    await _context.SaveChangesAsync();

        //    return newArticuloCreated.Entity;
        //}

        //public async Task<bool> UpdateArticuloAsync(Articulo ArticuloToUpdated)
        //{
        //    Articulo Articulo = _context.Articulo.Find(ArticuloToUpdated.IdArticulo);
        //    Articulo.Name = ArticuloToUpdated.Name;
        //    Articulo.Address = ArticuloToUpdated.Address;
        //    Articulo.PhoneNumber = ArticuloToUpdated.PhoneNumber;

        //    _context.Articulo.Update(Articulo);

        //    int recordsAffeted = await _context.SaveChangesAsync();

        //    return (recordsAffeted == 1);
        //}

        //public async Task<bool> DeleteArticuloAsync(Articulo ArticuloToDelete)
        //{
        //    Articulo Articulo = _context.Articulo.Find(ArticuloToDelete.IdArticulo);

        //    _context.Articulo.Remove(Articulo);

        //    int recordsAffeted = await _context.SaveChangesAsync();

        //    return (recordsAffeted == 1);
        //}
    }
}
