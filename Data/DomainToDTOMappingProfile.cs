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
            CreateMap<Empresa, EmpresaDto>().ReverseMap();
            CreateMap<EmpresaTecnologia, EmpresaTecnologiaDto>().ReverseMap();
            CreateMap<Tecnologia, TecnologiaDto>().ReverseMap();
            CreateMap<Vaga, VagaDto>().ReverseMap();
            CreateMap<VagaTecnologiaRequisito, VagaTecnologiaRequisitoDto>().ReverseMap();
            CreateMap<VinculoCanditadoVaga, VinculoCanditadoVagaDto>().ReverseMap();
            CreateMap<VinculoCanditadoVagaTecnologia, VinculoCanditadoVagaTecnologiaDto>().ReverseMap();
        }
    }
}