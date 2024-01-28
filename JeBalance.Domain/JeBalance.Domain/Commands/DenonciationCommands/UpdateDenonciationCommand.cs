using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
    public class UpdateDenonciationCommand : IRequest<int>
    {
        public int Id { get; }
        public Denonciation Denonciation { get; }

        public UpdateDenonciationCommand(int id, 
            DateTime Horodatage,
			Personne Informateur,
			Personne Suspect,
			Delit Delit,
			string? PaysEvasion,
			Reponse Reponse)
        {
            Id = id;
            Denonciation = new Denonciation(Horodatage,
											Informateur,
											Suspect,
											Delit,
											PaysEvasion,
											Reponse);
        }
    }
}
