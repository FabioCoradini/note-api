using System;
using NotesApi.Notes.Models;

namespace NotesApi.Notes.Contracts
{
	public interface INoteService
	{
		Task<int> AddNoteAsync(Note model);
		Task<Note?> GetNoteAsync(int id);
        Task<List<Note>> GetNotesAsync();
        Task<Note?> UpdateNoteAssync(Note model);
		Task RemoveNoteAsync(int id);
	}
}

