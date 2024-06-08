using AutoMapper;
using RH.DTOs;
using RH.Models;

namespace RH.Data
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Vaga, VagaDto>().ReverseMap();
            CreateMap<Tecnologia, TecnologiaDto>().ReverseMap();
            CreateMap<Empresa, EmpresaDto>().ReverseMap();
        }
    }
}