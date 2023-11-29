using Api_Filme.Domain.InterfaceRepository.InterfaceRepositoryCinema;
using Api_Filme.Domain.Model;
using Api_Filme.Infrastructure.Repository.RepositoryCinema.FuncoesCinema.InterfaceFuncoesCinema;
using Microsoft.AspNetCore.Mvc;

namespace Api_Filme.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : Controller
    {
        private readonly ICinemaAtualizaRepository _cinemaAtualizaRepository;
        private readonly ICinemaBuscarIdRepository _cinemaBuscarIdRepository;
        private readonly ICinemaBuscarRepository _cinemaBuscarRepository;
        private readonly ICinemaDeleteRepository _cinemaDeleteRepository;
        private readonly IAdicionarCinemaRepository _adicionarCinemaRepository;
        private readonly IValidadorNome _validadorNome;
        private readonly IValidadorEndereco _validadorEndereco;
        private readonly IValidadorTelefone _validadorTelefone;
        p
        
        public CinemaController(IAdicionarCinemaRepository adicionarCinema, ICinemaDeleteRepository cinemaDelete, ICinemaBuscarRepository cinemaBuscar,
            ICinemaBuscarIdRepository cinemaBuscarId, ICinemaAtualizaRepository cinemaAtualiza, IValidadorNome validadorNome, IValidadorEndereco validadorEndereco, IValidadorTelefone validadorTelefone)
        {
            _adicionarCinemaRepository = adicionarCinema;
            _cinemaAtualizaRepository = cinemaAtualiza;
            _cinemaBuscarIdRepository = cinemaBuscarId;
            _cinemaBuscarRepository = cinemaBuscar;
            _cinemaDeleteRepository = cinemaDelete;
            _validadorNome = validadorNome;
            _validadorEndereco = validadorEndereco;
            _validadorTelefone = validadorTelefone;
        }

        [HttpGet("Buscar")]
        public async Task<ActionResult> Buscar_Todos()
        {
            try
            {
                var cinema = await _cinemaBuscarRepository.BuscarCinema();
                if (cinema.Any())
                {
                    return Ok(cinema);
                }
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Buscar por ID")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {
                var cinema = await _cinemaBuscarIdRepository.BuscarCinemaId(id);
                if (cinema != null)
                {
                    return Ok(cinema);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
           
        }

        [HttpPost("Inserir")]
        public async Task<ActionResult> InserirCinema([FromBody] CinemaModel cinemaModel)
        {
            try
            {
               if(!_validadorNome.ValidadorNomeCinema(cinemaModel.Nome))
                    return BadRequest("O nome deve ter no minimo 4 letras");
                if (!_validadorEndereco.ValidadarEndereco(cinemaModel.Endereco))
                    return BadRequest("O endereço deve ter no minimo 10 caracteres");
                if (!_validadorTelefone.ValidadorFone(cinemaModel.Telefone))
                    return BadRequest("Precisa ser um telefone valido");
       
                var success = await _adicionarCinemaRepository.AdicionarCinema(cinemaModel);
                if (success)
                {
                    return CreatedAtAction(nameof(Buscar_Todos), new { id = cinemaModel.Id }, cinemaModel);

                }
                return BadRequest("Erro ao Adicionar Cinema!");
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult> AtualizarCinema(int id, [FromBody] CinemaModel cinemaModel)
        {
            try
            {
                if (!_validadorNome.ValidadorNomeCinema(cinemaModel.Nome))
                    return BadRequest("O nome deve ter no minimo 4 letras");
                if (!_validadorEndereco.ValidadarEndereco(cinemaModel.Endereco))
                    return BadRequest("O endereço deve ter no minimo 10 caracteres");
                if (!_validadorTelefone.ValidadorFone(cinemaModel.Telefone))
                    return BadRequest("Precisa ser um telefone valido");

                var sucess = await _cinemaAtualizaRepository.AtualizarCinema(cinemaModel, id);
                if (sucess)
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
        public async Task<ActionResult> DeletarCinema(int id)
        {
            try
            {
                var sucess = await _cinemaDeleteRepository.DeleteCinema(id);
                if (sucess)
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
