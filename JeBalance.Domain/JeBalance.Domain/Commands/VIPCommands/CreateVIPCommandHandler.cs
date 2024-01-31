using JeBalance.Domain.Commands.PersonneCommands;
using JeBalance.Domain.Model;
using JeBalance.Domain.Queries.VIP;
using JeBalance.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.VIPCommands
{
	public class CreateVIPCommandHandler : IRequestHandler<CreateVIPCommand, bool>
	{
		private readonly IVIPRepository _repository;

		public CreateVIPCommandHandler(IVIPRepository repository) => _repository = repository;
		public Task<bool> Handle(CreateVIPCommand query, CancellationToken cancellationToken)
		{
			return _repository.Create(query.Id);
		}
	}
}
