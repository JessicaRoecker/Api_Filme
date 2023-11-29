using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySala;
using Api_Filme.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api_Filme.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : Controller
    {
        private readonly ISalaAdicionarRepository _adicionarRepository;
        private readonly ISalaAtualizaRepository _atualizaRepository;
        private readonly ISalaBuscarIdRepository _buscarIdRepository;
        private readonly ISalaBuscarRepository _buscarRepository;
        private readonly ISalaDeleteRepository _deleteRepository;

        public SalaController(ISalaDeleteRepository salaDelete, ISalaBuscarRepository salaBuscar,ISalaBuscarIdRepository salaBuscarId,
            ISalaAtualizaRepository salaAtualiza, ISalaAdicionarRepository salaAdicionar)
        {
            _adicionarRepository = salaAdicionar;
            _atualizaRepository = salaAtualiza;
            _buscarRepository = salaBuscar;
            _deleteRepository = salaDelete;
            _buscarIdRepository = salaBuscarId;
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> BuscarTodas()
        {
            try
            {
                var sala = await _buscarRepository.BuscarSala();
                if (sala.Any())
                {
                    return Ok(sala);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet("Buscar por Id")]
        public async Task<IActionResult> BuscarSalaPorId(int id)
        {
            try
            {
                var sala = await _buscarIdRepository.BuscarSalaId(id);
                if(sala != null)
                {
                    return Ok(sala);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> AdicionarSala([FromBody] SalaModel salaModel)
        {
            try
            {
                var sucess = await _adicionarRepository.AdicionarSala(salaModel);
                if (sucess)
                {
                    return CreatedAtAction(nameof(BuscarTodas), new { id = salaModel.Id}, salaModel);
                }
                return BadRequest("Erro ao Adicionar Sala");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }
        
        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarSala(int id, [FromBody] SalaModel salaModel)
        {
            try
            {
                var sucess = await _atualizaRepository.AtualizaSala(salaModel, id);
                    if (sucess)
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Deletar")]
        public async Task<IActionResult> DeletarSala(int id)
        {
            try
            {
                var sucess = await _deleteRepository.DeleteSala(id);
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
