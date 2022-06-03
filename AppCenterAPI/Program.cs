﻿using AppCenterAPI;
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
		var branches = JsonConvert.DeserializeObject<List<Root>>(responseBody);
		foreach (var branch in branches)
		{
			Console.WriteLine("{0} build {1}.", branch.branch.name,branch.lastBuild.status);
		}

	}
}