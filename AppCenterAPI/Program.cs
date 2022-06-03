using AppCenterAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;

using (HttpClient client = new HttpClient())
{
	client.DefaultRequestHeaders.Accept.Add(
		new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


	client.DefaultRequestHeaders.Add("X-API-Token", "69a22fa24e39afb87391c9167aebcd5df79bd401");
	using (HttpResponseMessage response = await client.GetAsync("https://api.appcenter.ms/v0.1/apps/aleksandar_popov/Akvelon-home-task/branches"))
	{
		response.EnsureSuccessStatusCode();
		var responseBody = await response.Content.ReadAsStringAsync();
		var test = JsonConvert.DeserializeObject<List<Root>>(responseBody);
		foreach (var bran in test)
		{
			Console.WriteLine("{0} build {1}.", bran.branch.name,bran.lastBuild.status);
		}

	}
}