using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PhonePlan.Crud
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseKestrel();
					webBuilder.UseIIS();
					webBuilder.UseUrls("http://*:5000");
					webBuilder.UseStartup<Startup>();
				});
	}
}
