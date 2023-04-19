﻿using FinalProjectContract.Data;
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

        public ImageProcessService(IProcessImageWorkflow processImageWorkflow)
        {
            _processImageWorkflow = processImageWorkflow;
        }
        public ProcessImageResponse ProcessImage(ProcessImageRequest request)
        {
            return  _processImageWorkflow.ProcessImage(request);
        }
    }
}
