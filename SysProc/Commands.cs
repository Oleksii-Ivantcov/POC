using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysProc
{
    public enum ProcessCommand
    {
        Start = 0,
        Stop = 1,
        GetProcess = 2,
    }
    [Serializable]
    public class Commands
    {
        private ProcessCommand _command;
        private string _loc;

        public ProcessCommand Command
        {
            get => _command;
            set => _command = value;
        }

        public string Loc
        {
            get => _loc;
            set => _loc = value;
        }
        public Commands(ProcessCommand command)
        {
            _command = command;
        }
    }
}
