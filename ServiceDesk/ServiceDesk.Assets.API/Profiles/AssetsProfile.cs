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
            CreateMap<Asset, AssetDto>()
                .Include<Computer, ComputerDto>()
                .Include<Cable, CableDto>()
                .Include<Device, DeviceDto>()
                .Include<Rack, RackDto>()
                .Include<PDU, PDUDto>()
                .Include<Storage.Entities.Monitor, MonitorDto>()
                .Include<Phone, PhoneDto>()
                .Include<Printer, PrinterDto>()
                .Include<Simcard, SimcardDto>()
                .Include<Software, SoftwareDto>()
                .ReverseMap();

            CreateMap<Computer, ComputerDto>().ReverseMap();
            CreateMap<CreateComputerDto, ComputerDto>().ReverseMap();

            CreateMap<Cable, CableDto>().ReverseMap();
            CreateMap<CreateCableDto, CableDto>().ReverseMap();

            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<CreateDeviceDto, DeviceDto>().ReverseMap();

            CreateMap<Rack, RackDto>().ReverseMap();
            CreateMap<CreateRackDto, RackDto>().ReverseMap();

            CreateMap<PDU, PDUDto>().ReverseMap();
            CreateMap<CreatePDUDto, PDUDto>().ReverseMap();

            CreateMap<Storage.Entities.Monitor, MonitorDto>().ReverseMap();
            CreateMap<CreateMonitorDto, MonitorDto>().ReverseMap();

            CreateMap<Phone, PhoneDto>().ReverseMap();
            CreateMap<CreatePhoneDto, PhoneDto>().ReverseMap();

            CreateMap<Printer, PrinterDto>().ReverseMap();
            CreateMap<CreatePrinterDto, PrinterDto>().ReverseMap();

            CreateMap<Simcard, SimcardDto>().ReverseMap();
            CreateMap<CreateSimcardDto, SimcardDto>().ReverseMap();

            CreateMap<Software, SoftwareDto>().ReverseMap();
            CreateMap<CreateSoftwareDto, SoftwareDto>().ReverseMap();
        }
    }
}
