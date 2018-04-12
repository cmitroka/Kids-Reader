using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WindowsEventLog
{
    public static void WriteToWindowsEventLog(string AppName, string WhatToLog, string WorIorE)
    {
        if (WorIorE.ToUpper() == "W")
        {
            System.Diagnostics.EventLog.WriteEntry(AppName, WhatToLog, System.Diagnostics.EventLogEntryType.Warning, 234);
        }
        else if (WorIorE.ToUpper() == "E")
        {
            System.Diagnostics.EventLog.WriteEntry(AppName, WhatToLog, System.Diagnostics.EventLogEntryType.Error, 234);
        }
        else
        {
            System.Diagnostics.EventLog.WriteEntry(AppName, WhatToLog);
        }
    }

}
