using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Assets.CrossCutting.Dtos;
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
        private readonly AssetsDbContext _assetsDb;
        private readonly IMapper _mapper;
        public ElementService(TicketDbContext ticketDbContext, IMapper mapper, AssetsDbContext assetsDb)
        {
            _ticketDbContext=ticketDbContext;
            _assetsDb= assetsDb;
            _mapper =mapper;
        }

        public async Task<IEnumerable<AssetDto>> GetAssetsForTicket(Guid ticketId)
        {
            // Pobierz elementy powiązane ze zgłoszeniem
            var elements = await _ticketDbContext.Elements.Where(x => x.TicketId == ticketId).ToListAsync();

            // Zbierz identyfikatory zasobów
            var assetIds = elements.Select(x => x.AssertId).ToList();

            // Pobierz zasoby z bazy danych zasobów
            var assets = await _assetsDb.Assets.Where(x => assetIds.Contains(x.Guid)).ToListAsync();

            // Zamapuj zasoby na AssetDto
            var assetDtos = assets.Select(a => new AssetDto
            {
                Name = a.Name,
                Model = a.Model,
                SerialNumber = a.SerialNumber,
            }).ToList();

            return assetDtos;
        }
        public async System.Threading.Tasks.Task AddElements(Guid ticketId, string name)
        {
            var asset = await _assetsDb.Assets.FirstOrDefaultAsync(x => x.Name == name);
            var element = new Element
            {
                Id = Guid.NewGuid(),
                TicketId = ticketId,
                AssertId = asset.Guid,
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
