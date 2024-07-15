using AutoMapper;
using ServiceDesk.Ticket.CrossCutting.Dots;

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



            
        }
    }
}
