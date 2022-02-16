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
    public class ReadingTaskController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private string _requestip;
        ReadingTaskBll rbll = new();
        public ReadingTaskController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _requestip = accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }


        [HttpGet]
        [Route("{classname}/{uid}")]
        public List<ReadingTask> GetTaskInfoByClass(string classname,string uid)
        {
            return rbll.GetTaskInfoByClass(classname, uid, _requestip);
        }

        [HttpPost]
        public bool AddTaskInfo([FromBody]ReadingTask rt)
        {
            return rbll.AddTaskInfo(rt);
        }

        [HttpPost]
        public bool UpdateTaskInfo([FromBody]ReadingTask rt)
        {
            return rbll.UpdateTaskInfo(rt);
        }

        [HttpGet]
        [Route("{taskid}/{uid}")]
        public List<TaskFinishInfo> GetTaskFinishInfo(int taskid,string uid)
        {
            return rbll.GetTaskFinishInfo(taskid,uid,_requestip);
        }

        [HttpPost]
        public bool UpdateTaskFinishInfo([FromBody]TaskFinishInfo tf)
        {
            return rbll.UpdateTaskFinishInfo(tf);
        }

        [HttpDelete]
        [Route("{taskid}/{uid}")]
        public bool DeleteTask(int taskid,string uid)
        {
            return rbll.DeleteTaskByID(taskid,uid,_requestip);
        }

        [HttpPost]
        public bool AddTaskFinishInfo([FromBody]TaskFinishInfo tf)
        {
            return rbll.AddTaskFinishInfo(tf);
        }
    }
}
