using System.Collections.Generic;

namespace PhonePlan.Domain.Entities
{
	public sealed class PhonePlansEntity
	{
		public PhonePlansEntity()
		{
			DirectRemoteDialingPhonePlans = new HashSet<DirectRemoteDialingPhonePlanEntity>();
		}

		public int PlanCode { get; set; }

		public int Minutes { get; set; }

		public string InternetFranchise { get; set; }

		public decimal Value { get; set; }

		public PlanType PlanType { get; set; }

		public string Operator { get; set; }

		public ICollection<DirectRemoteDialingPhonePlanEntity> DirectRemoteDialingPhonePlans { get; private set; }
	}
}
