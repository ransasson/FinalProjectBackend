﻿using FinalProjectDataModel;
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
    public class ImageProcessingBridge : IImageProcessingBridge
    {
        private readonly string _outputFolderPath = "Prediction_Output";
        private readonly string _pythonModelPath = "Production_Model.py";
        public CallModelResponse CallModel(CallModelRequest request)
        {
			try
			{
                string parameter = request.ImagePath;
                // Create a ProcessStartInfo object to configure the process
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "python"; // Use "python" as the FileName to run Python from system PATH
                psi.Arguments = $"\"{_pythonModelPath}\" \"{parameter}\""; // Pass the script path and parameter as arguments
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                // Create a new process and start it
                Process process = new Process();
                process.StartInfo = psi;
                process.Start();

                // Read the output from the Python script
                string output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();
                
                // Wait for the process to exit
                process.WaitForExit();
                
                var files = Directory.GetFiles(Path.GetDirectoryName(request.ImagePath));
                var file = files.Where(x => x.EndsWith("people.json")).FirstOrDefault();
                if(file == null)
                {
                    throw new Exception("Failed to get people data! model produced no output file! Python output: " + error);
                }
                var json_data = File.ReadAllText(file) ;
                var people = JsonSerializer.Deserialize<List<PersonData>>(json_data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                //CleanUp();
                if(people ==null)
                {
                    throw new Exception("Failed to get people data from python script! Python output: " + error);
                }
                return new CallModelResponse()
                {
                    People = people
                };
            }
            catch (Exception)
			{
				throw;
			}
        }

        private void CleanUp()
        {
            if (Directory.Exists(_outputFolderPath))
            {
                foreach (var file in Directory.GetFiles(_outputFolderPath))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
