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
        SaveImageResponse SaveImage(SaveImageRequest request);
    }
}
