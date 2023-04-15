using FinalProjectContract.Controllers;
using FinalProjectContract.Data;
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
        public FinalProjectController()
        {
            
        }
        public override Task<ActionResult<ProcessImageResponse>> ProcessImage(ProcessImageRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
