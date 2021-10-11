using System.Collections.Generic;

namespace PhonePlan.Domain.Entities
{
	public sealed class DirectRemoteDialingEntity
	{
		public DirectRemoteDialingEntity()
		{
			DirectRemoteDialingPhonePlans = new HashSet<DirectRemoteDialingPhonePlanEntity>();
		}

		public int DirectRemoteDialingCode { get; set; }

		public string Code { get; set; }

		public ICollection<DirectRemoteDialingPhonePlanEntity> DirectRemoteDialingPhonePlans { get; private set; }
	}
}
