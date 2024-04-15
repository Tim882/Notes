using System.Text.Json.Serialization;
using DataBase;
using DataBase.Interfaces;
using DataBase.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Notes.Dto;
using Notes.Validators;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NotesContext>(options => options.UseNpgsql(connection,
    b => b.MigrationsAssembly("DataBase")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddControllers();
//builder.Services.AddControllers().AddJsonOptions(o => {
//    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    //o.JsonSerializerOptions.MaxDepth = 0;
//});
builder.Services.AddScoped<IValidator<NoteDto>, NoteValidator>();
builder.Services.AddScoped<IValidator<TagDto>, TagValidator>();
builder.Services.AddScoped<IValidator<ReminderDto>, ReminderValidator>();
builder.Services.AddScoped<IRepository<Note>, Repository<Note>>();
builder.Services.AddScoped<IRepository<NoteTag>, Repository<NoteTag>>();
builder.Services.AddScoped<IRepository<Reminder>, Repository<Reminder>>();
builder.Services.AddScoped<IRepository<ReminderTag>, Repository<ReminderTag>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

