using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.VIPCommands
{
	public class DeleteVIPCommand : IRequest<bool>
	{
		public int Id { get; }

		public DeleteVIPCommand(int id) => Id = id;
	}
}
