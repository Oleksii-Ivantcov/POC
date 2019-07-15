using System;
using System.Collections.Generic;
using System.Text;

namespace SysProcess
{
    [Serializable]
    public class Process
    {
        private string _processName;
        private string _loc { get; set; }
        private int _size { get; set; }

        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; }
        }

        public string Loc
        {
            get { return _loc; }
            set { _loc = value; }
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public Process(string name, string loc, int size)
        {
            _processName = name;
            _loc = loc;
            _size = size;
        }
    }
}
