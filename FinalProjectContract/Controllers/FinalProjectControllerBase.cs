using FinalProjectContract.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectContract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class FinalProjectControllerBase: ControllerBase
    {
        /// <summary>
        /// Process image
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ProcessImage")]
        public abstract Task<ActionResult<ProcessImageResponse>> ProcessImage(ProcessImageRequest request);
    }
}
