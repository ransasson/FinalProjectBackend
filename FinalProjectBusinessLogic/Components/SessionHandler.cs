using FinalProjectBusinessLogic.Services;
using FinalProjectContract.Data;
using FinalProjectDataModel;
using FinalProjectModel.Components;
using FinalProjectModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinalProjectBusinessLogic.Components
{
    public class SessionHandler : ISessionHandler
    {
		private const string _modelInputPath = "Prediction_Input";

        public async Task<GetAllSessionsResponse> GetAllSessions(GetAllSessionsRequest request)
        {
			try
			{
                var response = new GetAllSessionsResponse();
                var sessions = Directory.GetDirectories(_modelInputPath);
                foreach (var session in sessions)
                {
                    response.Sessions.Add(new SessionIdentifier() { Id = Path.GetFileName(session) });
                }
                return response;
            }
			catch (Exception)
			{
				throw;
			}
           
        }

        public async Task<GetSessionResponse> GetSession(GetSessionRequest request)
        {
			try
			{
				var response = new GetSessionResponse();
				var sessions = Directory.GetDirectories(_modelInputPath);
				if (!sessions.Any())
				{
					throw new Exception("No session in database!");
				}
				var selectedSession = sessions.FirstOrDefault(x => x.EndsWith(request.SessionId));
				if (selectedSession != null)
				{
					var files = Directory.GetFiles(selectedSession);
                    var imagePath = files.FirstOrDefault(x => !x.EndsWith(".json"));
					var jsonPath = files.FirstOrDefault(x => x.EndsWith(".json"));
					if(imagePath == null || jsonPath == null)
					{
						throw new Exception($"Data for {request.SessionId} does not exist");
					}
					var imageData = File.ReadAllBytes(imagePath);
                    var json_data = File.ReadAllText(jsonPath);
                    var people = JsonSerializer.Deserialize<List<PersonData>>(json_data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
					response.SessionDetails = new SessionDetails()
					{
						SessionIdentifier = new SessionIdentifier()
						{
							Id = Path.GetFileName(selectedSession)
						},
						People = people,
						ImageData = imageData
					};
					
                }
                return response;
            }
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<SaveImageResponse> SaveImage(SaveImageRequest request)
        {
			try
			{
				if(request?.Image!=null)
				{
					if(!Directory.Exists(_modelInputPath))
					{
						Directory.CreateDirectory(_modelInputPath);
					}
					var sessionPath = Path.Combine(_modelInputPath, Guid.NewGuid().ToString());
                    Directory.CreateDirectory(sessionPath);
					var imagePath = Path.Combine(sessionPath,request.Image.FileName);
                    using var fileStream = new FileStream(imagePath, FileMode.Create);
                    await request.Image.CopyToAsync(fileStream);
					return new SaveImageResponse()
					{
						ImagePath = imagePath
					};
                }
				throw new Exception("Failed to save image! No image data was given!");
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
