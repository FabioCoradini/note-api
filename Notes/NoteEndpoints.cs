using System;
using NotesApi.Notes.Contracts;
using NotesApi.Notes.Models;
using O9d.AspNet.FluentValidation;

namespace NotesApi.Notes
{
	internal static class NoteEndpoints
	{
		internal static void MapNoteEndpoints(this WebApplication app)
		{
			var group = app.MapGroup("api/v1/notes")
				.WithTags("Notes")
				.WithOpenApi()
				.WithValidationFilter();

            group.MapPost("/", CreateNoteAsync)
                .Accepts<Note>(Constants.ContentTypes.ApplicatinoJson)
                .Produces(201)
                .ProducesValidationProblem()
                .WithName("CreateNote");

            group.MapGet("/{id:int}", GetNoteByIdAsync)
                .Produces<Note>()
                .Produces(404)
                .WithName("GetNote")
                .WithOpenApi(operation =>
                {
                    operation.Description = "Return note by id";
                    return operation;
                });

            group.MapGet("/", GetAllNotesAsync)
                .Produces<Note>()
                .Produces(404)
                .WithName("GetAllNotes")
                .WithOpenApi(operation =>
                {
                    operation.Description = "Get all notes";
                    return operation;
                });

            group.MapPut("/{id:int}", UpdateNoteAsync)
                .Accepts<Note>(Constants.ContentTypes.ApplicatinoJson)
                .Produces(200)
                .ProducesValidationProblem()
                .Produces(404)
                .WithName("UpdateNote");

            group.MapDelete("/{id:int}", RemoveNoteAsync)
            .Produces(404)
            .Produces(204)
            .WithName("RemoveNote");
        }

		private static async Task<IResult> CreateNoteAsync(
            [Validate] Note model,
			INoteService service,
			LinkGenerator linkGenerator,
			HttpContext context)
		{
            
			var noteId = await service.AddNoteAsync(model);
			var path = linkGenerator.GetUriByName(context, "GetNote", new { id = noteId })!;
            model.Id = noteId;
			return Results.Created(path, model);
        }

		private static async Task<IResult> GetNoteByIdAsync(
            int id,
            INoteService service)
		{
            var note = await service.GetNoteAsync(id);

            if (note is null)
                return Results.NotFound();

            return Results.Ok(note);
        }

        private static async Task<IResult> GetAllNotesAsync(
            INoteService service)
        {
            //TODO
            return Results.Ok(await service.GetNotesAsync());
        }

        private static async Task<IResult> UpdateNoteAsync(
            int id,
            [Validate] Note model,
            INoteService service)
        {
            model.Id = id;

            var note = await service.UpdateNoteAssync(model);

            if (note is null)
                return Results.NotFound();

            return Results.Ok(note);
        }

        private static async Task<IResult> RemoveNoteAsync(
            int id, INoteService service)
        {
            var note = await service.GetNoteAsync(id);

            if (note is null)
                return Results.NotFound();

            await service.RemoveNoteAsync(id);

            return Results.Ok();
        }
    }
}

