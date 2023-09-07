using System;
using Microsoft.EntityFrameworkCore;
using NotesApi.Data.DataModel;

namespace NotesApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<NoteDataModel> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            modelBuilder.SeedNotes();
        }
    }
}

