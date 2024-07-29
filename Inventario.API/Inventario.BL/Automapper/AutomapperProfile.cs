using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Inventario.Entities.DTO;
using Inventario.Entities.Models;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Inventario.BL.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Productos, ProductosDTO>()
                .ForMember(destination => destination.Codigo, options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.NombreProducto, options => options.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.PrecioProducto, options => options.MapFrom(source => source.Precio))
                .ForMember(destination => destination.StockProducto, options => options.MapFrom(source => source.Stock))
                .ReverseMap();
        }
    }
}
