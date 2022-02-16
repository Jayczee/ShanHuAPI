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
    public class TeachersController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private string _requestip;
        TeacherBll tbll = new();
        public TeachersController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _requestip= accessor.HttpContext.Connection.RemoteIpAddress.ToString(); 
        }

        [Route("/{uid}")]
        [HttpGet]
        public Teacher GetTecherInf(string uid)
        {
            Teacher t = tbll.GetTeacherInf(uid, _requestip);
            return t;
        }

        [HttpPost]
        public bool UpdateTeacherInf([FromBody]Teacher t)
        {
            return tbll.UpdateTeacherInf(t);
        }

        [Route("{uid}")]
        [HttpGet]
        public List<string> GetClassInf(string uid)
        {
            return tbll.GetClassInf(uid, _requestip);
        }
    }
}
