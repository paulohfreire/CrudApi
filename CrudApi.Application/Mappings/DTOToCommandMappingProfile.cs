using AutoMapper;
using CrudApi.Application.DTOs;
using CrudApi.Application.Products.Commands;

namespace CrudApi.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
