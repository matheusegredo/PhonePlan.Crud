using System;

namespace PhonePlan.CrossCutting.Exceptions
{
	public sealed class InvalidRequestException : Exception
	{
		public InvalidRequestException(string message) : base(message)
		{
		}
	}
}