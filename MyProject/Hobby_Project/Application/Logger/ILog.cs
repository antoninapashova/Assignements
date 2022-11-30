using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logger
{
    public interface ILog
    {
        void LogMessage(string commandType, string message);
        void ReadMessages(string commandType);
    }
}
