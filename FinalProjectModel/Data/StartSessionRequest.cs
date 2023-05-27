using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModel.Data
{
    public class StartSessionRequest
    {
        public IFormFile Image { get; set; }
    }
}
