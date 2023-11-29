using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryFilme;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Repository.RepositoryFilme.FuncoesFilme.InterfaceFuncaoFilme;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit.Sdk;
using ZstdSharp;
using ZstdSharp.Unsafe;

namespace Api_Filme.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeBuscarRepository _repository;
        private readonly IFilmeBuscarIdRepository _idRepository;
        private readonly IFilmeAdicionarRepository _adicionarRepository;
        private readonly IFilmeAtualizarRepository _atualizarRepository;
        private readonly IFilmeDeleteRepository _deleterepository;
        private readonly IValidadorDeAno _validadorDeAno;
        private readonly IValidadorCampoFilmeNaoNulo _validadorCampoNaoNulo;
        private readonly IValidadorDuracaoFilme _validadorDuracaoFilme;


        public FilmeController(IFilmeBuscarRepository repository, IFilmeBuscarIdRepository idRepository, IFilmeAdicionarRepository adicionarRepository, IFilmeAtualizarRepository atualizarRepository,
            IFilmeDeleteRepository deleterepository, IValidadorDeAno validadorDeAno, IValidadorCampoFilmeNaoNulo validadorCampoNaoNulo, IValidadorDuracaoFilme validadorDuracaoFilme)
        {
            _repository = repository;
            _idRepository = idRepository;
            _adicionarRepository = adicionarRepository;
            _atualizarRepository = atualizarRepository;
            _deleterepository = deleterepository;
            _validadorDeAno = validadorDeAno;
            _validadorCampoNaoNulo = validadorCampoNaoNulo;
            _validadorDuracaoFilme = validadorDuracaoFilme;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult> Buscar_Todas()
        {
            try
            {
                var filmes = await _repository.BuscarTodosFilmesAsync();
                if (filmes.Any())
                {
                    return Ok(filmes);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Buscar por Id")]
        public async Task<ActionResult> Buscar_Id(int id)
        {
            try
            {
                var filme = await _idRepository.BuscarFilmesIdAsync(id);
                if (filme != null)
                {
                    return Ok(filme);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("Inserir")]
        public async Task<ActionResult> Inserir_Novos([FromBody] FilmeModel filme)
        {
            try
            {
                // Verificar se o ano está no intervalo permitido
                if (!_validadorDeAno.ValidadorAno(filme.Ano_Lancamento))
                    return BadRequest("O ano de lançamento deve estar entre 28/12/1895 e o ano atual.");

                // Verificar se o nome do filme, diretor e genero não são nulos
                if (!_validadorCampoNaoNulo.ValidarCamposFilmeNaoNull(filme.Genero, filme.Diretor, filme.Titulo))
                    return BadRequest("O nome do filme, diretor e gênero não podem ser nulos ou vazios.");


                // Verificar se a duração está no intervalo permitido
                if (!_validadorDuracaoFilme.ValidadorDuracaoFilmes(filme.Duracao))
                    return BadRequest("A duração do filme deve estar entre 40 minutos e 5 horas.");

                var success = await _adicionarRepository.AdicionarAsync(filme);
                if (success)
                {
                    return CreatedAtAction(nameof(Buscar_Todas), new { id = filme.Id }, filme);
                }

                return BadRequest("Erro ao adicionar o filme.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("Atualizar")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] FilmeModel filme)
        {
            try
            {
                if (!_validadorDuracaoFilme.ValidadorDuracaoFilmes(filme.Duracao))
                    return BadRequest("A duração do filme deve estar entre 40 minutos e 5 horas.");

                if (!_validadorCampoNaoNulo.ValidarCamposFilmeNaoNull(filme.Genero, filme.Diretor, filme.Titulo))
                    return BadRequest("O nome do filme, diretor e gênero não podem ser nulos ou vazios.");

                if (!_validadorDeAno.ValidadorAno(filme.Ano_Lancamento))
                    return BadRequest("O ano de lançamento deve estar entre 28/12/1895 e o ano atual.");
               
                var success = await _atualizarRepository.AtualizarAsync(filme, id);
                if (success)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                var success = await _deleterepository.DeletarAsync(id);
                if (success)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
