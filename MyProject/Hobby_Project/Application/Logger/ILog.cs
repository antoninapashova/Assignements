using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logger
{
    public interface ILog
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
