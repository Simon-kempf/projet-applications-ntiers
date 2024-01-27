using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands
{
	public class CreatePersonneCommand : IRequest<int>
	{
		public Personne Personne { get; }

		public CreatePersonneCommand(string nom, string prenom, Statut statut) => Personne = new Personne(nom, prenom, statut);
	}
}
