using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JeBalance.Domain.Business
{
    public class Categorie
    {
        private readonly List<IPersonne> _personnes;

        public string Nom { get; }

        public IReadOnlyCollection<IPersonne> Personnes => _personnes;

        public Categorie(string nom)
        {
            Nom = nom;
            _personnes = new List<IPersonne>();
        }

        public void AjouterPersonne(IPersonne personne)
        {
            _personnes.Add(personne);
        }

        public IPersonne? RechercherPersonne(int id)
        {
            return _personnes.FirstOrDefault(p => p.Id == id);
        }

        public void SupprimerPersonne(int id)
        {
            var personne = RechercherPersonne(id);

            if (personne != null)
            {
                _personnes.Remove(personne);
            }
        }
    }
}
