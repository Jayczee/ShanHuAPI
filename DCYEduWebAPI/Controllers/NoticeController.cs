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
    public class NoticeController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private string _requestip;
        NoticeBll nbll = new();

        public NoticeController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _requestip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }


        [HttpPost]
        public bool UpdateNotice([FromBody]Notice not)
        {
            return nbll.UpdateNotice(not);
        }

        [Route("{NID}/{uid}")]
        [HttpDelete]
        public bool DeleteNotice(int NID,string uid)
        {
            return nbll.DeleteNotice(NID, uid,_requestip);
        }

        [Route("{className}/{uid}")]
        [HttpGet]
        public List<Notice> GetNoticesByClassName(string className,string uid)
        {
            return nbll.GetNoticesByClassName(className, uid, _requestip);
        }

        [Route("{NID}/{uid}")]
        [HttpGet]
        public List<NoticeReadCondition> GetNoticeReadConditions(int NID,string uid)
        {
            return nbll.GetNoticeReadConditions(NID, uid, _requestip);
        }

        [Route("{NID}/{SCardNum}")]
        [HttpPost]
        public bool SetNoticeReadCondition(int NID,int SCardNum)
        {
            return nbll.SetNoticeReadCondition(NID, SCardNum);
        }
    }
}
