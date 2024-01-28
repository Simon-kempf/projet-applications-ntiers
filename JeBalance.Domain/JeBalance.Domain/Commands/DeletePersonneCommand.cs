﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands
{
	public class DeletePersonneCommand : IRequest<bool>
	{
		public int Id { get; }

		public DeletePersonneCommand(int id) => Id = id;
	}
}
