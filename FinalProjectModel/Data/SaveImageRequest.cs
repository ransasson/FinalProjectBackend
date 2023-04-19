using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModel.Data
{
    public class SaveImageRequest
    {
        public IFormFile Image { get; set; }
    }
}
