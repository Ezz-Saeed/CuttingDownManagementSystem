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

        private readonly string remoteConnection = "Server=db18919.public.databaseasp.net; Database=db18919; User Id=db18919; Password=rC!6%9Aj2Gh@; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True; ";

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Exec_SP_Create();
                Exec_SP_Close();
                await Task.Delay(5000, cancellationToken);
            }
        }

        public void Exec_SP_Create()
        {
            using SqlConnection connection = new SqlConnection(remoteConnection);
            using SqlCommand command = new SqlCommand("SP_Create", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Create Stored procedure executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void Exec_SP_Close()
        {
            using SqlConnection connection = new SqlConnection(remoteConnection);
            using SqlCommand command = new SqlCommand("SP_Close", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Close Stored procedure executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
