using AutoMapper;
using RH.DTOs;
using RH.Models;

namespace RH.Data
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Candidato, CandidatoDto>().ReverseMap();
            CreateMap<Tecnologia, TecnologiaDto>().ReverseMap();
            CreateMap<Vaga, VagaDto>().ReverseMap();
        }
    }
}