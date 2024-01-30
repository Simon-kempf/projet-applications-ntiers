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
	public class DeleteVIPCommandHandler : IRequestHandler<DeleteVIPCommand, bool>
	{
		private readonly IVIPRepository _repository;

		public DeleteVIPCommandHandler(IVIPRepository repository) => _repository = repository;
		public Task<bool> Handle(DeleteVIPCommand query, CancellationToken cancellationToken)
		{
			return _repository.Delete(query.Id);
		}
	}
}
