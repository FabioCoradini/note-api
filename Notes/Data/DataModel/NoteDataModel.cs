using System;
using System.ComponentModel.DataAnnotations;

namespace NotesApi.Data.DataModel
{
	public class NoteDataModel
	{
        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Body { get; set; }

        public DateTime DateCreation { get; set; }
    }
}

