using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Model.Utilisateurs;
using JeBalance.Domain.Model;
using API.Business;
using API.Controllers.Dto;
using System;

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
        [Route("denonciations")]
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

            var _denonciation = new Denonciation(DateTime.Now, _repository.Lister().Count(), informateur, suspect, denonciation.Delit!.Value, denonciation.PaysEvasion!.Value);

            _repository.Ajouter(_denonciation);

            return Ok(_denonciation.Id);
        }

        [HttpGet]
        [Route("denonciations/nontraitees")]
        public IActionResult Listerdenonciationsnontraitees()
        {
            return Ok(_repository.ListerNonTraitees().Select(Convertir));
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

        [HttpPut]
        [Route("denonciations/{id}")]
        public IActionResult RepondreDenonciation([FromRoute] int id, [FromBody] ReponseDto reponse)
        {
            var denonciation = _repository.Rechercher(id);

            if (denonciation == null)
            {
                return BadRequest();
            }

            if(denonciation.Reponse != null)
            {
                return BadRequest();
            }

            denonciation.Reponse = new Reponse(DateTime.Now, (JeBalance.Domain.Model.Type) reponse.Type, reponse.Retribution);

            return Ok(denonciation.Id);
        }

        private static DenonciationConsultationDto? Convertir(Denonciation? denonciation)
        {
            if (denonciation == null)
            {
                return null;
            }

            return new DenonciationConsultationDto
            {
                Id = denonciation.Id,
                Horodatage = denonciation.Horodatage,
                Informateur = Convertir(denonciation.Informateur),
                Suspect = Convertir(denonciation.Suspect),
                Delit = denonciation.Delit,
                PaysEvasion = denonciation.PaysEvasion,
                Reponse = Convertir(denonciation.Reponse)
            };
        }
        private static PersonneDto? Convertir(Personne? personne)
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
        private static ReponseDto? Convertir(Reponse? reponse)
        {
            if (reponse == null)
            {
                return null;
            }

            return new ReponseConsultationDto
            {
                Horodatage = reponse.Horodatage,
                Type = (int) reponse.Type,
                Retribution = reponse.Retribution
            };
        }
    }
}
