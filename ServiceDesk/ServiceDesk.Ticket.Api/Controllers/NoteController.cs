﻿using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Ticket.Api.Interfaces;
using ServiceDesk.Ticket.CrossCutting.Dots;

namespace ServiceDesk.Ticket.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        [HttpGet]
        public async Task<IEnumerable<NoteDto>> GetNotes()
        {
            return await _noteService.GetNotes();
        }
        [HttpGet("{id}")]
        public async Task<NoteDto> GetNote(Guid id)
        {
            return await _noteService.GetNote(id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNote(NoteDto noteDto)
        {
            await _noteService.CreateNote(noteDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task DeleteNote(Guid id)
        {
            await _noteService.DeleteNote(id);
        }
        [HttpPut("{id}")]
        public async Task UpdateNote(Guid id, NoteDto noteDto)
        {
            await _noteService.UpdateNote(id, noteDto);
        }

    }
}
