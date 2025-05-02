using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSimulatorConsoleApp.Services
{
    public class IncidentGeneratorSimulator(int parallelRequests = 5, int delayBetweenRoundsInSeconds = 10)
    {
        private const string baseUrl = "http://localhost:5288/api/Incidents";
        private HttpClient httpClient = new();
        private static  readonly ThreadLocal<Random> random = new(() => new Random());

        //private readonly int parallelRequests = 5;
        //private int delayBetweenRoundsInSeconds = 10;

        public async Task  CallGenerateAPIsAsync()
        {
            Console.WriteLine("Incident Generator Started...");

            while (true)
            {
                var tasks = new List<Task>();

                await Parallel.ForEachAsync(Enumerable.Range(0, parallelRequests), async (i, _) =>
                {
                    try
                    {
                        //var random = new Random();
                        var count = random.Value?.Next(5, 20);
                        var closedPercentage = random.Value?.Next(30, 80);

                        if (i % 2 == 0)
                        {
                            var response = await httpClient.
                            PostAsync($"{baseUrl}/generateIncidentsA?count={count}&closedPercentage={closedPercentage}", null);
                            Console.WriteLine($"[A] Sent {count} incidents. Status: {response.StatusCode}");
                        }
                        else
                        {
                            var response = await httpClient.
                            PostAsync($"{baseUrl}/generateIncidentsB?count={count}&closedPercentage={closedPercentage}", null);
                            Console.WriteLine($"[B] Sent {count} incidents. Status: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                });

                await Task.Delay(delayBetweenRoundsInSeconds * 1000);
            }
        }
    }
}
