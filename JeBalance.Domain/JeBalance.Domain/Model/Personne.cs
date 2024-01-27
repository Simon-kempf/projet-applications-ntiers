using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JeBalance.Domain.Model
{
    public class Personne : Entity
    {
		public Nom? Nom { get; set; }

		public Prenom? Prenom { get; set; }
		public Statut Statut { get; set; }
		public Personne(string nom, string prenom) : base(0)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.NONE;
        }
        public Personne(int id, string nom, string prenom) :
       base(id)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.NONE;
        }

		public Personne(int id, string nom, string prenom, Statut statut) :
	   base(id)
		{
			Nom = new Nom(nom);
			Prenom = new Prenom(prenom);
			Statut = statut;
		}

		public Personne(int id) : base(id)
		{
		}

		public Personne() : base(0) { }
    }
}
