﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectContract.Data
{
    public class ProcessImageRequest
    {
        public IFormFile Image { get; set; }
    }
}
