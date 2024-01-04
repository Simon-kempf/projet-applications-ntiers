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
            if (denonciation == null)
            {
                return BadRequest();
            }

            var informateurDto = denonciation.Informateur;
            var informateur = new Personne(informateurDto!.Id, informateurDto.Nom!.Value, informateurDto.Prenom!.Value);

            var suspectDto = denonciation.Suspect;
            var suspect = new Personne(suspectDto!.Id, suspectDto.Nom!.Value, suspectDto.Prenom!.Value);

            var _denonciation = new Denonciation(_repository.Lister().Count(), informateur, suspect, denonciation.Delit!.Value, denonciation.PaysEvasion!.Value);

            _repository.Ajouter(_denonciation);

            return Ok(Convertir(_denonciation));
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
                Id = denonciation.Id,
                Informateur = Convertir(denonciation.Informateur),
                Suspect = Convertir(denonciation.Suspect),
                Delit = denonciation.Delit,
                PaysEvasion = denonciation.PaysEvasion
            };
        }
        private static PersonneDto? Convertir(IPersonne? personne)
        {
            if (personne == null)
            {
                return null;
            }

            return new PersonneDto
            {
                Id = personne.Id,
                Nom = personne.Nom,
                Prenom = personne.Prenom
            };
        }
    }
}
