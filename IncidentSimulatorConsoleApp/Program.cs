namespace IncidentSimulatorConsoleApp
{
    using IncidentSimulatorConsoleApp.Services;
    using System.Net.Http.Json;

    class Program
    {
        static async Task Main(string[] args)
        {
            var simulator = new IncidentGeneratorSimulator();
            await simulator.CallGenerateAPIsAsync();

            //const string baseUrl = "http://localhost:5288/api/Incidents";
            //HttpClient httpClient = new();

            //int parallelRequests = 5;
            //int delayBetweenRoundsInSeconds = 10;

            //Console.WriteLine("Incident Generator Started...");

            //while (true)
            //{
            //    var tasks = new List<Task>();

            //    await Parallel.ForEachAsync(Enumerable.Range(0, parallelRequests), async (i, _) =>
            //    {
            //        try
            //        {
            //            var random = new Random();
            //            var count = random.Next(5, 20);
            //            var closedPercentage = random.Next(30, 80);

            //            if (i % 2 == 0)
            //            {
            //                var response = await httpClient.PostAsync($"{baseUrl}/generateIncidentsA?count={count}&closedPercentage={closedPercentage}", null);
            //                Console.WriteLine($"[A] Sent {count} incidents. Status: {response.StatusCode}");
            //            }
            //            else
            //            {
            //                var response = await httpClient.PostAsync($"{baseUrl}/generateIncidentsB?count={count}&closedPercentage={closedPercentage}", null);
            //                Console.WriteLine($"[B] Sent {count} incidents. Status: {response.StatusCode}");
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine($"Error: {ex.Message}");
            //        }
            //    });

            //    await Task.Delay(delayBetweenRoundsInSeconds * 1000);
            //}
        }
    }

}
