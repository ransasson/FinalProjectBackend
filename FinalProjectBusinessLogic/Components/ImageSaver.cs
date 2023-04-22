using FinalProjectBusinessLogic.Services;
using FinalProjectModel.Components;
using FinalProjectModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBusinessLogic.Components
{
    public class ImageSaver : IImageSaver
    {
		private readonly string _modelInputPath = "Prediction_Input";
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
					var imagePath = Path.Combine(_modelInputPath, request.Image.FileName);
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
