
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.SubSystemInterfaces
{
    public interface ILoggingSubSystem
    {
        void RecordAction(string action);
        string GetRecords();
    }
}