using JeBalance.Domain.Model;
using System.Text.Json.Serialization;

namespace API.Parameters
{
	public class FindNonTraiteesParameter
	{
		public int Limit { get; set; }

		public int Offset { get; set; }

		public FindNonTraiteesParameter()
		{
		}
	}
}
