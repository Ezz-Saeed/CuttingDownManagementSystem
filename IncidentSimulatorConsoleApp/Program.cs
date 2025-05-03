namespace IncidentSimulatorConsoleApp
{
    using IncidentSimulatorConsoleApp.Services;
    using System.Net.Http.Json;

    class Program
    {
        static async Task Main(string[] args)
        {
            var simulator = new IncidentGeneratorSimulator();
            SPCreateCaller spCaller = new();


            var cts = new CancellationTokenSource();
            var simulatorTask = Task.Run(() => simulator.CallGenerateAPIsAsync());
            var spCreateTask = Task.Run(() => spCaller.RunAsync(cts.Token));

            await Task.WhenAll(simulatorTask, spCreateTask);


        }
    }

}
