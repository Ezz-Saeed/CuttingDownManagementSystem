using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentSimulatorConsoleApp.Services
{
    public class SPCreateCaller
    {
        private readonly string localConnection = 
                "Server=DESKTOP-2SR000U\\SQLEXPRESS01;Database=CutDownDb;Trusted_Connection=true;Encrypt=false";

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Exec_SP_Create();
                await Task.Delay(5000, cancellationToken);
            }
        }

        public void Exec_SP_Create()
        {
            using SqlConnection connection = new SqlConnection(localConnection);
            using SqlCommand command = new SqlCommand("SP_Create", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Stored procedure executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
