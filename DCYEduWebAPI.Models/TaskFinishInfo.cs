using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class TaskFinishInfo
    {
        private int _finishid=-1;
        private string _taskname="";
        private string _taskfinishtime = "";
        private int taskid = -1;
        private string _sourceurl = "";
        private string _taskfinishname = "";
        private string _taskteachername = "";
        private string _taskteachermsg = "";
        private string _taskcorrect = "";
        private int _taskresult = 0;

        public int Finishid { get => _finishid; set => _finishid = value; }
        public string Taskname { get => _taskname; set => _taskname = value; }
        public string Taskfinishtime { get => _taskfinishtime; set => _taskfinishtime = value; }
        public int Taskid { get => taskid; set => taskid = value; }
        public string Sourceurl { get => _sourceurl; set => _sourceurl = value; }
        public string Taskfinishname { get => _taskfinishname; set => _taskfinishname = value; }
        public string Taskteachername { get => _taskteachername; set => _taskteachername = value; }
        public string Taskteachermsg { get => _taskteachermsg; set => _taskteachermsg = value; }
        public string Taskcorrect { get => _taskcorrect; set => _taskcorrect = value; }
        public int Taskresult { get => _taskresult; set => _taskresult = value; }
    }
}
