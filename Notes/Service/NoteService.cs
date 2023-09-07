using System;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.Data.DataModel;
using NotesApi.Notes.Contracts;
using NotesApi.Notes.Models;

namespace NotesApi.Notes.Service
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDBContext _applicationDBContext;

        public NoteService(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<int> AddNoteAsync(Note model)
        {
            var note = new NoteDataModel()
            {
                Title = model.Title,
                Body = model.Body,
                DateCreation = DateTime.Now.ToUniversalTime()
            };
            await _applicationDBContext.Notes.AddAsync(note);
            await _applicationDBContext.SaveChangesAsync();

            return note.Id;
        }

        public async Task<Note?> GetNoteAsync(int id)
        {
            var noteModel = await _applicationDBContext.Notes.FindAsync(id);

            if (noteModel is null)
                return null;

            return new Note
            {
                Id = noteModel.Id,
                Title = noteModel.Title,
                Body = noteModel.Body,
                DateCreation = noteModel.DateCreation
            };
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            // Add pagination in the future and mapper

            var notesModelList = await _applicationDBContext.Notes.ToListAsync();
            return notesModelList.Select(n => new Note
            {
                Id = n.Id,
                Title = n.Title,
                Body = n.Body,
                DateCreation = n.DateCreation
            }).ToList();
        }

        public async Task<Note?> UpdateNoteAssync(Note model)
        {
            var note = await _applicationDBContext.Notes.FirstOrDefaultAsync(n => n.Id == model.Id);

            if (note is null)
                return null;

            note.Id = model.Id;
            note.Title = model.Title;
            note.Body = model.Body;

            _applicationDBContext.Notes.Update(note);
            await _applicationDBContext.SaveChangesAsync();

            return model;
        }

        public async Task RemoveNoteAsync(int id)
        {
            _applicationDBContext.Notes.Remove((await _applicationDBContext.Notes.FindAsync(id))!);
            await _applicationDBContext.SaveChangesAsync();
        }
    }
}

