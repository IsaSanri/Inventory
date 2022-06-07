using AutoMapper;
using InventorySystem.Entities.DTOs;
using InventorySystem.Entities.Entities;

namespace InventorySystem.Core.Core.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ArticuloCreateDto, Articulo>();
            CreateMap<Articulo, ArticuloCreateDto>();

            CreateMap<ArticuloSaldoExistenciaDto, ArticuloCreateDto>();
            CreateMap<Articulo,ArticuloSaldoExistenciaDto>();

            CreateMap<MovimientoCreateDto, Movimiento>();
            CreateMap<Movimiento, MovimientoCreateDto>();
        }
    }
}
