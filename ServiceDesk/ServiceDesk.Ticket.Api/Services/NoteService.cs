using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;
using ServiceDesk.Ticket.Storage;

namespace ServiceDesk.Ticket.Api.Services
{
    public class NoteService:INoteService
    {
        private readonly TicketDbContext _dbContext;
        private readonly IMapper _mapper;

        public NoteService(TicketDbContext dbContext, IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper=mapper;
        }

        public async Task<IEnumerable<NoteDto>> GetNotes()
        {
            var notes = await _dbContext.Notes.ToListAsync();
            return _mapper.Map<IEnumerable<NoteDto>>(notes);
        }
        public async Task<NoteDto> GetNote(Guid id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<NoteDto>(note);
        }
        public async Task CreateNote(NoteDto noteDto)
        {
            var note = _mapper.Map<Storage.Entities.Note>(noteDto);
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteNote(Guid id)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(t => t.Id == id);
            if (note != null)
            {
                _dbContext.Notes.Remove(note);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateNote(Guid id, NoteDto noteDto)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(t => t.Id == id);
            if (note is null)
            {
                throw new Exception("Note not found");
            }
            _mapper.Map(noteDto, note);
            await _dbContext.SaveChangesAsync();
        }
    }
}
