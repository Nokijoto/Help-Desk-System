using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDto>> GetNotes();
        Task<NoteDto> GetNote(Guid id);
        Task CreateNote(NoteDto noteDto);
        Task DeleteNote(Guid id);
        Task UpdateNote(Guid id, NoteDto noteDto);

    }
}
