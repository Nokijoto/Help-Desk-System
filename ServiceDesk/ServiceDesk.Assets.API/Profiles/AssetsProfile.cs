using AutoMapper;
using ServiceDesk.Assets.CrossCutting.Dtos;
using ServiceDesk.Assets.CrossCutting.Dtos.CreateDto;
using ServiceDesk.Assets.Storage.Entities;

namespace ServiceDesk.Assets.API.Profiles
{
    public class AssetsProfile:Profile
    {
        public AssetsProfile()
        {
            CreateMap<Asset, AssetDto>().ReverseMap();
            CreateMap<Computer, ComputerDto>().ReverseMap();
            CreateMap<CreateComputerDto, ComputerDto>().ReverseMap();
            CreateMap<Cable, CableDto>().ReverseMap();
            CreateMap<CreateCableDto, CableDto>().ReverseMap();
        }
    }
}
