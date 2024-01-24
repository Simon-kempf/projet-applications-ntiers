using JeBalance.Domain.Model;

namespace API_Secrete.Business
{
    public class VIPList
    {
        private readonly List<IPersonne> _vips;

        public IReadOnlyCollection<IPersonne> Vips => _vips;

        public VIPList()
        {
            _vips = [];
        }

        public void AjouterVIP(IPersonne personne)
        {
            if(RechercherVIP(personne.Id) == null)
            {
                _vips.Add(personne);
            }
        }

        public IPersonne? RechercherVIP(int id)
        {
            return _vips.FirstOrDefault(p => p.Id == id);
        }

        public void SupprimerVIP(IPersonne person)
        {
            _vips.Remove(person);
        }
    }
}
