namespace PhonePlan.Domain.Entities
{
	public sealed class DirectRemoteDialingPhonePlanEntity
	{
		public DirectRemoteDialingPhonePlanEntity()
		{

		}		

		public int DirectRemoteDialingPhonePlanCode { get; set; }

		public int DirectRemoteDialingCode { get; set; }

		public int PhonePlanCode { get; set; }

		public PhonePlansEntity PhonePlans { get; set; }

		public DirectRemoteDialingEntity DirectRemoteDialing { get; set; }		
	}
}
