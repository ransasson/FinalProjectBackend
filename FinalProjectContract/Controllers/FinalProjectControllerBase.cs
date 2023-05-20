using FinalProjectContract.Data;
using Microsoft.AspNetCore.Http;
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
        public abstract Task<ActionResult<ProcessImageResponse>> ProcessImage(IFormFile image);

        [HttpGet]
        [Route("GetAllSessions")]
        public abstract Task<ActionResult<GetAllSessionsResponse>> GetAllSessions();

        [HttpGet]
        [Route("GetSession")]
        public abstract Task<ActionResult<GetSessionResponse>> GetSession(string id);
    }
}
