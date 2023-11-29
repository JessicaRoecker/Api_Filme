using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema;
using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme;
using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala;
using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao;
using Api_Filme.Infrastructure.Data;
using Api_Filme.Infrastructure.Repository.RepositoryCinema;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;
using Api_Filme.Infrastructure.Repository.RepositoryFilme;
using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme;
using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme.InterfaceFuncaoFilme;
using Api_Filme.Infrastructure.Repository.RepositorySala;
using Api_Filme.Infrastructure.Repository.RepositorySessao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IFilmeBuscarRepository, FilmeBuscarRepository>();
builder.Services.AddScoped<IFilmeBuscarIdRepository, FilmeBuscarIdRepository>();
builder.Services.AddScoped<IFilmeAdicionarRepository, FilmeAdicionarRepository>();
builder.Services.AddScoped<IFilmeAtualizarRepository, FilmeAtualizarRepository>();
builder.Services.AddScoped<IFilmeDeleteRepository, FilmeDeleteRepository>();
builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddScoped<ICinemaAtualizaRepository, CinemaAtualizaRepository>();
builder.Services.AddScoped<ICinemaBuscarIdRepository, CinemaBuscarIdRepository>();
builder.Services.AddScoped<ICinemaBuscarRepository, CinemaBuscarRepository>();
builder.Services.AddScoped<ICinemaDeleteRepository, CinemaDeleteRepository>();
builder.Services.AddScoped<IAdicionarCinemaRepository, AdicionarCinemaRepository>();
builder.Services.AddScoped<ISalaAtualizaRepository, SalaAtualizaRepository>();
builder.Services.AddScoped<ISalaAdicionarRepository, SalaAdicionarRepository>();
builder.Services.AddScoped<ISalaBuscarIdRepository, SalaBuscarIdRepository>();
builder.Services.AddScoped<ISalaBuscarRepository, SalaBuscarRepository>();
builder.Services.AddScoped<ISalaDeleteRepository, SalaDeleteRepository>();
builder.Services.AddScoped<ISessaoAdicionarRepository, SessaoAdicionarRepository>();
builder.Services.AddScoped<ISessaoAtualizaRepository, SessaoAtualizaRepository>();
builder.Services.AddScoped<ISessaoBuscarIdRepository, SessaoBuscarIdRepository>();
builder.Services.AddScoped<ISessaoDeleteRepository, SessaoDeleteRepository>();
builder.Services.AddScoped<ISessaoBuscarRepository, SessaoBuscarRepository>();
builder.Services.AddScoped<IValidadorCampoFilmeNaoNulo, ValidadorCampoFilmeNaoNulo>();
builder.Services.AddScoped<IValidadorDeAno, ValidadorDeAno>();
builder.Services.AddScoped<IValidadorDuracaoFilme, ValidadorDuracaoFilme>(); 
builder.Services.AddScoped<IValidadorNome, ValidadorNome>();    
builder.Services.AddScoped<IValidadorTelefone, ValidadorTelefone>();
builder.Services.AddScoped<IValidadorEndereco, ValidadorEndereco>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
