using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Model.Utilisateurs;
using JeBalance.Domain.Model;
using API_Secrete.Business;
using API_Secrete.Controllers.Dto;

namespace API_Secrete.Controllers
{
    [ApiController]
    [Route("api")]
    public class VIPListController : ControllerBase
    {
        private readonly IVIPListRepository _repository;

        public VIPListController(IVIPListRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("vips")]
        public IActionResult Listervips()
        {
            return Ok(_repository.Lister().Select(Convertir));
        }

        [HttpGet]
        [Route("vips/get/{id}")]
        public IActionResult Cherchervip([FromRoute] int id)
        {
            var vip = _repository.Rechercher(id);

            if (vip == null)
            {
                return BadRequest("Aucun VIP ne correspond à cet identifiant");
            }

            return Ok(Convertir(vip));
        }

        [HttpDelete]
        [Route("vips/supprimer/{id}")]
        public IActionResult Supprimervip([FromRoute] int id)
        {
            if (_repository.Rechercher(id) == null)
            {
                return BadRequest("Aucun VIP ne correspond à cet identifiant");
            }
            _repository.Supprimer(id);
            return Ok(id);
        }

        [HttpPut]
        [Route("vips/ajouter/")]
        public IActionResult Ajoutervip([FromBody] PersonneDto vip)
        {
            if(vip != null)
            {
                var newvip = new VIP(vip.Id, vip.Nom!.Value, vip.Prenom!.Value);
                _repository.Ajouter(newvip);
                return Ok(vip.Id);
            }

            return BadRequest("La personne renseignée n'est pas conforme");
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
