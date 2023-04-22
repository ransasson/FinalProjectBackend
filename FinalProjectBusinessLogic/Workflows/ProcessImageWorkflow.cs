using FinalProjectContract.Data;
using FinalProjectModel.Components;
using FinalProjectModel.Data;
using FinalProjectModel.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBusinessLogic.Workflows
{
    public class ProcessImageWorkflow : IProcessImageWorkflow
    {
		private readonly IImageSaver _imageSaver;
		private readonly IModelCaller _modelCaller;
        public ProcessImageWorkflow(IImageSaver imageSaver,IModelCaller modelCaller)
        {
            _imageSaver = imageSaver;
            _modelCaller = modelCaller;
        }
        public async Task<ProcessImageResponse> ProcessImage(ProcessImageRequest request)
        {
			try
			{
                var saveImageResponse = await _imageSaver.SaveImage(new SaveImageRequest()
                {
                    Image = request.Image
                });
                if(saveImageResponse == null || saveImageResponse.ImagePath == null)
                {
                    throw new Exception("Failed to process image, image path is null!");
                }
                var modelResponse = _modelCaller.CallModel(new CallModelRequest()
                {
                    ImagePath = saveImageResponse.ImagePath
                });
                return new ProcessImageResponse()
                {
                    People = modelResponse?.People
                };
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
