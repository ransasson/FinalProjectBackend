using FinalProjectDataModel;
using FinalProjectModel.Components;
using FinalProjectModel.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinalProjectBusinessLogic.Components
{
    public class ModelCaller : IModelCaller
    {
        public CallModelResponse CallModel(CallModelRequest request)
        {
			try
			{
                string parameter = request.ImagePath;
                string pythonScriptPath = "pythonTest.py";
                // Create a ProcessStartInfo object to configure the process
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "python"; // Use "python" as the FileName to run Python from system PATH
                psi.Arguments = $"\"{pythonScriptPath}\" \"{parameter}\""; // Pass the script path and parameter as arguments
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                // Create a new process and start it
                Process process = new Process();
                process.StartInfo = psi;
                process.Start();

                // Read the output from the Python script
                string output = process.StandardOutput.ReadToEnd();

                // Wait for the process to exit
                process.WaitForExit();
                var people = JsonSerializer.Deserialize<List<PersonData>>(output, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                if(people ==null)
                {
                    throw new Exception("Failed to get people data from python script!");
                }
                return new CallModelResponse()
                {
                    People = people
                };
            }
            catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
