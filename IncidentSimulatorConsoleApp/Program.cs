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

            
        }
    }

}
