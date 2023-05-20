using FinalProjectContract.Data;
using FinalProjectModel.Services;
using FinalProjectModel.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBusinessLogic.Services
{
    public class ImageProcessService : IImageProcessService
    {
        private readonly IProcessImageWorkflow _processImageWorkflow;
        private readonly IGetAllSessionsWorkflow _getAllSessionsWorkflow;
        private readonly IGetSessionWorkflow _getSessionWorkflow;

        public ImageProcessService(IProcessImageWorkflow processImageWorkflow, IGetAllSessionsWorkflow getAllSessionsWorkflow, IGetSessionWorkflow getSessionWorkflow)
        {
            _processImageWorkflow = processImageWorkflow;
            _getAllSessionsWorkflow = getAllSessionsWorkflow;
            _getSessionWorkflow = getSessionWorkflow;
        }

        public async Task<GetAllSessionsResponse> GetAllSessions(GetAllSessionsRequest request)
        {
            return await _getAllSessionsWorkflow.GetAllSessionsAsync(request);
        }

        public async Task<GetSessionResponse> GetSession(GetSessionRequest request)
        {
            return await _getSessionWorkflow.GetSessionAsync(request);
        }

        public async Task<ProcessImageResponse> ProcessImage(ProcessImageRequest request)
        {
            return  await _processImageWorkflow.ProcessImage(request);
        }
    }
}
