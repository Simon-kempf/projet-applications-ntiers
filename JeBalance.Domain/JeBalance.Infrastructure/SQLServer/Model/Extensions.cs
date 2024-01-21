using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
    public static class Extensions
    {
        public static Denonciation ToDomain(this DenonciationSQLS denonciation)
        {
            return new Denonciation(
                denonciation.Horodatage,
                new Personne(denonciation.Informateur!.Id, null, null),
                new Personne(denonciation.Suspect!.Id, null, null),
                (Delit)denonciation.Delit,
                denonciation.PaysEvasion!.Value
            );
        }
        public static DenonciationSQLS ToSQLS(this Denonciation denonciation)
        {
            return new DenonciationSQLS
            {
                Id = denonciation.Id,
                IdInformateur = denonciation.Informateur!.Id,
                IdSuspect = denonciation.Suspect!.Id,
                Delit = (int)denonciation.Delit!.Value,
                StatutInfo = (int)denonciation.Informateur!.Statut,
                StatutSuspect = (int)denonciation.Suspect!.Statut,
                Horodatage = denonciation.Horodatage!.Value
            };
        }
    }
}
