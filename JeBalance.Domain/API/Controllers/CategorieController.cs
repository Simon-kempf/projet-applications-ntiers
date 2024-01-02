using Microsoft.AspNetCore.Mvc;
using JeBalance.Domain.Model.Utilisateurs;
using JeBalance.Domain.Model;
using API.Business;
using API.Controllers.Dto;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieRepository _repository;

        public CategorieController(ICategorieRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("categories")]
        public IActionResult Listercategories()
        {
            return Ok(_repository.Lister().Select(Convertir));
        }

        [HttpGet]
        [Route("categories/{nom}")]
        public IActionResult ConsulterCategorie([FromRoute] string nom)
        {
            var categorie = _repository.Rechercher(nom);

            if (categorie == null)
            {
                return BadRequest();
            }

            return Ok(Convertir(categorie));
        }

        [HttpPut]
        [Route("categories/{categorieNom}/personne/")]
        public IActionResult CreerProduit([FromRoute] string categorieNom, [FromBody] PersonneDto personne)
        {
            var categorie = _repository.Rechercher(categorieNom);

            if (categorie == null)
            {
                return BadRequest();
            }

            var _personne = new VIP(personne.Id, personne.Nom!.Value, personne.Prenom!.Value);

            categorie.AjouterPersonne(_personne);

            return Ok();
        }

        [HttpPost]
        [Route("categories/{categorieId}/produits/{produitId}/{nom}/{quantite}")]
        public IActionResult ModifierProduit([FromRoute] string categorieNom, [FromRoute] int personneId, [FromRoute] string nom, [FromRoute] int quantite)
        {
            var categorie = _repository.Rechercher(categorieNom);

            if (categorie == null)
            {
                return BadRequest();
            }

            var personne = categorie.RechercherPersonne(personneId);

            if (personne == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("categories/{categorieId}/produits/{produitId}")]
        public IActionResult SupprimerProduit([FromRoute] string categorieNom, [FromRoute] int produitId)
        {
            var categorie = _repository.Rechercher(categorieNom);

            if (categorie == null)
            {
                return BadRequest();
            }

            categorie.SupprimerPersonne(produitId);

            return Ok();
        }

        private static CategorieDto? Convertir(Categorie? categorie)
        {
            if (categorie == null)
            {
                return null;
            }

            return new CategorieDto
            {
                Nom = categorie.Nom,
                Personnes = categorie.Personnes.Select(Convertir).ToList()
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
