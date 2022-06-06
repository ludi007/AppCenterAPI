using AppCenterAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

using (HttpClient client = new HttpClient())
{
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Add("X-API-Token", "69a22fa24e39afb87391c9167aebcd5df79bd401");
    int flag = 0;

    using (HttpResponseMessage response = await client.GetAsync("https://api.appcenter.ms/v0.1/apps/aleksandar_popov/Akvelon-home-task/branches"))
    {
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var branches = JsonConvert.DeserializeObject<List<Root>>(responseBody);
        CheckBuild checkBuild;
        DateTime start;
        DateTime end;
        TimeSpan seconds;
        foreach (var branch in branches)
        {
            var json = new Rootobject() { sourceVersion = "1a64a8f263e87ce4ed5a0b4f9133da3acc122af9", debug = true };
            string jsonBody = JsonConvert.SerializeObject(json);
            var data = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var responseBuild = await client.PostAsync("https://api.appcenter.ms/v0.1/apps/aleksandar_popov/Akvelon-home-task/branches/" + branch.branch.name + "/builds", data);
        	responseBuild.EnsureSuccessStatusCode();
            var responseString = await responseBuild.Content.ReadAsStringAsync();
        	var build = JsonConvert.DeserializeObject<Builds>(responseString);
            do
            {
                var check = await client.GetAsync("https://api.appcenter.ms/v0.1/apps/aleksandar_popov/Akvelon-home-task/builds/" + build.id);
                check.EnsureSuccessStatusCode();
                var checkResponse = await check.Content.ReadAsStringAsync();
                checkBuild = JsonConvert.DeserializeObject<CheckBuild>(checkResponse);
                start = checkBuild.startTime;
                if (checkBuild.status != "failed" && checkBuild.status != "completed")
                {
                    Thread.Sleep(2000);
                }
                else
                    flag = 1;
                
            } while (flag == 0);
            end = checkBuild.finishTime;
            seconds = end.Subtract(start);
            Console.WriteLine("{0} build {1} in {2} seconds. Link to build logs: {3}", build.sourceBranch, checkBuild.status, seconds.Seconds, "https://api.appcenter.ms/v0.1/apps/aleksandar_popov/Akvelon-home-task/builds/" + build.id + "/logs");
        }

    }
}


public class Rootobject
{
    public string sourceVersion { get; set; }
    public bool debug { get; set; }
}
