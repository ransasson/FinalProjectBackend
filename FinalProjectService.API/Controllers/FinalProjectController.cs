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
        public override async Task<ActionResult<ProcessImageResponse>> ProcessImage(IFormFile image)
        {
            if(image == null)
            {
                return BadRequest();
            }
            try
            {
                ProcessImageResponse response = _finalProjectService.ProcessImage(new ProcessImageRequest()
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
