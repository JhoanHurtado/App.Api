using App.Api.Dto.Dtos;
using App.Api.Model.Models;
using AutoMapper;

namespace App.Api.WeApi.Profiles
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            this.CreateMap<Cliente, ClienteDto>().ReverseMap();
            this.CreateMap<Producto, ProductoDto>().ReverseMap();
            this.CreateMap<Factura, FacturaDto>().ReverseMap();
            this.CreateMap<DetalleFactura, DetalleFacturaDto>().ReverseMap();
        }
    }
}
