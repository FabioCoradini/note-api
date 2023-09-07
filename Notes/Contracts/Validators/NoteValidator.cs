using System;
using FluentValidation;
using NotesApi.Notes.Models;

namespace NotesApi.Notes.Contracts.Validators
{
	public class NoteValidator : AbstractValidator<Note>
	{
		public NoteValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty();
		}
	}
}

