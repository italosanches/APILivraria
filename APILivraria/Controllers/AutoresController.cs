using APILivraria.Models;
using APILivraria.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APILivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutoresController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> Get()
        {

            try
            {
                var listAutor = await _autorRepository.GetAutoresASync();
                if(listAutor == null) 
                { 
                    return NotFound("Não foram encontrados autores"); 
                }
                return Ok(listAutor);
            }
            catch (Exception ex)
            {

                return (StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}"));
            }

        }
        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<Autor>> GetById(int id)
        {
            var autor = await _autorRepository.GetAutorByIdAsync(id);
            if (autor is null)
            {
                return NotFound("autor não encontrado");
            }
            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Autor autor)
        {
            try
            {
                int createid = await _autorRepository.CreateAsync(autor);
                if (createid > 0)
                {
                    return new CreatedAtRouteResult("GetById", new { id = createid }, autor);
                }
                return BadRequest("Dados invalidos");
            }
            catch (DbUpdateException ex)
            {

                return (StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}"));
            }
            catch (Exception ex)
            {
                return (StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}"));
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Autor autor)
        {
            if (autor == null)
            {
                return BadRequest("Dados inválidos ou ID não corresponde ao autor fornecido.");
            }
            try
            {
                var update = await _autorRepository.UpdateAsync(autor);
                if (update)
                {
                    return Ok(autor);
                }
                return BadRequest("Não foi possivel atualizar, verifique os dados.");
            }
            catch (DbUpdateException ex)
            {
                return (StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}"));
            }
            catch (Exception ex)
            {
                return (StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}"));
            }

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0 )
            {
                return BadRequest("Dados inválidos.");
            }
            try
            {
                var update = await _autorRepository.DeleteAsync(id);
                if (update)
                {
                    return Ok("Cadastro deletado");
                }
                return BadRequest("Não foi possivel deletar o autor, verifique os id.");
            }
            catch (DbUpdateException ex)
            {
                return (StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}"));
            }
            catch (Exception ex)
            {
                return (StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno: {ex.Message}"));
            }

        }


    }
}
