using System.Net;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NotesApi.Data;
using NotesApi.Infrastructure;
using NotesApi.Notes;
using NotesApi.Notes.Contracts;
using NotesApi.Notes.Contracts.Validators;
using NotesApi.Notes.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => {
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Note API", Version = "v1"});
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddValidatorsFromAssemblyContaining<NoteValidator>();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());

//app.Map("/{*url}", () => Results.Problem(new ProblemDetails
//{
//    Title = "Not Found",
//    Status = (int)HttpStatusCode.NotFound
//}));

app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(config =>
    //{
    //    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes v1");
    //    config.RoutePrefix = string.Empty;   //https://localhost:<port>/
    //});
}

app.MapNoteEndpoints();

app.Run();
