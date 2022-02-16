using DCYEduWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DCYEduWebAPI.DAL;


namespace DCYEduWebAPI.BLL
{
    public class ReadingTaskBll
    {
        UserBll ubll = new();
        ReadingTaskDal rdal = new();
        public List<ReadingTask> GetTaskInfoByClass(string classname, string uid, string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dt = rdal.GetTaskInfoByClass(classname);
            if (dt.Rows.Count <= 0)
                return null;
            List < ReadingTask > list= new List<ReadingTask>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ReadingTask rt = new();
                rt.Taskid = Int32.Parse(dt.Rows[i]["TaskID"].ToString());
                rt.Taskname = dt.Rows[i]["TaskName"].ToString();
                rt.Taskclass= dt.Rows[i]["TaskClass"].ToString();
                rt.Starttime= dt.Rows[i]["TaskStartTime"].ToString();
                rt.Endtime= dt.Rows[i]["TaskEndTime"].ToString();
                rt.Taskinfo= dt.Rows[i]["TaskInfo"].ToString();
                rt.Tasktname= dt.Rows[i]["TaskTeacherName"].ToString();
                rt.Taskbook= dt.Rows[i]["TaskBook"].ToString();
                list.Add(rt);
            }
            return list;
        }

        public List<TaskFinishInfo> GetTaskFinishInfo( int taskid, string uid,string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return null;
            DataTable dt = rdal.GetTaskFinishInfo(taskid);
            if (dt.Rows.Count <= 0)
                return null;
            List<TaskFinishInfo> list = new List<TaskFinishInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaskFinishInfo tf = new();
                tf.Finishid = Int32.Parse(dt.Rows[i]["FinishID"].ToString());
                tf.Taskname = dt.Rows[i]["TaskName"].ToString();
                tf.Taskfinishtime = dt.Rows[i]["TaskFinishTime"].ToString();
                tf.Taskid = Int32.Parse(dt.Rows[i]["TaskID"].ToString());
                tf.Sourceurl = dt.Rows[i]["SourceURL"].ToString();
                tf.Taskfinishname = dt.Rows[i]["TaskFinishName"].ToString();
                tf.Taskteachermsg = dt.Rows[i]["TaskTeacherMsg"].ToString();
                tf.Taskcorrect = dt.Rows[i]["TaskCorrect"].ToString();
                tf.Taskresult = Int32.Parse(dt.Rows[i]["TaskResult"].ToString());
                list.Add(tf);
            }
            return list;
        }

        public bool AddTaskFinishInfo(TaskFinishInfo tf)
        {
            int res = rdal.AddTaskFinishInfo(tf);
            if (res >= 1)
                return true;
            return false;
        }

        public bool DeleteTaskByID(int taskid,string uid,string ip)
        {
            if (!ubll.CheckRequest(uid, ip))
                return false;
            int res = rdal.DeleteTaskFinishInfo(taskid);
            if (res <= 0)
                return false;
            return true;
        }

        public bool UpdateTaskFinishInfo(TaskFinishInfo tf)
        {
            int res = rdal.UpdateTaskFinishInfo(tf);
            if (res >= 2)
                return true;
            return false;
        }

        public bool UpdateTaskInfo(ReadingTask rt)
        {
            int res = rdal.UpdateTaskInfo(rt);
            if (res <= 0)
                return false;
            return true;
        }

        public bool AddTaskInfo(ReadingTask rt)
        {
            int res= rdal.AddTaskInfo(rt);
            if (res <= 0)
                return false;
            return true;
        }
    }
}
