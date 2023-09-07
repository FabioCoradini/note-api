using System;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data.DataModel;

namespace NotesApi.Data
{
	public static class ApplicationDBContextSeed
	{
		public static void SeedNotes(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<NoteDataModel>()
				.HasData(new List<NoteDataModel>
				{
					new()
					{
						Id = 1,
						Title = "My first note",
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
						DateCreation = DateTime.Now.ToUniversalTime()
					},
                    new()
                    {
                        Id = 2,
                        Title = "My first note",
                        Body = "LoremLorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque dignissim vehicula iaculis. Sed mattis dui eros, in accumsan tellus efficitur lacinia. Nulla mollis consequat orci quis consectetur.",
                        DateCreation = DateTime.Now.ToUniversalTime()
                    },
                    new()
                    {
                        Id = 3,
                        Title = "My first note",
                        Body = "Sed vitae magna consequat, sollicitudin enim et, vehicula dui. Integer porta lectus nec facilisis eleifend. Cras fermentum tellus vel neque fermentum, quis pellentesque felis pretium. Donec erat turpis, euismod eu massa non, ornare eleifend justo. Cras et mauris eros. Duis dapibus sem ut ornare hendrerit. Duis ornare tempus massa sed aliquet.",
                        DateCreation = DateTime.Now.ToUniversalTime()
                    }
                });
		}
	}
}

