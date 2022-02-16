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
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private string _requestip;
        StudentsBll sbll = new();
        public StudentsController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _requestip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        [Route("{classname}/{uid}")]
        [HttpGet]
        public List<Student> GetStudents(string classname,string uid)
        {
            return sbll.GetStudentsByClassName(classname, uid, _requestip);
        }

        [Route("{SCardNum}/{uid}")]
        [HttpGet]
        public Student GetStudentByCardNum(string SCardNum,string uid)
        {
            return sbll.GetStudentBySCardNum(SCardNum, uid, _requestip);
        }

        [Route("{uid}")]
        [HttpPost]
        public bool UpDateStudentByCardNum([FromBody]Student s,string uid)
        {
            return sbll.UpDateStudentByCardNum(s, uid, _requestip);
        }
    }
}
