using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Interfaces
{
    public interface IElementService
    {
        System.Threading.Tasks.Task AddElements(Guid ticketId, Guid assetId);
        System.Threading.Tasks.Task DeleteElement(Guid id);
        Task<IEnumerable<ElementDto>> GetElement(Guid id);
        
    }
}
