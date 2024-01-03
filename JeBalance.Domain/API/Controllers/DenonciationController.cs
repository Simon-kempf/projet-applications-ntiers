using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Model.Utilisateurs;
using JeBalance.Domain.Model;
using API.Business;
using API.Controllers.Dto;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class DenonciationController : ControllerBase
    {
        private readonly IDenonciationRepository _repository;

        public DenonciationController(IDenonciationRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("denonciations")]
        public IActionResult Listerdenonciations()
        {
            return Ok(_repository.Lister().Select(Convertir));
        }

        [HttpPut]
        [Route("denonciations/create")]
        public IActionResult AjouterDenonciation([FromBody] DenonciationDto denonciation)
        {
            var _denonciation = new Denonciation(denonciation.Informateur!, denonciation.Suspect!, denonciation.Delit!.Value, denonciation.PaysEvasion!.Value);

            _repository.Lister().Append(_denonciation);

            if (denonciation == null)
            {
                return BadRequest();
            }

            return Ok(denonciation);
        }

        [HttpGet]
        [Route("denonciations/{id}")]
        public IActionResult ConsulterDenonciation([FromRoute] int id)
        {
            var denonciation = _repository.Rechercher(id);

            if (denonciation == null)
            {
                return BadRequest();
            }

            return Ok(Convertir(denonciation));
        }

        private static DenonciationDto? Convertir(Denonciation? denonciation)
        {
            if (denonciation == null)
            {
                return null;
            }

            return new DenonciationDto
            {
                Informateur = denonciation.Informateur,
                Suspect = denonciation.Suspect
            };
        }
    }
}
