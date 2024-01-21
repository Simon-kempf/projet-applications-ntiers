using JeBalance.Domain.Model;
using JeBalance.Domain.Model.Utilisateurs;
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

		public static Personne ToDomain(this PersonneSQLS personne)
		{
			return new Personne(
			personne.Id,
			personne.Nom,
			personne.Prenom,
            (Statut)personne.Statut);
		}
		public static PersonneSQLS ToSQLS(this Personne personne)
		{
			return new PersonneSQLS
			{
				Id = personne.Id,
				Nom = personne.Nom!.Value,
				Prenom = personne.Prenom!.Value,
                Statut = (int)personne.Statut!
			};
		}

		public static Reponse ToDomain(this ReponseSQLS reponse)
		{
			return new Reponse(
				reponse.Horodatage,
				reponse.Id,
				(Domain.Model.Type)reponse.Type,
				reponse.Retribution);
		}
		public static ReponseSQLS ToSQLS(this Reponse reponse)
		{
			return new ReponseSQLS
			{
				Horodatage = reponse.Horodatage,
				Id = reponse.Id,
				Type = (int)reponse.Type,
				Retribution = reponse.Retribution!.Value
			};
		}

		public static VIP ToDomain(this VIPSQLS vip)
		{
			return new VIP(
				vip.Id,
				vip.Nom,
				vip.Prenom);
		}
		public static VIPSQLS ToSQLS(this VIP vip)
		{
			return new VIPSQLS
			{
				Id = vip.Id,
				Nom = vip.Nom!.Value,
				Prenom = vip.Prenom!.Value,
				Statut = 4
			};
		}

	}
}
