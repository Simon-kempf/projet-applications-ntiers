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
        public Reponse Reponse { get; }

        public UpdateDenonciationCommand(int id, 
            int TypeReponse,
            int Retribution)
        {
            Id = id;
            Reponse = new Reponse(DateTime.Now, (Model.Type) TypeReponse, Retribution);
        }
    }
}
