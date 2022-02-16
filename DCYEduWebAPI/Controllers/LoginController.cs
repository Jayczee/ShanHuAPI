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
    [Route("[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private string _requestip;
        UserBll userbll = new();

        public LoginController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _requestip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }


        [HttpGet("{uid}/{pwd}")]
        public User Login(string uid, string pwd)
        {
            User user = userbll.Login(uid, pwd, _requestip);
            return user;
        }

        [HttpGet("{wxid}")]
        public Student WXLogin(string wxid)
        {
            return userbll.WXLogin(wxid);
        }

        [HttpGet("{stuName}/{stuCardNum}/{wxid}")]
        public int WXBind(string stuName,string stuCardNum,string wxid)
        {
            return userbll.WXBind(stuName,stuCardNum, wxid);
        }
    }
}
