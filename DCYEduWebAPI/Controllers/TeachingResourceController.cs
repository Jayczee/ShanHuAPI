using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DCYEduWebAPI.BLL;
using DCYEduWebAPI.Models;

namespace DCYEduWebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TeachingResourceController : ControllerBase
    {

        private IHttpContextAccessor _accessor;
        private string _requestip;
        TeachingResourceBll trbll = new();

        public TeachingResourceController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _requestip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }


        [Route("{className}/{uid}")]
        [HttpGet]
        public List<TeachingResource> GetTeachingResourcesByClassName(string className,string uid)
        {
            return trbll.GetTeachingResourcesByClassName(className, uid, _requestip);
        }

        [Route("{uid}")]
        [HttpPost]
        public bool AddTeachingResources([FromBody]TeachingResource tr,string uid)
        {
            return trbll.AddTeachingResources(tr, uid, _requestip);
        }

        [Route("{trid}/{uid}")]
        [HttpDelete]
        public bool DeleteTeachingResources(string trid,string uid)
        {
            return trbll.DeleteTeachingResources(trid, uid, _requestip);
        }

    }
}
