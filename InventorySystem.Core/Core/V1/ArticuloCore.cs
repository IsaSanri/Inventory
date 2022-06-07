using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Extensions.Logging;
using InventorySystem.DataAccess.Context;
using InventorySystem.Entities.Entities;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Utils;
using Microsoft.EntityFrameworkCore;
using InventorySystem.Core.Core.ErrorsHandler;


namespace InventorySystem.Core.Core.V1
{
    public class ArticuloCore
    {
        private readonly SqlServerContext _context;
        private readonly ILogger _logger;
        private readonly ErrorHandler<Articulo> _errorHandler;
        private readonly IMapper _mapper;

        public ArticuloCore(ILogger<Articulo> logger, IMapper mapper, SqlServerContext context)
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
                var response = await _context.Articulo.ToListAsync();
                return new ResponseService<List<Articulo>>(false, response.Count == 0 ? "No records found" : $"{response.Count} records found", System.Net.HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return _errorHandler.Error(ex, "GetArticuloAsync", new List<Articulo>());
                
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

        public async Task<bool> DeleteArticuloAsync(Articulo ArticuloToDelete)
        {
            Articulo Articulo = _context.Articulo.Find(ArticuloToDelete.IdArticulo);
           
            _context.Articulo.Remove(Articulo);

            int recordsAffeted = await _context.SaveChangesAsync();

            return (recordsAffeted == 1);
        }
    }
}
