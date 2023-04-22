using FinalProjectModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModel.Components
{
    public interface IImageSaver
    {
        Task<SaveImageResponse> SaveImage(SaveImageRequest request);
    }
}
