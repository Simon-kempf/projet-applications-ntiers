using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
    public class CreateDenonciationCommand : IRequest<int>
    {
        public Denonciation Denonciation { get; }

		public CreateDenonciationCommand(DateTime Horodatage,
            Personne Informateur, 
            Personne Suspect,
            Delit Delit,
            string? PaysEvasion,
            Reponse Reponse) => Denonciation = new Denonciation(Horodatage,
			                                                    Informateur,
			                                                    Suspect,
			                                                    Delit,
			                                                    PaysEvasion,
			                                                    Reponse);
    }
}
