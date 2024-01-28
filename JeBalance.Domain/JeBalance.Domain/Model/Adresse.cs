using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
	public class Adresse
	{
		public CodePostal CodePostal { get; set; }
		public NomDeCommune NomDeCommune { get; set; }
		public NomDeVoie NomDeVoie { get; set; }
		public NumeroDeVoie NumeroDeVoie { get; set; }

		public Adresse()
		{
		}

		public Adresse(int codePostal, string nomDeCommune, string nomDeVoie, int numeroDeVoie)
		{
			CodePostal = new CodePostal(codePostal);
			NomDeCommune = new NomDeCommune(nomDeCommune);
			NomDeVoie = new NomDeVoie(nomDeVoie);
			NumeroDeVoie = new NumeroDeVoie(numeroDeVoie);
		}

		public string toString()
		{
			return CodePostal.Value.ToString() + ";"
				+ NomDeCommune.Value.ToString() + ";"
				+ NomDeVoie.Value.ToString() + ";"
				+ NumeroDeVoie.Value.ToString();
		}


	}
}
