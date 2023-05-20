using FinalProjectContract.Controllers;
using FinalProjectContract.Data;
using FinalProjectModel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectService.API.Controllers
{
    public class FinalProjectController : FinalProjectControllerBase
    {
        private readonly IImageProcessService _finalProjectService;
        public FinalProjectController(IImageProcessService finalProjectService)
        {
            _finalProjectService = finalProjectService;
        }

        public override async Task<ActionResult<GetAllSessionsResponse>> GetAllSessions()
        {
            try
            {
                var response = await _finalProjectService.GetAllSessions(new GetAllSessionsRequest());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public override async Task<ActionResult<GetSessionResponse>> GetSession(string id)
        {
            try
            {
                var response = await _finalProjectService.GetSession(new GetSessionRequest() { SessionId = id});
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public override async Task<ActionResult<ProcessImageResponse>> ProcessImage(IFormFile image)
        {
            if(image == null)
            {
                return BadRequest();
            }
            try
            {
                ProcessImageResponse response = await _finalProjectService.ProcessImage(new ProcessImageRequest()
                {
                    Image = image
                });
                return Ok(response);
            }
            catch (Exception ex)
            {

               return StatusCode(500, ex.Message);
            }
        }
    }
}
