using Api_Filme.Domain.InterfaceRepository.InterfaceRepositorySessao;
using Api_Filme.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api_Filme.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : Controller
    {
        private readonly ISessaoAdicionarRepository _sessaoAdicionarRepository;
        private readonly ISessaoAtualizaRepository _sessaoAtualizaRepository;
        private readonly ISessaoBuscarIdRepository _sessaoBuscarIdRepository;
        private readonly ISessaoBuscarRepository _sessaoBuscarRepository;
        private readonly ISessaoDeleteRepository _sessaoDeleteRepository;

        public SessaoController(ISessaoAdicionarRepository sessaoAdicionarRepository, ISessaoAtualizaRepository sessaoAtualizaRepository, ISessaoBuscarIdRepository sessaoBuscarIdRepository, ISessaoBuscarRepository sessaoBuscarRepository, ISessaoDeleteRepository sessaoDeleteRepository)
        {
            _sessaoAdicionarRepository = sessaoAdicionarRepository;
            _sessaoAtualizaRepository = sessaoAtualizaRepository;
            _sessaoBuscarIdRepository = sessaoBuscarIdRepository;
            _sessaoBuscarRepository = sessaoBuscarRepository;
            _sessaoDeleteRepository = sessaoDeleteRepository;
        }

        [HttpGet("Buscar")]
        public async Task<IActionResult> BuscarTodasSessoes()
        {
            try
            {
                var sessao = await _sessaoBuscarRepository.BuscarTodasAsSessoes();
                if (sessao.Any())
                {
                    return Ok(sessao);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }  
        }

        [HttpGet("Buscar por ID")]
        public async Task<IActionResult> BuscarSessaoPorId(int id)
        {
            try
            {
                var sessao = await _sessaoBuscarIdRepository.BuscarSessoesId(id);
                if (sessao != null)
                {
                    return Ok(sessao);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Inserir")]
        public async Task<IActionResult> AdionarSala([FromBody] SessoesModel sessoesModel)
        {
            try
            {
                var sucess = await _sessaoAdicionarRepository.AdicionarSessao(sessoesModel);
                if (sucess)
                {
                    return CreatedAtAction(nameof(BuscarTodasSessoes), new { id = sessoesModel.Id }, sessoesModel);
                }
                return BadRequest("Erro ao adicionar a sessao");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpPut("Atualizar")]
        public async Task<IActionResult> AtualizarSessao(int id, [FromBody] SessoesModel sessoesModel)
        {
            try
            {
                var sucess = await _sessaoAtualizaRepository.AtualizarSessao(sessoesModel, id);
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
        public async Task<IActionResult> DeletarSessao(int id)
        {
            try
            {
                var sucess = await _sessaoDeleteRepository.DeleteSessao(id);
                if (sucess)
                {
                    return NoContent();
                }
                return NotFound();
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }  
        }
    }
}
