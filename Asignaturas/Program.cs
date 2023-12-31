using Asignatura.Services;
using Asignatura.Services.Interfaces;
using Asignaturas;
using Asignaturas.Services;
using Asignaturas.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AsignaturesContext>(builder.Configuration.GetConnectionString("asignature"));
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IAsignature, Asignature>();
builder.Services.AddScoped<IInscripcion, Inscripcion>();
builder.Services.AddScoped<IHello, Hello>();
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

app.MapControllers();

app.Run();
