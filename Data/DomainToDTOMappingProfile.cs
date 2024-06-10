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
            CreateMap<CandidatoTecnologia, CandidatoTecnologiaDto>().ReverseMap();
            CreateMap<Empresa, EmpresaDto>().ReverseMap();
            CreateMap<EmpresaTecnologia, EmpresaTecnologiaDto>().ReverseMap();
            CreateMap<EmpresaVaga, EmpresaVagaDto>().ReverseMap();
            CreateMap<Tecnologia, TecnologiaDto>().ReverseMap();
            CreateMap<Vaga, VagaDto>().ReverseMap();
            CreateMap<VagaTecnologia, VagaTecnologiaDto>().ReverseMap();
            CreateMap<VagaTecnologiaRequisito, VagaTecnologiaRequisitoDto>().ReverseMap();
            CreateMap<VinculoCanditadoVaga, VinculoCanditadoVagaDto>().ReverseMap();
            CreateMap<VinculoCanditadoVagaTecnologia, VinculoCanditadoVagaTecnologiaDto>().ReverseMap();
        }
    }
}