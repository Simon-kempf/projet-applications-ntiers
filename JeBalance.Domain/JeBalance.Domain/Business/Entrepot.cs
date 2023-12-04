using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JeBalance.Domain.Business
{
    public class Entrepot
    {
        private readonly List<Personne> _personnes;

        public int Id { get; }

        public IReadOnlyCollection<Personne> Personnes => _personnes;

        public Entrepot(int id)
        {
            Id = id;
            _personnes = new List<Personne>();
        }

        public void AjouterPersonne(Personne personne)
        {
            _personnes.Add(personne);
        }

        public Personne? RechercherPersonne(int id)
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
