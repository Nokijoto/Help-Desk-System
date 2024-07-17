using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Assets.Storage;
using ServiceDesk.Assets.Storage.Entities;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;
using ServiceDesk.Ticket.Storage.Entities;
using System.Data.Common;

namespace ServiceDesk.Ticket.Api.Services
{
    public class ElementService: IElementService
    {
        private readonly TicketDbContext _ticketDbContext;
        
        private readonly IMapper _mapper;
        public ElementService(TicketDbContext ticketDbContext, IMapper mapper)
        {
            _ticketDbContext=ticketDbContext;
            
            _mapper=mapper;
        }

        public async Task<IEnumerable<ElementDto>> GetElement(Guid id)
        {
            var elements = await _ticketDbContext.Elements.Where(x => x.TicketId == id).ToListAsync();
            return _mapper.Map<IEnumerable<ElementDto>>(elements);
        }
        public async System.Threading.Tasks.Task AddElements(Guid ticketId, Guid assetId)
        {
            var element = new Element
            {
                Id = Guid.NewGuid(),
                TicketId = ticketId,
                AssertId = assetId
            };
            await _ticketDbContext.Elements.AddAsync(element);
            await _ticketDbContext.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteElement(Guid elementId)
        {
            var element = await _ticketDbContext.Elements.FindAsync(elementId);
            if (element == null)
            {
                throw new Exception("Element not found");
            }

            _ticketDbContext.Elements.Remove(element);
            await _ticketDbContext.SaveChangesAsync();
        }

    }
}
