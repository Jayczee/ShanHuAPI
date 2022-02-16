using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DCYEduWebAPI.Models;

namespace DCYEduWebAPI.DAL
{
    public class ReadingTaskDal
    {
        public DataTable GetTaskInfoByClass(string classname)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from ReadingTaskinfo where TaskClass=@para1",
                new SqlParameter("@para1", classname));
            return res;
        }

        public int AddTaskInfo(ReadingTask rt)
        {
            int res = SqlHelper.ExecuteNonQuery("insert into ReadingTaskinfo(TaskName,TaskClass,TaskStartTime,TaskEndTime,TaskInfo,TaskTeacherName,TaskBook)values(@para1,@para2,@para3,@para4,@para5,@para6,@para7)",
                new SqlParameter("@para1", rt.Tasktname),
                new SqlParameter("@para2" ,rt.Taskclass),
                new SqlParameter("@para3", rt.Starttime),
                new SqlParameter("@para4", rt.Endtime),
                new SqlParameter("@para5", rt.Taskinfo),
                new SqlParameter("@para6", rt.Tasktname),
                new SqlParameter("@para7", rt.Taskbook)) ;
            return res;
        }

        public int UpdateTaskInfo(ReadingTask rt)
        {
            int res = SqlHelper.ExecuteNonQuery("update ReadingTaskinfo set TaskName=@para1,TaskClass=@para2,TaskStartTime=@para3,TaskEndTime=@para4,TaskInfo=@para5,TaskTeacherName=@para6,TaskBook=@para7 where TaskID=@para8",
                new SqlParameter("@para1", rt.Tasktname),
                new SqlParameter("@para2", rt.Taskclass),
                new SqlParameter("@para3", rt.Starttime),
                new SqlParameter("@para4", rt.Endtime),
                new SqlParameter("@para5", rt.Taskinfo),
                new SqlParameter("@para6", rt.Tasktname),
                new SqlParameter("@para7", rt.Taskbook),
                new SqlParameter("@para8",rt.Taskid));
            return res;
        }

        public DataTable GetTaskFinishInfo(int taskid)
        {
            DataTable res = SqlHelper.ExecuteTable("select * from TaskFinishinfo where TaskID=@para2",
                new SqlParameter("@para2", taskid));
            return res;
        }

        public int UpdateTaskFinishInfo(TaskFinishInfo tf)
        {
            int res = SqlHelper.ExecuteNonQuery("update TaskFinishinfo set TaskTeacherMsg=@para1,TaskCorrect=@para2,TaskResult=@para3 where FinishID=@para4",
                new SqlParameter("@para1",tf.Taskteachermsg),
                new SqlParameter("@para2", tf.Taskcorrect),
                new SqlParameter("@para3", tf.Taskresult),
                new SqlParameter("@para4", tf.Finishid));
            string sname = SqlHelper.ExecuteScalar("select TaskFinishName from TaskFinishinfo where FinishID=@para1",
                new SqlParameter("@para1",tf.Finishid)).ToString();
            string c=SqlHelper.ExecuteScalar("select TaskClass from ReadingTaskinfo where TaskId = @para1",
                new SqlParameter("@para1",tf.Taskid)).ToString();
            string ccode= SqlHelper.ExecuteScalar("select CNo from classinfo where CName = @para1",
                new SqlParameter("@para1", c)).ToString();
            int p = int.Parse(SqlHelper.ExecuteScalar("select SPoints from student where SClassNo=@para1 and SName=@para2",
                new SqlParameter("@para1", ccode),
                new SqlParameter("@para2", sname)).ToString());
            int tp= int.Parse(SqlHelper.ExecuteScalar("select STotalPoints from student where SClassNo=@para1 and SName=@para2",
                new SqlParameter("@para1", ccode),
                new SqlParameter("@para2", sname)).ToString());
            p += tf.Taskresult;tp += tf.Taskresult;
            int res2 = SqlHelper.ExecuteNonQuery("update student set SPoints=@para1,STotalPoints=@para2 where SClassNo=@para3 and SName=@para4",
                new SqlParameter("@para1",p),
                new SqlParameter("@para2",tp),
                new SqlParameter("@para3",ccode),
                new SqlParameter("@para4",sname));
            return res+res2;
        }

        public int AddTaskFinishInfo(TaskFinishInfo tf)
        {
            int res = SqlHelper.ExecuteNonQuery("insert into TaskFinishinfo(TaskName,TaskFinishTime,TaskID,SourceURL,TaskFinishName)values(@para1,@para2,@para3,@para4,@para5)",
                new SqlParameter("@para1",tf.Taskname),
                new SqlParameter("@para2",DateTime.Now.ToString("G")),
                new SqlParameter("@para3",tf.Taskid),
                new SqlParameter("@para4",tf.Sourceurl),
                new SqlParameter("@para5",tf.Taskfinishname));
            return res;
        }

        public int DeleteTaskFinishInfo(int taskid)
        {
            int res1 = SqlHelper.ExecuteNonQuery("delete from ReadingTaskinfo where TaskID=@para1",
                new SqlParameter("@para1", taskid));
            int res2 = SqlHelper.ExecuteNonQuery("delete from TaskFinishinfo where TaskID=@para1",
                new SqlParameter("@para1", taskid));
            return res1+res2;
        }
    }
}
