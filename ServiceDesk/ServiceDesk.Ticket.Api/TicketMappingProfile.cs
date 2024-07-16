using AutoMapper;
using ServiceDesk.Ticket.Api.DefaultResolver;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;

namespace ServiceDesk.Ticket.Api
{
    public class TicketMappingProfile:Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<Storage.Entities.Ticket,TicketDto>();
            CreateMap<TicketDto, Storage.Entities.Ticket>();

            CreateMap<TaskDto, Storage.Entities.Task>().ReverseMap();
            

            CreateMap<Storage.Entities.Note, NoteDto>();
            CreateMap<NoteDto, Storage.Entities.Note>();

            CreateMap<Storage.Entities.Ticket, DetailsTicketDto>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));

            CreateMap<Storage.Entities.Ticket, TicketDto>()
            .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name))
            .ForMember(dest => dest.PriorityName, opt => opt.MapFrom(src => src.Priority.Name));

            CreateMap<CreateTicketDto, Storage.Entities.Ticket>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom<DefaultStatusResolver>())
                .ForMember(dest => dest.PriorityId, opt => opt.MapFrom<DefaultPriorityResolver>()); 
            CreateMap<UpdateTicketDto, Storage.Entities.Ticket>();

            CreateMap<CreateTaskDto, Storage.Entities.Task>();

            CreateMap<CreateNoteDto, Storage.Entities.Note>();



        }
    }
}
