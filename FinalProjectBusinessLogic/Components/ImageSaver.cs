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
        public SaveImageResponse SaveImage(SaveImageRequest request)
        {
            return new SaveImageResponse()
            {
                ImagePath = "Path"
            };
        }
    }
}
