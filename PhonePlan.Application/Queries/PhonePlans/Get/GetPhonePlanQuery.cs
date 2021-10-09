namespace PhonePlan.Application.Queries.PhonePlans.Get
{
	public class GetPhonePlanQuery
	{
		public GetPhonePlanQuery(int idPhonePlan)
		{
			IdPhonePlan = idPhonePlan;
		}

		public int IdPhonePlan { get; private set; }
	}
}