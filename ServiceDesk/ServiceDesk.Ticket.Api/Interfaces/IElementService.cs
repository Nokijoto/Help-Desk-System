using ServiceDesk.Assets.CrossCutting.Dtos;
using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Interfaces
{
    public interface IElementService
    {
        System.Threading.Tasks.Task AddElements(Guid ticketId, string name);
        System.Threading.Tasks.Task DeleteElement(Guid id);
        Task<IEnumerable<AssetDto>> GetAssetsForTicket(Guid ticketId);


    }
}
