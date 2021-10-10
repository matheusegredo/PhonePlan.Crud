using System;

namespace PhonePlan.Application.Commands.PhonePlans.Put
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string message) : base(message)
		{
		}		
	}
}