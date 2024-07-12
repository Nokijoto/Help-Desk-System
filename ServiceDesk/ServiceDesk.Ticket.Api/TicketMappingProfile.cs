using AutoMapper;

namespace ServiceDesk.Ticket.Api
{
    public class TicketMappingProfile:Profile
    {
        public TicketMappingProfile()
        {
            CreateMap<Storage.Entities.Ticket, CrossCutting.Dots.TicketDto>();
            CreateMap<CrossCutting.Dots.TicketDto, Storage.Entities.Ticket>();
        }
    }
}
