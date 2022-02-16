using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCYEduWebAPI.Models
{
    public class ReadingTask
    {
        private int _taskid = -1;
        private string _taskname = "";
        private string _taskclass = "";
        private string _starttime = "";
        private string _endtime = "";
        private string _taskinfo = "";
        private string _tasktname = "";
        private string _taskbook = "";

        public int Taskid { get => _taskid; set => _taskid = value; }
        public string Taskname { get => _taskname; set => _taskname = value; }
        public string Taskclass { get => _taskclass; set => _taskclass = value; }
        public string Starttime { get => _starttime; set => _starttime = value; }
        public string Endtime { get => _endtime; set => _endtime = value; }
        public string Taskinfo { get => _taskinfo; set => _taskinfo = value; }
        public string Tasktname { get => _tasktname; set => _tasktname = value; }
        public string Taskbook { get => _taskbook; set => _taskbook = value; }
    }
}
