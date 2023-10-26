using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    public enum Statut
    {
        NONE = 0,
        INFORMATEUR = 1,
        SUSPECT = 2,
        CALOMNIATEUR = 3,
        VIP = 4,
        ADMINISTRATEUR = 5
    }
}
