using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCYEduWebAPI.Models;
using DCYEduWebAPI.BLL;

namespace DCYEduWebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReadingTreeController : ControllerBase
    {
        [HttpGet]
        public TreeLevel GetTreeLevelSet()
        {
            return null;
        }
    }
}
