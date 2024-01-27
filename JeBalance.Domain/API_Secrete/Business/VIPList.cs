using JeBalance.Domain.Model;

namespace API_Secrete.Business
{
    public class VIPList
    {
        private readonly List<Personne> _vips;

        public IReadOnlyCollection<Personne> Vips => _vips;

        public VIPList()
        {
            _vips = [];
        }

        public void AjouterVIP(Personne personne)
        {
            if(RechercherVIP(personne.Id) == null)
            {
                _vips.Add(personne);
            }
        }

        public Personne? RechercherVIP(int id)
        {
            return _vips.FirstOrDefault(p => p.Id == id);
        }

        public void SupprimerVIP(Personne person)
        {
            _vips.Remove(person);
        }
    }
}
