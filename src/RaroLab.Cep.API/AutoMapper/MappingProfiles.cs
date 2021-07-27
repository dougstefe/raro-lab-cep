using AutoMapper;
using RaroLab.Cep.API.ViewModels;
using RaroLab.Cep.Domain.Models.Services.ViaCep;

namespace RaroLab.Cep.API.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Address

            CreateMap<ViaCepAddressResponseModel, AddressResponseViewModel>()
                .ForMember(
                    dest => dest.Address,
                    opts => opts.MapFrom(src => src.Logradouro))
                .ForMember(
                    dest => dest.Complement,
                    opts => opts.MapFrom(src => src.Complemento))
                .ForMember(
                    dest => dest.District,
                    opts => opts.MapFrom(src => src.Bairro))
                .ForMember(
                    dest => dest.FU,
                    opts => opts.MapFrom(src => src.Uf))
                .ForMember(
                    dest => dest.Location,
                    opts => opts.MapFrom(src => src.Localidade))
                .ForMember(
                    dest => dest.ZipCode,
                    opts => opts.MapFrom(src => src.Cep));

            #endregion
        }
    }
}
