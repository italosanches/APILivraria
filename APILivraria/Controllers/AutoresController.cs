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

		[HttpGet("GetAll")]
		public ActionResult<IEnumerable<Autor>> Get()
		{
			return Ok(_autorRepository.Autores.ToList());

		}
		[HttpGet("GetById/{id:int}", Name = "GetById")]
		public async Task<ActionResult<Autor>> Get(int id)
		{
			var autor = await _autorRepository.GetAutorById(id);
			if (autor is null)
			{
				return NotFound("autor não encontrado");
			}
			return Ok(autor);
		}

		[HttpPost("Create")]
		public ActionResult Create([FromBody] Autor autor)
		{
			try
			{
				int createid = _autorRepository.Create(autor);
				if (createid > 0)
				{
					return new CreatedAtRouteResult("GetById", new { id = createid }, autor);
				}
				return BadRequest("Dados invalidos");
			}
			catch (DbUpdateException ex)
			{

				return StatusCode(500, ex.Message);
			}
			catch (Exception ex)
			{

				return StatusCode(500, ex.Message);
			}
		}

		[HttpPut("Update/{id:int}")]
		public ActionResult Update(int id, [FromBody] Autor autor)
		{
			try
			{
				var update = _autorRepository.Update(autor, id);
				if (update)
				{
					return Ok(autor);
				}
				return BadRequest("Erro ao fazer a atualização, verifique.");
			}
			catch (DbUpdateException ex)
			{

				return StatusCode(500, ex.Message);
			}
			catch (Exception ex)
			{

				return StatusCode(500, ex.Message);
			}

			
		}

	}
}
