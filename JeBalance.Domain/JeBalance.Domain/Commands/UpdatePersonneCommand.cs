using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands
{
	public class UpdatePersonneCommand : IRequest<int>
	{
		public int Id { get; }
		public Personne Personne { get; }

		public UpdatePersonneCommand(int id, string nom, string prenom, Statut statut)
		{
			Id = id;
			Personne = new Personne(nom, prenom, statut);
		}
	}
}
