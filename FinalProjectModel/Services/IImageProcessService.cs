using FinalProjectContract.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModel.Services
{
    public interface IImageProcessService
    {
        Task<ProcessImageResponse> ProcessImage(ProcessImageRequest request);
    }
}
