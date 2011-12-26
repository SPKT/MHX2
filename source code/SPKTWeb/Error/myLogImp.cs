using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Diagnostics;
using System.IO;

/// <summary>
/// Ghi các thông tin quan trọng như khi user đăng kí, đăng nhập, khi user mua hàng.
/// </summary>
public class myLogImp
{
    private EventLog _log;

    public EventLog Log
    {
        get { return _log; }
        set { _log = value; }
    }
    private EventLogEntry _entry;

    public EventLogEntry Entry
    {
        get { return _entry; }
        set { _entry = value; }
    }
	public myLogImp()
	{
	}   
    public void LogImportant(String fromPage,String message,EventLogEntryType type,String writePath)
    {
        RegisterLog();
        _log = new EventLog("ImportantLog");
        _log.Source = fromPage;
        _log.WriteEntry(message, type);
        int e=_log.Entries.Count;
        Entry = _log.Entries[e - 1];
        writeLogEntry(writePath);
    }
    public void LogError(String pageError, string ex, String writePath)
    {
        RegisterLog();
        _log = new EventLog("ImportantLog");
        _log.Source = pageError;
        _log.WriteEntry(ex, EventLogEntryType.Error);
        int e = _log.Entries.Count;
        Entry = _log.Entries[e - 1];
        writeLogEntry(writePath);
    }
    public void LogError(String pageError, Exception error, String writePath)
    {
        RegisterLog();
        _log = new EventLog("ImportantLog");
        _log.Source = pageError;
        _log.WriteEntry(error.Message, EventLogEntryType.Error);
        int e = _log.Entries.Count;
        Entry = _log.Entries[e - 1];
        writeLogEntry(writePath);
    }
    public void RegisterLog()
    {
        if (!EventLog.SourceExists("WebSiteSieuThiTH"))
        {            
             EventLog.CreateEventSource("WebSiteSieuThiTH", "ImportantLog");
        }
    }
   
    public void writeLogEntry(String path)
    {        
        StreamWriter sw;
        sw = new StreamWriter(path,true);
        sw.WriteLine("Entry source: " + Entry.Source);
        sw.WriteLine("Entry Type:" + Entry.EntryType.ToString());
        sw.WriteLine("Message:" + Entry.Message);
        sw.WriteLine("Time Generated:" + Entry.TimeGenerated);
        sw.WriteLine();
        sw.Close();
    }
}
